import { getUserData } from '../utils/util.js';
import { html, nothing } from '../utils/lib.js';
import { deleteShoesById, getDetailsById } from '../data/data.js'

export async function showDetails(ctx) {
    const userData = getUserData();
    const shoesId = ctx.params.id;

    const data = await getDetailsById(shoesId);

    const isCreator = userData && data._ownerId === userData._id;

    async function onDelete() {
        if (confirm('Are you sure you want to delete this card?')) {
            await deleteShoesById(shoesId);

            ctx.page.redirect('/dashboard');
        }
    }

    ctx.render(detailsTemplate(isCreator, data, onDelete));
}

function detailsTemplate(isCreator, data, handler) {
    const altText = data.imageUrl.split('/').pop().split('.')[0];
    return html`
    <section id="details">
        <div id="details-wrapper">
            <p id="details-title">Shoe Details</p>
            <div id="img-wrapper">
                <img src="${data.imageUrl}" alt=${altText} />
            </div>
            <div id="info-wrapper">
                <p>Brand: <span id="details-brand">${data.brand}</span></p>
                <p>
                    Model: <span id="details-model">${data.model}</span>
                </p>
                <p>Release date: <span id="details-release">${data.release}</span></p>
                <p>Designer: <span id="details-designer">${data.designer}</span></p>
                <p>Value: <span id="details-value">${data.value}</span></p>
            </div>
    
            ${ isCreator ? 
                html`<div id="action-buttons">
                <a href="/dashboard/edit/${data._id}" id="edit-btn">Edit</a>
                <a @click=${handler} href="javascript:void(0)" id="delete-btn">Delete</a>
                </div>` 
                : nothing 
            }
    
        </div>
    </section>
    `
}