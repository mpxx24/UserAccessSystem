"use strict";
var AssignUsersToTerritories = (function () {
    function AssignUsersToTerritories(config) {
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
        var thisObj = this;
        var addUserUrl = $("#" + thisObj.configuration.AssignButtonId).data("request-address");
        var valueTerritory = $("select#" + this.configuration.TerritoriesDropdownId).val();
        var valuesUsers = $("select#" + this.configuration.UsersListBoxId).val();
        var input = {
            TerritoryId: valueTerritory,
            UserIds: valuesUsers
        };
        $.ajax({
            url: addUserUrl,
            type: "POST",
            dataType: "text",
            conventType: "application/json; charset=utf-8",
            data: { p: JSON.stringify(input) },
            success: function () {
                alert("Updated territory!");
            },
            complete: function (data) {
                console.log(data);
            },
            error: function (error) {
                alert("Failed to add assign users to territory!");
            }
        });
    };
    ;
    return AssignUsersToTerritories;
}());
//# sourceMappingURL=AssignUsersToTerritories.js.map