import { addAlbum } from '../data/data.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export function showCreate(ctx) {
    async function onSubmit(data, form) {
        const formData = Object.fromEntries(data);
        const { singer, album, imageUrl, release, label, sales } = formData;
        
        if (!singer || !album || !imageUrl || !release || !label || !sales) {
            return;
        }

        await addAlbum(formData);

        ctx.page.redirect('/dashboard');
        form.reset();
    }

    ctx.render(createTemplate(getFormData(onSubmit)));
}

function createTemplate(handler) {
    return html`
    <section id="create">
        <div class="form">
          <h2>Add Album</h2>
          <form @submit=${handler} class="create-form">
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
            <input type="text" name="album" id="album-album" placeholder="Album" />
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
            <input type="text" name="release" id="album-release" placeholder="Release date" />
            <input type="text" name="label" id="album-label" placeholder="Label" />
            <input type="text" name="sales" id="album-sales" placeholder="Sales" />

            <button type="submit">post</button>
          </form>
        </div>
    </section>`;
}