import { userLogout } from '../data/user.js';
import { page } from '../utils/lib.js';

export function logoutAndRedirect() {
    userLogout();
    page.redirect('/');
}