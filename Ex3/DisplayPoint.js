﻿//drawing the image map
function setup(canvasName) {
    var canvas = document.getElementById(canvasName);
    var context = canvas.getContext("2d");
    context.canvas.width = window.innerWidth;
    context.canvas.height = window.innerHeight;
    var image = document.getElementById("map");
    context.drawImage(image, 0, 0, image.width, image.height, 0, 0, canvas.width, canvas.height);
}

//drawing a new point with the line connecting the point to the previous one (if such exists)
function drawLineWithPoint(x, y, prevX, prevY, canvasName) {

    var canvas = document.getElementById(canvasName);
    //normalizing
    x = (x + 180) * canvas.width / 360.0
    y = (y + 90) * canvas.height / 180.0

    var context = canvas.getContext("2d");

    context.beginPath();
    context.arc(x, y, 8, 0 * Math.PI, 2 * Math.PI);
    context.strokeStyle = "blue";
    context.stroke();
    context.fillStyle = "red";
    context.fill();

    //if a point was drawn before, connecting it with the current one with a line
    if (prevX != -1) {
        //normalizing it too
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