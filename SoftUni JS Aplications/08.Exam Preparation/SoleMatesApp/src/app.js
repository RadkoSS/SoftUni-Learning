import { render } from './utils/lib.js';
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
    ctx.render = (content) => {
        render(content, mainRoot);
    };

    next();
}

function navigate(ctx, next) {
    ctx.updateNav = () => render(updateNavigation(), navRoot);;

    ctx.updateNav();

    next();
}

// function parseQuery(ctx, next) {
//     ctx.query = {};

//     if (ctx.querystring) {
//         const query = Object.fromEntries(ctx.querystring
//             .split('&')
//             .map(e => e.split('=')));

//         Object.assign(ctx.query, query);
//     }

//     next();
// }

page(middleware);
page(navigate);
// page(parseQuery);
page('/index.html', '/');
page('/', showHome);
page('/dashboard', showDashboard);
page('/register', showRegister);
page('/dashboard/edit/:id', showEdit);
page('/dashboard/:id', showDetails);
page('/search', showSearch);
page('/search/:brand', showSearch);
page('/logout', logoutAndRedirect);
page('/login', showLogin);
page('/add', showCreate);

page.start();