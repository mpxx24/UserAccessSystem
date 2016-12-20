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
        var valueTerritory = $(`select#${this.configuration.TerritoriesDropdownId}`).val();
        var valuesUsers = $(`select#${this.configuration.UsersListBoxId}`).val();
        console.log(valueTerritory, valuesUsers);
    };
}