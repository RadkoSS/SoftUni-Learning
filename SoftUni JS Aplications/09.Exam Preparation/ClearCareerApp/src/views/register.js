import { userRegister } from '../data/user.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export function showRegistration(ctx) {
    async function onSubmit(data, form) {
        const { email, password, rePassword } = data;
    
        if(!email || !password || !rePassword) {
            alert(`There are empty fields!`);
            return;
        }
    
        if(password !== rePassword) {
            alert(`Passwords don't match!`);
            return;
        }
        
        try {
            await userRegister(email, password);
    
            ctx.page.redirect('/dashboard');
            form.reset();
        } catch(error) {
            console.log(error.message);
        }
    }
    
    ctx.render(registrationTemplate(getFormData(onSubmit)));
}

function registrationTemplate(handler) {
    return html`
        <section id="register">
          <div class="form">
            <h2>Register</h2>
            <form @submit=${handler} class="login-form">
              <input
                type="text"
                name="email"
                id="register-email"
                placeholder="email"
              />
              <input
                type="password"
                name="password"
                id="register-password"
                placeholder="password"
              />
              <input
                type="password"
                name="rePassword"
                id="repeat-password"
                placeholder="repeat password"
              />
              <button type="submit">register</button>
              <p class="message">Already registered? <a href="/login">Login</a></p>
            </form>
          </div>
        </section>
    `;
}