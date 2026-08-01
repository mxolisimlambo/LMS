/**
 * ==========================================================
 * Module : Account
 * File   : change-password.js
 * Purpose: Change Password Page
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
    if (!SecurityService.isAuthenticated()) {
        window.location.href = '/Account/Login';
        return;
    }

    initializeControls();
}

// =====================================================
// Controls
// =====================================================

function initializeControls() {
    $('#CurrentPassword').trigger('focus');
}

// =====================================================
// Change Password
// =====================================================

$(document).on('click', '#btnChangePassword', async function (e) {
    e.preventDefault();

    AccountUI.clearValidation();

    const model = {
        currentPassword: $('#CurrentPassword').val(),

        newPassword: $('#NewPassword').val(),

        confirmPassword: $('#ConfirmPassword').val(),
    };

    const validation = AccountValidation.validateChangePassword(model);

    if (!validation.valid) {
        AccountUI.showValidation(validation.errors);
        return;
    }

    try {
        AccountUI.showLoading('#btnChangePassword');

        const response = await AccountService.changePassword(model);

        if (!response.success) {
            if (response.errors && response.errors.length > 0) {
                AccountUI.showApiErrors(response.errors);
            } else {
                AccountUI.showError(response.message);
            }

            return;
        }

        AccountUI.showSuccess(response.message);

        AccountUI.clearForm('#ChangePasswordForm');
    } catch (error) {
        console.error(error);

        AccountUI.showError('An unexpected error occurred.');
    } finally {
        AccountUI.hideLoading('#btnChangePassword');
    }
});

// =====================================================
// Enter Key Support
// =====================================================

$(document).on('keypress', '#ConfirmPassword', function (e) {
    if (e.which === 13) {
        $('#btnChangePassword').trigger('click');
    }
});

// =====================================================
// Clear Validation
// =====================================================

$(document).on('input', '#CurrentPassword,#NewPassword,#ConfirmPassword', function () {
    AccountUI.clearValidation();
});
