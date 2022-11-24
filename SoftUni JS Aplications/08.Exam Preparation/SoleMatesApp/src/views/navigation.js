import { checkLoggedStatus, userLogout } from "../data/user.js";
import { html, nothing } from "../utils/lib.js";


export function updateNavigation() {
    const status = checkLoggedStatus();

    return navigationTemplate(status);
}

function navigationTemplate(loggedStatus, handler) {
    return html`
    <div>
        <a href="/dashboard">Dashboard</a>
        <a href="/search">Search</a>
    </div>
    
    ${ loggedStatus ? html`<div class="user">
        <a href="/add">Add Pair</a>
        <a href="/logout">Logout</a>
    </div>` : nothing }
    
    ${ loggedStatus == false ? html`<div class="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>` : nothing }
    `;
}

