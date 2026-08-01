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
        return await ApiClient.post('Auth/login', model);
    }

    // =============================================
    // Register
    // =============================================

    async function register(model) {
        return await ApiClient.post('Auth/register', model);
    }

    // =============================================
    // Forgot Password
    // =============================================

    async function forgotPassword(model) {
        return await ApiClient.post('Auth/forgot-password', model);
    }

    // =============================================
    // Reset Password
    // =============================================

    async function resetPassword(model) {
        return await ApiClient.post('Auth/reset-password', model);
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

    return {
        login,

        register,

        forgotPassword,

        resetPassword,

        changePassword,

        currentUser,
    };
})();
