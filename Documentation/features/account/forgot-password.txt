/**
 * ==========================================================
 * Module : Account
 * File   : forgot-password.js
 * Purpose: Forgot Password Page
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
    SecurityService.redirectIfAuthenticated();

    initializeControls();
}

// =====================================================
// Controls
// =====================================================

function initializeControls() {
    $('#Email').trigger('focus');
}

// =====================================================
// Forgot Password
// =====================================================

$(document).on('click', '#btnForgotPassword', async function (e) {
    e.preventDefault();

    AccountUI.clearValidation();

    const model = {
        email: $('#Email').val().trim(),
    };

    const validation = AccountValidation.validateForgotPassword(model);

    if (!validation.valid) {
        AccountUI.showValidation(validation.errors);

        return;
    }

    try {
        AccountUI.showLoading('#btnForgotPassword');

        const response = await AccountService.forgotPassword(model);

        if (!response.success) {
            if (response.errors && response.errors.length > 0) {
                AccountUI.showApiErrors(response.errors);
            } else {
                AccountUI.showError(response.message);
            }

            return;
        }

        AccountUI.showSuccess(response.message);

        AccountUI.clearForm('#ForgotPasswordForm');
    } catch (error) {
        console.error(error);

        AccountUI.showError('An unexpected error occurred.');
    } finally {
        AccountUI.hideLoading('#btnForgotPassword');
    }
});

// =====================================================
// Enter Key Support
// =====================================================

$(document).on('keypress', '#Email', function (e) {
    if (e.which === 13) {
        $('#btnForgotPassword').trigger('click');
    }
});

// =====================================================
// Clear Validation
// =====================================================

$(document).on('input', '#Email', function () {
    AccountUI.clearValidation();
});
