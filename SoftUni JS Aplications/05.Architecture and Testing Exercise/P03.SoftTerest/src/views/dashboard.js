import { getAllIdeas } from "../api/data.js";

const dashboard = document.getElementById('dashboard-holder');

export async function dashboardView(context) {
    context.showSection(dashboard);

    const ideas = await getAllIdeas();

    if (ideas.length === 0) {
        dashboard.innerHTML = `<h1>No ideas yet! Be the first one :)</h1>`;
    } else {
        dashboard.replaceChildren(...ideas.map(renderIdea))
    }
}

function renderIdea(idea) {
    const div = document.createElement('div');

    div.classList = 'card overflow-hidden current-card details';
    div.style.width = '20rem';
    div.style.height = '18rem';

    div.innerHTML = `
    <div class="card-body">
    <p class="card-text">${idea.title}</p>
</div>
<img class="card-image" src="${idea.img}" alt="Card image cap">
<a class="btn" href="/details">Details</a>
`
    return div;
}