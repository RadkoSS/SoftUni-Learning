import { deleteGameById, getAllComments, getDetailsById, postComment } from '../data/data.js';
import { html, repeat, nothing } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export async function showDetails(ctx) {
    const id = ctx.params.id;
    const details = await getDetailsById(id);
    const comments = await getAllComments(id);

    const isOwner = ctx.user && ctx.user._id === details._ownerId;

    async function onDelete() {
        await deleteGameById(id);
        ctx.page.redirect('/dashboard');
    }
    
    function onEdit() {
        ctx.page.redirect('/dashboard/edit/' + id);
    }

    async function onComment(data, form) {
        const formData = Object.fromEntries(data);

        if (formData.comment !== '') {
          debugger
          await postComment(id, formData.comment);
          ctx.page.redirect('/dashboard/' + id);
          form.reset();
        }
    }

    ctx.render(detailsTemplate(details, ctx.user, isOwner, onDelete, onEdit, comments, getFormData(onComment)));
}

function detailsTemplate(data, loggedStatus, ownerStatus, onDelete, onEdit, comments, handler) {
    return html`  
        <section id="game-details">
            <h1>Game Details</h1>
            <div class="info-section">

                <div class="game-header">
                    <img class="game-img" src=${data.imageUrl} />
                    <h1>${data.title}</h1>
                    <span class="levels">MaxLevel: ${data.maxLevel}</span>
                    <p class="type">${data.category}</p>
                </div>

                <p class="text">${data.summary}</p>

                <div class="details-comments">
                  <h2>Comments:</h2>
                    <ul>
                      ${ comments && comments.length !== 0 
                      ? repeat(comments, c => c._id, createComment) 
                      : html`<p class="no-comment">No comments.</p>` 
                      }    
                    </ul>
                  </div>
                
                ${ loggedStatus && ownerStatus 
                  ? html`<div class="buttons">
                    <a @click=${onEdit} href="javascript:void(0)" class="button">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="button">Delete</a>
                </div>` 
                : nothing 
                }
            </div>

            ${ loggedStatus && !ownerStatus 
              ? html`
                <article class="create-comment">
                <label>Add new comment:</label>
                <form @submit=${handler} class="form">
                    <textarea name="comment" placeholder="Comment......"></textarea>
                    <input class="btn submit" type="submit" value="Add Comment">
                </form>
            </article>
              ` 
              : nothing
              }
        </section>
    `;
}

function createComment(data) {
  return html`
    <li class="comment">
        <p>Content: ${data.comment}</p>
    </li>
  `;
}