document.addEventListener("DOMContentLoaded", (e) => {
  var root = document.querySelector("#flip-card")

  root?.querySelector(".front .content")?.addEventListener("click", (_) => {
    root.classList.add("flipped")
  })

  root?.querySelector(".back button")?.addEventListener("click", (_) => {
    root.classList.remove("flipped")
  })
});
