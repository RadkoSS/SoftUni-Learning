import { userRegister } from '../data/user.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export function showRegistration(ctx) {
  async function onSubmit(data, form) {
    const email = data.get("email");
    const password = data.get("password");
    const rePassword = data.get("confirm-password");

    if (!email || !password || !rePassword) {
      return alert(`There are empty fields!`);
    }

    if (password !== rePassword) {
      return alert(`Passwords don't match!`);
    }

    try {
      await userRegister(email, password);

      ctx.page.redirect('/');
      form.reset();
    } catch (error) {
      console.log(error.message);
    }
  }

  ctx.render(registrationTemplate(getFormData(onSubmit)));
}

function registrationTemplate(handler) {
  return html`
        <section id="register-page" class="content auth">
          <form @submit=${handler} id="register">
            <div class="container">
              <div class="brand-logo"></div>
              <h1>Register</h1>
        
              <label for="email">Email:</label>
              <input type="email" id="email" name="email" placeholder="maria@email.com">
        
              <label for="pass">Password:</label>
              <input type="password" name="password" id="register-password">
        
              <label for="con-pass">Confirm Password:</label>
              <input type="password" name="confirm-password" id="confirm-password">
        
              <input class="btn submit" type="submit" value="Register">
        
              <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
              </p>
            </div>
          </form>
        </section>
    `;
}