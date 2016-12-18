"use strict";
var AddTerritory = (function () {
    function AddTerritory(configuration) {
        this.configuration = configuration;
        this.initializeView();
        this.initializeControls();
    }
    AddTerritory.prototype.initializeView = function () {
    };
    ;
    AddTerritory.prototype.initializeControls = function () {
        var thisObj = this;
        $("#" + thisObj.configuration.ButtonAddTerritoryId).click(function () { thisObj.saveTerritory(); });
    };
    ;
    AddTerritory.prototype.saveTerritory = function () {
        var thisObj = this;
        var addTerritoryUrl = $("#" + thisObj.configuration.ButtonAddTerritoryId).data("request-address");
        var input = {
            Name: $("#" + thisObj.configuration.NameTextBoxId).val(),
            ShortName: $("#" + thisObj.configuration.ShortNameTextBoxId).val()
        };
        console.log(addTerritoryUrl, input);
        $.ajax({
            url: addTerritoryUrl,
            type: "POST",
            dataType: "text",
            conventType: "application/json; charset=utf-8",
            data: { p: JSON.stringify(input) },
            complete: function () {
                $("#" + thisObj.configuration.PopupAddTerritoryId).dialog().dialog("close");
                $("#" + thisObj.configuration.TerritoryGridId).bootgrid("reload");
            },
            error: function (error) {
                alert("Failed to add user!");
            }
        });
    };
    ;
    return AddTerritory;
}());
//# sourceMappingURL=AddTerritory.js.map