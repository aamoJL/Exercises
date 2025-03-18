document.addEventListener("DOMContentLoaded", () => {
  const button = document.getElementById("show-more-button");
  const text = document.getElementById("compact-text");

  button.addEventListener("click", () => {
    if (text.classList.contains("compact")) {
      text.classList.remove("compact");
      button.innerText = "Show less";
    }
    else {
      text.classList.add("compact");
      button.innerText = "Show more...";
    }
  })
})