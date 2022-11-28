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
    
            ctx.page.redirect('/dashboard');
            form.reset();
        } catch(error) {
            console.log(error.message);
        }
    }

    ctx.render(loginTemplate(getFormData(onSubmit)));
}

function loginTemplate(handler) {
    return html`
        <section id="login">
          <div class="form">
            <h2>Login</h2>
            <form @submit=${handler} class="login-form">
              <input type="text" name="email" id="email" placeholder="email" />
              <input
                type="password"
                name="password"
                id="password"
                placeholder="password"
              />
              <button type="submit">login</button>
              <p class="message">
                Not registered? <a href="/register">Create an account</a>
              </p>
            </form>
          </div>
        </section>
    `;
}