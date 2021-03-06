$(function () {
    ClearForm();
    $(document).delegate('#btnSave', 'click', function (e) {
        e.preventDefault();
        SaveFormValue();
    });
    $(document).delegate('#btnAddNew', 'click', function (e) {
        e.preventDefault();
        ClearForm();
        $("#modalCG01").modal("toggle");
    });
    $(document).delegate('#btnClear', 'click', function (e) {
        e.preventDefault();
        ClearForm();
    });
    LoadGridData();

    LoadCG01DDLMasterData();
});
   
  
function LoadCG01DDLMasterData() {
    $.ajax({
        type: "GET",
        url: "/CG01/LoadCG01DDLMasterData",
        data: {},
        contentType: "application/json",
        datatype: "json",
        success: function (data) {

            BindddlWithControlID(data, "ddlCountry", "Select", "");
        }
    });
}
function LoadGridData() {
    $.ajax({
        type: "GET",
        url: "/CG01/LoadAllCG01",
        data: {},
        contentType: "application/json",
        datatype: "json",
        success: function (data) {
            BindGridData(data);
        }
    });
}
function BindGridData(data) {
    $("#tblCG01").kendoGrid().empty();
    $("#tblCG01").kendoGrid({
        dataSource: {
            data: data,
            dataType: "json",
        },
        toolbar: "<a id='btnAddNew' role='button' class='k-button k-button-icontext k-grid-add' href='javascript:void(0)'><span class='k-icon k-i-plus'></span>Add New Record</a>"+
            "<a  role='button' style='float:right;' class='k-button k-button-icontext k-grid-add' href='javascript:void(0)' onclick='LoadPdf()'><span class='k-icon k-i-plus'></span>PDF</a>" +
            "<a  role='button' style='float:right;' class='k-button k-button-icontext k-grid-add' href='javascript:void(0)' onclick='LoadExcel()'><span class='k-icon k-i-plus'></span>Excel</a>",
        columns: [
            { field: "InfoID", title: "InfoID", filterable: false },
            { field: "InfoName", title: "InfoName", filterable: true },
            { field: "InfoWeb", title: "InfoWeb", filterable: false },
            { field: "Infomail", title: "Infomail", filterable: false },
            { field: "Country", title: "Country", filterable: false },
            {
                template: '<a role="button" class="k-button k-button-icontext k-grid-edit" href="javascript:void(0)" onclick=LoadEditData(#=InfoID#)><span class="k-icon k-i-edit"></span>Edit</a>' +
                    '<a role="button" class="k-button k-button-icontext k-grid-delete" href="javascript:void(0)" onclick=DeleteGridData(#=InfoID#)><span class="k-icon k-i-close"></span>Delete</a>',
                field: "InfoID",
                title: "Action",
                width: 170,
                headerAttributes: { style: "text-align: center" },
                attributes: { class: "text-center" },
                filterable: false
            },
        ],
        sortable: true,
        filterable: {
            extra: false, //do not show extra filters
            operators: { // redefine the string operators
                string: {
                    contains: "Contains",
                    startswith: "Starts With",
                    eq: "Is Equal To"
                }
            }
        },
        resizable: true,
        //height: 150,
        pageable: false,
        scrollable: true,
        detailTemplate: kendo.template($("#template").html()),
        detailInit: detailInit
    });
}
function detailInit(e) {
    var detailRow = e.detailRow;

    detailRow.find(".tabstrip").kendoTabStrip({
        animation: {
            open: { effects: "fadeIn" }
        }
    });
}
function LoadPdf() {
    window.location.href = "/Report/Info?reportTypes=pdf";
}
function LoadExcel() {
    window.location.href =  "/Report/Info?reportTypes=EXCELOPENXML";
}
function SaveFormValue() {
    var _isError = 0;
    var InfoID = $("#hdInfoID").val();
    var Country = $("#ddlCountry").val();
    var InfoName = $("#txtInfoName").val();
    var InfoWeb = $("#txtInfoWeb").val();
    var Infomail = $("#txtInfomail").val();
    if (_isError == 1) {
        return false;
    }
    var _dbModel = { 'InfoID': InfoID, 'InfoName': InfoName, 'InfoWeb': InfoWeb, 'Infomail': Infomail, 'Country': Country };
    $.ajax({
        type: "POST",
        url: "/CG01/SaveCG01",
        data: JSON.stringify(_dbModel),
        contentType: "application/json",
        datatype: "json",
        success: function (data) {
            if (data.success == true) {
                LoadGridData();
                $("#modalCG01").modal("toggle");
                $.notify("Data Save Successfully..", "success");
            }
            else {
                $.notify("Data Save Failed..", "error");
            }
            ClearForm();
        }
    });
}
function LoadEditData(InfoID) {
    var _dbModel = { 'InfoID': InfoID };
    $.ajax({
        type: "POST",
        url: "/CG01/LoadSelectedCG01",
        data: JSON.stringify(_dbModel),
        contentType: "application/json",
        datatype: "json",
        success: function (data) {
            $.each(data, function (i, item) {
                $("#hdInfoID").val(item.InfoID);
                $("#ddlCountry").val(item.Country);
                $("#txtInfoName").val(item.InfoName);
                $("#txtInfoWeb").val(item.InfoWeb);
                $("#txtInfomail").val(item.Infomail);
            });
            $("#modalCG01").modal("toggle");
        }
    });
}

    function DeleteGridData(InfoID) {
        var ans = confirm("Are you sure to delete a record");
        if (ans == true) {
            var _dbModel = { 'InfoID': InfoID };
            $.ajax({
                type: "POST",
                url: "/CG01/DeleteCG01",
                data: JSON.stringify(_dbModel),
                contentType: "application/json",
                datatype: "json",
                success: function (data) {
                    if (data.success == true) {
                        LoadGridData();
                        $.notify("Data Deleted Successfully..", "success");
                    }
                    else {
                        $.notify("Data Deleted Failed..!", "error");
                    }
                }
            });
        }
    }
    function ClearForm() {
        $("#hdValue").val("");
        $(".txt").val("");
    }
