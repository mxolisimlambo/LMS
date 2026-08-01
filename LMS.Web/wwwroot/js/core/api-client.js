/**
 * ==========================================================
 * Module : Core
 * File   : api-client.js
 * Purpose: Handles all HTTP communication with the API
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.ApiClient = (function () {
    'use strict';

    // ============================================
    // Build Headers
    // ============================================

    function getHeaders() {
        const headers = {
            'Content-Type': 'application/json',
        };

        const token = StorageService.getAccessToken();

        if (token) {
            headers['Authorization'] = `Bearer ${token}`;
        }

        return headers;
    }

    // ============================================
    // AJAX Request
    // ============================================

    function request(method, endpoint, data = null) {
        return $.ajax({
            url: `${AppConfig.api.baseUrl}/${endpoint}`,

            type: method,

            headers: getHeaders(),

            contentType: 'application/json',

            dataType: 'json',

            timeout: AppConfig.api.timeout,

            data: data ? JSON.stringify(data) : null,
        }).fail(function (xhr) {
            handleError(xhr);
        });
    }

    // ============================================
    // HTTP Methods
    // ============================================

    function get(endpoint) {
        return request('GET', endpoint);
    }

    function post(endpoint, data) {
        return request('POST', endpoint, data);
    }

    function put(endpoint, data) {
        return request('PUT', endpoint, data);
    }

    function del(endpoint) {
        return request('DELETE', endpoint);
    }

    // ============================================
    // Error Handling
    // ============================================

    function handleError(xhr) {
        switch (xhr.status) {
            case 401:
                console.warn('Unauthorized');

                break;

            case 403:
                console.warn('Forbidden');

                break;

            case 404:
                console.warn('Not Found');

                break;

            case 500:
                console.error('Internal Server Error');

                break;

            default:
                console.error(xhr);

                break;
        }
    }

    // ============================================

    return {
        get,

        post,

        put,

        delete: del,
    };
})();
