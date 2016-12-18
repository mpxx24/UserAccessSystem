import Interface = require("./IInterface");
declare var $: any;

interface ITerritoryConfiguration {
    TerritoryGridId: string;
    ButtonAddTerritoryId: string;
    AddTerritoryPopup: string;
}

class Territory implements Interface.IInterface{
    configuration: ITerritoryConfiguration;
    configAddTerritoryPopup: any;

    constructor(configuration: ITerritoryConfiguration) {
        this.configuration = configuration;
        this.initializeGrid();
        this.initializeView();
        this.initializeControls();
    }

    initializeView(): void {
        this.initializeAddTerritoryPopup();
    };

    initializeControls(): void {
        var thisObj = this;
        $(`#${this.configuration.ButtonAddTerritoryId}`).click(() => thisObj.openAddTerritoryPopup());
    };

    openAddTerritoryPopup(): void {
        $(`#${this.configuration.AddTerritoryPopup}`).dialog(this.configAddTerritoryPopup).dialog("open");
    };

    initializeGrid(): void {
        $(`#${this.configuration.TerritoryGridId}`).bootgrid({
            ajax: true,
            post() {
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

    initializeAddTerritoryPopup(): void {
        var addPopupUrl = $(`#${this.configuration.AddTerritoryPopup}`).data("request-address");
        this.configAddTerritoryPopup = {
            autoOpen: false,
            position: { my: "top+150px", at: "top", of: window },
            resizable: false,
            title: "Add Territory",
            modal: true,
            open() {
                $(this).load(addPopupUrl);
            }
        };
        $(`#${this.configuration.AddTerritoryPopup}`).dialog(this.configAddTerritoryPopup);
    };

}