import { html } from '../utils/lib.js';

export function showHome(ctx) {
  ctx.render(homeTemplate());
}

function homeTemplate() {
  return html`
        <section id="home">
        <img src="./images/landing.png" alt="home" />

        <h2 id="landing-text"><span>Add your favourite albums</span> <strong>||</strong> <span>Discover new ones right
            here!</span></h2>
      </section>`;
}