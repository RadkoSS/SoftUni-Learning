import { userLogin } from '../data/user.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export function showLogin(ctx) {
    async function onSubmit(data, form) {
        const { email, password } = Object.fromEntries(data);
    
        if(!email || !password) {
            return;
        }
    
        try {
            await userLogin(email, password);
    
            ctx.page.redirect('/');
            form.reset();
        } catch(error) {
            console.log(error.message);
        }
    }

    ctx.render(loginTemplate(getFormData(onSubmit)));
}

function loginTemplate(handler) {
    return html`
        <section id="login-page" class="auth">
            <form @submit=${handler} id="login">

                <div class="container">
                    <div class="brand-logo"></div>
                    <h1>Login</h1>
                    <label for="email">Email:</label>
                    <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">

                    <label for="login-pass">Password:</label>
                    <input type="password" id="login-password" name="password">
                    <input type="submit" class="btn submit" value="Login">
                    <p class="field">
                        <span>If you don't have profile click <a href="/register">here</a></span>
                    </p>
                </div>
            </form>
        </section>
    `;
}