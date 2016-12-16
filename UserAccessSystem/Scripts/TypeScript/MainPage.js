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
    };
    MainPage.prototype.openEditUserPopup = function () {
    };
    MainPage.prototype.initializeGrid = function () {
        $("#" + this.configuration.UsersGridId).bootgrid({
            ajax: true,
            post: function () {
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
        }).on("selected.rs.jquery.bootgrid", function (e, rows) {
            //var rowIds = [];
            //for (var i = 0; i < rows.length; i++) {
            //    rowIds.push(rows[i].Id);
            //}
        });
    };
    return MainPage;
}());
//# sourceMappingURL=MainPage.js.map