import { createIdea } from "../api/data.js";

const create = document.getElementById('create-view');

const createForm = create.getElementsByTagName('form')[0];
createForm.addEventListener('submit', onSubmit);

let ctx = null;
export function createView(context) {
    ctx = context;
    context.showSection(create);
}

function onSubmit(event) {
    event.preventDefault();

    const { title, description, imageURL } = Object.fromEntries(new FormData(createForm));

    if (title.length < 6 || description.length < 10 || imageURL.length < 5) {
        alert('Invalid data! Try again.');
        return;
    }
    debugger
    createIdea({
        title,
        description,
        img: imageURL
    });
    ctx.goTo('/dashboard');

    createForm.reset();
}