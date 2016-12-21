import Interface = require("./IInterface");
declare var $: any;
declare var DataFactory: any;

interface IApiTests {
    GetAllUsersLinkId: string;
    GetUserWithIdLinkId: string;
    UserIdTextboxId: string;
    GetAllTerritoriesLinkId: string;
    GetTerritoryWithIdLinkId: string;
    TerritoryIdTextboxId: string;
}

class ApiTests implements Interface.IInterface {
    configuration: any;

    constructor(config: IApiTests) {
        this.configuration = config;
        this.initializeView();
        this.initializeControls();
    }

    initializeView(): void {}

    initializeControls(): void {
        var thisObj = this;;
        $(`#${thisObj.configuration.GetAllUsersLinkId}`).click(() => thisObj.getAllUsersResponse());
        $(`#${thisObj.configuration.GetUserWithIdLinkId}`).click(() => thisObj.getUserWithIdResponse());
        $(`#${thisObj.configuration.GetAllTerritoriesLinkId}`).click(() => thisObj.getAllTerritoriesResponse());
        $(`#${thisObj.configuration.GetTerritoryWithIdLinkId}`).click(() => thisObj.getTerritoryWithIdResponse());
    };

    getAllUsersResponse(): void {
        var configAllUsers = {
            Address: "http://localhost:55529/api/users"
        };
        DataFactory.GetWebApiResponseInTextArea(configAllUsers);
    };

    getUserWithIdResponse(): void {
        var userId = $(`#${this.configuration.UserIdTextboxId}`).val();

        if (!userId) {
            alert("Need to enter the ID of user!");
        }
        if (isNaN(userId)) {
            alert("Value entered must be a number!");
        } else {
            var configUserWithId = {
                Address: `http://localhost:55529/api/users/${userId}`
            };
            DataFactory.GetWebApiResponseInTextArea(configUserWithId);
        }
    };

    getAllTerritoriesResponse(): void {
        var configAllTerritories = {
            Address: "http://localhost:55529/api/territories"
        };
        DataFactory.GetWebApiResponseInTextArea(configAllTerritories);
    };

    getTerritoryWithIdResponse(): void {
        var territoryId = $(`#${this.configuration.TerritoryIdTextboxId}`).val();

        if (!territoryId) {
            alert("Need to enter the ID of user!");
        }
        if (isNaN(territoryId)) {
            alert("Value entered must be a number!");
        } else {
            var configTerritoryWithId = {
                Address: `http://localhost:55529/api/territories/${territoryId}`
            };
            DataFactory.GetWebApiResponseInTextArea(configTerritoryWithId);
        }
    };
}