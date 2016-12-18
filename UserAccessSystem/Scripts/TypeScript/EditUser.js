"use strict";
var EditUser = (function () {
    function EditUser(configuration) {
        this.configuration = configuration;
        this.initializeView();
        this.initializeControls();
    }
    EditUser.prototype.initializeView = function () {
    };
    ;
    EditUser.prototype.initializeControls = function () {
        var thisObj = this;
        ControlsHelper.CreateDatePicker(thisObj.configuration.LastSubscriptionDatePickerId);
        $("#" + thisObj.configuration.ButtonSaveEditedUserIs).click(function () { thisObj.updateUser(); });
    };
    ;
    EditUser.prototype.updateUser = function () {
        var thisObj = this;
        var saveEditedUserUrl = $("#" + thisObj.configuration.ButtonSaveEditedUserIs).data("request-address");
        var input = {
            Id: thisObj.configuration.Model_Id,
            FirstName: $("#" + thisObj.configuration.FirstNameTextBoxId).val(),
            LastName: $("#" + thisObj.configuration.LastNameTextBoxId).val(),
            LastSubscription: $("#" + thisObj.configuration.LastSubscriptionDatePickerId).val()
        };
        $.ajax({
            url: saveEditedUserUrl,
            type: "POST",
            dataType: "text",
            conventType: "application/json; charset=utf-8",
            data: { p: JSON.stringify(input) },
            complete: function () {
                $("#" + thisObj.configuration.PopupEditUserId).dialog().dialog("close");
                //$(`#${thisObj.configuration.UserGridId}`).bootgrid("reload");
            },
            error: function (error) {
                alert("Failed to edit user!");
            }
        });
    };
    ;
    return EditUser;
}());
//# sourceMappingURL=EditUser.js.map