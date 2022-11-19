import { html, render } from './node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

const root = document.getElementById('allCats');

loadCats();

function loadCats() {
    const catsTemplate = html`
        <ul>
            ${cats.map(makeCatsList)}
        </ul>
    `;

    render(catsTemplate, root);
}

function makeCatsList(data) {
    return html`
        <li>
            <img src="./images/${data.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button @click=${onClick} class="showBtn">Show status code</button>
                <div class="status" style="display: none" id=${data.id}>
                    <h4>Status Code: ${data.statusCode}</h4>
                    <p>${data.statusMessage}</p>
                </div>
            </div>
        </li>
    `
}

function onClick(event) {
    const statusDiv = document.getElementById(event.target.nextElementSibling.id);
    const button = event.target;

    button.textContent = button.textContent === 'Show status code' ? 'Hide status code' : 'Show status code';
    
    statusDiv.style.display = statusDiv.style.display === 'none' ? 'block' : 'none';
}