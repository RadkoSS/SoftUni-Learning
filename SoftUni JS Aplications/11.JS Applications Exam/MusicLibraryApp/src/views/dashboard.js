import { allAlbumsData } from '../data/data.js';
import { html, nothing, repeat } from '../utils/lib.js';

export async function showDashboard(ctx) {
    const allData = await allAlbumsData();
    ctx.render(dashboardTemplate(allData));
}

function dashboardTemplate(allData) {
    return html`
    <section id="dashboard">
        <h2>Albums</h2>
        <ul class="card-wrapper">
            ${allData && allData.length !== 0 
            ? repeat(allData, d => d._id, createCard) 
            : nothing 
            }
        </ul>
        
        ${!allData || allData.length === 0 
            ? html`<h2>There are no albums added yet.</h2>` 
            : nothing 
        }
    </section>`;
}

function createCard(data) {
    const altText = data.imageUrl.split('/').pop().split('.')[0];
    return html`
        <li class="card">
            <img src=".${data.imageUrl}" alt=${altText} />
            <p>
              <strong>Singer/Band: </strong><span class="singer">${data.singer}</span>
            </p>
            <p>
              <strong>Album name: </strong><span class="album">${data.album}</span>
            </p>
            <p><strong>Sales:</strong><span class="sales">${data.sales}</span></p>
            <a class="details-btn" href="/dashboard/${data._id}">Details</a>
        </li>
    `;
}