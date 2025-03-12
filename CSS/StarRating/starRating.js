document.addEventListener("DOMContentLoaded", () => {
  const starContainer = document.getElementById("star-container");
  const valueText = document.getElementById("rating-value");

  let currentValue = 0;

  document.getElementsByName("rating-value-setter").forEach(element => {
    const value = element.getAttribute("data-value");

    element.addEventListener("mouseenter", () => {
      if (starContainer) {
        starContainer.style.width = `${(value / 5 * 100).toString()}%`;
        starContainer.classList.add("hover");
      }
    });

    element.addEventListener("mouseleave", () => {
      if (starContainer) {
        starContainer.style.width = `${(currentValue / 5 * 100).toString()}%`;
        starContainer.classList.remove("hover");
      }
    });

    element.addEventListener("click", (e) => {
      currentValue = currentValue === value ? 0 : value;

      if (valueText)
        valueText.innerText = currentValue;
    })
  });
});