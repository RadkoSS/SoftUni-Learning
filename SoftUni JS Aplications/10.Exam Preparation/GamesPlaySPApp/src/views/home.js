import { mostRecentGames } from '../data/data.js';
import { html } from '../utils/lib.js';

export async function showHome(ctx) {
  const games = await mostRecentGames();

  ctx.render(homeTemplate(games));
}

function homeTemplate(gamesList) {
  return html`
        <section id="welcome-world">
          <div class="welcome-message">
            <h2>ALL new games are</h2>
            <h3>Only in GamesPlay</h3>
          </div>
          <img src="./images/four_slider_img01.png" alt="hero">
        
          <div id="home-page">
            <h1>Latest Games</h1>
            ${!gamesList || gamesList.length === 0 
            ? html`<p class="no-articles">No games yet</p>` 
            : gamesList.map(displayThreeMostRecentGames)
            }
          </div>
    `;
}

function displayThreeMostRecentGames(game) {
  return html`
      <div class="game">
        <div class="image-wrap">
          <img src=${game.imageUrl}>
        </div>
        <h3>${game.title}</h3>
        <div class="rating">
          <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
        </div>
        <div class="data-buttons">
          <a href="/dashboard/${game._id}" class="btn details-btn">Details</a>
        </div>
      </div>
  `;
}