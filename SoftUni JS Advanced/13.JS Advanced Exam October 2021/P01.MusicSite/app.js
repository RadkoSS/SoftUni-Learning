window.addEventListener('load', solve);

function solve() {
    const genre = findElement(`genre`);
    const song = findElement(`name`);
    const author = findElement(`author`);
    const date = findElement(`date`);
    
    const addBtn = findElement(`add-btn`);
    addBtn.addEventListener(`click`, addToCollection);

    const collectionOfSongs = findElement(`all-hits-container`);
    const savedSongs = findElement(`saved-container`);
    const likesCounter = findElement(`likes`).children[0];

    let numberOfLikes = 0;

    function addToCollection(event){
        event.preventDefault();

        if(!validateInputs()){
            return;
        }

        let genreName = genre.value;
        let songName = song.value;
        let authorName = author.value;
        let dateText = date.value;

        let div = elementFactory(`div`);
        div.setAttribute(`class`, `hits-info`);

        let image = elementFactory(`img`);
        image.setAttribute(`src`, `./static/img/img.png`);
        // image.setAttribute(`alt`, `image`);
        div.appendChild(image);

        elementFactory(`h2`, `Genre: ${genreName}`, div);
        elementFactory(`h2`, `Name: ${songName}`, div);
        elementFactory(`h2`, `Author: ${authorName}`, div);
        elementFactory(`h3`, `Date: ${dateText}`, div);
        
        let saveBtn = elementFactory(`button`, `Save song`);
        saveBtn.setAttribute(`class`, `save-btn`);
        saveBtn.addEventListener(`click`, saveSong);

        let likeBtn = elementFactory(`button`, `Like song`);
        likeBtn.setAttribute(`class`, `like-btn`);
        likeBtn.addEventListener(`click`, likeSong);

        let deleteBtn = elementFactory(`button`, `Delete`);
        deleteBtn.setAttribute(`class`, `delete-btn`);
        deleteBtn.addEventListener(`click`, deleteSong);

        div.appendChild(saveBtn);
        div.appendChild(likeBtn);
        div.appendChild(deleteBtn);

        collectionOfSongs.appendChild(div);
        clearInputs();

        function likeSong(event){
            event.preventDefault();
            
            event.target.disabled = true;
            
            likesCounter.textContent = `Total Likes: ${++numberOfLikes}`;
        }
        
        function saveSong(event) {
            event.preventDefault();
            
            event.target.parentNode.remove();
            
            div.removeChild(saveBtn);
            div.removeChild(likeBtn);
            savedSongs.appendChild(div);
        }
    
        function deleteSong(event){
            event.preventDefault();
    
            event.target.parentNode.remove();
        }
    }

    function elementFactory(tag, content = ``, parent) {
        const element = document.createElement(tag);
        element.textContent = content;

        if (parent) {
            parent.appendChild(element);
        }

        return element;
    }

    function findElement(idOrClass){
        let element = document.getElementById(idOrClass);

        if(!element){
            element = document.querySelector(`.${idOrClass}`);
        }
        return element;
    }

    function validateInputs(){
        if(genre.value === `` || song.value === `` || author.value === `` || date.value === ``){
            return false;
        }
        return true;
    }

    function clearInputs(){
        genre.value = ``;
        song.value = ``;
        author.value = ``;
        date.value = ``;
    }
}