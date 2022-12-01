import { allGamesData } from '../data/data.js';
import { html, repeat } from '../utils/lib.js';

export async function showDashboard(ctx) {
    const allData = await allGamesData();
    ctx.render(dashboardTemplate(allData));
}

function dashboardTemplate(allData) {
    return html`
        <section id="catalog-page">
            <h1>All Games</h1>
    
            ${allData && allData.length !== 0 
            ? repeat(allData, d => d._id, createCard) 
            : html`<h3 class="no-articles">No articles yet</h3>` 
            }
        </section>
    `
}

function createCard(data) {
    return html`
             <div class="allGames">
                <div class="allGames-info">
                    <img src=${data.imageUrl}>
                    <h6>${data.category}</h6>
                    <h2>${data.title}</h2>
                    <a href="/dashboard/${data._id}" class="details-button">Details</a>
                </div>
            </div>
    `;
}