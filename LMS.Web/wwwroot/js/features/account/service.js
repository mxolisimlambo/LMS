/**
 * ==========================================================
 * Module : Account
 * File   : service.js
 * Purpose: Business Logic for Authentication
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.AccountService = (function () {
    'use strict';

    // =====================================================
    // Login
    // =====================================================

    async function login(model) {
        try {
            const response = await AccountApi.login(model);

            if (!response.success) {
                return response;
            }

            StorageService.setAccessToken(response.data.accessToken);

            StorageService.setRefreshToken(response.data.refreshToken);

            StorageService.setCurrentUser(response.data.user);

            return response;
        } catch (error) {
            console.error(error);

            throw error;
        }
    }
    // =====================================================
    // Logout
    // =====================================================

    async function logout() {
        const user = StorageService.getCurrentUser();

        if (user) {
            try {
                await AccountApi.logout({
                    userId: user.userId,
                });
            } catch (e) {
                console.warn('Logout API unavailable.');
            }
        }

        SecurityService.logout();
    }
    // =====================================================
    // Register
    // =====================================================

    async function register(model) {
        return await AccountApi.register(model);
    }

    // =====================================================
    // Forgot Password
    // =====================================================

    async function forgotPassword(model) {
        return await AccountApi.forgotPassword(model);
    }

    // =====================================================
    // Reset Password
    // =====================================================

    async function resetPassword(model) {
        return await AccountApi.resetPassword(model);
    }

    // =====================================================
    // Change Password
    // =====================================================

    async function changePassword(model) {
        return await AccountApi.changePassword(model);
    }

    // =====================================================
    // Current User
    // =====================================================

    async function refreshCurrentUser(userId) {
        const response = await AccountApi.currentUser(userId);

        if (response.success) {
            StorageService.setCurrentUser(response.data);
        }

        return response;
    }

    // =====================================================
    // Logout
    // =====================================================

    function logout() {
        SecurityService.logout();
    }

    // =====================================================

    return {
        login,

        register,

        forgotPassword,

        resetPassword,

        changePassword,

        refreshCurrentUser,

        logout,
    };
})();
