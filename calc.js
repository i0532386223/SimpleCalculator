// var string = "2+22";
// var string = "2+22*4-100/2+(3*3)";
var string = "2+22*4";

function calc() {
    console.log(string);
    var res = string.split('');
    var arr = new Array();
    var buffer = '';
    for (var i = 0; i < res.length; i++) {
        var item = res[i];
        if (item >= '0' && item <= '9') {
            buffer += item;
        } else {
            if (buffer.length > 0) {
                arr.push(buffer);
                buffer = '';
            }
            arr.push(item);
        }
    }
    if (buffer.length > 0) {
        arr.push(buffer);
    }
    console.log(arr);
    console.log(calculate(arr));
}

function calculate(arr) {
    var i = 0;
    while (arr.length > i + 2) {
        var a = parseInt(arr[i]);
        var b = parseInt(arr[i + 2]);
        var x = operation(a, b, arr[i + 1]);
        arr[i + 2] = x;
        arr[i] = null;
        arr[i + 1] = null;
        i += 2;
    }
    clear(arr);
    return arr[0];
}

function clear(res) {
    var i = 0;
    while (i < res.length) {
        if (res[i] == null) {
            res.splice(i,1);
        } else {
            i++;
        }
    }
}

function operation(a, b, operation) {
    if (operation == "+") return a + b;
    if (operation == "-") return a - b;
    if (operation == "*") return a * b;
    return 0;
}

calc();