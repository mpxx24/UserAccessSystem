declare var $: any;

interface IMainPageConfiguration {
    ButtonAddUserId: string;
    ButtonEditUserId: string;
    ButtonRemoveUserId: string;
    UsersGridId: string;
    AddUserPopup: string;
    EditUserPopup: string;
}

class MainPage {
    configuration: IMainPageConfiguration;
    configAddUserPopup: any;
    configEditUserPopup: any;

    constructor(configuration: IMainPageConfiguration) {
        this.configuration = configuration;
        this.initializeGrid();
        this.initializeView();
        this.initlializeControls();
    }

    initializeView(): void {
        this.initializeAddUserPopup();
        this.initializeEditUserPopup();
    };

    initlializeControls(): void {
        var thisObj = this;
        $(`#${thisObj.configuration.ButtonAddUserId}`).click(() => { thisObj.openAddUserPopup() });
        $(`#${thisObj.configuration.ButtonEditUserId}`).click(() => { thisObj.openEditUserPopup() });
    };

    initializeAddUserPopup(): void {
        var addPopupUrl = $(`#${this.configuration.AddUserPopup}`).data("request-address");
        this.configAddUserPopup = {
            autoOpen: false,
            position: { my: "top+150px", at: "top", of: window },
            resizable: false,
            title: "Add User",
            modal: true,
            open() {
                $(this).load(addPopupUrl);
            }
        };
        $(`#${this.configuration.AddUserPopup}`).dialog(this.configAddUserPopup);
    };

    openAddUserPopup(): void {
        $(`#${this.configuration.AddUserPopup}`).dialog(this.configAddUserPopup).dialog("open");
    };

    initializeEditUserPopup() {

    }

    openEditUserPopup(): void {

    }

    initializeGrid() {
        $(`#${this.configuration.UsersGridId}`).bootgrid({
            ajax: true,
            post() {
                return {
                    id: "x8gt2424-1ht7-4jh5-8123-78duqklqugej"
                };
            },
            url: "Home/GetAllUsers",
            selection: true,
            multiSelect: true,
            rowSelect: false,
            keepSelection: true,
            templates: {
                search: ""
            },
            navigation: 0
        }).on("selected.rs.jquery.bootgrid", (e, rows) => {
            //var rowIds = [];
            //for (var i = 0; i < rows.length; i++) {
            //    rowIds.push(rows[i].Id);
            //}
        });
    }
}