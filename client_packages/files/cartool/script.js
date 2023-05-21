// Define an array of available vehicles
document.addEventListener("DOMContentLoaded", function() {
    
    // Get references to the DOM elements we'll use
    var haubaButton = document.getElementById("hauba");
    var gepekButton = document.getElementById("gepek");
    var vrata1Button = document.getElementById("vrata1");
    var vrata2Button = document.getElementById("vrata2");
    var vrata3Button = document.getElementById("vrata3");
    var vrata4Button = document.getElementById("vrata4");
    var neonButton = document.getElementById("neon");
    var blinkerButton = document.getElementById("blinker");
    var engineButton = document.getElementById("engine");
    var lockButton = document.getElementById("lock");
    
    vrata1Button.addEventListener("click", function(event) {
        mp.trigger("ClientCarControl", 3);
    });
    vrata2Button.addEventListener("click", function(event) {
        mp.trigger("ClientCarControl", 4);
    });
    vrata3Button.addEventListener("click", function(event) {
        mp.trigger("ClientCarControl", 5);
    });
    vrata4Button.addEventListener("click", function(event) {
        mp.trigger("ClientCarControl", 6);
    });
    
    // Handle the purchase form submit event 
    haubaButton.addEventListener("click", function(event) {
        mp.trigger("ClientCarControl", 1);
    });
    
    gepekButton.addEventListener("click", function() {    
        mp.trigger("ClientCarControl", 2);
    });

    neonButton.addEventListener("click", function() {    
        mp.trigger("ClientCarControl", 9);
    });

    blinkerButton.addEventListener("click", function() {    
        mp.trigger("ClientCarControl", 8);
    });

    engineButton.addEventListener("click", function() {    
        mp.trigger("ClientCarControl", 7);
    });

    lockButton.addEventListener("click", function() {    
        mp.trigger("ClientCarControl", 0);
    });
    
    
    });