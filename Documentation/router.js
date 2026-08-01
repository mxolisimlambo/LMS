/**
 * ==========================================================
 * Module : Core
 * File   : router.js
 * Purpose: Starts feature modules
 * Author : Mxolisi Goodman
 * ==========================================================
 */

window.Router = (function () {
    'use strict';

    function initialize() {
        const page = $('body').data('page');

        switch (page) {
            case 'home':
                if (window.HomePage) {
                    HomePage.initialize();
                }

                break;

            case 'login':
                if (window.LoginPage) {
                    LoginPage.initialize();
                }

                break;

            case 'course-list':
                if (window.CourseListPage) {
                    CourseListPage.initialize();
                }

                break;

            case 'course-details':
                if (window.CourseDetailsPage) {
                    CourseDetailsPage.initialize();
                }

                break;

            case 'student-dashboard':
                if (window.StudentDashboardPage) {
                    StudentDashboardPage.initialize();
                }

                break;

            default:
                console.log('No page module found.');

                break;
        }
    }

    return {
        initialize,
    };
})();
