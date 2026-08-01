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

    const pages = {};

    function register(pageName, pageModule) {
        console.log('Registering:', pageName);
        pages[pageName] = pageModule;
    }

    function initialize() {
        const page = $('body').data('page');

        if (!page) return;

        const module = pages[page];

        if (!module) return;

        if (typeof module.initialize === 'function') {
            module.initialize();
        }
    }

    return {
        register,

        initialize,
    };
})();
