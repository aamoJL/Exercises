document.addEventListener("DOMContentLoaded", (_) => {
  document.querySelectorAll(".spoiler.click").forEach(element => {
    element.addEventListener("click", (_) => {
      if(element.classList.contains("show"))
        element.classList.remove("show");
      else
        element.classList.add("show");
    });
  });
});