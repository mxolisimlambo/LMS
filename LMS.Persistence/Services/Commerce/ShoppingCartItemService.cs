using LMS.Application.Interfaces.Commerce;
using LMS.Domain.Entities.Commerce.ShoppingCard;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Commerce.ShoppingCart.CartItem;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Commerce;

public class ShoppingCartItemService : IShoppingCartItemService
{
    private readonly ApplicationDbContext _context;

    public ShoppingCartItemService(
        ApplicationDbContext context)
    {
        _context = context;
    }

   // ======================================================
// ADD COURSE TO SHOPPING CART
// ======================================================

public async Task<ShoppingCartItem?> AddCourseAsync(
    long shoppingCartId,
    long courseId)
{
    var shoppingCart = await _context.ShoppingCarts
        .FirstOrDefaultAsync(x =>
            x.ShoppingCartId == shoppingCartId &&
            !x.IsDeleted);

    if (shoppingCart == null)
        return null;

    var course = await _context.Courses
        .Include(x => x.CoursePrice)
        .FirstOrDefaultAsync(x =>
            x.CourseId == courseId &&
            !x.IsDeleted);

    if (course == null)
        return null;

    if (!course.IsPublished)
        return null;

    var exists = await _context.ShoppingCartItems
        .AnyAsync(x =>
            x.ShoppingCartId == shoppingCartId &&
            x.CourseId == courseId &&
            !x.IsDeleted);

    if (exists)
        return null;

    var shoppingCartItem = new ShoppingCartItem
    {
        ShoppingCartId = shoppingCartId,

        CourseId = courseId,

        UnitPrice =
            course.CoursePrice?.Price ?? 0m,

        DiscountAmount = 0m,

        TotalPrice =
            course.CoursePrice?.Price ?? 0m,

        CreatedDate =
            DateTime.UtcNow,

        IsDeleted = false
    };

    _context.ShoppingCartItems.Add(
        shoppingCartItem);

    await _context.SaveChangesAsync();

    return shoppingCartItem;
}

    public async Task<bool> UpdateShoppingCartItemAsync(
        UpdateShoppingCartItemDto dto)
    {
        var shoppingCartItem = await _context
            .ShoppingCartItems
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartItemId ==
                dto.ShoppingCartItemId &&
                !x.IsDeleted);

        if (shoppingCartItem == null)
            return false;

        var course = await _context.Courses
            .Include(x => x.CoursePrice)
            .FirstOrDefaultAsync(x =>
                x.CourseId ==
                shoppingCartItem.CourseId &&
                !x.IsDeleted);

        if (course == null)
            return false;

        var unitPrice = course.CoursePrice?.Price ?? 0;

        var discountAmount = 0m;

        var totalPrice =
            unitPrice - discountAmount;

        if (totalPrice < 0)
            totalPrice = 0;

        shoppingCartItem.UnitPrice =
            unitPrice;

        shoppingCartItem.DiscountAmount =
            discountAmount;

        shoppingCartItem.TotalPrice =
            totalPrice;

        await RecalculateCartAsync(
            shoppingCartItem.ShoppingCartId);

