"use strict";
var AssignUsersToTerritories = (function () {
    function AssignUsersToTerritories(config) {
        console.log("t");
        this.configuration = config;
        this.initializeView();
        this.initializeControls();
    }
    AssignUsersToTerritories.prototype.initializeView = function () {
    };
    ;
    AssignUsersToTerritories.prototype.initializeControls = function () {
        var thisObj = this;
        $("#" + thisObj.configuration.AssignButtonId).click(function () { return thisObj.assignUsers(); });
    };
    ;
    AssignUsersToTerritories.prototype.assignUsers = function () {
        var valueTerritory = $("select#" + this.configuration.TerritoriesDropdownId).val();
        var valuesUsers = $("select#" + this.configuration.UsersListBoxId).val();
        console.log(valueTerritory, valuesUsers);
    };
    ;
    return AssignUsersToTerritories;
}());
//# sourceMappingURL=AssignUsersToTerritories.js.map