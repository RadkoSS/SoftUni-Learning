import { addGame } from '../data/data.js';
import { html } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export function showCreate(ctx) {
    async function onSubmit(data, form) {
        const formData = Object.fromEntries(data);
        const { title, category, maxLevel, imageUrl, summary } = formData;

        if (!title || !category || !maxLevel || !imageUrl || !summary) {
            return;
        }

        await addGame(formData);

        ctx.page.redirect('/');
        form.reset();
    }

    ctx.render(createTemplate(getFormData(onSubmit)));
}

function createTemplate(handler) {
    return html`
        <section id="create-page" class="auth">
            <form @submit=${handler} id="create">
                <div class="container">

                    <h1>Create Game</h1>
                    <label for="leg-title">Legendary title:</label>
                    <input type="text" id="title" name="title" placeholder="Enter game title...">

                    <label for="category">Category:</label>
                    <input type="text" id="category" name="category" placeholder="Enter game category...">

                    <label for="levels">MaxLevel:</label>
                    <input type="number" id="maxLevel" name="maxLevel" min="1" placeholder="1">

                    <label for="game-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" placeholder="Upload a photo...">

                    <label for="summary">Summary:</label>
                    <textarea name="summary" id="summary"></textarea>
                    <input class="btn submit" type="submit" value="Create Game">
                </div>
            </form>
        </section>
    `;
}