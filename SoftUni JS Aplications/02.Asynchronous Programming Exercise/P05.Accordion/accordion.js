window.addEventListener(`load`, solution);

async function solution() {
    const mainSection = document.getElementById(`main`);

    const titlesUrl = `http://localhost:3030/jsonstore/advanced/articles/list`;

    try{
        const titles = await getTitlesData(titlesUrl);

        titles.forEach(async data => {
            const accordionDiv = elementFactory(`div`, mainSection, ``, `class`, `accordion`);

            const div = elementFactory(`div`, accordionDiv, ``, `class`, `head`);

            elementFactory(`span`, div, `${data.title}`);
            
            const button = elementFactory(`button`, div, `More`, `class`, `button`, `id`, `${data._id}`);

            const contentData = await getContentData(data._id);

            const extraDiv = elementFactory(`div`, accordionDiv, ``, `class`, `extra`);
            elementFactory(`p`, extraDiv, `${contentData}`);

            button.addEventListener(`click`, toggleInformation);
        });

    } catch(error){
        console.log(error.message);
    }
}

async function getTitlesData(dataUrl){
    const request = await fetch(dataUrl);
    const data = await request.json();

    return data;
}

async function getContentData(id){
    const contentUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;

    const request = await fetch(contentUrl);
    const data = await request.json();

    return data.content;
}

function toggleInformation(event){
    const toggledDiv = event.target.parentNode.parentNode.children[1];
    const button = event.target;

    toggledDiv.style.display = toggledDiv.style.display === `block` ? `none` : `block`;
    
    button.textContent = toggledDiv.style.display === `block` ? `Less` : `More`;
}

function elementFactory(tag, parent, content = ``, ...attributes) {
    const element = document.createElement(tag);
    element.textContent = content;

    for(let index = 1; index < attributes.length; index += 2){
        element.setAttribute(`${attributes[index - 1]}`, `${attributes[index]}`);
    }

    if (parent) {
        parent.appendChild(element);
    }

    return element;
}