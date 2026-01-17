const wheelProperties = {
  wheelRadius: 94,
  lineWidth: 2,
  outerStrokeColor: "black",
  innerStrokeColor: "black",
  rotationSpeed: 20,
  fullSpins: 5
}
var wheelIsRunning = false
var currentWheelRotation = 0

document.addEventListener("DOMContentLoaded", _ => {
  const canvas = document.getElementById("raffle-wheel-canvas")
  /**  @type {CanvasRenderingContext2D} */
  const context = canvas.getContext("2d")
  const segments = [
    { name: "Yellow", color: "lightyellow" },
    { name: "Blue", color: "lightskyblue" },
    { name: "Green", color: "lightgreen" },
    { name: "Red", color: "lightpink" },
    { name: "Gray", color: "lightgray" },
  ]

  drawWheel(context, segments, degreesToRadians((360 / segments.length) / 2))

  document.getElementById("raffle-wheel-canvas").addEventListener("click", _ => {
    if (wheelIsRunning) return

    wheelIsRunning = true

    const winnerTextElement = document.getElementById("raffle-winner-name")
    const winnerIndex = Math.floor(Math.random() * segments.length)
    const winnerAngleRange = {
      min: degreesToRadians((360 / segments.length) * winnerIndex),
      max: degreesToRadians((360 / segments.length) * (winnerIndex + 1)),
    }
    const endRotation = (Math.random() * (winnerAngleRange.max - winnerAngleRange.min) + winnerAngleRange.min)
    const delta = (endRotation >= currentWheelRotation)
      ? endRotation - currentWheelRotation
      : 2 * Math.PI - currentWheelRotation + endRotation
    const fullSpins = Math.floor(Math.random() * wheelProperties.fullSpins) + 1
    const rotation = delta + fullSpins * (2 * Math.PI)

    winnerTextElement.textContent = "..."

    spinWheel(context, segments, rotation, () => {
      wheelIsRunning = false
      winnerTextElement.textContent = segments[winnerIndex].name
    })
  })
})

/**
 * @param {CanvasRenderingContext2D} context
 * @param {{name: String, color: String}[]} segments 
 * @param {Number} rotation rotation in radians
*/
function drawWheel(context, segments, rotation = 0) {
  context.resetTransform()
  context.clearRect(0, 0, context.canvas.width, context.canvas.height)
  context.translate(x = 100, y = 100)

  currentWheelRotation = rotation % (2 * Math.PI)

  drawSegments(context, segments, currentWheelRotation)
  drawDividerStrokes(context, segments.length, currentWheelRotation)
  drawOuterStroke(context)
  drawCenterCircle(context)
  drawWinnerInidicator(context)
}

/**
 * @param {CanvasRenderingContext2D} context 
 * @param {{name: String, color: String}[]} segments 
 * * @param {Number} rotation rotation in radians
 */
function drawSegments(context, segments, rotation = 0) {
  const segmentRadAngle = degreesToRadians(360 / segments.length)

  for (let i = 0; i < segments.length; i++) {
    // Fill
    context.beginPath()
    context.rotate(-(-rotation + segmentRadAngle + segmentRadAngle * i))
    context.lineTo(x = 0, y = 0)
    context.arc(
      x = 0, y = 0,
      radius = wheelProperties.wheelRadius,
      startAngle = 0,
      endAngle = segmentRadAngle,
    )
    context.rotate((-rotation + segmentRadAngle + segmentRadAngle * i))
    context.lineTo(x = 0, y = 0)

    context.fillStyle = segments[i].color
    context.fill()

    // Text
    context.beginPath()
    context.rotate(-(-rotation + segmentRadAngle + segmentRadAngle * i - segmentRadAngle / 2))

    context.fillStyle = "black"
    context.font = "16px Arial"
    context.textAlign = "start"
    context.textBaseline = "middle"
    context.textRendering = "optimizeLegibility"
    context.fillText(text = segments[i].name, x = 20, y = 0, maxWidth = wheelProperties.wheelRadius)
    context.rotate((-rotation + segmentRadAngle + segmentRadAngle * i - segmentRadAngle / 2))
  }
}

/**
 * @param {CanvasRenderingContext2D} context 
 */
function drawOuterStroke(context) {
  context.beginPath()
  context.arc(
    x = 0, y = 0,
    radius = wheelProperties.wheelRadius,
    startAngle = 0,
    endAngle = 2 * Math.PI
  )

  context.strokeStyle = wheelProperties.outerStrokeColor
  context.lineWidth = wheelProperties.lineWidth
  context.stroke()
}

/**
 * @param {CanvasRenderingContext2D} context 
 * @param {Number} segmentCount
 * @param {Number} rotation rotation in radians
 */
function drawDividerStrokes(context, segmentCount, rotation = 0) {
  const segmentRadAngle = degreesToRadians(360 / segmentCount)

  context.beginPath()
  for (let i = 0; i < segmentCount; i++) {
    context.rotate(-(-rotation + segmentRadAngle + segmentRadAngle * i))
    context.moveTo(0, 0)
    context.lineTo(x = wheelProperties.wheelRadius, y = 0)
    context.rotate((-rotation + segmentRadAngle + segmentRadAngle * i))
  }

  context.strokeStyle = wheelProperties.innerStrokeColor
  context.lineWidth = wheelProperties.lineWidth
  context.stroke()
}

/**
 * @param {CanvasRenderingContext2D} context
 */
function drawCenterCircle(context) {
  context.beginPath()
  context.arc(0, 0, 10, 0, 2 * Math.PI)

  context.fillStyle = "white"
  context.fill()
  context.strokeStyle = wheelProperties.innerStrokeColor
  context.lineWidth = wheelProperties.lineWidth
  context.stroke()
}

/**
 * @param {CanvasRenderingContext2D} context
 */
function drawWinnerInidicator(context) {
  const offset = { x: wheelProperties.wheelRadius + 4, y: 0 }

  context.moveTo(x = offset.x, y = offset.y - 6)
  context.lineTo(x = offset.x - 15, y = offset.y)
  context.lineTo(x = offset.x, y = offset.y + 6)
  context.closePath()

  context.lineWidth = 5
  context.strokeStyle = "black"
  context.stroke()
  context.fillStyle = "white"
  context.fill()
}

/**
 * @param {CanvasRenderingContext2D} context 
 * @param {{name: String, color: String}[]} segments 
 * @param {Number} rotationAngle current angle in radians
 * @param {Number} rotation end angle in radians
 * @param {Function} onStop called when the rotation stops
 */
function spinWheel(context, segments, rotation, onStop) {
  const startAngle = currentWheelRotation
  var rotated = 0
  var lastTimestamp = 0
  var animationId = requestAnimationFrame(tick)

  function tick(timestamp) {
    if (lastTimestamp === 0) lastTimestamp = timestamp

    const deltaTime = (timestamp - lastTimestamp) / 1000;
    lastTimestamp = timestamp;

    const rotationDelta = wheelProperties.rotationSpeed * deltaTime
    rotated = Math.min(rotated += rotationDelta, rotation)

    drawWheel(context, segments, startAngle + rotated)

    if (rotated >= rotation) {
      cancelAnimationFrame(animationId)
      onStop()
      return
    }

    animationId = requestAnimationFrame(tick)
  }
}

/**
 * @param {Number} degrees 
 * @returns radians
 */
function degreesToRadians(degrees) {
  return degrees * (Math.PI / 180);
}