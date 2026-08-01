/**
 * ==========================================================
 * Module : Core
 * File   : security.js
 * Purpose: Authentication & Authorization
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.SecurityService = (function () {
    'use strict';

    // =====================================================
    // Authentication
    // =====================================================

    function isAuthenticated() {
        return !!StorageService.getAccessToken();
    }

    // =====================================================
    // Current User
    // =====================================================

    function getCurrentUser() {
        return StorageService.getCurrentUser();
    }

    // =====================================================
    // Access Token
    // =====================================================

    function getAccessToken() {
        return StorageService.getAccessToken();
    }

    // =====================================================
    // Refresh Token
    // =====================================================

    function getRefreshToken() {
        return StorageService.getRefreshToken();
    }

    // =====================================================
    // Roles
    // =====================================================

    function getRoles() {
        const user = getCurrentUser();

        return user?.roles ?? [];
    }

    // =====================================================
    // Permissions
    // =====================================================

    function getPermissions() {
        const user = getCurrentUser();

        return user?.permissions ?? [];
    }

    // =====================================================
    // Role Check
    // =====================================================

    function hasRole(role) {
        return getRoles().includes(role);
    }

    // =====================================================
    // Permission Check
    // =====================================================

    function hasPermission(permission) {
        return getPermissions().includes(permission);
    }

    // =====================================================
    // Common Roles
    // =====================================================

    function isAdministrator() {
        return hasRole('Administrator');
    }

    function isInstructor() {
        return hasRole('Instructor');
    }

    function isStudent() {
        return hasRole('Student');
    }

    function isParent() {
        return hasRole('Parent');
    }

    // =====================================================
    // Redirect After Login
    // =====================================================

    function redirectAfterLogin() {
        if (!isAuthenticated()) {
            window.location.href = '/Account/Login';

            return;
        }

        if (isAdministrator()) {
            window.location.href = '/Dashboard/Admin';

            return;
        }

        if (isInstructor()) {
            window.location.href = '/Dashboard/Instructor';

            return;
        }

        if (isStudent()) {
            window.location.href = '/Dashboard/Student';

            return;
        }

        if (isParent()) {
            window.location.href = '/Dashboard/Parent';

            return;
        }

        window.location.href = '/';
    }

    // =====================================================
    // Redirect If Authenticated
    // =====================================================

    function redirectIfAuthenticated() {
        if (isAuthenticated()) {
            redirectAfterLogin();
        }
    }

    // =====================================================
    // Logout
    // =====================================================

    function logout() {
        StorageService.clearAuthentication();

        window.location.href = '/Account/Login';
    }

    // =====================================================

    return {
        isAuthenticated,

        getCurrentUser,

        getAccessToken,

        getRefreshToken,

        getRoles,

        getPermissions,

        hasRole,

        hasPermission,

        isAdministrator,

        isInstructor,

        isStudent,

        isParent,

        redirectAfterLogin,

        redirectIfAuthenticated,

        logout,
    };
})();
