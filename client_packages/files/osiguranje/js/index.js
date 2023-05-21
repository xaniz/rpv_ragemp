document.addEventListener("DOMContentLoaded", function() {

    const buttons = document.querySelectorAll(".button-container button");
  
    buttons.forEach(function(button, index) {
      button.addEventListener("click", function() {
        mp.trigger("InsuranceBuy", index);
        mp.trigger("Hide_Crafting_System");
      });
    });
  
  });