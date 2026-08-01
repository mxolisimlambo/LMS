/**
 * ==========================================================
 * Module : Core
 * File   : layout.js
 * Purpose: Application Layout Initialization
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.Layout = (function () {
    'use strict';

    // =====================================================
    // Initialize
    // =====================================================

    async function initialize() {
        try {
            await initializeComponents();

            initializeAuthentication();
            initializeAuthorization();

            initializeHeader();

            initializeSidebar();

            initializeFooter();

            initializeSearch();

            initializeNotifications();

            initializeCart();

            initializeTheme();

            bindEvents();
        } catch (error) {
            console.error(error);
        }
    }

    // =====================================================
    // Components
    // =====================================================

    async function initializeComponents() {
        await ComponentLoader.loadMany([
            // { selector: '#loader', path: '/html/shared/loader.html' },

            { selector: '#header', path: '/html/shared/header.html' },

            { selector: '#topbar', path: '/html/shared/topbar.html' },

            { selector: '#sidebar', path: '/html/shared/sidebar.html' },

            { selector: '#footer', path: '/html/shared/footer.html' },

            //{ selector: '#modals', path: '/html/shared/modals.html' },
        ]);
    }
    // =====================================================
    // Authentication
    // =====================================================

    function initializeAuthentication() {
        if (!SecurityService.isAuthenticated()) {
            return;
        }

        loadCurrentUser();
    }
    // =====================================================
    // Authorization
    // =====================================================

    function initializeAuthorization() {
        if (!SecurityService.isAuthenticated()) {
            $('[data-auth]').hide();

            $('[data-anonymous]').show();

            return;
        }

        $('[data-auth]').show();

        $('[data-anonymous]').hide();

        applyRoleAuthorization();

        applyPermissionAuthorization();
    }

    // =====================================================
    // Role Authorization
    // =====================================================

    function applyRoleAuthorization() {
        $('[data-role]').each(function () {
            const role = $(this).data('role');

            if (!SecurityService.hasRole(role)) {
                $(this).remove();
            }
        });
    }

    // =====================================================
    // Permission Authorization
    // =====================================================

    function applyPermissionAuthorization() {
        $('[data-permission]').each(function () {
            const permission = $(this).data('permission');

            if (!SecurityService.hasPermission(permission)) {
                $(this).remove();
            }
        });
    }

    // =====================================================
    // Current User
    // =====================================================

    function loadCurrentUser() {
        const user = SecurityService.getCurrentUser();

        if (!user) {
            return;
        }

        $('#lblUserName').text(user.fullName ?? '');

        $('#lblUserEmail').text(user.email ?? '');

        if (user.profilePicture) {
            $('#imgProfile').attr('src', user.profilePicture);
        }
    }

    // =====================================================
    // Header
    // =====================================================

    function initializeHeader() {
        const user = SecurityService.getCurrentUser();

        if (!user) {
            $('.authenticated').hide();

            $('.anonymous').show();

            return;
        }

        $('.authenticated').show();

        $('.anonymous').hide();

        $('#lblUserName').text(user.fullName || '');

        $('#lblUserEmail').text(user.email || '');

        if (user.profilePicture) {
            $('#imgProfile').attr('src', user.profilePicture);
        }
    }

    // =====================================================
    // Sidebar
    // =====================================================

    function initializeSidebar() {
        $('.sidebar-link').removeClass('active');

        const path = window.location.pathname.toLowerCase();

        $(`.sidebar-link[data-url='${path}']`).addClass('active');
    }
    // =====================================================
    // Footer
    // =====================================================

    function initializeFooter() {
        $('#lblYear').text(new Date().getFullYear());
    }
    // =====================================================
    // Search
    // =====================================================

    function initializeSearch() {
        $('#txtSearch').on('keypress', function (e) {
            if (e.which !== 13) {
                return;
            }

            const keyword = $(this).val().trim();

            if (keyword.length === 0) {
                return;
            }

            window.location.href = `/Search?keyword=${encodeURIComponent(keyword)}`;
        });
    }

    // =====================================================
    // Notifications
    // =====================================================

    function initializeNotifications() {
        $('#notificationCount').text('0');
    }
    // =====================================================
    // Shopping Cart
    // =====================================================

    function initializeCart() {
        $('#cartCount').text('0');
    }

    // =====================================================
    // Theme
    // =====================================================

    function initializeTheme() {
        const theme = localStorage.getItem('theme') || 'light';

        $('body').attr('data-theme', theme);
    }

    // =====================================================
    // Logout
    // =====================================================

    async function logout(e) {
        if (e) {
            e.preventDefault();
        }

        await AccountService.logout();
    }

    // =====================================================
    // Global Events
    // =====================================================

    function bindEvents() {
        $(document).off('click', '#btnLogout').on('click', '#btnLogout', logout);
    }

    // =====================================================

    return {
        initialize,
        initializeAuthentication,

        initializeAuthorization,

        loadCurrentUser,

        initializeHeader,

        initializeSidebar,

        initializeFooter,

        initializeSearch,

        initializeNotifications,

        initializeCart,

        initializeTheme,

        initializeComponents,

        bindEvents,

        logout,
    };
})();
