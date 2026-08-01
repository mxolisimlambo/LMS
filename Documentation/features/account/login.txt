/**
 * ==========================================================
 * Module : Account
 * File   : login.js
 * Purpose: Login Page
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.LoginPage = (function () {
    'use strict';

    // =====================================================
    // Initialize
    // =====================================================

    function initialize() {
        SecurityService.redirectIfAuthenticated();

        initializeControls();

        AccountEvents.bindEvents();
    }

    // =====================================================
    // Controls
    // =====================================================

    function initializeControls() {
        $('#Email').trigger('focus');
    }

    // =====================================================

    return {
        initialize,
    };
})();

PageRegistry.register('login', LoginPage);

// =====================================================
// Enter Key Login
// =====================================================

$(document).on('keypress', '#Password', function (e) {
    if (e.which === 13) {
        $('#btnLogin').trigger('click');
    }
});

// =====================================================
// Clear Validation
// =====================================================

$(document).on('input', '#Email,#Password', function () {
    AccountUI.clearValidation();
});
