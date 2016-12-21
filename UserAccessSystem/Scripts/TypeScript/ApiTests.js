"use strict";
var ApiTests = (function () {
    function ApiTests(config) {
        this.configuration = config;
        this.initializeView();
        this.initializeControls();
    }
    ApiTests.prototype.initializeView = function () {
    };
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
        this.getListResponse("http://localhost:55529/api/users");
    };
    ;
    ApiTests.prototype.getUserWithIdResponse = function () {
        this.getSingleItemResponse(this.configuration.UserIdTextboxId, "http://localhost:55529/api/users");
    };
    ;
    ApiTests.prototype.getAllTerritoriesResponse = function () {
        this.getListResponse("http://localhost:55529/api/territories");
    };
    ;
    ApiTests.prototype.getTerritoryWithIdResponse = function () {
        this.getSingleItemResponse(this.configuration.TerritoryIdTextboxId, "http://localhost:55529/api/territories");
    };
    ;
    ApiTests.prototype.getListResponse = function (address) {
        var configAllItems = {
            Address: address
        };
        DataFactory.GetWebApiResponseInTextArea(configAllItems);
    };
    ;
    ApiTests.prototype.getSingleItemResponse = function (controlId, address) {
        var territoryId = $("#" + controlId).val();
        if (!territoryId) {
            alert("Need to enter the ID of user!");
        }
        if (isNaN(territoryId)) {
            alert("Value entered must be a number!");
        }
        else {
            var configTerritoryWithId = {
                Address: address + "/" + territoryId
            };
            DataFactory.GetWebApiResponseInTextArea(configTerritoryWithId);
        }
    };
    ;
    return ApiTests;
}());
//# sourceMappingURL=ApiTests.js.map