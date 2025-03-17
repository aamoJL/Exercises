class StarRating {
  valueRange = {
    start: 0,
    end: 0
  };
  visualRange = {
    start: 0,
    end: 0
  };
  dragging = false;
  dragStart = 0;
}

const starRating = new StarRating();

document.addEventListener("DOMContentLoaded", () => {
  document.getElementById("value-setters-container").addEventListener("pointerleave", () => {
    starRating.dragging = false;

    updateVisual(starRating.valueRange);
  })

  document.getElementsByName("rating-value-setter").forEach(element => {
    const value = element.getAttribute("data-value");

    element.addEventListener("mouseenter", () => {
      if (starRating.dragging) {
        starRating.visualRange.start = Math.min(starRating.dragStart, value);
        starRating.visualRange.end = Math.max(starRating.dragStart, value);
      }
      else
        starRating.visualRange = { start: 0, end: value };

      updateVisual(starRating.visualRange, true);
    });

    element.addEventListener("dragstart", (e) => {
      e.preventDefault();
      starRating.dragging = true;
      starRating.visualRange.start = value;
      starRating.dragStart = value;

      updateVisual(starRating.visualRange, true);
    });

    element.addEventListener("pointerup", () => {
      if (starRating.dragging) {
        starRating.valueRange = {
          start: starRating.visualRange.start,
          end: starRating.visualRange.end
        }

        updateValueVisual(starRating.valueRange);
        updateVisual(starRating.valueRange);
      }

      starRating.dragging = false;
    });

    element.addEventListener("click", () => {
      var newValue = starRating.valueRange.start === value && starRating.valueRange.end ? 0 : value;
      starRating.valueRange = {
        start: newValue,
        end: newValue,
      };

      updateValueVisual(starRating.valueRange);
      updateVisual(starRating.valueRange);
    })
  });
});

/**
 * @param {{start: number, end: number}} range
*/
function updateValueVisual(range) {
  const valueText = document.getElementById("rating-value");

  if (valueText) {
    if (range.start === range.end)
      valueText.innerText = range.start;
    else
      valueText.innerText = `${range.start} - ${range.end}`;
  }
}

/**
 * @param {{start: number, end: number}} range
 * @param {boolean} hover
*/
function updateVisual(range, hover = false) {
  const visualContainer = document.getElementById("value-visual-container");

  if (visualContainer) {
    const visualStart = range.start === range.end ? 0 : range.start - 1;
    const visualEnd = range.end;

    visualContainer.style.clipPath = `inset(0% ${100 - (visualEnd / 5 * 100)}% 0% ${(visualStart / 5 * 100)}%)`;

    if (hover)
      visualContainer.classList.add("hover");
    else
      visualContainer.classList.remove("hover");
  }
}