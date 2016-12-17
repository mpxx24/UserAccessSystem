var AddUser = (function () {
    function AddUser(configuration) {
        this.configuration = configuration;
        this.initializeView();
        this.initlializeControls();
    }
    AddUser.prototype.initializeView = function () {
    };
    ;
    AddUser.prototype.initlializeControls = function () {
        var thisObj = this;
        ControlsHelper.CreateDatePicker(thisObj.configuration.DateOfBirthDatePickerId);
        ControlsHelper.CreateDatePicker(thisObj.configuration.LastSubscriptionDatePickerId);
        $("#" + thisObj.configuration.ButtonAddUserId).click(function () { thisObj.saveUser(); });
    };
    ;
    AddUser.prototype.saveUser = function () {
        var thisObj = this;
        var addUserUrl = $("#" + thisObj.configuration.ButtonAddUserId).data("request-address");
        var input = {
            FirstName: $("#" + thisObj.configuration.FirstNameTextBoxId).val(),
            LastName: $("#" + thisObj.configuration.LastNameTextBoxId).val(),
            DateOfBirth: $("#" + thisObj.configuration.DateOfBirthDatePickerId).val(),
            LastSubscription: $("#" + thisObj.configuration.LastSubscriptionDatePickerId).val()
        };
        $.ajax({
            url: addUserUrl,
            type: "POST",
            dataType: "text",
            conventType: "application/json; charset=utf-8",
            data: { p: JSON.stringify(input) },
            complete: function () {
                $("#" + thisObj.configuration.PopupAddUserId).dialog().dialog("close");
                $("#" + thisObj.configuration.UserGridId).bootgrid("reload");
            },
            error: function (error) {
                alert("Failed to add user!");
            }
        });
    };
    ;
    return AddUser;
}());
//# sourceMappingURL=AddUser.js.map