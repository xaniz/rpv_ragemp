function scaling() {
    const defaultHeight = 680;
    const currentHeight = window.innerHeight;
    const scaleCoeff = currentHeight / defaultHeight;

    const iphone = document.querySelector('#iphone');
    iphone.style.transform = `scale(${scaleCoeff})`;
}

window.onload = () => {
    scaling();
}

window.onresize = () => {
    scaling();
}

mp.events.add({"requestclock": () => {
    var clockContainer = document.querySelector(".clock-container");
    if (clockContainer) {
      clockContainer.removeAttribute("hidden");
  
      function rotateHands() {
        // Get the current time
        const now = new Date();
        const hours = now.getHours();
        const minutes = now.getMinutes();
        const seconds = now.getSeconds();
  
        // Calculate the degree of rotation for each hand
        const hourDegree = (hours / 12) * 360 + (minutes / 60) * 30 + 90;
        const minuteDegree = (minutes / 60) * 360 + (seconds / 60) * 6 + 90;
        const secondDegree = (seconds / 60) * 360 + 90;
  
        // Update the transform property of each hand
        document.querySelector('.hour-hand').style.transform = `rotate(${hourDegree}deg)`;
        document.querySelector('.minute-hand').style.transform = `rotate(${minuteDegree}deg)`;
  
        // Adjust the second hand transform to rotate from the center of the clock
        const secondHand = document.querySelector('.second-hand');
        secondHand.style.transformOrigin = 'bottom center';
        secondHand.style.transform = `rotate(${secondDegree}deg) translateX(-50%)`;
      }
  
      // Call the rotateHands function every second
      setInterval(rotateHands, 1000);
    }
  },});