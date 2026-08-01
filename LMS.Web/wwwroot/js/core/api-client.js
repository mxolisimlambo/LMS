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

    // =====================================================
    // Headers
    // =====================================================

    function getHeaders(includeToken = true) {
        const headers = {};

        if (includeToken) {
            const token = StorageService.getAccessToken();

            if (token) {
                headers.Authorization = `Bearer ${token}`;
            }
        }

        return headers;
    }

    // =====================================================
    // Request
    // =====================================================

    function request(method, endpoint, data = null, includeToken = true) {
        return $.ajax({
            url: `${AppConfig.api.baseUrl}/${endpoint}`,

            type: method,

            headers: getHeaders(includeToken),

            contentType: 'application/json',

            dataType: 'json',

            timeout: AppConfig.api.timeout,

            data: data ? JSON.stringify(data) : null,
        }).fail(function (xhr) {
            handleError(xhr);
        });
    }

    // =====================================================
    // GET
    // =====================================================

    function get(endpoint, includeToken = true) {
        return request('GET', endpoint, null, includeToken);
    }

    // =====================================================
    // POST
    // =====================================================

    function post(endpoint, data, includeToken = true) {
        return request('POST', endpoint, data, includeToken);
    }

    // =====================================================
    // PUT
    // =====================================================

    function put(endpoint, data, includeToken = true) {
        return request('PUT', endpoint, data, includeToken);
    }

    // =====================================================
    // PATCH
    // =====================================================

    function patch(endpoint, data, includeToken = true) {
        return request('PATCH', endpoint, data, includeToken);
    }

    // =====================================================
    // DELETE
    // =====================================================

    function del(endpoint, includeToken = true) {
        return request('DELETE', endpoint, null, includeToken);
    }

    // =====================================================
    // Upload
    // =====================================================

    function upload(endpoint, formData, includeToken = true) {
        return $.ajax({
            url: `${AppConfig.api.baseUrl}/${endpoint}`,

            type: 'POST',

            headers: getHeaders(includeToken),

            processData: false,

            contentType: false,

            timeout: AppConfig.api.timeout,

            data: formData,
        }).fail(function (xhr) {
            handleError(xhr);
        });
    }

    // =====================================================
    // Download
    // =====================================================

    function download(endpoint, includeToken = true) {
        return $.ajax({
            url: `${AppConfig.api.baseUrl}/${endpoint}`,

            type: 'GET',

            headers: getHeaders(includeToken),

            xhrFields: {
                responseType: 'blob',
            },
        }).fail(function (xhr) {
            handleError(xhr);
        });
    }

    // =====================================================
    // Error Handler
    // =====================================================

    function handleError(xhr) {
        switch (xhr.status) {
            case 401:
                console.warn('Unauthorized');

                // SecurityService.redirectToLogin();

                break;

            case 403:
                console.warn('Forbidden');

                break;

            case 404:
                console.warn('Resource Not Found');

                break;

            case 500:
                console.error('Internal Server Error');

                break;

            default:
                console.error(xhr);

                break;
        }
    }

    // =====================================================

    return {
        get,

        post,

        put,

        patch,

        delete: del,

        upload,

        download,
    };
})();
