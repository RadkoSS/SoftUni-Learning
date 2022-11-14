export function initialize(links) {
    const mainSection = document.getElementById('main-view');

    document.getElementById('app-navigation').addEventListener('click', onNavigate);

    function showSection(section) {
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
        goTo
    }

    return context;
}