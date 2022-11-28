import { applicationsCount, checkIfUserIsOwner, deleteOfferById, getDetailsById, updateApplicationsCount } from '../data/data.js';
import { html, nothing } from '../utils/lib.js';

export async function showDetails(ctx) {
    const id = ctx.params.id;
    const details = await getDetailsById(id);
    const count = await applicationsCount(id);

    const isLiked = ctx.user && await checkIfUserIsOwner(id, ctx.user._id) == 1;
    const isOwner = ctx.user && ctx.user._id === details._ownerId;

    async function onDelete() {
        await deleteOfferById(id);
        ctx.page.redirect('/dashboard');
    }
    
    async function onApply() {
        await updateApplicationsCount(id);
        ctx.page.redirect('/dashboard/' + id);
    }

    ctx.render(detailsTemplate(details, ctx.user, isOwner, isLiked, onDelete, onApply, count));
}

function detailsTemplate(data, loggedStatus, ownerStatus, isLiked, onDelete, onApply, count) {
    return html`
        <section id="details">
          <div id="details-wrapper">
            <img id="details-img" src="${data.imageUrl}" alt="example" />
            <p id="details-title">${data.title}</p>
            <p id="details-category">
              Category: <span id="categories">${data.category}</span>
            </p>
            <p id="details-salary">
              Salary: <span id="salary-number">${data.salary}</span>
            </p>
            <div id="info-wrapper">
              <div id="details-description">
                <h4>Description</h4>
                <span>${data.description}</span>
              </div>
              <div id="details-requirements">
                <h4>Requirements</h4>
                <span>${data.requirements}</span>
              </div>
            </div>
            <p>Applications: <strong id="applications">${count}</strong></p>

            ${ loggedStatus && ownerStatus
            ? html`
            <div id="action-buttons">
              <a href="/dashboard/edit/${data._id}" id="edit-btn">Edit</a>
              <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>
            </div>
            ` 
            : loggedStatus && !ownerStatus && !isLiked
            ? html`
            <div id="action-buttons">
              <a @click=${onApply} href="javascript:void(0)" id="apply-btn">Apply</a>
            </div>
            `
            : nothing
            }
          </div>
        </section>
    `;
}