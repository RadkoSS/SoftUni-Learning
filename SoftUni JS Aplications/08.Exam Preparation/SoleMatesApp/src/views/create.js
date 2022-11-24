import { html } from '../utils/lib.js';

export function showCreate(ctx) {
    ctx.render(createViewTemplate());
}

function createViewTemplate() {
    return html`
        <p>KUR</p>
    `
}