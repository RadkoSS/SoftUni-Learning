import { userLogin } from '../data/user.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export function showLogin(ctx) {
    ctx.render(loginTemplate(getFormData(onSubmit)));

    async function onSubmit(data, form) {
        const { email, password } = data;
        if(!email || !password) {
            return;
        }
        try {
            await userLogin(email, password);

            ctx.updateNav();
            form.reset();
            ctx.page.redirect('/');
        } catch (e) {
            console.log(e.message);
        }

    }
}

function loginTemplate(handler) {
    return html`
        <section id="login">
            <div class="form">
                <h2>Login</h2>
                <form @submit=${handler} class="login-form">
                    <input type="text" name="email" id="email" placeholder="email" />
                    <input type="password" name="password" id="password" placeholder="password" />
                    <button type="submit">login</button>
                    <p class="message">
                        Not registered? <a href="/register">Create an account</a>
                    </p>
                </form>
            </div>
        </section>
    `;
}