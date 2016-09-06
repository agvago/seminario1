﻿var app = angular.module('app');

app.factory('SimulacionService', ['$http', function ($http) {
    return {
        consultarTor: function (cuit) {
            return $http.get("/api/Validationes/GetTorState/" + cuit).success(function (data) {
                return data;
            }).error (function (error) {
                alert(error);
            });
        },

        consularNosis: function (data) {
            return $http.post("/api/Validationes/GetNosisState/", { "rows": data }).success(function (data) {
                return data;
            }).error (function (error) {
                alert(error);
            });
        },

        fillComboProducto: function () {
            return $http.get("/api/Setting/GetAllProductos").success(function (data) {
                return data;
            }).error (function (error) {
                alert(error);
            });
        },

        fillComboProvincia: function () {
            return $http.get("/api/Setting/GetAllProvincias").success(function (data) {
                return data;
            }).error (function (error) {
                alert(error);
            });
        },

        createSimulacion: function (simulacion) {
            return $http.post("/api/Simulacion/CreateSimulacion/", simulacion).success(function (data) {
                return data;
            }).error (function (error) {
                alert(error);
            });
        },

        updateSimulacion: function (simulacion) {
            return $http.post("/api/Simulacion/UpdateSimulacion/", simulacion).success(function (data) {
                return data;
            }).error(function (error) {
                alert(error);
            });
        },
        
        getSimulacionById: function (simulacionId) {
            return $http.get("/api/Simulacion/GetSimulacionById/" + simulacionId).success(function (data) {
                return data;
            }).error(function (error) {
                alert(error);
            });
        },

        getAllSimulacion: function (simulacion) {
            return $http.get("/api/Simulacion/GetAllSimulacion").success(function (data) {
                return data;
            }).error (function (error){
                alert(error);
            });
        }
   }
}]);