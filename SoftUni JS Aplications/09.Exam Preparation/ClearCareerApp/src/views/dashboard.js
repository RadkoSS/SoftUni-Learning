import { allOffersData } from '../data/data.js';
import { html, nothing, repeat } from '../utils/lib.js';

let index = 0;
export async function showDashboard(ctx) {
    const allData = await allOffersData();
    ctx.render(dashboardTemplate(allData));
}

function dashboardTemplate(allData) {
    return html`
        <section id="dashboard">
            <h2>Job Offers</h2>
    
            ${allData && allData.length !== 0 
            ? repeat(allData, d => d._id, createCard) : nothing }
        
            ${ !allData || allData.length === 0 
            ? html`<h2>No offers yet.</h2>`
            : nothing 
            }
        </section>
    `
}

function createCard(data) {
    return html`
            <div class="offer">
                <img src="${data.imageUrl}" alt="example${++index}" />
                <p>
                    <strong>Title: </strong><span class="title">${data.title}</span>
                </p>
                <p><strong>Salary:</strong><span class="salary">${data.salary}</span></p>
                <a class="details-btn" href="/dashboard/${data._id}">Details</a>
            </div>
    `
}