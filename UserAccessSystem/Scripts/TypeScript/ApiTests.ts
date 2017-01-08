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

    initializeView(): void {
        
    }

    initializeControls(): void {
        var thisObj = this;;
        $(`#${thisObj.configuration.GetAllUsersLinkId}`).click(() => thisObj.getAllUsersResponse());
        $(`#${thisObj.configuration.GetUserWithIdLinkId}`).click(() => thisObj.getUserWithIdResponse());
        $(`#${thisObj.configuration.GetAllTerritoriesLinkId}`).click(() => thisObj.getAllTerritoriesResponse());
        $(`#${thisObj.configuration.GetTerritoryWithIdLinkId}`).click(() => thisObj.getTerritoryWithIdResponse());
    };

    getAllUsersResponse(): void {
        this.getListResponse("http://localhost:55529/api/users");
    };

    getUserWithIdResponse(): void {
        this.getSingleItemResponse(this.configuration.UserIdTextboxId, "http://localhost:55529/api/users");
    };

    getAllTerritoriesResponse(): void {
        this.getListResponse("http://localhost:55529/api/territories");
    };

    getTerritoryWithIdResponse(): void {
        this.getSingleItemResponse(this.configuration.TerritoryIdTextboxId, "http://localhost:55529/api/territories");
    };
    
    getListResponse(address: string): void {
        var configAllItems = {
            Address: address
        };
        DataFactory.GetWebApiResponseInTextArea(configAllItems);
    };

    getSingleItemResponse(controlId: string, address: string): void {
        var territoryId = $(`#${controlId}`).val();

        if (!territoryId) {
            alert("Need to enter proper ID!");
        }
        if (isNaN(territoryId)) {
            alert("Value entered must be a number!");
        } else {
            var configTerritoryWithId = {
                Address: `${address}/${territoryId}`
            };
            DataFactory.GetWebApiResponseInTextArea(configTerritoryWithId);
        }
    };
}