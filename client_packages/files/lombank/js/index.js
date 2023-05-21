document.addEventListener("DOMContentLoaded", function() {

  // Get a reference to the button
  const button = document.querySelector(".button");

  // Add a click event listener to the button
  button.addEventListener("click", function() {
      const input = document.querySelector(".input");
      const inputValue = input.value;
      
      mp.trigger("ExchangeRPV", inputValue);
      mp.trigger("Hide_Crafting_System");
  });
});

