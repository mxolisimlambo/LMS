using LMS.Application.Interfaces.Commerce;
using LMS.Domain.Entities.Commerce.ShoppingCard;
using LMS.Persistence.Context;
using LMS.Shared.DTOs.Commerce.ShoppingCart.Cart;
using Microsoft.EntityFrameworkCore;

namespace LMS.Persistence.Services.Commerce;

public class ShoppingCartService : IShoppingCartService
{
    private readonly ApplicationDbContext _context;

    public ShoppingCartService(
        ApplicationDbContext context)
    {
        _context = context;
    }

   // ======================================================
// CREATE SHOPPING CART
// ======================================================

public async Task<ShoppingCart> CreateShoppingCartAsync(
    long studentProfileId)
{
    var shoppingCart = new ShoppingCart
    {
        StudentProfileId = studentProfileId,

        TotalAmount = 0m,

        TotalItems = 0,

        CreatedDate = DateTime.UtcNow,

        UpdatedDate = null,

        IsDeleted = false
    };

    _context.ShoppingCarts.Add(
        shoppingCart);

    await _context.SaveChangesAsync();

    return shoppingCart;
}
    public async Task<bool> UpdateShoppingCartAsync(
        UpdateShoppingCartDto dto)
    {
        var shoppingCart = await _context.ShoppingCarts
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartId == dto.ShoppingCartId &&
                !x.IsDeleted);

        if (shoppingCart == null)
            return false;

        await RecalculateCartAsync(
            shoppingCart.ShoppingCartId);

        return true;
    }

    public async Task<bool> DeleteShoppingCartAsync(
        long shoppingCartId)
    {
        var shoppingCart = await _context.ShoppingCarts
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartId == shoppingCartId &&
                !x.IsDeleted);

        if (shoppingCart == null)
            return false;

        shoppingCart.IsDeleted = true;
        shoppingCart.UpdatedDate = DateTime.UtcNow;

        var activeCartItems = await _context.ShoppingCartItems
            .Where(x =>
                x.ShoppingCartId == shoppingCartId &&
                !x.IsDeleted)
            .ToListAsync();

        foreach (var cartItem in activeCartItems)
        {
            cartItem.IsDeleted = true;
        }

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ShoppingCartDto?> GetShoppingCartByIdAsync(
        long shoppingCartId)
    {
        return await _context.ShoppingCarts
            .Where(x =>
                x.ShoppingCartId == shoppingCartId &&
                !x.IsDeleted)
            .Select(x => new ShoppingCartDto
            {
                ShoppingCartId = x.ShoppingCartId,
                StudentProfileId = x.StudentProfileId,
                TotalAmount = x.TotalAmount,
                TotalItems = x.TotalItems,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                IsDeleted = x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ShoppingCartDto?> GetShoppingCartByStudentAsync(
        long studentProfileId)
    {
        return await _context.ShoppingCarts
            .Where(x =>
                x.StudentProfileId == studentProfileId &&
                !x.IsDeleted)
            .Select(x => new ShoppingCartDto
            {
                ShoppingCartId = x.ShoppingCartId,
                StudentProfileId = x.StudentProfileId,
                TotalAmount = x.TotalAmount,
                TotalItems = x.TotalItems,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                IsDeleted = x.IsDeleted
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ShoppingCartSummaryDto>>
        GetAllShoppingCartsAsync()
    {
        return await _context.ShoppingCarts
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.CreatedDate)
            .Select(x => new ShoppingCartSummaryDto
            {
                ShoppingCartId = x.ShoppingCartId,
                StudentProfileId = x.StudentProfileId,
                TotalItems = x.TotalItems,
                TotalAmount = x.TotalAmount
            })
            .ToListAsync();
    }

    public async Task<bool> ClearShoppingCartAsync(
        long shoppingCartId)
    {
        var shoppingCart = await _context.ShoppingCarts
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartId == shoppingCartId &&
                !x.IsDeleted);

        if (shoppingCart == null)
            return false;

        var activeCartItems = await _context.ShoppingCartItems
            .Where(x =>
                x.ShoppingCartId == shoppingCartId &&
                !x.IsDeleted)
            .ToListAsync();

        foreach (var cartItem in activeCartItems)
        {
            cartItem.IsDeleted = true;
        }

        shoppingCart.TotalItems = 0;
        shoppingCart.TotalAmount = 0;
        shoppingCart.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RestoreShoppingCartAsync(
        long shoppingCartId)
    {
        var shoppingCart = await _context.ShoppingCarts
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartId == shoppingCartId &&
                x.IsDeleted);

        if (shoppingCart == null)
            return false;

        var activeCartExists = await _context.ShoppingCarts
            .AnyAsync(x =>
                x.StudentProfileId == shoppingCart.StudentProfileId &&
                !x.IsDeleted);

        if (activeCartExists)
            return false;

        shoppingCart.IsDeleted = false;
        shoppingCart.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(
        long shoppingCartId)
    {
        return await _context.ShoppingCarts
            .AnyAsync(x =>
                x.ShoppingCartId == shoppingCartId &&
                !x.IsDeleted);
    }

    private async Task RecalculateCartAsync(
        long shoppingCartId)
    {
        var shoppingCart = await _context.ShoppingCarts
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartId == shoppingCartId &&
                !x.IsDeleted);

        if (shoppingCart == null)
            return;

        var activeCartItems = await _context.ShoppingCartItems
            .Where(x =>
                x.ShoppingCartId == shoppingCartId &&
                !x.IsDeleted)
            .ToListAsync();

        shoppingCart.TotalItems = activeCartItems.Count;

        shoppingCart.TotalAmount = activeCartItems
            .Sum(x => x.TotalPrice);

        shoppingCart.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }
    // ======================================================
    // GET ACTIVE SHOPPING CART
    // ======================================================

    public async Task<ShoppingCart?> GetActiveShoppingCartAsync(
        long studentProfileId)
    {
        return await _context.ShoppingCarts
            .FirstOrDefaultAsync(x =>
                x.StudentProfileId == studentProfileId &&
                !x.IsDeleted);
    }
    // ======================================================
    // CLOSE SHOPPING CART
    // ======================================================

    public async Task<bool> CloseShoppingCartAsync(
        long shoppingCartId)
    {
        var shoppingCart = await _context.ShoppingCarts
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartId == shoppingCartId &&
                !x.IsDeleted);

        if (shoppingCart == null)
            return false;

        shoppingCart.TotalAmount = 0m;

        shoppingCart.TotalItems = 0;

        shoppingCart.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }
// ======================================================
// VALIDATE SHOPPING CART
// ======================================================

public async Task<bool> ValidateShoppingCartAsync(
    long studentProfileId)
{
    var studentExists = await _context.StudentProfiles
        .AnyAsync(x =>
            x.StudentProfileId == studentProfileId &&
            !x.IsDeleted);

    if (!studentExists)
        return false;

    var shoppingCart = await _context.ShoppingCarts
        .AnyAsync(x =>
            x.StudentProfileId == studentProfileId &&
            !x.IsDeleted);

    return shoppingCart;
}
}
