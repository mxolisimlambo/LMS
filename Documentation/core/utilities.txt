/**
 * ==========================================================
 * Module : Core
 * File   : utilities.js
 * Purpose: Common helper methods
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.Utilities = (function () {
    'use strict';

    // ============================================
    // Loading
    // ============================================

    function showLoader() {
        $('#loader-container').show();
    }

    function hideLoader() {
        $('#loader-container').hide();
    }

    // ============================================
    // Notifications
    // ============================================

    function success(message) {
        alert(message);
    }

    function error(message) {
        alert(message);
    }

    function warning(message) {
        alert(message);
    }

    function info(message) {
        alert(message);
    }

    // ============================================
    // Formatting
    // ============================================

    function formatCurrency(value) {
        return new Intl.NumberFormat('en-ZA', {
            style: 'currency',

            currency: 'ZAR',
        }).format(value);
    }

    function formatDate(date) {
        return new Date(date).toLocaleDateString();
    }

    // ============================================
    // Validation
    // ============================================

    function isNullOrEmpty(value) {
        return value === null || value === undefined || value === '';
    }

    // ============================================

    return {
        showLoader,

        hideLoader,

        success,

        error,

        warning,

        info,

        formatCurrency,

        formatDate,

        isNullOrEmpty,
    };
})();
