const scaling = () => {
    const defaultHeight = 1080;
    const windowHeight = window.innerHeight;
    const scalingCoeff = windowHeight / defaultHeight;

    const speedo = document.querySelector('#speedometer');
    speedo.style.transform = `scale(${scalingCoeff})`;
}

window.onload = () => {
    scaling();

    let turnSignals = {
        'right': 1,
        'left': 0
    }
    
    draw(100, 1, 0.5, 0.5, turnSignals);
    
    const input = document.querySelector('#speed');
    input.addEventListener('change', () => {
        draw(100, 1, input.value, input.value, turnSignals);
    });
}

window.onresize = () => {
    scaling();
}