        return true;
    }

    public async Task<bool> DeleteShoppingCartItemAsync(
        long shoppingCartItemId)
    {
        var shoppingCartItem = await _context
            .ShoppingCartItems
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartItemId ==
                shoppingCartItemId &&
                !x.IsDeleted);

        if (shoppingCartItem == null)
            return false;

        shoppingCartItem.IsDeleted = true;

        await RecalculateCartAsync(
            shoppingCartItem.ShoppingCartId);

        return true;
    }

    public async Task<ShoppingCartItemDto?>
        GetShoppingCartItemByIdAsync(
            long shoppingCartItemId)
    {
        return await _context
            .ShoppingCartItems
            .Where(x =>
                x.ShoppingCartItemId ==
                shoppingCartItemId &&
                !x.IsDeleted)
            .Select(x =>
                new ShoppingCartItemDto
                {
                    ShoppingCartItemId =
                        x.ShoppingCartItemId,

                    ShoppingCartId =
                        x.ShoppingCartId,

                    CourseId =
                        x.CourseId,

                    CourseTitle =
                        x.Course != null
                            ? x.Course.Title
                            : string.Empty,

                    CourseThumbnail =
                        x.Course != null
                            ? x.Course.Thumbnail
                            : null,

                    UnitPrice =
                        x.UnitPrice,

                    DiscountAmount =
                        x.DiscountAmount,

                    TotalPrice =
                        x.TotalPrice,

                    CreatedDate =
                        x.CreatedDate,

                    IsDeleted =
                        x.IsDeleted
                })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<
        ShoppingCartItemDto>>
        GetShoppingCartItemsByCartAsync(
            long shoppingCartId)
    {
        return await _context
            .ShoppingCartItems
            .Where(x =>
                x.ShoppingCartId ==
                shoppingCartId &&
                !x.IsDeleted)
            .OrderByDescending(
                x => x.CreatedDate)
            .Select(x =>
                new ShoppingCartItemDto
                {
                    ShoppingCartItemId =
                        x.ShoppingCartItemId,

                    ShoppingCartId =
                        x.ShoppingCartId,

                    CourseId =
                        x.CourseId,

                    CourseTitle =
                        x.Course != null
                            ? x.Course.Title
                            : string.Empty,

                    CourseThumbnail =
                        x.Course != null
                            ? x.Course.Thumbnail
                            : null,

                    UnitPrice =
                        x.UnitPrice,

                    DiscountAmount =
                        x.DiscountAmount,

                    TotalPrice =
                        x.TotalPrice,

                    CreatedDate =
                        x.CreatedDate,

                    IsDeleted =
                        x.IsDeleted
                })
            .ToListAsync();
    }

    public async Task<IEnumerable<
        ShoppingCartItemSummaryDto>>
        GetShoppingCartItemSummariesByCartAsync(
            long shoppingCartId)
    {
        return await _context
            .ShoppingCartItems
            .Where(x =>
                x.ShoppingCartId ==
                shoppingCartId &&
                !x.IsDeleted)
            .OrderByDescending(
                x => x.CreatedDate)
            .Select(x =>
                new ShoppingCartItemSummaryDto
                {
                    ShoppingCartItemId =
                        x.ShoppingCartItemId,

                    CourseId =
                        x.CourseId,

                    CourseTitle =
                        x.Course != null
                            ? x.Course.Title
                            : string.Empty,

                    CourseThumbnail =
                        x.Course != null
                            ? x.Course.Thumbnail
                            : null,

                    TotalPrice =
                        x.TotalPrice
                })
            .ToListAsync();
    }

    public async Task<bool>
        RestoreShoppingCartItemAsync(
            long shoppingCartItemId)
    {
        var shoppingCartItem = await _context
            .ShoppingCartItems
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartItemId ==
                shoppingCartItemId &&
                x.IsDeleted);

        if (shoppingCartItem == null)
            return false;

        var shoppingCartExists =
            await _context.ShoppingCarts
                .AnyAsync(x =>
                    x.ShoppingCartId ==
                    shoppingCartItem
                        .ShoppingCartId &&
                    !x.IsDeleted);

        if (!shoppingCartExists)
            return false;

        var activeDuplicateExists =
            await _context.ShoppingCartItems
                .AnyAsync(x =>
                    x.ShoppingCartId ==
                    shoppingCartItem
                        .ShoppingCartId &&
                    x.CourseId ==
                    shoppingCartItem
                        .CourseId &&
                    !x.IsDeleted);

        if (activeDuplicateExists)
            return false;

        shoppingCartItem.IsDeleted =
            false;

        await RecalculateCartAsync(
            shoppingCartItem
                .ShoppingCartId);

        return true;
    }

    public async Task<bool> ExistsAsync(
        long shoppingCartItemId)
    {
        return await _context
            .ShoppingCartItems
            .AnyAsync(x =>
                x.ShoppingCartItemId ==
                shoppingCartItemId &&
                !x.IsDeleted);
    }

    private async Task RecalculateCartAsync(
        long shoppingCartId)
    {
        var shoppingCart = await _context
            .ShoppingCarts
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartId ==
                shoppingCartId &&
                !x.IsDeleted);

        if (shoppingCart == null)
            return;

        var activeCartItems =
            await _context
                .ShoppingCartItems
                .Where(x =>
                    x.ShoppingCartId ==
                    shoppingCartId &&
                    !x.IsDeleted)
                .ToListAsync();

        shoppingCart.TotalItems =
            activeCartItems.Count;

        shoppingCart.TotalAmount =
            activeCartItems.Sum(
                x => x.TotalPrice);

        shoppingCart.UpdatedDate =
            DateTime.UtcNow;

        await _context
            .SaveChangesAsync();
    }
    // ======================================================
    // GET CHECKOUT ITEMS
    // ======================================================

    public async Task<List<ShoppingCartItem>>
        GetCheckoutItemsAsync(
            long shoppingCartId)
    {
        return await _context.ShoppingCartItems
            .Include(x => x.Course)
            .Where(x =>
                x.ShoppingCartId == shoppingCartId &&
                !x.IsDeleted)
            .ToListAsync();
    }
// ======================================================
// CLEAR SHOPPING CART ITEMS
// ======================================================

public async Task ClearShoppingCartItemsAsync(
    long shoppingCartId)
{
    var items = await _context.ShoppingCartItems
        .Where(x =>
            x.ShoppingCartId == shoppingCartId &&
            !x.IsDeleted)
        .ToListAsync();

    foreach (var item in items)
    {
        item.IsDeleted = true;
    }

    await _context.SaveChangesAsync();
}
}
