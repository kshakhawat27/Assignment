
(function ($) {

    $.fn.extend({

        VoucherReq: function (options) {

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

                returnRecord: function (options) {
                    return record;
                },

                returnOptions: function (options) {
                    return options;
                },

                returnfiledList: function (options) {
                    return _filedList;
                },

                sendBudgetItem: function (options) {

                    var flag = 0;
                    var count = 0;
                    var itemSend = 1;
                    var list = new Array();

                    for (var i = 0; i < record.length; i++) {

                        for (var Column in options) {

                            if (Column == "NumberOfSendItem") {

                                itemSend = parseInt(options[Column]);
                            }
                            else
                                list.push(options[Column]);
                        }


                        for (var j = 0; j < _filedList.length; j++) {
                            var text = _filedList[j];
                            if (record[i]["Glcode"] != "" && record[i]["Glcode"] != null) {
                                if (text != "AccountTitle")
                                    list.push(record[i][text]);
                            }
                            else {
                                flag = 1;
                                list = new Array();
                            }

                        }

                        if (flag == 0)
                            count++;

                        flag = 0;

                        if (count == itemSend) {
                            var check = 0;
                            for (var k = 7; k <= 18; k++)
                                if (list[k] != "0.00" && list[k] != "0" && list[k] != "") {
                                    check = 1;
                                    break;
                                }

                            if (check == 1) {
                                $.post(sendUrl + "?list=" + list, function (data) {
                                });
                            }
                            check = 0;
                            count = 0;
                            list = new Array();
                        }
                    }

                    if (count > 0) {
                        //alert(count);
                        $.post(sendUrl + "?list=" + list, function (data) {
                        });


                    }
//                    alert("Information is successfully saved.");
                },


                send: function (options) {

                    var count = 0;
                    var itemSend = 5;
                    //var itemSend = record.length;
                    var list = new Array();

                    for (var i = 0; i < record.length; i++) {

                        for (var Column in options) {

                            if (Column == "NumberOfSendItem") {

                                itemSend = parseInt(options[Column]);
                            }
                            else
                                list.push(options[Column]);
                        }


                        for (var j = 0; j < _filedList.length; j++) {
                            var text = _filedList[j];
                            list.push(record[i][text]);
                        }

                        count++;

                        if (count == itemSend) {
                            $.post(sendUrl + "?list=" + list, function (data) {

                            });

                            count = 0;
                            list = new Array();
                        }
                    }

                    if (count > 0) {
                        //alert(count);
                        $.post(sendUrl + "?list=" + list, function (data) {
                        });


                    }
//                    alert("Information is successfully saved.");
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
                },

                sendSelectedRow: function (options) {
                    var count = 0;
                    var list = new Array();

                    for (var i = 0; i < selectedRecord.length; i++) {

                        for (var Column in options) {

                            list.push(options[Column]);
                        }

                        for (var j = 0; j < _filedList.length; j++) {
                            var text = _filedList[j];
                            list.push(record[selectedRecord[i]][text]);
                        }

                        count++;

                        if (count == 10) {
                            $.post(sendUrl + "?list=" + list, function (data) {

                            });

                            count = 0;
                            list = new Array();
                        }
                    }

                    if (count > 0) {

                        $.post(sendUrl + "?list=" + list, function (data) {
                        });
                    }

//                    alert("Information is successfully saved.");

                },


                addVoucher: function (options) {

                    var count = 1;
                    var list = new Array();
                    var flag = 0;

                    for (var i = 0; i < record.length; i++) {

                        for (var Column in options) {
                            list.push(options[Column]);
                        }


                        for (var j = 0; j < _filedList.length; j++) {
                            var text = _filedList[j];
                            list.push(record[i][text]);
                        }

                        $.ajax({
                            url: tempAddVoucherUrl + "?list=" + list,
                            type: 'post',
                            dataType: 'json',
                            timeout: 2000,
                            async: false,
                            error: function () {
                                flag = 1;
                                alert("An error occured while communicating to the server.");
                            },
                            success: function (data) {

                            }
                        });

                        list = new Array();

                    }
                    if (flag == 0)
                        alert("Data Saved Successfully !!!!!!!");
                },

                saveVoucher: function (options) {
                    var count = 0;
                    var list = new Array();

                    for (var Column in options) {
                        list.push(options[Column]);
                    }
                    $.post(tempSaveVoucherUrl + "?list=" + list, function (data) {

//                        if (data)
//                            alert("Information is successfully saved.");

                    });



                }
            };


            $.fn.VoucherReq = function (method) {

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
                tempAddVoucherUrl = options.action.addVoucherList;
                tempSaveVoucherUrl = options.action.saveVoucherList;
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

                    var temp = _text.split("-");
                    var input = "";

                    if (temp[0] != "ReadOnly") {
                        var id = "";
                        if (_columntype.amountColumn)
                            id = i + "0";

                        else id = "";
                        input = $('<input class="add" id=' + id + ' style="width:' + _columntype.width + '" type="text"' + (_text != 'undefined' ? 'value="' + _text + '"' : '') + ' name="' + _text + '"></input>');

                        input.bind('change', function (event) {
                            record[i][field] = $(this).val();
                            $(this).closest('tr').addClass('editededRow');
                            if (_gettotalColumnList.length > 0 && record.length > 0)
                                getSumatinoOfRowValue();

                            getRowWisSumation();

                        });
                    }

                    else {
                        input = "<td style=border:none;width:" + _columntype.width + "'>" + temp[1] + "</td>";
                    }

                    var x = $('<td></td>').appendTo(_newRow);
                    x.append(input);

                }

                else if (_columntype.type == 'RadioButton') {


                    var newColumn = $('<td></td>').appendTo(_newRow);
                    var index = 0;

                    for (var temp in _columntype.options) {
                        var radioButton = $('<input type="radio" class="input" name="' + _columntype.title + (radioButonIndex) + '" value="' + temp + '">' + _columntype.options[temp] + '</>')
                        if (temp == _text)
                            radioButton.attr('checked', true);

                        radioButton.bind('change', function () {
                            record[i][field] = $(this).val();
                            $(this).closest('tr').addClass('editededRow');
                        });


                        newColumn.append(radioButton);
                    }

                    radioButonIndex++;
                }

                else if (_columntype.type == 'dropdown') {

                    var newColumn = $('<td></td>').addClass("td").appendTo(_newRow);

                    var createDropDownItem = $('<select style="width:' + _columntype.width + ';" id="Edit-' + _columntype.title + '" name=' + _columntype.title + '></select>').appendTo(newColumn);
                    var tempList = dropDownListData[DropDownCount];

                    createDropDownItem.append(tempList);
                    DropDownCount = DropDownCount + 1;
                    $(createDropDownItem).val(_text);

                    createDropDownItem.bind('change', function (event) {
                        record[i][field] = $(this).val();
                        $(this).closest('tr').addClass('editededRow');

                        $.post("/ACC/Voucher/GetAvailavilAmount?ProjectId=" + $(this).val() + "&GlCode=" + record[i]["Glcode"] + "&Rc=" + record[i]["Rc"], function (data) {

                            var id = i + "0";
                            document.getElementById(id).value = data;
                          
                        });
                    });

                }


                //                else if (_columntype.type == 'checkBox') {

                //                    var newColumn = $('<td></td>').appendTo(_newRow);
                //                    var count = 0;
                //                    for (var temp in _columntype.options) {
                //                        var checkBox = $("<input class='" + field.inputClass + "' id=Edit-'" + _columntype.title + "' type='checkbox' name='" + _columntype.title + count + "' value='" + temp + "'>" + _columntype.options[temp] + "</>").appendTo(newColumn);
                //                        if (temp == _text)
                //                            checkBox.attr('checked', true);


                //                        checkBox.bind('change', function (event) {
                //                            for (var temp in _columntype.options) {
                //                                alert($(this).val());
                //                                record[i][field] = $(this).val();
                //                            }
                //                        });
                //                        count++;
                //                    }
                //                }

                else {

                    if (_columntype.rowSumation) {
                        if (_columntype.width == 'undefined')
                            _columntype.width = "80px";
                        var input = $('<input class="total" style="width:' + _columntype.width + '" type="text" ' + (_text != 'undefined' ? 'value="' + _text + '"' : '') + ' name="' + _text + '"></input>');
                        var x = $('<td></td>').appendTo(_newRow);
                        $(input).attr('readonly', true);


                        x.append(input);

                    }
                    else
                        $('<td>' + _text + '</td>').appendTo(_newRow);
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

                    if (options.fields[Column].type == 'dropdown') {
                        getDroupDownList(Column);
                    }
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
                            var isRowOdd = true;
                            for (var i = 0; i < record.length; i++) {
                                var flag = true;
                                DropDownCount = 0;

                                if (isRowOdd) {
                                    var _newRow = $('<tr></tr>').appendTo(_table);
                                    isRowOdd = false;
                                }

                                else {
                                    var _newRow = $('<tr></tr>').appendTo(_table);
                                    isRowOdd = true;
                                }


                                $('#detable tr').mouseover(function () {
                                    var className = $(this).attr('class');
                                    if (className != "editededRow")
                                        $(this).addClass('selectedRow');
                                }).mouseout(function () {
                                    var className = $(this).attr('class');
                                    if (className != "editededRow")
                                        $(this).removeClass('selectedRow');
                                });

                                for (var j = 0; j < _columnList.length; j++) {

                                    if (flag) {

                                        if (options.checkbox) {
                                            var _newRow = $('<tr></tr>').appendTo(_table);
                                            var newColumn = $('<td></td>').appendTo(_newRow);
                                            var checkbox = $("<input id='Edit" + i + "' value='" + i + "' type='checkbox'></>").appendTo(newColumn);

                                            checkbox.bind('change', function (event) {
                                                var check = 0;
                                                var temp = new Array();

                                                for (var i = 0; i < selectedRecord.length; i++) {
                                                    if (selectedRecord[i] != $(this).val())
                                                        temp.push(selectedRecord[i]);
                                                    else {
                                                        check = 1;
                                                    }
                                                }

                                                selectedRecord = temp;
                                                if (check == 0) {
                                                    selectedRecord.push($(this).val());
                                                    selectedRecord.sort();
                                                }

                                            });
                                            flag = false;
                                        }
                                    }

                                    var field = _columnList[j];
                                    var text = record[i][field];
                                    _addrecordIntable(_newRow, text, options.fields[field], i, field);

                                }
                            }

                            if (_gettotalColumnList.length > 0 && record.length > 0)
                                getSumatinoOfRowValue();
                        } else {

                            var _newRow = $('<tr>dsdsd</tr>').appendTo(_table);
                            $('<td="text-aligh:center">No data Found</td>').appendTo(_newRow);
                        }

                    }

                });
            }

            function getRowWisSumation() {

                $("tr").each(function () {
                    var total = 1;
                    var flag = 0;
                    // select all "addup" elements in the current row
                    $(".add", this).each(function () {
                        var temp = "";

                        if (this.value == "0")
                            temp = 1;
                        else {
                            temp = this.value
                            flag = 1;
                        }

                        total = total * temp;
                    });
                    // display the total
                    if (flag == 0)
                        total = "";
                    $(".total", this).val(total);
                });

            }

            function getSumatinoOfRowValue() {

                var check = true; // for add total text



                if (isShowSumRow == true) {
                    $('#detable tr:last').remove();

                }

                var _newRow = $('<tr></tr>').appendTo(_table);

                if (options.checkbox)
                    $('<td></td>').appendTo(_newRow);


                for (var i = 0; i < _columnList.length; i++) {

                    var sum = 0;
                    var field = _columnList[i];
                    var flag = 1;
                    for (var j = 0; j < _gettotalColumnList.length; j++) {
                        if (_columnList[i] == _gettotalColumnList[j]) {
                            flag = 0;
                            break;
                        }
                    }

                    if (flag == 0) {

                        for (var k = 0; k < record.length; k++) {

                            var text = record[k][field];
                            if (text == "" || text == null)
                                text = "0";
                            sum = sum + parseInt(text);
                        }



                        if (check) {
                            $('#detable tr td:last').remove();
                            $('<td style="text-align:center">Total</td>').appendTo(_newRow);
                            check = false;
                        }

                        var td = $('<td>' + sum + '</td>').appendTo(_newRow);
                        isShowSumRow = true;

                    }
                    else {
                        $('<td></td>').appendTo(_newRow);
                        isShowSumRow = true;

                    }

                }
            }
            function getDroupDownList(Column) {

                var temp;
                //alert(dropDownUrl);
                $.ajax({
                    url: options.fields[Column].options,
                    type: 'post',
                    dataType: 'json',
                    timeout: 2000,
                    async: false,
                    error: function () {
                        alert("An error occured while communicating to the server.");
                    },
                    success: function (data) {
                        temp = data;
                    },

                    complete: function () {
                        var items = "";
                        $.each(temp, function (i, temp) {
                            items += "<option value='" + temp.Value + "'>" + temp.Text + "</option>";
                        });
                        dropDownListData.push(items);

                    }
                });
            }


        }
    });
})(jQuery);

