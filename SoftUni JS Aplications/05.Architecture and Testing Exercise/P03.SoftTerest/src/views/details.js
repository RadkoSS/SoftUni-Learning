import { deleteIdea } from "../api/data.js";

const details = document.getElementById('details-view');

let ctx = null;
export function detailsView(context, htmlToInject) {
    ctx = context;
    details.innerHTML = htmlToInject;

    const deleteBtn = details.getElementsByTagName('a')[0];

    if (deleteBtn) {
        deleteBtn.addEventListener('click', onClick);
    }

    context.showSection(details);
}

async function onClick(event) {
    event.preventDefault();
    if (confirm('Are you sure you want to delete this post?')) {
        await deleteIdea(event.target.id);

        ctx.goTo(new URL(event.target.href).pathname);
    }
}