import { userLogout } from '../data/user.js';

export async function logoutAndRedirect(ctx) {
    await userLogout();

    ctx.page.redirect('/');
    ctx.updateNav();
}