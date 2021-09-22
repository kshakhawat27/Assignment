function BindddlWithControlID(data, ControlID, SelectedText, SelectedValue) {
    $("#" + ControlID).empty();

    if (SelectedText !== "") {
        $("#" + ControlID).append($("<option></option>").val("-1").html(SelectedText));
    }

    $.each(data, function (i, item) {
        $("#" + ControlID).append($("<option></option>").val(item.Code).html(item.Value));
    });

    if (SelectedValue !== "") {
        $("#" + ControlID).val(SelectedValue);
    }
}
function BindddlWithControlClassName(data, ControlID, SelectedText, SelectedValue) {
    $("." + ControlID).empty();

    if (SelectedText !== "") {
        $("." + ControlID).append($("<option></option>").val("-1").html(SelectedText));
    }

    $.each(data, function (i, item) {
        $("." + ControlID).append($("<option></option>").val(item.Code).html(item.Value));
    });

    if (SelectedValue !== "") {
        $("." + ControlID).val(SelectedValue);
    }
}
function BindSelectPickerWithControlID(data, ControlID, SelectedText, SelectedValue) {
    $("#" + ControlID).empty();

    if (SelectedText !== "") {
        $("#" + ControlID).append($("<option></option>").val("-1").html(SelectedText));
    }

    $.each(data, function (i, item) {
        $("#" + ControlID).append($("<option></option>").val(item.Code).html(item.Value));
    });

    if (SelectedValue !== "") {
        $("#" + ControlID).val(SelectedValue);
    }

    $("#" + ControlID).selectpicker('render');
    $("#" + ControlID).selectpicker('refresh');
}
function BindSelectPickerWithControlClassName(data, ControlID, SelectedText, SelectedValue) {
    $("." + ControlID).empty();

    if (SelectedText !== "") {
        $("." + ControlID).append($("<option></option>").val("-1").html(SelectedText));
    }

    $.each(data, function (i, item) {
        $("." + ControlID).append($("<option></option>").val(item.Code).html(item.Value));
    });

    if (SelectedValue !== "") {
        $("." + ControlID).val(SelectedValue);
    }

    $("." + ControlID).selectpicker('render');
    $("." + ControlID).selectpicker('refresh');
}

function SaveUpdateDataUsingInline(TableName, QryOption, ColumnNames, ColumnValues, PrimaryColumnName, PrimaryColumnValue) {
    var _dbModel = { "TableName": TableName, "QryOption": QryOption, "ColumnNames": ColumnNames, "ColumnValues": ColumnValues, "PrimaryColumnName": PrimaryColumnName, "PrimaryColumnValue": PrimaryColumnValue };
    $.ajax({
        type: "POST",
        url: baseURL + "/Common/SaveUpdateDataUsingInline",
        data: JSON.stringify(_dbModel),
        contentType: "application/json",
        datatype: "json",
        success: function (data) {
            if (data.success === true) {
                LoadGridData();
                alert("Data Save Successfully..");
            }
            else {
                alert("Data Save Failed..");
            }
        }
    });
}

var isDateField = [];
function LoadAllValue(ParameterNames, ParameterValues, SPName, QryOption, GridID, ColumnNames, DatabaseTableName, PrimaryColumnNane) {
    var _dbModel = { "ParameterNames": ParameterNames, "ParameterValues": ParameterValues, "SPName": SPName, "QryOption": QryOption };
    $.ajax({
        type: "POST",
        url: baseURL + "/Common/LoadDataUsingSP",
        data: JSON.stringify(_dbModel),
        contentType: "application/json",
        datatype: "json",
        asyn: false,
        success: function (result) {
            generateKendoGrid($.parseJSON(result), DatabaseTableName, PrimaryColumnNane, ColumnNames, GridID);
        }
    });
}

function generateKendoGrid(response, DBName, PCName, ColumnNames, GridID) {
    var columns = generateColumns(response, DBName, PCName, ColumnNames);
    $("#" + GridID).kendoGrid().empty();
    var grid = $("#" + GridID).kendoGrid({
        dataSource: {
            transport: {
                read: function (options) {
                    options.success(response);
                }
            },
            pageSize: 5,
        },
        columns: columns,
        filterable: true,
        sortable: true,
        pageable: true,
        editable: false
    });
}

function generateColumns(response, DBName, PCName, ColumnNames) {
    return ColumnNames.map(function (name) {
        if (name === "Edit") {
            return {
                field: name, width: "130px", filterable: false, attributes: { class: "text-center" }, headerAttributes: { style: "text-align:center" },
                template: "<a href='javascript:void(0)' class='k-button k-button-icontext k-grid-edit' onclick=EditGridDate('#=AreaID#','" + DBName + "','" + PCName + "')><i class='k-icon k-i-edit'></i>Edit</a>"
            };
        }
        else if (name === "Delete") {
            return {
                field: name, width: "130px", filterable: false, attributes: { class: "text-center" }, headerAttributes: { style: "text-align:center" },
                template: "<a href='javascript:void(0)' class='k-button k-button-icontext k-grid-delete' onclick=DeleteGridDate('#=AreaID#','" + DBName + "','" + PCName + "')><i class='k-icon k-i-close'></i>Delete</a>"
            };
        }
        else {
            return { field: name };
        }
    });
}

function DeleteGridDate(PrimaryColumnValue, DBName, PrimaryColumnName) {
    var answer = confirm("Are You Sure to Delete the Selected Item..?")
    if (answer == true) {
        var _dbModel = { 'PrimaryColumnValue': PrimaryColumnValue, 'DBName': DBName, 'PrimaryColumnName': PrimaryColumnName };
        $.ajax({
            type: "POST",
            url: baseURL + "/Common/DeleteDataUsingInline",
            data: JSON.stringify(_dbModel),
            contentType: "application/json",
            datatype: "json",
            success: function (data) {
                if (data.success === true) {
                    LoadGridData();
                    $.notify("Data Deleted Successfully..!", "success");
                }
                else {
                    $.notify("Data Deleted Failed..!", "error");
                }
            }
        });
    }
}

function BindddlWithParameter(ddlName, ControllerName, MethodsName, SpName, QryOption, SelectedValue, Param1, SelectedText) {
    var _dbModel = { 'SpName': SpName, 'QryOption': QryOption, 'Param1': Param1 };
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: baseURL + "/" + ControllerName + "/" + MethodsName,
        data: JSON.stringify(_dbModel),
        async: false,
        dataType: 'json',
        success: function (data) {
            $("#" + ddlName).empty();

            if (SelectedText !== "") {
                $("#" + ddlName).append($("<option ></option>").val("-1").html(SelectedText));
            }
            $.each(data, function (i, item) {
                $("#" + ddlName).append($("<option ></option>").val(item.Code).html(item.Value));
            });
        }
    });

    if (SelectedValue !== "")
        $("#" + ddlName).val(SelectedValue);

    $("#" + ddlName).selectpicker('refresh');
}

function ClearFormValue() {
    $(".txt").val("");
}

//$(document).ready(function() {
////https://jsfiddle.net/q33hg0ar/90/
//  $('#form').find('input, select, textarea').each(function() {
//    alert($(this).attr('name'));
//  });
//});