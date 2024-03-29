import { html, render } from './node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const root = document.getElementById('towns');
const result = document.getElementById('result');

document.querySelector('button').addEventListener('click', search);

renderTowns();

function renderTowns(match) {
   const result = loadAllTowns(towns, match);
   render(result, root)
}

function loadAllTowns(townsNames, match) {
   const ul = html`
      <ul>${townsNames.map(town => loadTown(town, match))}</ul>
   `
   return ul;
}

function loadTown(town, match) {
   //case-sensitive searching applied!
   return html`
      <li class="${match && town.includes(match) ? "active" : ""}">${town}</li>
   `
}

function search() {
   const searchedText = document.getElementById('searchText');

   renderTowns(searchedText.value);
   countMatches();

   searchedText.value = "";
}

function countMatches() {
   const count = document.querySelectorAll('.active').length;

   const countP = count ? html`<p>${count} matches found</p>` : "";

   render(countP, result);
}