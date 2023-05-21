const canvas = document.getElementById('canvas');
const ctx = canvas.getContext('2d');

const deg2Rad = (deg) => {
    return deg * (Math.PI / 180);
}

const rad2Deg = (rad) => {
    return rad * (180 / Math.PI);
}

class Speedo {
    constructor() {
        this.borderWidth = 7;
        this.dangerZoneStartAngle = deg2Rad(0);
        this.margin = deg2Rad(4);

        this.speedUnit = 'KM/H';

        this.startAngle = deg2Rad(180);
        this.endAngle = deg2Rad(45);

        const cw = canvas.width;
        const ch = canvas.height;

        this.radius = ch / 2 - this.borderWidth - 16;
        this.x = cw / 2;
        this.y = ch / 2;
    }

    val2Angle(value, startAngle = this.startAngle, endAngle=this.endAngle) {
        return value * (startAngle + endAngle);
    }

    drawTachometer() {
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.beginPath();
        ctx.arc(0, 0, this.radius, this.startAngle, this.dangerZoneStartAngle - this.margin);
        ctx.lineWidth = this.borderWidth;
        ctx.strokeStyle = 'rgba(255, 255, 255, 0.4)';
        ctx.stroke();
        ctx.restore();
    }

    drawTachometerFilled(value) {
        const end = this.dangerZoneStartAngle - this.margin;
        const fillValue = this.startAngle + this.val2Angle(value, this.startAngle, end) || this.startAngle;
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.beginPath();
        ctx.arc(0, 0, this.radius, this.startAngle, fillValue);
        ctx.lineWidth = this.borderWidth;
        ctx.strokeStyle = '#ffffff';
        ctx.stroke();
        ctx.restore();
    }

    drawFuelBar() {
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.beginPath();
        ctx.arc(0, 0, this.radius - 10, this.startAngle, this.endAngle);
        ctx.lineWidth = this.borderWidth - 2;
        ctx.strokeStyle = 'rgba(255, 255, 255, 0.4)';
        ctx.stroke();
        ctx.restore();
    }

    drawFuelFilledBar(value) {
        const fillValue = this.startAngle + this.val2Angle(value) || this.startAngle;
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.beginPath();
        ctx.arc(0, 0, this.radius - 10, this.startAngle, fillValue);
        ctx.lineWidth = this.borderWidth - 2;
        ctx.strokeStyle = '#3D5F8F';
        ctx.stroke();
        ctx.restore();
    }

    drawDangerZone() {
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.beginPath();
        ctx.arc(0, 0, this.radius, this.dangerZoneStartAngle, this.endAngle);
        ctx.lineWidth = this.borderWidth;
        ctx.strokeStyle = 'rgba(184, 0, 0, 0.4)';
        ctx.stroke();
        ctx.restore();
    }

    drawDangerZoneFilled(value) {
        const fillValue = this.dangerZoneStartAngle + this.val2Angle(value, this.dangerZoneStartAngle) || this.dangerZoneStartAngle;
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.beginPath();
        ctx.arc(0, 0, this.radius, this.dangerZoneStartAngle, fillValue);
        ctx.lineWidth = this.borderWidth;
        ctx.strokeStyle = '#b80000';
        ctx.stroke();
        ctx.restore();
    }

    calcTextMarksAngles (count) {
        const a = deg2Rad(225);
        let angles = [];

        for (let i = -count + 1; i <= 0; i++) {
            const angle = (i * a / (count - 1)) + a + this.startAngle;
            angles.push(angle);
        }

        return angles;
    }

    drawTextMarks(angles, step) {
        let value = 0;
        const radius = this.radius + 16;

        ctx.save();
        ctx.translate(this.x, this.y);

        ctx.font = 'italic bold 18px "Montserrat", sans-serif';
        ctx.fillStyle = '#ffffff';

        for (let angle in angles) {
            const x = (Math.cos(angles[angle]) - 0.05) * radius;
            const y = (Math.sin(angles[angle]) + 0.05) * radius;

            ctx.fillText(value, x, y);
            
            value += step;
        }

        ctx.restore();
    }

    drawTurnSignal(offsetX, offsetY, width, height, enabled=false) {
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.beginPath();
        ctx.moveTo(offsetX, offsetY - height + height * 0.25);
        ctx.lineTo(offsetX + width - width / 1.35, offsetY - height + height * 0.25);
        ctx.lineTo(offsetX + width - width / 1.35, offsetY - height);
        ctx.lineTo(offsetX + width - width / 2.5, offsetY - height / 2);
        ctx.lineTo(offsetX + width - width / 1.35, offsetY);
        ctx.lineTo(offsetX + width - width / 1.35, offsetY - height + height * 0.75);
        ctx.lineTo(offsetX, offsetY - height + height * 0.75);
        ctx.closePath();
        ctx.fillStyle = '#161616';
        if (enabled) {
            ctx.fillStyle = this.turnSignalColor;
        }
        ctx.fill();
        ctx.restore();
    }

