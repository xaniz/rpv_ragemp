var opts = {
    angle: 0.35, // The span of the gauge arc
    lineWidth: 0.05, // The line thickness
    radiusScale: 1, // Relative radius
    pointer: {
        length: 0.6, // // Relative to gauge radius
        strokeWidth: 0.035, // The thickness
        color: '#000000' // Fill color
    },
    limitMax: false,     // If false, max value increases automatically if value > maxValue
    limitMin: false,     // If true, the min value of the gauge will be fixed
    colorStart: '#BABABA',   // Colors
    colorStop: '#008df0',    // just experiment with them
    strokeColor: '#575757',  // to see which ones work best for you
    generateGradient: true,
    highDpiSupport: true,     // High resolution support
};
var opts2 = {
    angle: 0.35, // The span of the gauge arc
    lineWidth: 0.1, // The line thickness
    radiusScale: 1, // Relative radius
    pointer: {
        length: 0.6, // // Relative to gauge radius
        strokeWidth: 0.035,
        color: '#000000'
    },
    limitMax: false,
    limitMin: false,     // If true, the min value of the gauge will be fixed
    colorStart: 'red',
    colorStop: '#E0E0E0',
    strokeColor: '#E0E0E0',
    generateGradient: true,
    highDpiSupport: true,

};
const target = document.getElementById('gauge-speed');
const target2 = document.getElementById('fuel-gauge');
const gauge = new Donut(target).setOptions(opts);
const gauge1 = new Donut(target2).setOptions(opts2);
gauge.setMinValue(0);
gauge.animationSpeed = 15;
gauge.maxValue = 200;
gauge1.maxValue = 100;
gauge.setMinValue(0);
gauge.animationSpeed = 15;
$(document).ready(function(){
    gauge.set($('#speed_kmh')[0].innerText);

});
