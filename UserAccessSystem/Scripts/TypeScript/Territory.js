"use strict";
var Territory = (function () {
    function Territory(configuration) {
        this.configuration = configuration;
        this.initializeGrid();
        this.initializeView();
        this.initializeControls();
    }
    Territory.prototype.initializeView = function () {
    };
    ;
    Territory.prototype.initializeControls = function () {
        var thisObj = this;
        $("#" + this.configuration.ButtonAddTerritoryId).click(function () { return thisObj.addTerritory(); });
    };
    ;
    Territory.prototype.addTerritory = function () {
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
    return Territory;
}());
//# sourceMappingURL=Territory.js.map