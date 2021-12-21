
$(document).ready(function () {
    $('#btnPreview').on('click', function () {
        ReportManager.LoadReport();
    });
});

var ReportManager = {
    LoadReport: function () {
        var jsonParam = "";
        var serviceUrl = '/Person/LoadReportData';
        ReportManager.GetReport(serviceUrl, jsonParam, onFailed);
        function onFailed(error) {
            alert("not report found");
        }
    },
    GetReport: function (serviceUrl, jsonParam, errorCallBack) {
        $.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + jsonParam + "}",
            contentType: "application/json, charset=utf-8",
            success: function () {
                window.open('../Reports/ReportViewer.aspx', '_newtab');
            },
            error: errorCallBack
        });
    }
}