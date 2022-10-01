function getArticleGenerator(articles) {
    let articlesReference = articles;
    let article = document.getElementById("content");

    return () => {
        if(!articlesReference.length){
            return;
        }
        article.innerHTML += `<article>${articlesReference.shift()}</article>`;
    }
}