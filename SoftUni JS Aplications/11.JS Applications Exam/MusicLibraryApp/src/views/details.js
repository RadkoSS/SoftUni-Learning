import { checkLikedState, deleteAlbumById, getDetailsById, getLikesCount, likeAlbum } from '../data/data.js';
import { html, nothing } from '../utils/lib.js';

export async function showDetails(ctx) {
  const id = ctx.params.id;

  let requests = [
    getDetailsById(id),
    getLikesCount(id)
  ];

  if (ctx.user) {
    requests.push(checkLikedState(id, ctx.user._id));
  }

  const [details, likesCount, likedStatus] = await Promise.all(requests);

  const isOwner = ctx.user?._id === details._ownerId ? true : false;
  const canLike = ctx.user && !isOwner && likedStatus == 0 ? true : false;

  async function onDelete() {
    if (confirm('Are you sure you want to delete this album?')) {
      await deleteAlbumById(id);
      ctx.page.redirect('/dashboard');
    }
  }

  function onEdit() {
    ctx.page.redirect('/dashboard/edit/' + id);
  }

  async function onLike() {
    await likeAlbum(id);
    ctx.page.redirect('/dashboard/' + id);
  }

  ctx.render(detailsTemplate(details, ctx.user, isOwner, canLike, onDelete, onEdit, onLike, likesCount));
}

function detailsTemplate(data, loggedStatus, ownerStatus, canLike, onDelete, onEdit, onLike, likesCount) {
  return html`
      <section id="details">
        <div id="details-wrapper">
          <p id="details-title">Album Details</p>
          <div id="img-wrapper">
            <img src=".${data.imageUrl}" alt="example1" />
          </div>
          <div id="info-wrapper">
            <p><strong>Band:</strong><span id="details-singer">${data.singer}</span></p>
            <p>
              <strong>Album name:</strong><span id="details-album">${data.album}</span>
            </p>
            <p><strong>Release date:</strong><span id="details-release">${data.release}</span></p>
            <p><strong>Label:</strong><span id="details-label">${data.label}</span></p>
            <p><strong>Sales:</strong><span id="details-sales">${data.sales}</span></p>
          </div>
          <div id="likes">Likes: <span id="likes-count">${likesCount}</span></div>
      
          ${createButtons()}
        </div>
      </section>
    `;

  function createButtons() {
    if (loggedStatus && canLike) {
      return html`<div id="action-buttons">
                      <a @click=${onLike} href="javascript:void(0)" id="like-btn">Like</a>
                  </div>`;
    } if (ownerStatus) {
      return html`<div id="action-buttons">
                      <a @click=${onEdit} href="javascript:void(0)" id="edit-btn">Edit</a>
                      <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>
                  </div>`;
    }
    return nothing;
  }
}

