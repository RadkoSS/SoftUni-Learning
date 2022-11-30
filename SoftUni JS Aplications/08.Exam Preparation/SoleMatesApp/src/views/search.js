import { searchByBrand } from '../data/data.js';
import { checkLoggedStatus } from '../data/user.js';
import { html, nothing, repeat } from '../utils/lib.js';
import { getFormData } from '../utils/util.js';

export async function showSearch(ctx) {
    const search = ctx.params.brand;

    const data = search && await searchByBrand(search);

    async function onSubmit(data) {
        const formData = Object.fromEntries(data);
        if(formData.search !== ''){
            ctx.page.redirect('/search/' + encodeURI(formData.search));
        }
    }
    
    ctx.render(searchTemplate(getFormData(onSubmit), data));
}

function searchTemplate(handler, data) {
    return html`
        <section id="search">
          <h2>Search by Brand</h2>

          <form @submit=${handler} class="search-wrapper cf">
            <input
              id="#search-input"
              type="text"
              name="search"
              placeholder="Search here..."
              required
            />
            <button type="submit">Search</button>
          </form>

          <h3>Results:</h3>

          <div id="search-container">
            <ul class="card-wrapper">
            ${ data && data.length !== 0 
                ? repeat(data, d => d._id, createCard) 
                : nothing
            }
            ${ data && data.length === 0 
            ? html`<h2>There are no results found.</h2>` 
            : nothing }
            </ul>
          </div>
        </section>
    `;
}

function createCard(data) {
    const altText = data.imageUrl.split('/').pop().split('.')[0];
    return html`
        <li class="card">
                <img src="${data.imageUrl}" alt=${altText} />
                <p>
                  <strong>Brand: </strong><span class="brand">${data.brand}</span>
                </p>
                <p>
                  <strong>Model: </strong
                  ><span class="model">${data.model}</span>
                </p>
                <p><strong>Value:</strong><span class="value">${data.value}</span>$</p>
                ${ checkLoggedStatus() == true 
                ? html`<a class="details-btn" href="/dashboard/${data._id}">Details</a>` 
                : nothing 
                }
              </li>
    `;
}