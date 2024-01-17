document.addEventListener('DOMContentLoaded', function() {
        var options = ["0", "1X", "0", "2X", "0", "3X", "0", "0", "5X", "0", "1X", "0", "1X", "0", "2X", "0", "3X", "0", "1X", "0"];
        
        var startAngle = 0;
        var arc = Math.PI / (options.length / 2);
        var isSpinning = false;
        var ctx;
    
        var canvas = document.getElementById("canvas");
        if (canvas.getContext) {
            ctx = canvas.getContext("2d");
        }

    function getColorForOption(option) {
        switch (option) {
            case "0":
                return '#808080';
            case "1X":
                return '#007bff';
            case "2X":
                return '#28a745';
            case "3X":
                return '#ffc107';
            case "5X":
                return '#dc3545';
            default:
                return '#ffffff';
        }
    }

    function drawRouletteWheel() {
        var outsideRadius = 200;
        var textRadius = 160;
        var insideRadius = 0; 
        ctx.clearRect(0, 0, 500, 500);
        ctx.lineWidth = 2;
    
        for (var i = 0; i < options.length; i++) {
            var angle = startAngle + i * arc;
            var startAngleRad = angle;
            var endAngleRad = angle + arc;
    
            var gradient = ctx.createRadialGradient(
                250, 250, insideRadius,
                250, 250, outsideRadius
            );
    
            switch (options[i]) {
                case "0":
                    gradient.addColorStop(0, '#333333');
                    gradient.addColorStop(1, '#808080');
                    break;
                case "1X":
                    gradient.addColorStop(0, '#4e085e');
                    gradient.addColorStop(1, '#007bff');
                    break;
                case "2X":
                    gradient.addColorStop(0, '#4e085e');
                    gradient.addColorStop(1, '#28a745');
                    break;
                case "3X":
                    gradient.addColorStop(0, '#4e085e');
                    gradient.addColorStop(1, '#ffc107');
                    break;
                case "5X":
                    gradient.addColorStop(0, '#4e085e');
                    gradient.addColorStop(1, '#dc3545');
                    break;
                default:
                    gradient.addColorStop(0, '#666666');
                    gradient.addColorStop(1, '#ffffff');
            }
    
            ctx.fillStyle = gradient;
    
            ctx.beginPath();
            ctx.moveTo(250, 250);
            ctx.arc(250, 250, outsideRadius, startAngleRad, endAngleRad, false);
            ctx.lineTo(250, 250);
            ctx.fill();
            ctx.stroke();
            
            ctx.fillStyle = 'white';
            ctx.save();
            ctx.translate(250 + Math.cos(startAngleRad + arc / 2) * textRadius, 
                                            250 + Math.sin(startAngleRad + arc / 2) * textRadius);
            ctx.rotate(startAngleRad + arc / 2 + Math.PI / 2);
            var text = options[i];
            ctx.fillText(text, -ctx.measureText(text).width / 2, 0);
            ctx.restore();
        }
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
        spinTimeTotal = 10000; 
        rotateWheel();
    });

    document.getElementById("exit").addEventListener("click", function() {
            mp.trigger("Hide_Crafting_System");
    });

    drawRouletteWheel();
});
