import { userLogout } from '../data/user.js';
import { html, page } from '../utils/lib.js';

export function updateNav(status) {
    return navigationTemplate(status);
}

function navigationTemplate(status) {
    return html`
          <a href="/dashboard">All games</a>
          
          ${!status
            ? html`<div id="guest">
                    <a href="/login">Login</a>
                    <a href="/register">Register</a>
                </div>` 
            : html`<div id="user">
                    <a href="/create">Create Game</a>
                    <a @click=${onLogout} href="javascript:void(0)">Logout</a>
                </div>` 
          }
    `;
}

function onLogout() {
    userLogout();
    page.redirect('/');
}