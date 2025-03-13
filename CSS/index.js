class CellContainer extends HTMLElement {
  constructor(props) {
    super(props);

    const template = document.getElementById("cell-container-template");
    const shadow = this.attachShadow({ mode: "open" });
    const content = template.content.cloneNode(true);

    shadow.appendChild(content);
  }

  connectedCallback() {
    const shadow = this.shadowRoot;
    const title = this.getAttribute("cell-title");

    shadow.getElementById("title").innerHTML = title;
  }
}

customElements.define("cell-container", CellContainer);