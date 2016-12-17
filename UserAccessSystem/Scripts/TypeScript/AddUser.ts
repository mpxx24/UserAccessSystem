declare var $: any;
declare var ControlsHelper: any;

interface IAddUserConfiguration {
    ButtonAddUserId: string;
    FirstNameTextBoxId: string;
    LastNameTextBoxId: string;
    DateOfBirthDatePickerId: string;
    LastSubscriptionDatePickerId: string;
    PopupAddUserId: string;
    UserGridId: string;
}

class AddUser {
    configuration: IAddUserConfiguration;

    constructor(configuration: IAddUserConfiguration) {
        this.configuration = configuration;
        this.initializeView();
        this.initlializeControls();
    }

    initializeView(): void {
    };

    initlializeControls(): void {
        var thisObj = this;

        ControlsHelper.CreateDatePicker(thisObj.configuration.DateOfBirthDatePickerId);
        ControlsHelper.CreateDatePicker(thisObj.configuration.LastSubscriptionDatePickerId);
        $(`#${thisObj.configuration.ButtonAddUserId}`).click(() => { thisObj.saveUser() });
    };

    saveUser(): void {
        var thisObj = this;
        var addUserUrl = $(`#${thisObj.configuration.ButtonAddUserId}`).data("request-address");

        var input = {
            FirstName: $(`#${thisObj.configuration.FirstNameTextBoxId}`).val(),
            LastName: $(`#${thisObj.configuration.LastNameTextBoxId}`).val(),
            DateOfBirth: $(`#${thisObj.configuration.DateOfBirthDatePickerId}`).val(),
            LastSubscription: $(`#${thisObj.configuration.LastSubscriptionDatePickerId}`).val()
        }

        $.ajax({
            url: addUserUrl,
            type: "POST",
            dataType: "text",
            conventType: "application/json; charset=utf-8",
            data: { p: JSON.stringify(input) },
            complete() {
                $(`#${thisObj.configuration.PopupAddUserId}`).dialog().dialog("close");
                $(`#${thisObj.configuration.UserGridId}`).bootgrid("reload");
            },
            error(error) {
                alert("Failed to add user!");
            }
        });

    };
}