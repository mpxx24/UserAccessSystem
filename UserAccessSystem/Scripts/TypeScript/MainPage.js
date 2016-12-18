var MainPage = (function () {
    function MainPage(configuration) {
        this.configuration = configuration;
        this.initializeGrid();
        this.initializeView();
        this.initlializeControls();
    }
    MainPage.prototype.initializeView = function () {
        this.initializeAddUserPopup();
        this.initializeEditUserPopup();
    };
    ;
    MainPage.prototype.initlializeControls = function () {
        var thisObj = this;
        $("#" + thisObj.configuration.ButtonAddUserId).click(function () { thisObj.openAddUserPopup(); });
        $("#" + thisObj.configuration.ButtonEditUserId).click(function () { thisObj.openEditUserPopup(); });
        $("#" + thisObj.configuration.ButtonRemoveUserId).click(function () { thisObj.removeUsers(); });
    };
    ;
    MainPage.prototype.initializeAddUserPopup = function () {
        var addPopupUrl = $("#" + this.configuration.AddUserPopup).data("request-address");
        this.configAddUserPopup = {
            autoOpen: false,
            position: { my: "top+150px", at: "top", of: window },
            resizable: false,
            title: "Add User",
            modal: true,
            open: function () {
                $(this).load(addPopupUrl);
            }
        };
        $("#" + this.configuration.AddUserPopup).dialog(this.configAddUserPopup);
    };
    ;
    MainPage.prototype.openAddUserPopup = function () {
        $("#" + this.configuration.AddUserPopup).dialog(this.configAddUserPopup).dialog("open");
    };
    ;
    MainPage.prototype.initializeEditUserPopup = function () {
        this.configEditUserPopup = {
            autoOpen: false,
            position: { my: "top+150px", at: "top", of: window },
            resizable: false,
            title: "Update User",
            modal: true
        };
        $("#" + this.configuration.EditUserPopup).dialog(this.configEditUserPopup);
        console.log("init edit popup");
    };
    ;
    MainPage.prototype.openEditUserPopup = function () {
        var _this = this;
        var editPopupUrl = $("#" + this.configuration.EditUserPopup).data("request-address");
        var selectedRows = $("#" + this.configuration.UsersGridId).bootgrid("getSelectedRows");
        this.configEditUserPopup.open = function () {
            $("#" + _this.configuration.EditUserPopup).load(editPopupUrl + "/?p=" + selectedRows);
        };
        if (selectedRows.length > 1) {
            alert("Only one user can be selected to perform EDIT action!");
        }
        else if (selectedRows.length === 0) {
            alert("You need to select a user to perform EDIT action!");
        }
        else {
            $("#" + this.configuration.EditUserPopup).dialog(this.configEditUserPopup).dialog("open");
        }
    };
    ;
    MainPage.prototype.initializeGrid = function () {
        $("#" + this.configuration.UsersGridId).bootgrid({
            ajax: true,
            post: function () {
                return {
                    id: "x8gt2424-1ht7-4jh5-8123-78duqklqugej"
                };
            },
            url: "User/GetAllUsers",
            selection: true,
            multiSelect: true,
            rowSelect: false,
            keepSelection: true,
            templates: {
                search: ""
            },
            navigation: 0
        }).on("selected.rs.jquery.bootgrid", function (e, rows) {
            //var rowIds = [];
            //for (var i = 0; i < rows.length; i++) {
            //    rowIds.push(rows[i].Id);
            //}
        });
    };
    ;
    MainPage.prototype.removeUsers = function () {
        var removeUsersUrl = $("#" + this.configuration.ButtonRemoveUserId).data("request-address");
        var selectedRows = $("#" + this.configuration.UsersGridId).bootgrid("getSelectedRows");
        var thisObj = this;
        $.ajax({
            url: removeUsersUrl,
            type: "POST",
            dataType: "text",
            conventType: "application/json; charset=utf-8",
            data: { p: JSON.stringify(selectedRows) },
            complete: function () {
                $("#" + thisObj.configuration.UsersGridId).bootgrid("reload");
            },
            error: function (error) {
                alert("Failed to remove user!");
            }
        });
    };
    ;
    return MainPage;
}());
//# sourceMappingURL=MainPage.js.map