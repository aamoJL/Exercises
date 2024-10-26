document.addEventListener("DOMContentLoaded", (e) => {
  document.getElementById("nameplate-container")?.addEventListener("mouseenter", (e) => {
    var element = document.getElementById("hover-status");
    element?.scrollTo({
      behavior: "smooth",
      top: element.scrollHeight,
    });
  });

  document.getElementById("nameplate-container")?.addEventListener("mouseleave", (e) => {
    var element = document.getElementById("hover-status");
    element?.scrollTo({
      behavior: "smooth",
      top: 0,
    });
  });
});
