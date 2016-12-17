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
        $(`#${thisObj.configuration.ButtonRemoveUserId}`).click(() => { thisObj.removeUsers() });
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

    initializeEditUserPopup(): void {
        this.configEditUserPopup = {
            autoOpen: false,
            position: { my: "top+150px", at: "top", of: window },
            resizable: false,
            title: "Update User",
            modal: true
        };
        $(`#${this.configuration.EditUserPopup}`).dialog(this.configEditUserPopup);
        console.log("init edit popup");
    };

    openEditUserPopup(): void {
        var editPopupUrl = $(`#${this.configuration.EditUserPopup}`).data("request-address");
        var selectedRows = $(`#${this.configuration.UsersGridId}`).bootgrid("getSelectedRows");
        
        this.configEditUserPopup.open = () => {
            $(`#${this.configuration.EditUserPopup}`).load(editPopupUrl + "/?p=" + selectedRows);
        }

        if (selectedRows.length > 1) {
            alert("Only one user can be selected to perform EDIT action!");
        } else if (selectedRows.length === 0) {
            alert("You need to select a user to perform EDIT action!");
        } else {
            $(`#${this.configuration.EditUserPopup}`).dialog(this.configEditUserPopup).dialog("open");
        }
    };

    initializeGrid(): void {
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
    };

    removeUsers(): void {
        var removeUsersUrl = $(`#${this.configuration.ButtonRemoveUserId}`).data("request-address");
        var selectedRows = $(`#${this.configuration.UsersGridId}`).bootgrid("getSelectedRows");

        var thisObj = this;
        $.ajax({
            url: removeUsersUrl,
            type: "POST",
            dataType: "text",
            conventType: "application/json; charset=utf-8",
            data: { p: JSON.stringify(selectedRows) },
            complete() {
                $(`#${thisObj.configuration.UsersGridId}`).bootgrid("reload");
            },
            error(error) {
                alert("Failed to remove user!");
            }
        });
    };
}