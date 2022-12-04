import { html } from '../utils/lib.js';
import { logoutAndRedirect } from './logout.js';

export function updateNav(status) {
    return navigationTemplate(status, logoutAndRedirect);
}

function navigationTemplate(status, handler) {
    return html`
          <a href="/dashboard">All games</a>
          
          ${!status
            ? html`<div id="guest">
                    <a href="/login">Login</a>
                    <a href="/register">Register</a>
                </div>` 
            : html`<div id="user">
                    <a href="/create">Create Game</a>
                    <a @click=${handler} href="javascript:void(0)">Logout</a>
                </div>` 
          }
    `;
}