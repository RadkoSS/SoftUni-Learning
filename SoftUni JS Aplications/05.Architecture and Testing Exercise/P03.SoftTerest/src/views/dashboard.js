import { getAllIdeas, getIdeaDetails } from "../api/data.js";
import { checkLoggedStatus } from "../api/user.js";

const dashboard = document.getElementById('dashboard-holder');

let ctx = null;
export async function dashboardView(context) {
    ctx = context;
    context.showSection(dashboard);

    const ideas = await getAllIdeas();

    if (ideas.length === 0) {
        dashboard.innerHTML = `<h1>No ideas yet! Be the first one :)</h1>`;
    } else {
        dashboard.replaceChildren(...ideas.map(renderIdea));
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
<a id="${idea._id}" class="btn" href="/details">Details</a>
`
    div.querySelector('.btn').addEventListener('click', showDetailsForIdea);
    return div;
}

async function showDetailsForIdea(event) {
    event.preventDefault();

    const ideaID = event.target.id;

    const details = await getIdeaDetails(ideaID);

    let ideaInnerHTML = `<img class="det-img" src="${details.img}" />
    <div class="desc">
        <h2 class="display-5">${details.title}</h2>
        <p class="infoType">Description:</p>
        <p class="idea-description">${details.description}</p>
    </div>`
    
    if (checkLoggedStatus()) {
        const userAuthKey = JSON.parse(sessionStorage.getItem('userData'))._id;

        if (userAuthKey === details._ownerId) {
            ideaInnerHTML += `<div class="text-center">
            <a id="${ideaID}" class="btn detb" href="/dashboard">Delete</a>
        </div>`
        }
    }

    ctx.goTo('/details', ideaInnerHTML);
}