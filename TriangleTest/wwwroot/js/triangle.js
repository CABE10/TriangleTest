
function generateTri() {
    var row = document.getElementById("inputRow").value;
    var column = document.getElementById("inputColumn").value;
    var obj = { "row": row, "column": column };
    var url = "../Triangle/GetTriangle/";
    postAjaxy(obj, url, (retVal) => {
        drawCanvas(retVal);
    });
}
function getRowAndColumn() {
    var v1x = document.getElementById("v1x").value;
    var v1y = document.getElementById("v1y").value;
    var v2x = document.getElementById("v2x").value;
    var v2y = document.getElementById("v2y").value;
    var v3x = document.getElementById("v3x").value;
    var v3y = document.getElementById("v3y").value;
    var obj = { "v1x": v1x, "v1y": v1y, "v2x": v2x, "v2y": v2y, "v3x": v3x, "v3y": v3y };
    var url = "../Triangle/GetRowAndColumn/";
    postAjaxy(obj, url, (retVal) => {
        document.getElementById("rowAndColumnResult").innerText = retVal;
    });
}
function drawCanvas(coordy) {
    //{"v1x":30,"v1y":30,"v2x":20,"v2y":40,"v3x":30,"v3y":40}
    var multiplier = 3; //I blew up the canvas just for visual effect. 60x60 was too small.
    var triangle = JSON.parse(coordy);
    var canvas = document.getElementById("myCanvas");
    var context = canvas.getContext("2d");
    context.clearRect(0, 0, canvas.width, canvas.height);
    context.beginPath();
    context.moveTo(triangle.v1x * multiplier, canvas.height - (triangle.v1y * multiplier));
    context.lineTo(triangle.v2x * multiplier, canvas.height - (triangle.v2y * multiplier));
    context.lineTo(triangle.v3x * multiplier, canvas.height - (triangle.v3y * multiplier));
    context.closePath();
    context.fill();
}
function postAjaxy(dataToPost, url, callback) {
    $.ajax({
        type: "POST",
        dataType: 'text',
        cache: false,
        data: JSON.stringify(dataToPost),
        url: url,
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            console.log(result);
            callback(result);
        },
        error: function (err) {
            console.log('error: ' + err);
        },
    });
}