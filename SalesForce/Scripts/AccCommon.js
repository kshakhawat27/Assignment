/////*Common*/
////function showPopup(containerId, coverBackground) {
////    $('.popup').css("display", "none");
////    $('#' + containerId).css("display", "block");
////    $('#' + containerId).center();


////    if ($('#' + containerId).offset().top > 200) {
////        $('#' + containerId).css("top", 50);
////    }
////}

////function closePopup(containerId) {
////    $('#Popup').hide();
////}

////var webRoot = '/ACC/';

/////*Common*/


////function showBudgetPopup(ID) {
////    if (ID == undefined) {
////        ID = '0';
////    }
////    $.ajaxSetup({ cache: false });
////    $.get(webRoot + 'Budget/BudgetSetupPopup', { Id: ID }, function (data) {
////        $('#PopupContainer').html(data);
////        showPopup('Popup', false);
////    });
////    alert(ID);
////}

////function ShowTestPopup() {
////    $.get(webRoot + 'COA/TestPopup', { temp: new Date().getMilliseconds() }, function (data) {
////        $('#PopupContainer').html(data);
////        showPopup('Popup', false);
////    });
////}

////function ShowAccountClassEdit(cLabel, parentCode) {
////    alert("TEst");
////    $.get(webRoot + 'COA/ShowAccountClassEdit', { cLabel: cLabel, parentCode: parentCode }, function (data) {
////        $('#PopupContainer').html(data);
////        showPopup('Popup', false);
////    });
////}

////function ShowAccountClass(cLabel,parentCode) {
////    $.get(webRoot + 'COA/ShowAccountClass', { cLabel: cLabel, parentCode: parentCode }, function (data) {
////        $('#PopupContainer').html(data);
////        showPopup('Popup', false);
////    });
////}

////function ShowGLAccountEdit(cLabel, parentCode) {
////    $.get(webRoot + 'COA/ShowGLAccountEdit', { cLabel: cLabel, parentCode: parentCode }, function (data) {
////        $('#PopupContainer').html(data);
////        showPopup('Popup', false);
////    });
////}
////function ShowGLAccount(cLabel, parentCode) {
////    $.get(webRoot + 'COA/ShowGLAccount', { cLabel: cLabel, parentCode: parentCode }, function (data) {
////        $('#PopupContainer').html(data);
////        showPopup('Popup', false);
////    });
////}


//function ShowCostCenterAccountClass(cLabel, parentCode, Code) {
//    $.get(webRoot + 'FP/ShowAccountClass', { cLabel: cLabel, parentCode: parentCode, Code: Code }, function (data) {
//        $('#PopupContainer').html(data);
//        showPopup('Popup', false);
//    });
//}