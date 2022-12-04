import { html } from '../utils/lib.js';
import { logoutAndRedirect } from './logout.js';

export function updateNav(status) {
    return navigationTemplate(status, logoutAndRedirect);
}

function navigationTemplate(status, handler) {
    return html`
        <div>
            <a href="/dashboard">Dashboard</a>
        </div>
          
        ${!status
            ? html`<div class="guest">
                        <a href="/login">Login</a>
                        <a href="/register">Register</a>
                    </div>` 
            : html`<div class="user">
                        <a href="/create">Add Album</a>
                        <a @click=${handler} href="javascript:void(0)">Logout</a>
                    </div>`
          }
    `;
}