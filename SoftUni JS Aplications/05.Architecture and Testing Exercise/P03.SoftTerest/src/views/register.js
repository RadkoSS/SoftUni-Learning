import { userRegister } from "../api/user.js";

const register = document.getElementById('register-view');
register.querySelector('.alreadyUser').addEventListener('click', redirectToLogin)

const registerForm = register.getElementsByTagName('form')[0];
registerForm.addEventListener('submit', onRegisterSubmit);

let ctx = null;

export function registerView(context) {
    ctx = context;

    context.showSection(register);
}

async function onRegisterSubmit(event) {
    event.preventDefault();

    const { email, password, repeatPassword } = Object.fromEntries(new FormData(registerForm));

    if (email.length < 3 || password.length < 3) {
        formReset('Email and password must be at least 3 symbols!');
        return;
    }
    if (password !== repeatPassword) {
        formReset('Passwords do not match!');
        return;
    }

    await userRegister(email, password);

    ctx.goTo(`/dashboard`);
    formReset();
}

function formReset(error) {
    if(error){
        alert(error);
    }
    registerForm.reset();
}

function redirectToLogin(event) {
    event.preventDefault();

    const path = new URL(event.target.href).pathname;

    ctx.goTo(path);
    formReset();
}