
function lpad(number, length) {
    
    var str = '' + number;
    while (str.length < length) {
        str = '0' + str;
    }

    return str;
}

function checkFraction(number) {
    var flag = 0;
    alert(number);
    for (var i = 0; i < number.length; i++) {
        if (number[i] == ".") {
            flag = 1;
            break;
        }
    }

    if (flag == 1)
        return 1;
    else 
    
    return 0;
}