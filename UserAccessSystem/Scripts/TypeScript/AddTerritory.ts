import Interface = require("./IInterface");
declare var $: any;

interface IAddTerritoryConfiguration {
    ButtonAddTerritoryId: string;
    NameTextBoxId: string;
    ShortNameTextBoxId: string;
    PopupAddTerritoryId: string;
    TerritoryGridId: string;
}

class AddTerritory implements Interface.IInterface {
    configuration: IAddTerritoryConfiguration;

    constructor(configuration: IAddTerritoryConfiguration) {
        this.configuration = configuration;
        this.initializeView();
        this.initializeControls();
    }

    initializeView(): void {
        
    };

    initializeControls(): void {
        var thisObj = this;
      
        $(`#${thisObj.configuration.ButtonAddTerritoryId}`).click(() => { thisObj.saveTerritory() });
    };

    saveTerritory(): void {
        var thisObj = this;
        var addTerritoryUrl = $(`#${thisObj.configuration.ButtonAddTerritoryId}`).data("request-address");

        var input = {
            Name: $(`#${thisObj.configuration.NameTextBoxId}`).val(),
            ShortName: $(`#${thisObj.configuration.ShortNameTextBoxId}`).val()
        }

        console.log(addTerritoryUrl, input);

        $.ajax({
            url: addTerritoryUrl,
            type: "POST",
            dataType: "text",
            conventType: "application/json; charset=utf-8",
            data: { p: JSON.stringify(input) },
            complete() {
                $(`#${thisObj.configuration.PopupAddTerritoryId}`).dialog().dialog("close");
                $(`#${thisObj.configuration.TerritoryGridId}`).bootgrid("reload");
            },
            error(error) {
                alert("Failed to add user!");
            }
        });
    };
}