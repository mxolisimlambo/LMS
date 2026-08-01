/**
 * ==========================================================
 * Module : Account
 * File   : register.js
 * Purpose: Register Page
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.RegisterPage = (function () {
    'use strict';

    // =====================================================
    // Initialize
    // =====================================================

    function initialize() {
        SecurityService.redirectIfAuthenticated();

        initializeControls();

        bindEvents();
    }

    // =====================================================
    // Controls
    // =====================================================

    function initializeControls() {
        $('#FirstName').trigger('focus');
    }

    // =====================================================
    // Events
    // =====================================================

    function bindEvents() {
        // Register Button
        $('#btnRegister').off('click').on('click', AccountEvents.register);

        // Form Submit
        $('#RegisterForm').off('submit').on('submit', AccountEvents.register);

        // Enter Key
        $('#ConfirmPassword')
            .off('keypress')
            .on('keypress', function (e) {
                if (e.which === 13) {
                    $('#btnRegister').trigger('click');
                }
            });

        // Clear Validation
        $('#FirstName,#LastName,#Email,#Password,#ConfirmPassword')
            .off('input')
            .on('input', function () {
                AccountUI.clearValidation();
            });
    }

    // =====================================================

    return {
        initialize,
    };
})();

// =========================================================
// Register Page
// =========================================================

PageRegistry.register('register', RegisterPage);
