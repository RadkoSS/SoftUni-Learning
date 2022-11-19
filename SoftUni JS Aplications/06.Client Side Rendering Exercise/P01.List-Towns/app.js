import { html, render } from './node_modules/lit-html/lit-html.js'

const root = document.getElementById('root');
const form = document.querySelector('.content');
form.addEventListener('submit', onSubmit);

function onSubmit(event) {
    event.preventDefault();
    const { towns } = Object.fromEntries(new FormData(form));

    if (towns) {
        const townsArray = towns.split(', ');
        renderTowns(townsArray);
        form.reset();
    }
}

function renderTowns(data) {
    const result = createTowns(data);

    render(result, root);
}

function createTowns(data) {
    const ul = html`
    <ul>
        ${data.map(el => html`<li>${el}</li>`)}
    </ul>
    `
    return ul;
}