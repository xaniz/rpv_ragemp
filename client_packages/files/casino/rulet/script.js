document.addEventListener('DOMContentLoaded', function() {
  var options = ["0", "1X", "0", "2X", "0", "3X", "0", "0", "5x", "0", "5x", "0", "1x", "0", "2x", "0", "3x", "0", "1x", "0"];
  var startAngle = 0;
  var arc = Math.PI / (options.length / 2);
  var isSpinning = false;
  var spinAngleStart = 10;
  var spinTime = 0;
  var spinTimeTotal = 0;
  var ctx;

  var betAmountInput = document.getElementById("betAmount");

  var canvas = document.getElementById("canvas");
  if (canvas.getContext) {
      var outsideRadius = 200;
      var textRadius = 160;
      var insideRadius = 125;

      ctx = canvas.getContext("2d");
  }

  function byte2Hex(n) {
      var nybHexString = "0123456789ABCDEF";
      return String(nybHexString.substr((n >> 4) & 0x0F,1)) + nybHexString.substr(n & 0x0F,1);
  }

  function RGB2Color(r, g, b) {
      return '#' + byte2Hex(r) + byte2Hex(g) + byte2Hex(b);
  }

  function getColor(item, maxitem) {
      var phase = 0;
      var center = 128;
      var width = 127;
      var frequency = Math.PI * 2 / maxitem;
      
      var red = Math.sin(frequency * item + 2 + phase) * width + center;
      var green = Math.sin(frequency * item + 0 + phase) * width + center;
      var blue = Math.sin(frequency * item + 4 + phase) * width + center;
      
      return RGB2Color(red, green, blue);
  }

  function drawRouletteWheel() {
    var outsideRadius = 200;
    var textRadius = 160;
    var insideRadius = 125;

    ctx.clearRect(0, 0, 500, 500);
    ctx.strokeStyle = "black";
    ctx.lineWidth = 2;

    for (var i = 0; i < options.length; i++) {
        var angle = startAngle + i * arc;
        ctx.fillStyle = getColor(i, options.length);

        ctx.beginPath();
        ctx.arc(250, 250, outsideRadius, angle, angle + arc, false);
        ctx.arc(250, 250, insideRadius, angle + arc, angle, true);
        ctx.fill();
        ctx.stroke();

        ctx.fillStyle = "black";
        ctx.save();
        ctx.translate(250 + Math.cos(angle + arc / 2) * textRadius, 
                        250 + Math.sin(angle + arc / 2) * textRadius);
        ctx.rotate(angle + arc / 2 + Math.PI / 2);
        var text = options[i];
        ctx.fillText(text, -ctx.measureText(text).width / 2, 0);
        ctx.restore();
    }

    // Arrow
      ctx.fillStyle = "red";
      ctx.beginPath();
      ctx.moveTo(250 - 4, 250 - (outsideRadius + 5));
      ctx.lineTo(250 + 4, 250 - (outsideRadius + 5));
      ctx.lineTo(250 + 4, 250 - (outsideRadius - 5));
      ctx.lineTo(250 + 9, 250 - (outsideRadius - 5));
      ctx.lineTo(250 + 0, 250 - (outsideRadius - 13));
      ctx.lineTo(250 - 9, 250 - (outsideRadius - 5));
      ctx.lineTo(250 - 4, 250 - (outsideRadius - 5));
      ctx.lineTo(250 - 4, 250 - (outsideRadius + 5));
      ctx.fill();
  }

  function rotateWheel() {
      spinTime += 30;
      if (spinTime >= spinTimeTotal) {
          stopRotateWheel();
          return;
      }
      var spinAngle = spinAngleStart - easeOut(spinTime, 0, spinAngleStart, spinTimeTotal);
      startAngle += (spinAngle * Math.PI / 180);
      drawRouletteWheel();
      requestAnimationFrame(rotateWheel);
  }

  function stopRotateWheel() {
    var degrees = startAngle * 180 / Math.PI + 90;
    var arcd = arc * 180 / Math.PI;
    var index = Math.floor((360 - degrees % 360) / arcd);
    var multiplierText = options[index];
    var multiplier = multiplierText === "0" ? 0 : parseFloat(multiplierText.replace('x', ''));
    var betAmountInput = document.getElementById("betAmount");
    var betAmount = parseInt(betAmountInput.value, 10); 
    if (!Number.isInteger(betAmount) || betAmount <= 0) {
        return;
    }

    var totalWin = betAmount * multiplier;

    ctx.save();
    ctx.font = 'bold 30px Helvetica, Arial';
    var text = multiplier > 0 ? "Win: $" + totalWin.toFixed(2) : "Try Again!";
    ctx.fillText(text, 250 - ctx.measureText(text).width / 2, 250 + 10);
    ctx.restore();
    
    mp.trigger("client::ruletpobeda", totalWin);
    isSpinning = false;
}

  function easeOut(t, b, c, d) {
      var ts = (t /= d) * t;
      var tc = ts * t;
      return b + c * (tc + -3 * ts + 3 * t);
  }

  document.getElementById("spin").addEventListener("click", function() {

    if (isSpinning) {
      return;
  }
    var betAmountInput = document.getElementById("betAmount");
    var betAmount = parseInt(betAmountInput.value, 10);
    
    if (!Number.isInteger(betAmount) || betAmount <= 0) {
        return;
    }
    
    mp.trigger("client::ruletzavrti", betAmount);
    isSpinning = true;
    
    spinAngleStart = Math.random() * 10 + 10;
    spinTime = 0;
    spinTimeTotal = Math.random() * 3 + 4 * 1000;
    rotateWheel();
});

  document.getElementById("exit").addEventListener("click", function() {
      mp.trigger("Hide_Crafting_System");
  });

  drawRouletteWheel();
});
