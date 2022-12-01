import { editGameById, getDetailsById } from '../data/data.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export async function showEdit(ctx) {
    const id = ctx.params.id;

    const dataToEdit = await getDetailsById(id);

    async function onSubmit(data, form) {
        const formData = Object.fromEntries(data);

        const { title, category, maxLevel, imageUrl, summary } = formData;

        if (!title || !category || !maxLevel || !imageUrl || !summary) {
            return;
        }

        await editGameById(id, formData);

        ctx.page.redirect('/dashboard/' + id);
        form.reset();
    }

    ctx.render(editTemplate(dataToEdit, getFormData(onSubmit)));
}

function editTemplate(data, handler) {
    return html`
        <section id="edit-page" class="auth">
            <form @submit=${handler} id="edit">
                <div class="container">

                    <h1>Edit Game</h1>
                    <label for="leg-title">Legendary title:</label>
                    <input type="text" id="title" name="title" .value=${data.title}>

                    <label for="category">Category:</label>
                    <input type="text" id="category" name="category" .value=${data.category}>

                    <label for="levels">MaxLevel:</label>
                    <input type="number" id="maxLevel" name="maxLevel" min="1" .value=${data.maxLevel}>

                    <label for="game-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" .value=${data.imageUrl}>

                    <label for="summary">Summary:</label>
                    <textarea name="summary" id="summary" .value=${data.summary}></textarea>
                    <input class="btn submit" type="submit" value="Edit Game">

                </div>
            </form>
        </section>
    `;
}