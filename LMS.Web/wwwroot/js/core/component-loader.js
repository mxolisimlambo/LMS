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

    // =====================================================
    // Cache
    // =====================================================

    const cache = {};

    // =====================================================
    // Exists
    // =====================================================

    function exists(selector) {
        return $(selector).length > 0;
    }

    function isCached(path) {
        return Object.prototype.hasOwnProperty.call(cache, path);
    }

    // =====================================================
    // Load Component
    // =====================================================

   async function load(selector, path) {
       try {
           let html;

           if (isCached(path)) {
               html = cache[path];
           } else {
               html = await $.get(path);

               cache[path] = html;
           }

           $(selector).html(html);
       } catch (error) {
           console.error(`Unable to load ${path}`);

           console.error(error);
       }
   }

    // =====================================================
    // Reload Component
    // =====================================================

    async function reload(selector, path) {
        delete cache[path];

        await load(selector, path);
    }

    // =====================================================
    // Load Multiple
    // =====================================================

    async function loadMany(components) {
        for (const component of components) {
            await load(component.selector, component.path);
        }
    }

    // =====================================================
    // Clear Cache
    // =====================================================

    function clearCache() {
        Object.keys(cache).forEach((key) => delete cache[key]);
    }

    // =====================================================

    return {
        load,

        loadMany,

        reload,

        exists,

        clearCache,
        isCached,
    };
})();
