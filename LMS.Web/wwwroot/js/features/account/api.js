/**
 * ==========================================================
 * Module : Account
 * File   : api.js
 * Purpose: Communication with Authentication API
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.AccountApi = (function () {
    'use strict';

    // =============================================
    // Login
    // =============================================

    async function login(model) {
        return await ApiClient.post('Auth/login', model, false);
    }

    // =============================================
    // Register
    // =============================================

    async function register(model) {
        return await ApiClient.post('Auth/register', model, false);
    }

    // =============================================
    // Forgot Password
    // =============================================

    async function forgotPassword(model) {
        return await ApiClient.post('Auth/forgot-password', model, false);
    }

    // =============================================
    // Reset Password
    // =============================================

    async function resetPassword(model) {
        return await ApiClient.post('Auth/reset-password', model, false);
    }

    // =============================================
    // Change Password
    // =============================================

    async function changePassword(model) {
        return await ApiClient.post('Auth/change-password', model);
    }

    // =============================================
    // Current User
    // =============================================

    async function currentUser(userId) {
        return await ApiClient.get(`Auth/current-user/${userId}`);
    }

    // =============================================
    // Logout
    // =============================================

    async function logout(model) {
        return await ApiClient.post('Auth/logout', model);
    }
    // =============================================

    return {
        login,
        logout,
        register,

        forgotPassword,

        resetPassword,

        changePassword,

        currentUser,
    };
})();
