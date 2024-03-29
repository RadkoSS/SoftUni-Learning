import { editOfferById, getDetailsById } from '../data/data.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export async function showEdit(ctx) {
    const id = ctx.params.id;

    const dataToEdit = await getDetailsById(id);

    async function onSubmit(data, form) {
        const formData = Object.fromEntries(data);

        const { title, imageUrl, category, description, requirements, salary } = formData;

        if (!title || !imageUrl || !category || !description || !requirements || !salary) {
            return;
        }

        await editOfferById(id, formData);

        ctx.page.redirect('/dashboard/' + id);
        form.reset();
    }

    ctx.render(editTemplate(dataToEdit, getFormData(onSubmit)));
}

function editTemplate(data, handler) {
    return html`
        <section id="edit">
          <div class="form">
            <h2>Edit Offer</h2>
            <form @submit=${handler} class="edit-form">
              <input
                type="text"
                name="title"
                id="job-title"
                placeholder="Title"
                .value=${data.title}
              />
              <input
                type="text"
                name="imageUrl"
                id="job-logo"
                placeholder="Company logo url"
                .value=${data.imageUrl}
              />
              <input
                type="text"
                name="category"
                id="job-category"
                placeholder="Category"
                .value=${data.category}
              />
              <textarea
                id="job-description"
                name="description"
                placeholder="Description"
                rows="4"
                cols="50"
                .value=${data.description}
              ></textarea>
              <textarea
                id="job-requirements"
                name="requirements"
                placeholder="Requirements"
                rows="4"
                cols="50"
                .value=${data.requirements}
              ></textarea>
              <input
                type="text"
                name="salary"
                id="job-salary"
                placeholder="Salary"
                .value=${data.salary}
              />

              <button type="submit">post</button>
            </form>
          </div>
        </section>
    `
}