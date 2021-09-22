
(function ($) {

    $.fn.extend({

        TEShedule: function (options) {

            var _container = null;
            var _tableDiv = null;
            var _table = null;
            var record = null;
            var creatUrl = "";
            var sendUrl = "";
            var tempAddVoucherUrl = "";
            var tempSaveVoucherUrl = "";
            var isShowSumRow = false;

            var dropDownListData = new Array();
            var DropDownCount = 0;
            var radioButonIndex = 0;
            var totalAmmountAlreadyShow = false;
            var _filedList = [];
            var _columnList = [];
            var _gettotalColumnList = [];
            var checkbox = false;
            var selectedRecord = new Array();
            var isCheckboxAllSelected = true;

            var tableOption = {

                action: {
                    createList: '',
                    sendList: '',
                    addVoucherList: '',
                    saveVoucherList: ''
                },

                fields: {}

            };

            var methods = {


                send: function (options) {

                    var id = "";
                    var flag = true;
                    var list = new Array();

                    for (var Column in options) {

                        list.push(options[Column]);
                    }



                    $.post("/PRG/Reports/SaveScheduleMasterEntry?list=" + list, function (data) {

                        id = data;
                        list = new Array();


                        for (var i = 0; i < record.length; i++) {

                            list = new Array();
                            temp = "";

                            for (var j = 0; j < _filedList.length; j++) {

                                var text = _filedList[j];

                                if (text == "InstUnit" || text == "Period") {
                                    list.push(record[i][text]);
                                }

                                else {

                                    if (record[i][text] == true)
                                        temp = temp + "1";
                                    else
                                        temp = temp + "0";
                                }

                            }

                            list.push(temp);
                            list.push(id);

                            if (id != "") {
                                $.post("/PRG/Reports/SaveScheduleDetailsEntry?list=" + list, function (data1) {
                                });
                            }

                            else {
                                flag = false;
                                break;
                            }
                        }

                    });






                    if (flag)
                        alert("Information is successfully saved.");
                    else {
                        alert("Information failed to save.");
                    }
                },





                sendTableItem: function (options) {

                    var list = new Array();


                    for (var i = 0; i < record.length; i++) {

                        list = new Array();
                        temp = "";

                        for (var j = 0; j < _filedList.length; j++) {

                            var text = _filedList[j];

                            if (text == "InstUnit" || text == "Period") {
                                list.push(record[i][text]);
                            }

                            else {

                                if (record[i][text] == true)
                                    temp = temp + "1";

                                else
                                    temp = temp + "0";
                            }

                        }

                        list.push(temp);


                        $.ajax({
                            url: "/PRG/Reports/RestoreSessionData?temp=" + list,
                            type: 'post',
                            dataType: 'json',
                            timeout: 2000,
                            async: false,

                            error: function () {
                                alert("An error occured while communicating to the server.");
                            },
                            success: function (data) {

                            }
                        });
                    }



                    $.post("/PRG/Reports/AddNewRow", function (data) {
                    });

                    record = null;
                },


                load: function (options) {


                    isShowSumRow = false;
                    DropDownCount = 0;
                    $('#detable tr').slice(1).remove();
                    var flag = 0;
                    DropDownCount = 0;
                    var tempUrl = '';
                    tempUrl = creatUrl;
                    for (var Column in options) {
                        if (flag == 0) {
                            tempUrl = tempUrl + "?";
                            flag = 1;
                        }
                        else
                            tempUrl = tempUrl + "&";
                        tempUrl = tempUrl + Column + "=" + options[Column];

                      

                    }
                    _getTableData(tempUrl);
                }
            };


            $.fn.TEShedule = function (method) {

                if (methods[method]) {
                    return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
                } else if (typeof method === 'object' || !method) {
                    return methods.init.apply(this, arguments);
                } else {
                    $.error('Method ' + method + ' does not exist on jQuery.tooltip');
                }

            };


            var options = $.extend(tableOption, options);

            this.each(function () {
                _tableDiv = this;
                _createContainer(this);
                _createTable();
                creatUrl = options.action.createList;
                sendUrl = options.action.sendList;




            });

            // Create Table Container
            function _createContainer() {

                _container = $('<div></div>').appendTo(_tableDiv);
            }

            // Create Table
            function _createTable() {
                _GetTableColumn();
                _table = $('<table id="detable"></table>').appendTo(_container);
                //                $('<caption style="background-image:url(../Content/themes/dTableCA.png);color:#147BB6;padding:0px;margin:0px;font-weight:bold;">Sample Dynameic Table</caption>').appendTo(_table);
                _createTableHead();

            }


            /* Creates header (all column headers) of the table.
            *************************************************************************/
            function _createTableHead() {

                var _thead = $('<thead></thead>').appendTo(_table);
                _addRowToTableHead(_thead);
            }

            /* Adds tr element to given thead element
            *************************************************************************/

            function _addRowToTableHead(_thead) {
                var _tr = $('<tr></tr>').appendTo(_thead);
                _addColumnsToHeaderRow(_tr);

            }


            function _addColumnsToHeaderRow(_tr) {


                if (options.checkbox) {

                    var checkBoxAll = $('<input id="all" value="all" type="checkbox">');
                    var isCheckboxAllSelected = true;

                    checkBoxAll.bind('change', function (event) {
                        if (isCheckboxAllSelected) {
                            $('table#detable input[type=checkbox]').attr('checked', true);
                            isCheckboxAllSelected = false;

                            for (var i = 0; i < record.length; i++)
                                selectedRecord.push(i);
                        }
                        else {

                            $('table#detable input[type=checkbox]').attr('checked', false);
                            isCheckboxAllSelected = true;
                            selectedRecord = new Array();
                        }
                    });

                    $('<th style="width:5px"></th>').append(checkBoxAll).appendTo(_tr);
                }

                for (var i = 0; i < _columnList.length; i++) {

                    var _fieldName = _columnList[i];
                    var _headerCell = _createHeaderCellForField(_fieldName, options.fields[_fieldName]);
                    _headerCell.data('fieldName', _fieldName).appendTo(_tr);
                }
            }

            function _createHeaderCellForField(fieldName, field) {
                field.width = field.width || '10px';
                return $('<th style="width:' + field.width + '">' +
                '<div><span>' + field.title +
                '</span></div></th>')
                .data('fieldName', fieldName)
            }



            function _createEmptyCommandHeader(_thead) {

                $('<tr><th style="text-aligh:center">No data Found</th></tr>').appendTo(_thead);
            }


            function _addrecordIntable(_newRow, _text, _columntype, i, field) {

                if (_columntype.type == 'textbox') {
                    if (_columntype.width == 'undefined')
                        _columntype.width = "10px";
                    var input = "";
                    input = $('<input style="width:' + _columntype.width + '" type="text"' + (_text != 'undefined' ? 'value="' + _text + '"' : '') + ' name="' + _text + '"></input>');

                    input.bind('change', function (event) {
                        record[i][field] = $(this).val();
                    });

                    var x = $('<td></td>').appendTo(_newRow);
                    x.append(input);


                }


                else {
                    var newColumn = $('<td></td>').appendTo(_newRow);
                    var checkBox = $("<input value='" + _text + "' type='checkbox'/>").appendTo(newColumn);

                    if (_text)
                        checkBox.attr('checked', true);


                    checkBox.bind('change', function (event) {
                        if (this.checked) {

                            record[i][field] = true;
                        }

                        else {
                            record[i][field] = false;
                        }

                    });

                }

            }


            function _GetTableColumn() {


                var flag = 0;
                for (var Column in options.fields) {

                    _filedList.push(Column);

                    if (options.fields[Column].visibility == true)
                        _columnList.push(Column);

                    if (options.fields[Column].getTotal == true && options.fields[Column].visibility == true)
                        _gettotalColumnList.push(Column);


                }
            }


            function _getTableData(url) {
               
                $.ajax({
                    url: url,
                    type: 'post',
                    dataType: 'json',
                    timeout: 2000,
                    async: false,

                    error: function () {
                        alert("An error occured while communicating to the server.");
                    },
                    success: function (data) {
                        record = data;

                        if (data != null) {


                            for (var i = 0; i < record.length; i++) {

                                var _newRow = $('<tr></tr>').appendTo(_table);

                                for (var j = 0; j < _columnList.length; j++) {

                                    var field = _columnList[j];
                                    var text = record[i][field];
                                    _addrecordIntable(_newRow, text, options.fields[field], i, field);

                                }
                            }


                        } else {


                            $('<td="text-aligh:center">No data Found</td>').appendTo(_newRow);
                        }

                    }

                });
            }






        }
    });
})(jQuery);

