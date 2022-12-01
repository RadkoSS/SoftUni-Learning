import { userLogout } from "../data/user.js";

export function logoutAndRedirect(ctx) {
    userLogout();
    ctx.page.redirect('/');
}