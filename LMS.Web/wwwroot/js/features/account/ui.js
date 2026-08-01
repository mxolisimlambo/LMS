/**
 * ==========================================================
 * Module : Account
 * File   : ui.js
 * Purpose: Account User Interface Functions
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.AccountUI = (function () {
    'use strict';

    // =====================================================
    // Loading
    // =====================================================

    function showLoading(buttonSelector) {
        $(buttonSelector).prop('disabled', true).addClass('disabled');
    }

    function hideLoading(buttonSelector) {
        $(buttonSelector).prop('disabled', false).removeClass('disabled');
    }

    // =====================================================
    // Validation Messages
    // =====================================================

    function clearValidation() {
        $('.validation-error').remove();

        $('.is-invalid').removeClass('is-invalid');
    }

    function showValidation(errors) {
        clearValidation();

        errors.forEach(function (message) {
            $('#validation-summary').append(`<div class="validation-error text-danger">${message}</div>`);
        });
    }

    // =====================================================
    // API Errors
    // =====================================================

    function showApiErrors(errors) {
        clearValidation();

        if (!errors || errors.length === 0) return;

        errors.forEach(function (error) {
            $('#validation-summary').append(`<div class="validation-error text-danger">${error.description}</div>`);
        });
    }

    // =====================================================
    // Success Message
    // =====================================================

    function showSuccess(message) {
        $('#validation-summary').html(`<div class="text-success">${message}</div>`);
    }

    // =====================================================
    // Error Message
    // =====================================================

    function showError(message) {
        $('#validation-summary').html(`<div class="text-danger">${message}</div>`);
    }

    // =====================================================
    // Form
    // =====================================================

    function clearForm(formSelector) {
        $(formSelector)[0].reset();
    }

    // =====================================================
    // Focus
    // =====================================================

    function focus(controlId) {
        $(controlId).focus();
    }

    // =====================================================

    return {
        showLoading,

        hideLoading,

        clearValidation,

        showValidation,

        showApiErrors,

        showSuccess,

        showError,

        clearForm,

        focus,
    };
})();
