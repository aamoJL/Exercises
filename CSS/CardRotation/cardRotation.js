document.addEventListener("DOMContentLoaded", (e) => {
  document
    .querySelector("#card-rotation")
    ?.querySelectorAll(".trading-card .card-image")
    .forEach((element) => {
      var cardElement = /** @type {HTMLElement} */ (element);

      element.addEventListener("mousemove", (e) => {
        var event = /** @type {MouseEvent} */ (e);

        var popupScale = 1.3;
        var maxDegree = 20;
        /**
         * Percentage of the maximum radius where the maximum degree will be applied to the rotation
         */
        var radiusPercent = 0.5;
        /**
         * Minimum length from the center of the element to the pointer, where the maximum degree will be applied to the rotation
         * Smaller of the height and width will be used to calculate the radius.
         */
        var maxRadius = (Math.min(cardElement.offsetWidth, cardElement.offsetHeight) / 2) * radiusPercent;

        var mouseX = event.offsetX - cardElement.offsetWidth / 2; //  x position within the element, range shifted from [0, W] to [-W/2, W/2].
        var mouseY = event.offsetY - cardElement.offsetHeight / 2; // y position within the element, range shifted from [0, H] to [-H/2, H/2].

        // Clamping the rotation vector length to the maxRadius and changing the range to [-1, 1]
        var vectorLength = Math.abs(Math.sqrt(mouseX ** 2 + mouseY ** 2));
        var xOffset = ((mouseY / vectorLength) * Math.min(vectorLength, maxRadius)) / maxRadius;
        var yOffset = ((mouseX / vectorLength) * Math.min(vectorLength, maxRadius)) / maxRadius;

        var blurLimit = 0.5;
        var blur = Math.max(Math.max(Math.abs(xOffset), Math.abs(yOffset)) - blurLimit, 0) * 1.4;
        var contrast = 1 + Math.max(Math.abs(xOffset), Math.abs(yOffset)) * 0.5;

        cardElement.style.transform = `
          perspective( 600px )
          rotateX(${-xOffset * maxDegree}deg)
          rotateY(${yOffset * maxDegree}deg)
          scale(${popupScale})`;
        cardElement.style.boxShadow = `${Math.max(10 * -yOffset, 0)}px ${Math.max(10 * -xOffset, 0)}px 20px #1313137c`;
        cardElement.style.filter = `blur(${blur}px) contrast(${contrast})`;
      });

      element.addEventListener("mouseleave", (e) => {
        cardElement.style.transform = "";
        cardElement.style.boxShadow = "";
        cardElement.style.filter = "";
      });
    });
});

/**
 * Clamps value to the given range
 * @param {number} value
 * @param {number} min
 * @param {number} max
 */
function clamp(value, min, max) {
  return Math.min(Math.max(value, min), max);
}
