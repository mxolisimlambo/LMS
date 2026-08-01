/**
 * ==========================================================
 * Module : Configuration
 * File   : config.js
 * Purpose: Global application configuration.
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.AppConfig = Object.freeze({
    // ======================================================
    // Application
    // ======================================================

    appName: 'LMS',

    version: '1.0.0',

    environment: 'Development',

    // ======================================================
    // API
    // ======================================================

    api: {
        baseUrl: 'http://localhost:5227/api',

        timeout: 60000,
    },

    // ======================================================
    // Authentication
    // ======================================================

    auth: {
        tokenKey: 'lms_access_token',

        refreshTokenKey: 'lms_refresh_token',

        currentUserKey: 'lms_current_user',
    },

    // ======================================================
    // Pagination
    // ======================================================

    pagination: {
        defaultPageSize: 10,

        pageSizes: [10, 20, 50, 100],
    },

    // ======================================================
    // Date Format
    // ======================================================

    date: {
        displayFormat: 'dd MMM yyyy',

        apiFormat: 'yyyy-MM-dd',
    },

    // ======================================================
    // UI
    // ======================================================

    ui: {
        animationDuration: 300,

        notificationDuration: 3000,
    },
});
