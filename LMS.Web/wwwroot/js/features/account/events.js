/**
 * ==========================================================
 * Module : Account
 * File   : events.js
 * Purpose: Account Event Handlers
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.AccountEvents = (function () {
    'use strict';

    // =====================================================
    // Login
    // =====================================================

    async function login(e) {
        if (e) {
            e.preventDefault();
        }

        AccountUI.clearValidation();

        const model = {
            email: $('#Email').val().trim(),

            password: $('#Password').val(),

            rememberMe: $('#RememberMe').is(':checked'),
        };

        const validation = AccountValidation.validateLogin(model);

        if (!validation.valid) {
            AccountUI.showValidation(validation.errors);

            return;
        }

        try {
            AccountUI.showLoading('#btnLogin');

            const response = await AccountService.login(model);

            if (!response.success) {
                if (response.errors && response.errors.length > 0) {
                    AccountUI.showApiErrors(response.errors);
                } else {
                    AccountUI.showError(response.message);
                }

                return;
            }

            AccountUI.showSuccess(response.message);

            SecurityService.redirectAfterLogin();
        } catch (error) {
            console.error(error);

            AccountUI.showError('An unexpected error occurred.');
        } finally {
            AccountUI.hideLoading('#btnLogin');
        }
    }

    // =====================================================
    // Register
    // =====================================================

    async function register(e) {
        if (e) {
            e.preventDefault();
        }

        AccountUI.clearValidation();

        const model = {
            firstName: $('#FirstName').val().trim(),

            lastName: $('#LastName').val().trim(),

            email: $('#Email').val().trim(),

            password: $('#Password').val(),

            confirmPassword: $('#ConfirmPassword').val(),
        };

        const validation = AccountValidation.validateRegister(model);

        if (!validation.valid) {
            AccountUI.showValidation(validation.errors);

            return;
        }

        try {
            AccountUI.showLoading('#btnRegister');

            const response = await AccountService.register(model);

            if (!response.success) {
                if (response.errors && response.errors.length > 0) {
                    AccountUI.showApiErrors(response.errors);
                } else {
                    AccountUI.showError(response.message);
                }

                return;
            }

            AccountUI.showSuccess(response.message);

            AccountUI.clearForm('#RegisterForm');

            setTimeout(function () {
                window.location.href = '/Account/Login';
            }, 1500);
        } catch (error) {
            console.error(error);

            AccountUI.showError('An unexpected error occurred.');
        } finally {
            AccountUI.hideLoading('#btnRegister');
        }
    }

    // =====================================================
    // Forgot Password
    // =====================================================

    async function forgotPassword(e) {
        if (e) {
            e.preventDefault();
        }

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
    }

    // =====================================================
    // Reset Password
    // =====================================================

    async function resetPassword(e) {
        if (e) {
            e.preventDefault();
        }

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
    }

    // =====================================================
    // Change Password
    // =====================================================

    async function changePassword(e) {
        if (e) {
            e.preventDefault();
        }

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
    }

    // =====================================================
    // Bind Events
    // =====================================================

    function bindEvents() {
        // Login
        $('#btnLogin').on('click', login);
        $('#LoginForm').on('submit', login);

        // Register
        $('#btnRegister').on('click', register);
        $('#RegisterForm').on('submit', register);

        // Forgot Password
        $('#btnForgotPassword').on('click', forgotPassword);
        $('#ForgotPasswordForm').on('submit', forgotPassword);

        // Reset Password
        $('#btnResetPassword').on('click', resetPassword);
        $('#ResetPasswordForm').on('submit', resetPassword);

        // Change Password
        $('#btnChangePassword').on('click', changePassword);
        $('#ChangePasswordForm').on('submit', changePassword);
    }

    // =====================================================
    // Initialize
    // =====================================================

    function initialize() {
        SecurityService.redirectIfAuthenticated();

        bindEvents();
    }

    // =====================================================

    return {
        initialize,

        bindEvents,

        login,

        register,

        forgotPassword,

        resetPassword,

        changePassword,
    };
})();
