let numberInput = document.getElementById("numberInput");
numberInput.addEventListener("input", function () {
  if (numberInput.value < 0) {
    numberInput.value = 0;
  }
});