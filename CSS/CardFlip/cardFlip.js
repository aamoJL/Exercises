document.addEventListener("DOMContentLoaded", (e) => {
  document.querySelector("#card-flip > .container > .trading-card")?.addEventListener("mouseover", (e) => {
    let element = /** @type {HTMLElement | null} */ (e.currentTarget);

    if (element) {
      element.classList.add("flipped");
    }
  });

  document.querySelector("#card-flip > .container > .trading-card")?.addEventListener("mouseout", (e) => {
    let element = /** @type {HTMLElement | null} */ (e.currentTarget);

    if (element) {
      element.classList.remove("flipped");
    }
  });
});
