import { addOffer } from '../data/data.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export function showCreate(ctx) {
    async function onSubmit(data, form) {
        const { title, imageUrl, category, description, requirements, salary } = data;

        if (!title || !imageUrl || !category || !description || !requirements || !salary) {
            return;
        }

        await addOffer(data);

        ctx.page.redirect('/dashboard');
        form.reset();
    }

    ctx.render(createTemplate(getFormData(onSubmit)));
}

function createTemplate(handler) {
    return html`
        <section id="create">
          <div class="form">
            <h2>Create Offer</h2>
            <form @submit=${handler} class="create-form">
              <input
                type="text"
                name="title"
                id="job-title"
                placeholder="Title"
              />
              <input
                type="text"
                name="imageUrl"
                id="job-logo"
                placeholder="Company logo url"
              />
              <input
                type="text"
                name="category"
                id="job-category"
                placeholder="Category"
              />
              <textarea
                id="job-description"
                name="description"
                placeholder="Description"
                rows="4"
                cols="50"
              ></textarea>
              <textarea
                id="job-requirements"
                name="requirements"
                placeholder="Requirements"
                rows="4"
                cols="50"
              ></textarea>
              <input
                type="text"
                name="salary"
                id="job-salary"
                placeholder="Salary"
              />

              <button type="submit">post</button>
            </form>
          </div>
        </section>
    `;
}