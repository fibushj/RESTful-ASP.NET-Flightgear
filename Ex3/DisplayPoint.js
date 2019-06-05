function setup(canvasName) {
    var canvas = document.getElementById(canvasName);

    var context = canvas.getContext("2d");
    context.canvas.width = window.innerWidth;
    context.canvas.height = window.innerHeight;
    var img = document.getElementById("map");
    context.drawImage(img, 0, 0, img.width, img.height, 0, 0, canvas.width, canvas.height);
}

function drawLineWithPoint(x, y, prevX, prevY, canvasName) {

    var canvas = document.getElementById(canvasName);

    x = (x + 180) * canvas.width / 360.0
    y = (y + 90) * canvas.height / 180.0

    var context = canvas.getContext("2d");

    context.beginPath();
    context.arc(x, y, 4, 0, 2 * Math.PI);
    context.strokeStyle = "blue";
    context.stroke();
    context.fillStyle = "red";
    context.fill();

    if (prevX != -1) {
        prevX = (prevX + 180) * canvas.width / 360.0
        prevY = (prevY + 90) * canvas.height / 180.0
        context.beginPath();
        context.lineWidth = "2";
        context.strokeStyle = "red";
        context.moveTo(prevX, prevY);
        context.lineTo(x, y);
        context.stroke();

    }

}