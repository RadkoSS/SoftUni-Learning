import { render, page } from './utils/lib.js';
import { updateNav } from './views/navigation.js';
import { getUserData } from './utils/util.js'
import { showHome } from './views/home.js';
import { showDashboard } from './views/dashboard.js';
import { showRegistration } from './views/register.js';
import { showEdit } from './views/edit.js';
import { showDetails } from './views/details.js';
import { showLogin } from './views/login.js';
import { showCreate } from './views/create.js';

const navigation = document.querySelector('.navigation');
const mainRoot = document.querySelector('.main');

function decorateContext(ctx, next) {
    ctx.render = (content) => {
        render(content, mainRoot);
    };

    ctx.user = getUserData();

    ctx.updateNavigation = () => {
        render(updateNav(ctx.user), navigation);
    };

    ctx.updateNavigation();

    next();
}

page(decorateContext);
page('/index.html', '/');
page('/', showHome);
page('/dashboard', showDashboard);
page('/register', showRegistration);
page('/dashboard/edit/:id', showEdit);
page('/dashboard/:id', showDetails);
page('/login', showLogin);
page('/create', showCreate);

page.start();