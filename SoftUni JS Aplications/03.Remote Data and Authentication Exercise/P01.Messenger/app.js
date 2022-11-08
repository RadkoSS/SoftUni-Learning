const author = document.getElementsByName(`author`)[0];
const content = document.getElementsByName(`content`)[0];
const textArea = document.getElementById(`messages`);

const url = `http://localhost:3030/jsonstore/messenger`;


function attachEvents() {
    const submitBtn = document.getElementById(`submit`);
    const refreshBtn = document.getElementById(`refresh`);

    submitBtn.addEventListener(`click`, sendMessage);
    refreshBtn.addEventListener(`click`, refreshMessages)
}

async function sendMessage(event){
    event.preventDefault();

    await fetch(url, headersGenerator(`post`, {
        author: author.value,
        content: content.value
    }));

    resetInputs();
}

async function refreshMessages(event){
    event.preventDefault();

    const request = await fetch(url);

    const messages = Object.values(await request.json()).map(msg => `${msg.author}: ${msg.content}`).join(`\n`);
    
    textArea.textContent = messages;
}

function headersGenerator(type, data){
    const parsedData = JSON.stringify(data);
    
    const headers = {
        method: `${type}`,
        headers: {
            'Content-Type': 'application/json'
        }
    }
    if(parsedData){
        headers.body = parsedData;
    }
    return headers;
}

function resetInputs(){
    author.value = ``;
    content.value = ``;
}

attachEvents();