async function attachEvents() {
    const postsUrl = `http://localhost:3030/jsonstore/blog/posts`;
    const commentsUrl = `http://localhost:3030/jsonstore/blog/comments`;

    const postsSelector = document.getElementById(`posts`);
    const loadPostsBtn = document.getElementById(`btnLoadPosts`);
    const viewPostBtn = document.getElementById(`btnViewPost`);

    const postTitle = document.getElementById(`post-title`);
    const postBody = document.getElementById(`post-body`);
    const postComments = document.getElementById(`post-comments`);

    loadPostsBtn.addEventListener(`click`, getPosts);
    viewPostBtn.addEventListener(`click`, getPostsContent);

    async function getPosts() {
        postsSelector.innerHTML = ``;
        debugger
        const request = await fetch(postsUrl);
        const data = await request.json();

        Object.entries(data).forEach(([postId, postData]) => {
            elementFactory(`option`, postsSelector, postData.title, `value`, postData.id);
        });
    }

    async function getPostsContent() {

        const request = await fetch(`${postsUrl}/${postsSelector.value}`);
        const data = await request.json();

        const { body, id, title } = data;

        postTitle.textContent = title.toUpperCase();
        postBody.textContent = body;

        await appendComments(id);
    }

    async function appendComments(idToMatch) {
        postComments.innerHTML = ``;

        const request = await fetch(commentsUrl);
        const data = await request.json();

        Object.entries(data).forEach(([key, value]) => {
            const { id, postId, text } = value;

            if (postId !== idToMatch) {
                return;
            }

            elementFactory(`li`, postComments, text, `id`, id);
        });
    }
}

function elementFactory(tag, parent, content = ``, ...attributes) {
    const element = document.createElement(tag);
    element.textContent = content;

    for (let index = 1; index < attributes.length; index += 2) {
        element.setAttribute(`${attributes[index - 1]}`, `${attributes[index]}`);
    }

    if (parent) {
        parent.appendChild(element);
    }

    return element;
}

attachEvents();