declare var $: any;
declare var ControlsHelper: any;

interface IEditUserConfiguration {
    ButtonSaveEditedUserIs: string,
    FirstNameTextBoxId: string;
    LastNameTextBoxId: string;
    LastSubscriptionDatePickerId: string;
    PopupEditUserId: string;
    UserGridId: string;
    Model_Id: string;
}

class EditUser {
    configuration: IEditUserConfiguration;
    configAddUserPopup: any;
    configEditUserPopup: any;

    constructor(configuration: IEditUserConfiguration) {
        this.configuration = configuration;
        this.initializeView();
        this.initlializeControls();
    }

    initializeView(): void {
    };

    initlializeControls(): void {
        var thisObj = this;

        ControlsHelper.CreateDatePicker(thisObj.configuration.LastSubscriptionDatePickerId);
        $(`#${thisObj.configuration.ButtonSaveEditedUserIs}`).click(() => { thisObj.updateUser() });
    };

    updateUser(): void {
        var thisObj = this;
        var saveEditedUserUrl = $(`#${thisObj.configuration.ButtonSaveEditedUserIs}`).data("request-address");

        var input = {
            Id: thisObj.configuration.Model_Id,
            FirstName: $(`#${thisObj.configuration.FirstNameTextBoxId}`).val(),
            LastName: $(`#${thisObj.configuration.LastNameTextBoxId}`).val(),
            LastSubscription: $(`#${thisObj.configuration.LastSubscriptionDatePickerId}`).val()
        }

        $.ajax({
            url: saveEditedUserUrl,
            type: "POST",
            dataType: "text",
            conventType: "application/json; charset=utf-8",
            data: { p: JSON.stringify(input) },
            complete() {
                $(`#${thisObj.configuration.PopupEditUserId}`).dialog().dialog("close");
                //$(`#${thisObj.configuration.UserGridId}`).bootgrid("reload");
            },
            error(error) {
                alert("Failed to edit user!");
            }
        });
    };
}