    drawSpeed(speed) {
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.font = 'bold 36px "Montserrat", sans-serif';
        ctx.fillStyle = '#ffffff';
        ctx.textAlign = 'right';
        ctx.fillText(speed, 25, 0);
        ctx.restore();
    }

    drawUnit() {
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.font = 'normal 300 12px "Montserrat", sans-serif';
        ctx.fillStyle = '#ffffff';
        ctx.textAlign = 'right';
        ctx.fillText(`${this.speedUnit}`, 25, 15);
        ctx.restore();
    }

    drawDelimiter() {
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.fillStyle = '#ffffff';
        ctx.fillRect(32.5, -30, 5, 50);
        ctx.restore();
    }

    drawGear(gear) {
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.font = 'bold 24px "Montserrat", sans-serif';
        ctx.fillStyle = '#ffffff';
        ctx.fillText(gear, 45, 4);
        ctx.restore();
    }

    drawTurnSignal(offsetX, offsetY, width, height, enabled=false) {
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.beginPath();
        ctx.moveTo(offsetX, offsetY - height + height * 0.25);
        ctx.lineTo(offsetX + width - width / 1.35, offsetY - height + height * 0.25);
        ctx.lineTo(offsetX + width - width / 1.35, offsetY - height);
        ctx.lineTo(offsetX + width - width / 2.5, offsetY - height / 2);
        ctx.lineTo(offsetX + width - width / 1.35, offsetY);
        ctx.lineTo(offsetX + width - width / 1.35, offsetY - height + height * 0.75);
        ctx.lineTo(offsetX, offsetY - height + height * 0.75);
        ctx.closePath();
        ctx.fillStyle = 'rgba(87, 213, 63, 0.1)';

        if (enabled) {
            ctx.fillStyle = '#57d53f';
        }

        ctx.fill();
        ctx.restore();
    }

    drawFuelIcon() {
        const iconPath = new Path2D('M14.478 2.293l-1.458-1.458c-.142-.142-.372-.142-.516 0-.142.142-.142.372 0 .516l1.201 1.201-1.201 1.201c-.069.068-.106.161-.106.258v1.093c0 .804.653 1.458 1.458 1.458v6.198c0 .201-.163.365-.365.365-.201 0-.365-.163-.365-.365v-.729c0-.603-.491-1.093-1.093-1.093h-.365v-9.479c0-.804-.653-1.458-1.458-1.458h-7.291c-.804 0-1.458.653-1.458 1.458v13.125c-.804 0-1.458.653-1.458 1.458v1.093c0 .201.162.365.365.365h12.397c.201 0 .365-.162.365-.365v-1.093c0-.804-.653-1.458-1.458-1.458v-2.917h.365c.201 0 .365.163.365.365v.729c0 .603.491 1.093 1.093 1.093.603 0 1.093-.491 1.093-1.093v-10.209c0-.097-.038-.189-.106-.258zm-4.268 3.911c0 .201-.162.365-.365.365h-6.563c-.201 0-.365-.162-.365-.365v-4.382c0-.201.162-.365.365-.365h6.563c.201 0 .365.162.365.365z');

        ctx.save();
        ctx.translate(42.5, this.y - 18);
        ctx.fillStyle = '#3D5F8F';
        ctx.fill(iconPath);
        ctx.restore();
    }
}

const draw = (speedValue, gearValue, tachometerValue, fuelValue, turnSignals) => {
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    const speedo = new Speedo();

    const total = speedo.startAngle + speedo.endAngle;
    const danger = speedo.dangerZoneStartAngle - speedo.endAngle;
    const f = (total + danger) / total;
    const multip1 = 1 / f;
    const multip2 = 1 / (1 - f);

    const textMarksAngles = speedo.calcTextMarksAngles(6);
    
    speedo.drawTachometer();
    speedo.drawDangerZone();

    if (tachometerValue <= f) {
        speedo.drawTachometerFilled(tachometerValue * multip1);
    } else {
        speedo.drawTachometerFilled(1);
        speedo.drawDangerZoneFilled((tachometerValue - f) * multip2);
    }    
    
    speedo.drawFuelBar();
    speedo.drawFuelFilledBar(fuelValue);
    speedo.drawTextMarks(angles=textMarksAngles, step=2);
    speedo.drawSpeed(speedValue);
    speedo.drawUnit();
    speedo.drawDelimiter();
    speedo.drawGear(gearValue);
    speedo.drawTurnSignal(20, 50, 30, 20, turnSignals.right);
    speedo.drawTurnSignal(-20, 50, -30, 20, turnSignals.left);
    speedo.drawFuelIcon();
}