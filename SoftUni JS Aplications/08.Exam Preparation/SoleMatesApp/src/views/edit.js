import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';
import { editShoesById, getDetailsById } from '../data/data.js'
 
export async function showEdit(ctx) {
    const shoesId = ctx.params.id;
    const data = await getDetailsById(shoesId);

    async function onSubmit(data, form) {
        const { brand, designer, imageUrl, model, release, value } = data;

        if(!brand || !designer || !imageUrl || !model || !release || !value) {
            return;
        }

        await editShoesById(shoesId, data);

        ctx.page.redirect(`/dashboard/${shoesId}`);
        form.reset();
    }
    
    ctx.render(editPageTemplate(data, getFormData(onSubmit)));
}

function editPageTemplate(data, handler) {
    return html`
        <section id="edit">
          <div class="form">
            <h2>Edit item</h2>
            <form @submit=${handler} class="edit-form">
              <input
                type="text"
                name="brand"
                id="shoe-brand"
                placeholder="Brand"
                .value=${data.brand}
              />
              <input
                type="text"
                name="model"
                id="shoe-model"
                placeholder="Model"
                .value=${data.model}
              />
              <input
                type="text"
                name="imageUrl"
                id="shoe-img"
                placeholder="Image url"
                .value=${data.imageUrl}
              />
              <input
                type="text"
                name="release"
                id="shoe-release"
                placeholder="Release date"
                .value=${data.release}
              />
              <input
                type="text"
                name="designer"
                id="shoe-designer"
                placeholder="Designer"
                .value=${data.designer}
              />
              <input
                type="text"
                name="value"
                id="shoe-value"
                placeholder="Value"
                .value=${data.value}
              />

              <button type="submit">post</button>
            </form>
          </div>
        </section>
    `
}