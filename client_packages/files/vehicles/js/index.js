function scaling() {
    let defaultHeight = 1080;
    let currentHeight = window.innerHeight;
    let scaleCoeff = currentHeight / defaultHeight;

    let container = document.querySelector('#menu');
    container.style.transform = `scale(${scaleCoeff})`;
}

window.onload = () => {
    scaling();
}

window.onresize = () => {
    scaling();
}