async function lockedProfile() {
    const url = `http://localhost:3030/jsonstore/advanced/profiles`;
    const main = document.getElementById(`main`);

    try{
        const data = await getUsersData(url);
        appendUsersToPage(data, main);
        
    } catch (error){
        console.log(error.message);
    }
}

async function getUsersData(url){
    const request = await fetch(url);
    const data = request.json();

    return data;
}

function appendUsersToPage(data, main) {
    resetHTML(main);
    let index = 1;

    Object.entries(data).forEach(([id, userData]) => {
        const username = userData.username;
        const email = userData.email;
        const age = userData.age;

        const htmlToInject = `<img src="./iconProfile2.png" class="userIcon" />
        <label>Lock</label>
        <input type="radio" name="user${index}Locked" value="lock" checked>
        <label>Unlock</label>
        <input type="radio" name="user${index}Locked" value="unlock"><br>
        <hr>
        <label>Username</label>
        <input type="text" name="user${index}Username" value="${username}" disabled readonly />
        <div id="user${index}HiddenFields" style="display:none">
            <hr>
            <label>Email:</label>
            <input type="email" name="user${index}Email" value="${email}" disabled readonly />
            <label>Age:</label>
            <input type="email" name="user${index}Age" value="${age}" disabled readonly />
        </div>
        <button>Show more</button>`;

        elementFactory(`div`, main, htmlToInject, `class`, `profile`);

        index++;
    });

    document.querySelectorAll(`button`).forEach(btn => {
        btn.addEventListener(`click`, toggleVisibility)
    });
}

function toggleVisibility(event){
    const userLockButton = event.target.parentNode.children[2];
    
    if(userLockButton.checked){
        return;
    }

    const userHiddenDataID = `${event.target.previousElementSibling.id}`;
    
    const userHiddenInfo = document.getElementById(userHiddenDataID);

    userHiddenInfo.style.display = userHiddenInfo.style.display === `none` ? `block` : `none`;

    event.target.textContent = event.target.textContent === `Show more` ? `Hide it` : `Show more`;
}

function elementFactory(tag, parent, innerHTML = ``, ...attributes) {
    const element = document.createElement(tag);
    element.innerHTML = innerHTML;

    for(let index = 1; index < attributes.length; index += 2){
        element.setAttribute(`${attributes[index - 1]}`, `${attributes[index]}`);
    }

    if (parent) {
        parent.appendChild(element);
    }

    return element;
}

function resetHTML(main){
    main.innerHTML = ``;
}