window.addEventListener("load", solve);

function solve() {
    const postTitle = document.getElementById(`post-title`);
    const postCategory = document.getElementById(`post-category`);
    const postContent = document.getElementById(`post-content`);
    
    const reviewList = document.getElementById(`review-list`);
    const publishedList = document.getElementById(`published-list`);
    
    const clearBtn = document.getElementById(`clear-btn`);
    clearBtn.addEventListener(`click`, clearApprovedPosts);

    const publishBtn = document.getElementById(`publish-btn`);
    publishBtn.addEventListener(`click`, () =>{
      if(!validateInputs()){
        return;
      }

      let postTitleText = postTitle.value;
      let postCategoryText = postCategory.value;
      let postContentText = postContent.value;

      const newPost = elementFactory(`li`);
      newPost.setAttribute(`class`, `rpost`);

      const article = elementFactory(`article`);

      elementFactory(`h4`, `${postTitleText}`, article);
      elementFactory(`p`, `Category: ${postCategoryText}`, article);
      elementFactory(`p`, `Content: ${postContentText}`, article);
      newPost.appendChild(article);

      const approveBtn = elementFactory(`button`, `Approve`, newPost);
      approveBtn.setAttribute(`class`, `action-btn approve`);
      approveBtn.addEventListener(`click`, approvePost);
      
      const editBtn = elementFactory(`button`, `Edit`, newPost);
      editBtn.setAttribute(`class`, `action-btn edit`);
      editBtn.addEventListener(`click`, editPost);

      reviewList.appendChild(newPost);
      clearInputs();

      function editPost(event){
        event.preventDefault();
        event.target.parentNode.remove();

        postTitle.value = postTitleText;
        postCategory.value = postCategoryText;
        postContent.value = postContentText;
      }

      function approvePost(event){
        event.preventDefault();
        event.target.parentNode.remove();

        const approvedPost = elementFactory(`li`);
        approvedPost.setAttribute(`class`, `rpost`);
        approvedPost.appendChild(article);

        publishedList.appendChild(approvedPost);
      }

    });

    function validateInputs(){
      if(postTitle.value === `` || postCategory.value === `` || postContent.value === ``){
        return false;
      }
      return true;
    }

    function elementFactory(tag, content = ``, parent){
      const element = document.createElement(tag);
      element.textContent = content;
      
      if(parent) {
        parent.appendChild(element);
      }

      return element;
    }

    function clearApprovedPosts(event){
      event.preventDefault();

      let postArray = Array.from(publishedList.children);

      postArray.forEach(post => {
        publishedList.removeChild(post);
      });
    }
    
    function clearInputs() {
      postTitle.value = ``;
      postCategory.value = ``;
      postContent.value = ``;
    }
}