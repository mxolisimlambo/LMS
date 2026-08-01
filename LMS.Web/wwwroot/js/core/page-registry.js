/**
 * ==========================================================
 * Module : Core
 * File   : page-registry.js
 * Purpose: Registers and initializes pages
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.PageRegistry = (function () {
    'use strict';

    // =====================================================
    // Variables
    // =====================================================

    const pages = {};

    let currentPage = null;

    // =====================================================
    // Register
    // =====================================================

    function register(pageName, pageModule) {
        pages[pageName] = pageModule;
    }

    // =====================================================
    // Exists
    // =====================================================

    function exists(pageName) {
        return Object.prototype.hasOwnProperty.call(pages, pageName);
    }

    // =====================================================
    // Current Page
    // =====================================================

    function current() {
        return currentPage;
    }

    // =====================================================
    // Initialize
    // =====================================================

    function initialize() {
        const page = $('body').data('page');

        if (!page) return;

        if (!exists(page)) {
            console.warn(`Page '${page}' is not registered.`);

            return;
        }

        currentPage = page;

        const module = pages[page];

        if (typeof module.initialize === 'function') {
            module.initialize();
        }
    }

    // =====================================================
    // Destroy
    // =====================================================

    function destroy() {
        currentPage = null;
    }

    // =====================================================

    return {
        register,

        initialize,

        exists,

        current,

        destroy,
    };
})();
