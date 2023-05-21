const scaling = () => {
    const defaultHeight = 2000;
    const currentHeight = window.innerHeight;
    const scaleCoeff = currentHeight / defaultHeight;

    const online = document.querySelector('#online');
    online.style.transform = `scale(${scaleCoeff})`;
}

window.onload = () => {
    scaling();
}

window.onresize = () => {
    scaling();
}