import { userLogin } from "../api/user.js";

const login = document.getElementById('login-view');

login.querySelector('.notUser').addEventListener('click', redirectToRegister);

const loginForm = login.getElementsByTagName('form')[0];
loginForm.addEventListener('submit', onLoginSubmit);

let ctx = null;

export function loginView(context) {
    ctx = context;

    context.showSection(login);
}

async function onLoginSubmit(event) {
    event.preventDefault();

    const { email, password } = Object.fromEntries(new FormData(loginForm));

    await userLogin(email, password);

    ctx.goTo(`/dashboard`);

    loginForm.reset();
}

function redirectToRegister(event) {
    event.preventDefault();

    const path = new URL(event.target.href).pathname;
    
    ctx.goTo(path);
    loginForm.reset();
}