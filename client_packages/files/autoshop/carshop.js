// Define an array of available vehicles
document.addEventListener("DOMContentLoaded", function() {
    
var vehicles = [
    { name: "primo", price: 27500, topspeed: 189},
    { name: "journey", price: 30000, topspeed: 134},
    { name: "glendale", price: 30000, topspeed: 197},
    { name: "surfer", price: 32500, topspeed: 134},
    { name: "issi2", price: 35000, topspeed: 182},
    { name: "moonbeam", price: 35000, topspeed: 167},
    { name: "asbo", price: 35500, topspeed: 171},
    { name: "ingot", price: 37500, topspeed: 167},
    { name: "stratum", price: 43500, topspeed: 182},
    { name: "minivan", price: 45000, topspeed: 167},
    { name: "bobcatxl", price: 48000, topspeed: 175},
    { name: "club", price: 50000, topspeed: 189},
    { name: "habanero", price: 50000, topspeed: 184},
    { name: "vigero", price: 51000, topspeed: 189},
    { name: "kanjo", price: 52500, topspeed: 189},
    { name: "everon", price: 52500, topspeed: 182},
    { name: "caracara2", price: 60000, topspeed: 185},
    { name: "speedo", price: 70000, topspeed: 173},
    { name: "omnis", price: 75000, topspeed: 204},
    { name: "bison", price: 75000, topspeed: 175},
    { name: "zion2", price: 85000, topspeed: 195},
    { name: "windsor", price: 92500, topspeed: 202},
    { name: "buffalo2", price: 115000, topspeed: 195},
    { name: "tailgater", price: 125000, topspeed: 195},
    { name: "kuruma", price: 125000, topspeed: 193},
    { name: "dominator3", price: 135000, topspeed: 195},
    { name: "jester3", price: 150000, topspeed: 210},
    { name: "stretch", price: 175000, topspeed: 182},
    { name: "infernus2", price: 175000, topspeed: 200},
    { name: "specter", price: 180000, topspeed: 208},
    { name: "locust", price: 200000, topspeed: 208},
    { name: "komoda", price: 215000, topspeed: 210},
    { name: "jugular", price: 225000, topspeed: 212},
    { name: "italigto", price: 230000, topspeed: 217},
    { name: "schafter3", price: 300000, topspeed: 202},
    { name: "visione", price: 375000, topspeed: 217},
    { name: "vagner", price: 430000, topspeed: 217},
    { name: "dubsta2", price: 600000, topspeed: 189},
    { name: "rebla", price: 600000, topspeed: 213},
    { name: "coquette4", price: 600000, topspeed: 217},
    { name: "baller4", price: 700000, topspeed: 182},
    { name: "toros", price: 750000, topspeed: 208},
    { name: "dubsta3", price: 800000, topspeed: 184},
    { name: "superd", price: 1000000, topspeed: 195},
    { name: "tyrant", price: 1150000, topspeed: 221},
    { name: "entityxf", price: 1500000, topspeed: 210},
    { name: "nero", price: 1800000, topspeed: 217},
    { name: "thrax", price: 1850000, topspeed: 215},
    { name: "nero2", price: 1900000, topspeed: 217},
    { name: "entity2", price: 2300000, topspeed: 228},
    { name: "deveste", price: 2500000, topspeed: 228}        
    
];

var colorMap = {
    "black": "0",
    "white": "132",
    "grey": "18",
    "red": "28",
    "green": "55",
    "blue": "70",
    "yellow": "89",
    "pink": "135",
    "purple": "145",
    "orange": "138"
  };

// Get references to the DOM elements we'll use
var vehicleBoxes = document.getElementById("vehicle-boxes");
var buyButton = document.getElementById("purchase-form");
var testButton = document.getElementById("test-form");
var vehicleSelect = document.getElementById("vehicle-select");
var prevButton = document.getElementById("prev-button");
var nextButton = document.getElementById("next-button");
var quitButton = document.getElementById("quit-form");
var vehicleIndex = 0;
var vehiclename = "";

// Populate the vehicle boxes with the vehicle names
for (var i = 0; i < vehicles.length; i++) {
    var box = document.createElement("div");
    box.classList.add("vehicle-box");
    box.textContent = vehicles[i].name;
    vehicleBoxes.appendChild(box);
}

var colorBoxes = document.querySelectorAll(".color-box");
var selectedColor = null;

colorBoxes.forEach(function(colorBox) {
    colorBox.addEventListener("click", function(event) {
      // Get the color value from the class name of the clicked box
      var className = event.target.classList[1];
      selectedColor = colorMap[className];
      
      // Set the selected color as the background color of a UI element
      var selectedColorElement = document.getElementById("selected-color");
      selectedColorElement.style.backgroundColor = selectedColor;
      
      // Do something with the selected color, such as update a UI element
      console.log("Selected color: " + selectedColor);
      updateVehicleDisplay();
    });
  });


// Update the vehicle index and display with the current vehicle
function updateVehicleDisplay() {
    var numVehiclesToShow = 5;
    var startIndex = Math.max(0, Math.min(vehicles.length - numVehiclesToShow, vehicleIndex));
    var endIndex = Math.min(startIndex + numVehiclesToShow, vehicles.length);
    var vehicleBoxesChildren = vehicleBoxes.children;

    // hide all vehicles
    for (var i = 0; i < vehicleBoxesChildren.length; i++) {
        vehicleBoxesChildren[i].style.display = "none";
    }

    // show the selected vehicles
    for (var i = startIndex; i < endIndex; i++) {
        vehicleBoxesChildren[i - startIndex].style.display = "flex";
        vehicleBoxesChildren[i - startIndex].textContent = vehicles[i].name;

        // add a class to the selected vehicle box
        if (i === vehicleIndex) {
            vehicleBoxesChildren[i - startIndex].classList.add("selected");
            document.getElementById("selected-car-name").textContent = vehicles[i].name;
            document.getElementById("selected-car-price").textContent = "Cena: $" + vehicles[i].price;
            document.getElementById("selected-car-topspeed").textContent = "Max Brzina: " + vehicles[i].topspeed;
            vehiclename = vehicles[i].name;
            mp.trigger("clientvehpreview", vehiclename, selectedColor);
        } else {
            vehicleBoxesChildren[i - startIndex].classList.remove("selected");
        }
    }
}


// Handle the previous button click event
prevButton.addEventListener("click", function(event) {
    vehicleIndex = Math.max(0, vehicleIndex - 1);
    updateVehicleDisplay();
});

// Handle the next button click event
nextButton.addEventListener("click", function(event) {
    vehicleIndex = Math.min(vehicles.length - 1, vehicleIndex + 1);
    updateVehicleDisplay();
});

// Handle the purchase form submit event 
buyButton.addEventListener("click", function(event) {
    var selectedVehicle = vehiclename;
    mp.trigger("clientbveh", selectedVehicle, selectedColor);
});

quitButton.addEventListener("click", function() {    
    mp.trigger("cexitvehshop");
    mp.trigger("HideCarShop");
});

testButton.addEventListener("click", function() {    
    var selectedVehicle = vehiclename;
    mp.trigger("testvoznjaveh", selectedVehicle);
});



// Get references to the DOM elements we'll use

// Initialize the UI with the first vehicle
updateVehicleDisplay();

// You can initialize the money display here using the player's current money
// var currentMoney = ...;
// updateMoneyDisplay(currentMoney);
});