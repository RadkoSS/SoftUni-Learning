import { findElement } from './util.js';
import { post } from './requests.js';

const loginForm = findElement(`login-form`);
loginForm.addEventListener(`submit`, onSubmit);

const notification = findElement(`#login-form > p.notification`);

async function onSubmit(event) {
    event.preventDefault();
    try {
        const { email, password } = Object.fromEntries(new FormData(loginForm));
        
        const data = await post(`/users/login`, null, { email, password });

        sessionStorage.setItem(`email`, data.email);
        sessionStorage.setItem(`accessToken`, data.accessToken);

        window.location = `./index.html`;
    } catch (error) {
        notification.textContent = `Error`;
        
        setTimeout(() => {
            notification.textContent = ``;
        }, 3000);
    }
}