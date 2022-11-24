import { html, render } from './utils/lib.js';
import { page } from './utils/lib.js';
import { showCreate } from './views/create.js';
import { showDashboard } from './views/dashboard.js';
import { showDetails } from './views/details.js';
import { showEdit } from './views/edit.js';
import { showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { logoutAndRedirect } from './views/logout.js';
import { updateNavigation } from './views/navigation.js';
import { showRegister } from './views/register.js';
import { showSearch } from './views/search.js';

const mainRoot = document.getElementsByTagName('main')[0];
const navRoot = document.querySelector('.navigation');

function middleware(ctx, next) {
    ctx.page = page;

    ctx.render = (content) => {
        render(content, mainRoot);
    };

    ctx.updateNav = updateNav;

    next();
}

function updateNav() {
    render(updateNavigation(), navRoot);
}

updateNav();
page(middleware);
page('index.html', '/');
page('/', showHome);
page('/dashboard', showDashboard);
page('/search', showSearch);
page('/add', showCreate);
page('/login', showLogin);
page('/logout', logoutAndRedirect);
page('/register', showRegister);
page('/edit', showEdit);
page('/search', showSearch);
page('/details', showDetails);

page.start();