/**
 * ==========================================================
 * Module : Account
 * File   : reset-password.js
 * Purpose: Reset Password Page
 * Author : Mxolisi Goodman
 * ==========================================================
 */

$(document).ready(function () {
    'use strict';

    initialize();
});

// =====================================================
// Initialize
// =====================================================

function initialize() {
    initializeControls();

    loadToken();
}

// =====================================================
// Controls
// =====================================================

function initializeControls() {
    $('#Email').trigger('focus');
}

// =====================================================
// Load Token From URL
// =====================================================

function loadToken() {
    const params = new URLSearchParams(window.location.search);

    $('#Token').val(params.get('token'));

    $('#Email').val(params.get('email'));
}

// =====================================================
// Reset Password
// =====================================================

$(document).on('click', '#btnResetPassword', async function (e) {
    e.preventDefault();

    AccountUI.clearValidation();

    const model = {
        email: $('#Email').val().trim(),

        token: $('#Token').val(),

        password: $('#Password').val(),

        confirmPassword: $('#ConfirmPassword').val(),
    };

    const validation = AccountValidation.validateResetPassword(model);

    if (!validation.valid) {
        AccountUI.showValidation(validation.errors);

        return;
    }

    try {
        AccountUI.showLoading('#btnResetPassword');

        const response = await AccountService.resetPassword(model);

        if (!response.success) {
            if (response.errors && response.errors.length > 0) {
                AccountUI.showApiErrors(response.errors);
            } else {
                AccountUI.showError(response.message);
            }

            return;
        }

        AccountUI.showSuccess(response.message);

        AccountUI.clearForm('#ResetPasswordForm');

        setTimeout(function () {
            window.location.href = '/Account/Login';
        }, 1500);
    } catch (error) {
        console.error(error);

        AccountUI.showError('An unexpected error occurred.');
    } finally {
        AccountUI.hideLoading('#btnResetPassword');
    }
});

// =====================================================
// Enter Key Support
// =====================================================

$(document).on('keypress', '#ConfirmPassword', function (e) {
    if (e.which === 13) {
        $('#btnResetPassword').trigger('click');
    }
});

// =====================================================
// Clear Validation
// =====================================================

$(document).on('input', '#Email,#Password,#ConfirmPassword', function () {
    AccountUI.clearValidation();
});
