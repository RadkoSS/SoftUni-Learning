import { html, repeat, nothing } from "../utils/lib.js";
import { allShoesData } from "../data/data.js";

export async function showDashboard(ctx) {
  const shoesData = await allShoesData();
  
  ctx.render(dashboardTemplate(shoesData));
}

function dashboardTemplate(data) {
  return html`
        <section id="dashboard">
          <h2>Collectibles</h2>
          <ul class="card-wrapper">
            ${data.length !== 0 ? repeat(data, d => d._id, createShoeCard) : nothing}
          </ul>
        
          ${data.length === 0 ? html`<h2>There are no items added yet.</h2>` : nothing}
        
        </section>
    `;
}

function createShoeCard(data) {
  const altText = data.imageUrl.split('/').pop().split('.')[0];
  return html`
        <li class="card">
          <img src=".${data.imageUrl}" alt=${altText} />
          <p>
            <strong>Brand: </strong><span class="brand">${data.brand}</span>
          </p>
          <p>
            <strong>Model: </strong><span class="model">${data.model}</span>
          </p>
          <p><strong>Value:</strong><span class="value">${data.value}</span>$</p>
          <a class="details-btn" href="/details">Details</a>
        </li>
    `;
}