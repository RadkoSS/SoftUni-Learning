import * as userActions from './api/user.js';
import { initialize } from './router.js'
import { createView } from './views/create.js';
import { dashboardView } from './views/dashboard.js';
import { detailsView } from './views/details.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { logout } from './views/logout.js';
import { registerView } from './views/register.js';

document.getElementById('default-section').remove();

const views = {
    "/": homeView,
    "/dashboard": dashboardView,
    "/login": loginView,
    "/create": createView,
    "/register": registerView,
    "/details": detailsView,
    "/logout": logout
}

const router = initialize(views);

router.updateNavigation();
router.goTo('/');