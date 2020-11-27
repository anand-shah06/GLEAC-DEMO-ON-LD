//
var ComputeLevenDist = {
    getDebug: function () {
        var sDebug = true;
        return sDebug;
    },
    logConsole: function (msg) {
        if (ComputeLevenDist.getDebug()) console.log(msg);
    },    
    //
    init: function () {
        ComputeLevenDist.logConsole("ComputeLevenDist init start");
        //
        $('#btnComputeDistance').click(function (e) {
            ComputeLevenDist.logConsole("Compute button start...");
            var doFormSubmit = false;
            //
            doFormSubmit = true;
            if (doFormSubmit) {                
                $("#btnSubmit").click();
            }
            ComputeLevenDist.logConsole("Compute button end...");
        });
        //
        $('#btnRefresh').click(function (e) {
            ComputeLevenDist.logConsole("Refresh button start...");
            $("#FirstString").val("");
            $("#SecondString").val("");
            $("#ResultTable_Cost").val("");
            $('#resultTable tbody').html("");
            $("#btnComputeDistance").attr("disabled", false);
            ComputeLevenDist.logConsole("Refresh button end...");
        });
        //
        $('#hylGetJwtToken').click(function (e) {
            ComputeLevenDist.logConsole("Start button start...");
            $("#hylGetJwtToken").attr("disabled", true);
            ComputeLevenDist.logConsole("Start button end...");
        });        
        //
        $('form').submit(function () {
            if ($(this).valid()) {
                $("#btnComputeDistance").attr("disabled", true);
                ComputeLevenDist.logConsole("Form submitted...");
            }
            else {
                ComputeLevenDist.logConsole("Form not submitted-Error...");
            }
        });
        //      
        ComputeLevenDist.logConsole("ComputeLevenDist init end");
    },
    //    
 }