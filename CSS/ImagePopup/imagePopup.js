document.addEventListener("DOMContentLoaded", () => {
  const body = document.querySelector("body");
  const popup = document.querySelector("#image-popup .popup");
  const img = popup?.getElementsByTagName("img")[0];

  if (!img)
    return;

  window.addEventListener("resize", () => {
    if (popup.classList.contains("open")) {
      setPosition(img);
    }
  });

  popup?.addEventListener("click", () => {
    if (popup.classList.contains("open")) {
      body.classList.remove("popup-open");
      popup.classList.remove("open");
      img.style.scale = 1;
      img.style.transform = "";
    }
    else {
      setPosition(img);

      body.classList.add("popup-open");
      popup.classList.add("open");
    }
  });
});

/**
 * @param {HTMLElement} element 
 */
function setPosition(element) {
  const margin = 40;
  const yRatio = window.innerHeight / (element.height + margin * 2);
  const xRatio = window.innerWidth / (element.width + margin * 2);
  const scale = Math.min(xRatio, yRatio, 2);

  const imgOffsets = getElementOffsets(element);
  const scrollOffset = { x: window.scrollX, y: window.scrollY };
  const horizontalPosition = (((window.innerWidth - element.width) / 2) - (imgOffsets.x + scrollOffset.x)) / scale;
  const verticalPosition = (((window.innerHeight - element.height) / 2) - (imgOffsets.y + scrollOffset.y)) / scale;

  element.style.scale = scale;
  element.style.transform = `translate(${horizontalPosition}px, ${verticalPosition}px)`;
}

/**
 * @param {HTMLElement} element 
 * @returns {{x: number, y: number }}
 */
function getElementOffsets(element) {
  var x = element.offsetLeft;
  var y = element.offsetTop;
  var parent = element.offsetParent;

  while (parent) {
    x += parent.offsetLeft;
    y += parent.offsetTop;

    parent = parent.offsetParent;
  }

  return { x, y }
}