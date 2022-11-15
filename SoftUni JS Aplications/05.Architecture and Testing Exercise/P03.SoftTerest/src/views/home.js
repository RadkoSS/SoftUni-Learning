import { checkLoggedStatus } from "../api/user.js";

const home = document.getElementById('home-view');
const getStartedBtn = document.getElementById('getStarted-Btn');

getStartedBtn.addEventListener('click', onClick);

let ctx = null;

export function homeView(context) {
    ctx = context;
    context.showSection(home);
}

function onClick(event) {
    event.preventDefault();
    
    const path = new URL(event.target.href).pathname;
    if (checkLoggedStatus()) {
        ctx.goTo(path);
    } else{
        ctx.goTo(`/login`);
    }
}