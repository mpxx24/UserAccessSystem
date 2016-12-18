"use strict";
var Territory = (function () {
    function Territory(configuration) {
        this.configuration = configuration;
        this.initializeGrid();
        this.initializeView();
        this.initializeControls();
    }
    Territory.prototype.initializeView = function () {
        this.initializeAddTerritoryPopup();
    };
    ;
    Territory.prototype.initializeControls = function () {
        var thisObj = this;
        $("#" + this.configuration.ButtonAddTerritoryId).click(function () { return thisObj.openAddTerritoryPopup(); });
    };
    ;
    Territory.prototype.openAddTerritoryPopup = function () {
        $("#" + this.configuration.AddTerritoryPopup).dialog(this.configAddTerritoryPopup).dialog("open");
    };
    ;
    Territory.prototype.initializeGrid = function () {
        $("#" + this.configuration.TerritoryGridId).bootgrid({
            ajax: true,
            post: function () {
                return {
                    id: "h4garp30-maue-kola-hepz-1ha7zfl40h2j"
                };
            },
            url: "Territory/GetAllTerritories",
            templates: {
                search: ""
            },
            navigation: 0
        });
    };
    ;
    Territory.prototype.initializeAddTerritoryPopup = function () {
        var addPopupUrl = $("#" + this.configuration.AddTerritoryPopup).data("request-address");
        this.configAddTerritoryPopup = {
            autoOpen: false,
            position: { my: "top+150px", at: "top", of: window },
            resizable: false,
            title: "Add Territory",
            modal: true,
            open: function () {
                $(this).load(addPopupUrl);
            }
        };
        $("#" + this.configuration.AddTerritoryPopup).dialog(this.configAddTerritoryPopup);
    };
    ;
    return Territory;
}());
//# sourceMappingURL=Territory.js.map