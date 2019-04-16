/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService'];

    function apiService($http, notificationService) {
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }

        function post(url, data, succes, failure) {
            $http.post(url, data).then(function (result) {
                succes(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError("Authenticate is require");
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        function put(url, data, succes, failure) {
            $http.put(url, data).then(function (result) {
                succes(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError("Authenticate is require");
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        function del(url, data, succes, failure) {
            $http.delete(url, data).then(function (result) {
                succes(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError("Authenticate is require");
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        return {
            get: get,
            post: post,
            put: put,
            del: del
        };
    }
})(angular.module('nshop.common'));