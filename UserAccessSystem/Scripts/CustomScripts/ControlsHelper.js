var ControlsHelper = function() {
}

ControlsHelper.CreateDatePicker = function(controlId) {
    $("#" + controlId).datepicker({
        dateFormat: 'dd/mm/yy'
    }).datepicker("setDate", new Date);
};