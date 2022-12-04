import { editAlbumById, getDetailsById } from '../data/data.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export async function showEdit(ctx) {
    const id = ctx.params.id;

    const dataToEdit = await getDetailsById(id);

    async function onSubmit(data, form) {
        const formData = Object.fromEntries(data);

        const { singer, album, imageUrl, release, label, sales } = formData;
        
        if (!singer || !album || !imageUrl || !release || !label || !sales) {
            return;
        }

        await editAlbumById(id, formData);

        ctx.page.redirect('/dashboard/' + id);
        form.reset();
    }

    ctx.render(editTemplate(dataToEdit, getFormData(onSubmit)));
}

function editTemplate(data, handler) {
    return html`
    <section id="edit">
        <div class="form">
          <h2>Edit Album</h2>
          <form @submit=${handler} class="edit-form">
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" .value=${data.singer}>
            <input type="text" name="album" id="album-album" placeholder="Album" .value=${data.album}>
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" .value=${data.imageUrl}>
            <input type="text" name="release" id="album-release" placeholder="Release date" .value=${data.release}>
            <input type="text" name="label" id="album-label" placeholder="Label" .value=${data.label}>
            <input type="text" name="sales" id="album-sales" placeholder="Sales" .value=${data.sales}>

            <button type="submit">post</button>
          </form>
        </div>
    </section>`;
}