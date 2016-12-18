import Interface = require("./IInterface");
declare var $: any;

interface ITerritoryConfiguration {
    TerritoryGridId: string;
    ButtonAddTerritoryId: string;
}

class Territory implements Interface.IInterface{
    configuration: ITerritoryConfiguration;

    constructor(configuration: ITerritoryConfiguration) {
        this.configuration = configuration;
        this.initializeGrid();
        this.initializeView();
        this.initializeControls();
    }

    initializeView(): void {
        
    };

    initializeControls(): void {
        var thisObj = this;
        $(`#${this.configuration.ButtonAddTerritoryId}`).click(() => thisObj.addTerritory());
    };

    addTerritory(): void {
        
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
    }
}