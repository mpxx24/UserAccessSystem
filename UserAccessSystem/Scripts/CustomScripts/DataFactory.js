var DataFactory = function() {
};

DataFactory.GetWebApiResponseInTextArea = function(parameters) {
    var taDiv = $("#webApiTextAreaTestResult");
    taDiv.remove();
    $.ajax({
        url: parameters.Address,
        type: "GET",
        dataType: "json",
        success: function(data) {
            var result = JSON.stringify(data);
            var testDiv = $("#ApiTests_ApiResponse");
            var textArea = "<textarea disabled id=\"webApiTextAreaTestResult\" contenteditable=\"true\"> " + result + "</textarea>";
            testDiv.append(textArea);
        },
        error: function(error) {
            alert("Failed to perform API request");
            console.log(error);
        }
    });
};