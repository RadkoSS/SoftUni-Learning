import { userLogout } from "../api/user.js";

export async function logout(context){
    if(confirm('Are you sure you want to log out?')) {
        await userLogout();
        context.goTo('/');
    }
}