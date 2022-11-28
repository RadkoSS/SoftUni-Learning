import { html, nothing } from '../utils/lib.js';

export function updateNav(status) {
    return navigationTemplate(status);
}

function navigationTemplate(status) {
    return html`
        <div>
            <a href="/dashboard">Dashboard</a>
          </div>

          ${status 
            ? html`<div class="user">
            <a href="/create">Create Offer</a>
            <a href="/logout">Logout</a>
          </div>` 
          : nothing 
          }
          

          ${!status
            ? html`<div class="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
          </div>` 
          : nothing 
          }
    `
}