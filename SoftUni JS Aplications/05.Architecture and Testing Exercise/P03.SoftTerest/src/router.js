import { checkLoggedStatus } from "./api/user.js";

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

    function goTo(path) {
        const handler = links[path];

        if (typeof handler !== 'function') {
            return;
        }
        handler(context);
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
        //TODO
        document.querySelectorAll('.user').forEach(e => e.style.display = 'block');
        document.querySelectorAll('.guest').forEach(e => e.style.display = 'none');
    } else {
        document.querySelectorAll('.user').forEach(e => e.style.display = 'none');
        document.querySelectorAll('.guest').forEach(e => e.style.display = 'block');
    }
}