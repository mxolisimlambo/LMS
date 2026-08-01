/**
 * ==========================================================
 * Module : Core
 * File   : storage.js
 * Purpose: Handles LocalStorage and SessionStorage
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.StorageService = (function () {
    'use strict';

    // =====================================================
    // Local Storage
    // =====================================================

    function set(key, value) {
        localStorage.setItem(key, JSON.stringify(value));
    }

    function get(key) {
        const value = localStorage.getItem(key);

        return value ? JSON.parse(value) : null;
    }

    function remove(key) {
        localStorage.removeItem(key);
    }

    function clear() {
        localStorage.clear();
    }

    // =====================================================
    // Session Storage
    // =====================================================

    function setSession(key, value) {
        sessionStorage.setItem(key, JSON.stringify(value));
    }

    function getSession(key) {
        const value = sessionStorage.getItem(key);

        return value ? JSON.parse(value) : null;
    }

    function removeSession(key) {
        sessionStorage.removeItem(key);
    }

    function clearSession() {
        sessionStorage.clear();
    }

    // =====================================================
    // Authentication
    // =====================================================

    function setAccessToken(token) {
        set(AppConfig.auth.tokenKey, token);
    }

    function getAccessToken() {
        return get(AppConfig.auth.tokenKey);
    }

    function removeAccessToken() {
        remove(AppConfig.auth.tokenKey);
    }

    function setRefreshToken(token) {
        set(AppConfig.auth.refreshTokenKey, token);
    }

    function getRefreshToken() {
        return get(AppConfig.auth.refreshTokenKey);
    }

    function removeRefreshToken() {
        remove(AppConfig.auth.refreshTokenKey);
    }

    function setCurrentUser(user) {
        set(AppConfig.auth.currentUserKey, user);
    }

    function getCurrentUser() {
        return get(AppConfig.auth.currentUserKey);
    }

    function removeCurrentUser() {
        remove(AppConfig.auth.currentUserKey);
    }

    function clearAuthentication() {
        removeAccessToken();

        removeRefreshToken();

        removeCurrentUser();
    }

    // =====================================================

    return {
        set,
        get,
        remove,
        clear,

        setSession,
        getSession,
        removeSession,
        clearSession,

        setAccessToken,
        getAccessToken,
        removeAccessToken,

        setRefreshToken,
        getRefreshToken,
        removeRefreshToken,

        setCurrentUser,
        getCurrentUser,
        removeCurrentUser,

        clearAuthentication,
    };
})();
