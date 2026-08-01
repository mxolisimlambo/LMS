/**
 * ==========================================================
 * Module : Account
 * File   : validation.js
 * Purpose: Validation for Authentication Forms
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.AccountValidation = (function () {
    'use strict';

    // =====================================================
    // Login Validation
    // =====================================================

    function validateLogin(model) {
        const errors = [];

        if (!model.email || model.email.trim() === '') {
            errors.push('Email is required.');
        }

        if (!model.password || model.password.trim() === '') {
            errors.push('Password is required.');
        }

        return {
            valid: errors.length === 0,

            errors: errors,
        };
    }

    // =====================================================
    // Register Validation
    // =====================================================

    function validateRegister(model) {
        const errors = [];

        if (!model.firstName || model.firstName.trim() === '') {
            errors.push('First Name is required.');
        }

        if (!model.lastName || model.lastName.trim() === '') {
            errors.push('Last Name is required.');
        }

        if (!model.email || model.email.trim() === '') {
            errors.push('Email is required.');
        }

        if (!model.password || model.password.trim() === '') {
            errors.push('Password is required.');
        }

        if (!model.confirmPassword || model.confirmPassword.trim() === '') {
            errors.push('Confirm Password is required.');
        }

        if (model.password !== model.confirmPassword) {
            errors.push('Passwords do not match.');
        }

        return {
            valid: errors.length === 0,

            errors: errors,
        };
    }

    // =====================================================
    // Forgot Password Validation
    // =====================================================

    function validateForgotPassword(model) {
        const errors = [];

        if (!model.email || model.email.trim() === '') {
            errors.push('Email is required.');
        }

        return {
            valid: errors.length === 0,

            errors: errors,
        };
    }

    // =====================================================
    // Change Password Validation
    // =====================================================

    function validateChangePassword(model) {
        const errors = [];

        if (!model.currentPassword) {
            errors.push('Current Password is required.');
        }

        if (!model.newPassword) {
            errors.push('New Password is required.');
        }

        if (!model.confirmPassword) {
            errors.push('Confirm Password is required.');
        }

        if (model.newPassword !== model.confirmPassword) {
            errors.push('Passwords do not match.');
        }

        return {
            valid: errors.length === 0,

            errors: errors,
        };
    }

    // =====================================================
    // Reset Password Validation
    // =====================================================

    function validateResetPassword(model) {
        const errors = [];

        if (!model.email) {
            errors.push('Email is required.');
        }

        if (!model.token) {
            errors.push('Reset Token is required.');
        }

        if (!model.password) {
            errors.push('Password is required.');
        }

        if (!model.confirmPassword) {
            errors.push('Confirm Password is required.');
        }

        if (model.password !== model.confirmPassword) {
            errors.push('Passwords do not match.');
        }

        return {
            valid: errors.length === 0,

            errors: errors,
        };
    }

    // =====================================================

    return {
        validateLogin,

        validateRegister,

        validateForgotPassword,

        validateChangePassword,

        validateResetPassword,
    };
})();
