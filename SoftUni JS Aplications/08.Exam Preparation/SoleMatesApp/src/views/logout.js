import { userLogout } from "../data/user.js";

export async function logoutAndRedirect(ctx) {
    if (confirm('Are you sure you want to log out?')) {
        await userLogout();
        
        ctx.page.redirect('/');
        ctx.updateNav();
    }
}