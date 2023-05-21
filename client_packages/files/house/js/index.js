function scaling() {
    let defaultHeight = 1080;
    let currentHeight = window.innerHeight;
    let scaleCoeff = currentHeight / defaultHeight;

    let house = document.querySelector('#house');
    house.style.transform = `scale(${scaleCoeff})`;
}

window.onload = () => {
    scaling();
}

window.onresize = () => {
    scaling();
}