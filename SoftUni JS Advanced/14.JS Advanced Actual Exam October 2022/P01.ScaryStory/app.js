window.addEventListener("load", solve);

function solve() {
  const mainDiv = findElement(`main`);
  const allMainDivContent = Array.from(findElement(`main`).children);

  const firstName = findElement(`first-name`);
  const lastName = findElement(`last-name`);
  const age = findElement(`age`);
  const storyTitle = findElement(`story-title`);
  const genre = findElement(`genre`);
  const storyText = findElement(`story`);

  const publishBtn = findElement(`form-btn`);
  publishBtn.addEventListener(`click`, publishStory);

  const previewSection = findElement(`preview-list`);

  function publishStory(event) {
    event.preventDefault();

    if (!validateInputs()) {
      return;
    }
    event.target.disabled = true;

    let firstNameValue = firstName.value;
    let lastNameValue = lastName.value;
    let ageValue = age.value;
    let storyTitleValue = storyTitle.value;
    let genreValue = genre.value;
    let storyTextValue = storyText.value;

    let liWithStory = elementFactory(`li`);
    liWithStory.setAttribute(`class`, `story-info`);

    let article = elementFactory(`article`);

    elementFactory(`h4`, `Name: ${firstNameValue} ${lastNameValue}`, article);
    elementFactory(`p`, `Age: ${ageValue}`, article);
    elementFactory(`p`, `Title: ${storyTitleValue}`, article);
    elementFactory(`p`, `Genre: ${genreValue}`, article);
    elementFactory(`p`, `${storyTextValue}`, article);

    liWithStory.appendChild(article);

    let saveBtn = elementFactory(`button`, `Save Story`);
    saveBtn.setAttribute(`class`, `save-btn`);
    saveBtn.addEventListener(`click`, saveStory);

    let editBtn = elementFactory(`button`, `Edit Story`);
    editBtn.setAttribute(`class`, `edit-btn`);
    editBtn.addEventListener(`click`, editStory);

    let deleteBtn = elementFactory(`button`, `Delete Story`);
    deleteBtn.setAttribute(`class`, `delete-btn`);
    deleteBtn.addEventListener(`click`, deleteStory);

    liWithStory.appendChild(saveBtn);
    liWithStory.appendChild(editBtn);
    liWithStory.appendChild(deleteBtn);

    clearInputs();
    previewSection.appendChild(liWithStory);

    function saveStory(event) {
      event.preventDefault();

      allMainDivContent.forEach(element => element.remove());

      elementFactory(`h1`, `Your scary story is saved!`, mainDiv);
    }

    function editStory(event) {
      event.preventDefault();
      event.target.parentNode.remove();

      firstName.value = firstNameValue;
      lastName.value = lastNameValue;
      age.value = ageValue;
      storyTitle.value = storyTitleValue;
      genre.value = genreValue;
      storyText.value = storyTextValue;

      publishBtn.disabled = false;
    }

    function deleteStory(event) {
      event.preventDefault();
      event.target.parentNode.remove();

      publishBtn.disabled = false;
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

  function findElement(idOrClass) {
    let element = document.getElementById(idOrClass);

    if (!element) {
      element = document.querySelector(`.${idOrClass}`);
    }
    return element;
  }

  function validateInputs() {
    if (firstName.value === `` || lastName.value === `` || age.value === `` || storyTitle.value === `` || genre.value === `` || storyText.value === ``) {
      return false;
    }
    return true;
  }

  function clearInputs() {
    firstName.value = ``;
    lastName.value = ``;
    age.value = ``;
    storyTitle.value = ``;
    genre.value = ``;
    storyText.value = ``;
  }
}