class Message {
  /**
   * @param {string} message
   * @param {string} sender
   */
  constructor(message, sender) {
    (this.text = message), (this.sender = sender);
    this.date = new Date();
  }
}

const messageAddedEvent = "messageAdded";
const userName = "JL";
const otherName = "AB";

let receivingMessageTimeout;

document.addEventListener("DOMContentLoaded", (e) => {
  document.getElementById("message-inputs")?.addEventListener("submit", (e) => {
    e.preventDefault();
    let messageInputElement = /** @type {HTMLInputElement | null} */ (document.getElementById("message-text"));
    if (messageInputElement !== null) {
      let message = messageInputElement.value;

      message && sendMessage(message);

      messageInputElement.value = "";
    }
  });

  document.addEventListener(messageAddedEvent, (e) => {
    let messagesElement = document.getElementById("messages");
    let scrollToBottom = messagesElement && Math.abs(messagesElement.scrollHeight - messagesElement.clientHeight - messagesElement.scrollTop) < 50;
    let message = /** @type {Message} */ (/** @type {CustomEvent} */ (e).detail);

    addMessage(message);

    // Scroll to bottom, if the scrollbar was at the bottom before the new message
    if (scrollToBottom && messagesElement) {
      messagesElement.scrollTo({
        top: messagesElement.scrollHeight,
        behavior: "smooth",
      });
    }

    // Other user sends a response message, if the main user sent the message
    if (message.sender === userName) {
      setTimeout(receivingMessage, 1000);
    }
  });
});

/**
 * Adds message that was sent by the user
 * @param {string} message Message text
 */
function sendMessage(message) {
  document.dispatchEvent(new CustomEvent(messageAddedEvent, { detail: new Message(message, userName) }));
}

/**
 * Shows user that the other user is writing a message
 * Sends the message after X seconds the user has sent the last message
 */
function receivingMessage() {
  let typingNotificationElement = document.getElementById("typing-notification");
  if (typingNotificationElement) {
    typingNotificationElement.innerText = `${otherName} is typing...`;
    typingNotificationElement.classList.add("typing");
  }

  clearTimeout(receivingMessageTimeout);
  receivingMessageTimeout = setTimeout(() => receiveMessage("Hello!"), 1000);
}

/**
 * Adds message that was received by the user
 * @param {string} message Message text
 */
function receiveMessage(message) {
  document.getElementById("typing-notification")?.classList.remove("typing");
  document.dispatchEvent(new CustomEvent(messageAddedEvent, { detail: new Message(message, otherName) }));
}

/**
 * Adds message to the message container using template element from #chat-message-template
 * @param {Message} message Message
 */
function addMessage(message) {
  let messageElement = /** @type {Element | undefined} */ (/**@type {HTMLTemplateElement | undefined} */ (document.getElementById("chat-message-template"))?.content.cloneNode(true));
  if (messageElement) {
    messageElement.querySelector(".message")?.classList.add(message.sender === userName ? "sent" : "received");
    messageElement.querySelector(".avatar")?.classList.add(message.sender === userName ? "online" : "away");

    let iconElement = messageElement.querySelector(".icon");
    if (iconElement) {
      iconElement.textContent = message.sender;
    }

    let textElement = messageElement.querySelector(".text");
    if (textElement) {
      textElement.textContent = message.text;
    }

    let dateElement = messageElement.querySelector(".date");
    if (dateElement) {
      dateElement.textContent = `${message.date.getHours()}:${message.date.getMinutes()}`;
    }

    let messagesElement = document.getElementById("messages");
    if (messagesElement) {
      messagesElement.appendChild(messageElement);
    }
  }
}
