import { addShoes } from '../data/data.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export function showCreate(ctx) {
  ctx.render(createViewTemplate(getFormData(onSubmit)));

  async function onSubmit(data, form) {
    const formData = Object.fromEntries(data);
    const { brand, model, imageUrl, release, designer, value } = formData;

    if (!brand || !model || !imageUrl || !release || !designer || !value) {
      return;
    }

    await addShoes(formData);

    form.reset();
    ctx.page.redirect('/dashboard');
  }
}

function createViewTemplate(handler) {
  return html`
        <section id="create">
          <div class="form">
            <h2>Add item</h2>
            <form @submit=${handler} class="create-form">
              <input type="text" name="brand" id="shoe-brand" placeholder="Brand" />
              <input type="text" name="model" id="shoe-model" placeholder="Model" />
              <input type="text" name="imageUrl" id="shoe-img" placeholder="Image url" />
              <input type="text" name="release" id="shoe-release" placeholder="Release date" />
              <input type="text" name="designer" id="shoe-designer" placeholder="Designer" />
              <input type="text" name="value" id="shoe-value" placeholder="Value" />
        
              <button type="submit">post</button>
            </form>
          </div>
        </section>
    `
}