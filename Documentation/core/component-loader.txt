/**
 * ==========================================================
 * Module : Core
 * File   : component-loader.js
 * Purpose: Dynamically loads reusable HTML components
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.ComponentLoader = (function () {
    'use strict';

    // ============================================
    // Load Component
    // ============================================

    async function load(selector, path) {
        try {
            const html = await $.get(path);

            $(selector).html(html);
        } catch (error) {
            console.error(`Unable to load ${path}`);

            console.error(error);
        }
    }

    // ============================================
    // Load Multiple Components
    // ============================================

    async function loadMany(components) {
        for (const component of components) {
            await load(component.selector, component.path);
        }
    }

    // ============================================

    return {
        load,

        loadMany,
    };
})();
