function scaling() {
    let defaultHeight = 1080;
    let currentHeight = window.innerHeight;
    let scaleCoeff = currentHeight / defaultHeight;

    let switcher = document.querySelector('#carShowroomSwitcher');
    let specs = document.querySelector('#carShowroomSpecs');
    switcher.style.transform = `scale(${scaleCoeff})`;
    specs.style.transform = `scale(${scaleCoeff})`;
}

window.onload = () => {
    scaling();
}

window.onresize = () => {
    scaling();
}