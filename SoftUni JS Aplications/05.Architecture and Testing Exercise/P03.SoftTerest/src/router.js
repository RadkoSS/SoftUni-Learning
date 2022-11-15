import { checkLoggedStatus } from "./api/user.js";

const loggedUserNav = document.querySelectorAll('.user');
const guestNav = document.querySelectorAll('.guest');

export function initialize(links) {
    const mainSection = document.getElementById('main-view');

    document.getElementById('app-navigation').addEventListener('click', onNavigate);

    function showSection(section) {
        updateNavigation();
        mainSection.replaceChildren(section);
    }

    function onNavigate(event) {
        event.preventDefault();

        let target = event.target;

        if (target.tagName === 'IMG') {
            target = target.parentElement;
        }
        if (target.tagName !== 'A') {
            return;
        }
        const path = new URL(target.href).pathname;

        goTo(path);
    }

    function goTo(path, htmlToInject) {
        const handler = links[path];

        if (typeof handler !== 'function') {
            return;
        }
        handler(context, htmlToInject);
    }

    const context = {
        showSection,
        goTo,
        updateNavigation
    }

    return context;
}

function updateNavigation(){
    if(checkLoggedStatus()){
        loggedUserNav.forEach(e => e.style.display = 'block');

        guestNav.forEach(e => e.style.display = 'none');
    } else {
        loggedUserNav.forEach(e => e.style.display = 'none');

        guestNav.forEach(e => e.style.display = 'block');
    }
}