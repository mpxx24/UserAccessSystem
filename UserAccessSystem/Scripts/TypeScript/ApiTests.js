"use strict";
var ApiTests = (function () {
    function ApiTests(config) {
        this.configuration = config;
        this.initializeView();
        this.initializeControls();
    }
    ApiTests.prototype.initializeView = function () { };
    ApiTests.prototype.initializeControls = function () {
        var thisObj = this;
        ;
        $("#" + thisObj.configuration.GetAllUsersLinkId).click(function () { return thisObj.getAllUsersResponse(); });
        $("#" + thisObj.configuration.GetUserWithIdLinkId).click(function () { return thisObj.getUserWithIdResponse(); });
        $("#" + thisObj.configuration.GetAllTerritoriesLinkId).click(function () { return thisObj.getAllTerritoriesResponse(); });
        $("#" + thisObj.configuration.GetTerritoryWithIdLinkId).click(function () { return thisObj.getTerritoryWithIdResponse(); });
    };
    ;
    ApiTests.prototype.getAllUsersResponse = function () {
        var configAllUsers = {
            Address: "http://localhost:55529/api/users"
        };
        DataFactory.GetWebApiResponseInTextArea(configAllUsers);
    };
    ;
    ApiTests.prototype.getUserWithIdResponse = function () {
        var userId = $("#" + this.configuration.UserIdTextboxId).val();
        if (!userId) {
            alert("Need to enter the ID of user!");
        }
        if (isNaN(userId)) {
            alert("Value entered must be a number!");
        }
        else {
            var configUserWithId = {
                Address: "http://localhost:55529/api/users/" + userId
            };
            DataFactory.GetWebApiResponseInTextArea(configUserWithId);
        }
    };
    ;
    ApiTests.prototype.getAllTerritoriesResponse = function () {
        var configAllTerritories = {
            Address: "http://localhost:55529/api/territories"
        };
        DataFactory.GetWebApiResponseInTextArea(configAllTerritories);
    };
    ;
    ApiTests.prototype.getTerritoryWithIdResponse = function () {
        var territoryId = $("#" + this.configuration.TerritoryIdTextboxId).val();
        if (!territoryId) {
            alert("Need to enter the ID of user!");
        }
        if (isNaN(territoryId)) {
            alert("Value entered must be a number!");
        }
        else {
            var configTerritoryWithId = {
                Address: "http://localhost:55529/api/territories/" + territoryId
            };
            DataFactory.GetWebApiResponseInTextArea(configTerritoryWithId);
        }
    };
    ;
    return ApiTests;
}());
//# sourceMappingURL=ApiTests.js.map