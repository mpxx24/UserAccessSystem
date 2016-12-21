import Interface = require("./IInterface");
declare var $: any;

interface IAssignUsersToTerritories {
    TerritoriesDropdownId:string;
    UsersListBoxId: string;
    AssignButtonId: string;
}

class AssignUsersToTerritories implements Interface.IInterface {
    configuration: IAssignUsersToTerritories;

    constructor(config: IAssignUsersToTerritories) {
        this.configuration = config;
        this.initializeView();
        this.initializeControls();
    }

    initializeView(): void {
        
    };

    initializeControls(): void {
        var thisObj = this;
        $(`#${thisObj.configuration.AssignButtonId}`).click(() => thisObj.assignUsers());
    };

    assignUsers(): void {
        var thisObj = this;
        var addUserUrl = $(`#${thisObj.configuration.AssignButtonId}`).data("request-address");

        var valueTerritory = $(`select#${this.configuration.TerritoriesDropdownId}`).val();
        var valuesUsers = $(`select#${this.configuration.UsersListBoxId}`).val();

        var input = {
            TerritoryId: valueTerritory,
            UserIds: valuesUsers
        }

        $.ajax({
            url: addUserUrl,
            type: "POST",
            dataType: "text",
            conventType: "application/json; charset=utf-8",
            data: { p: JSON.stringify(input) },
            success: () => {
                alert("Updated territory!");
            },
            complete(data) {
                console.log(data);
            },
            error(error) {
                alert("Failed to add assign users to territory!");
            }
        });
    };
}