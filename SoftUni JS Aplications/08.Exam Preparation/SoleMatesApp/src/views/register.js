import { userRegister } from '../data/user.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export function showRegister(ctx) {
  ctx.render(registerTemplate(getFormData(onSubmit)));

  async function onSubmit(data, form) {
    const { email, password, rePassword } = data;

    if (!email || !password || !rePassword) {
      return alert(`There are empty fields.`);
    }

    if (password !== rePassword) {
      return alert(`Passwords don't match.`);
    }

    try {
      await userRegister(email, password);

      ctx.updateNav();
      ctx.page.redirect('/');
      form.reset();
    } catch (e) {
      console.log(e.message);
    }

  }
}

function registerTemplate(handler) {
  return html`
        <section id="register">
          <div class="form">
            <h2>Register</h2>
            <form @submit=${handler} class="login-form">
              <input type="text" name="email" id="register-email" placeholder="email" />
              <input type="password" name="password" id="register-password" placeholder="password" />
              <input type="password" name="rePassword" id="repeat-password" placeholder="repeat password" />
              <button type="submit">login</button>
              <p class="message">Already registered? <a href="/login">Login</a></p>
            </form>
          </div>
        </section>
    `;
}