function validate() {
    const emailField = document.getElementById(`email`);
    emailField.addEventListener(`change`, validate);

    const emailRegEx = /^[a-z][a-z\d_]+\@[a-z]+\.[a-z]+$/g;

    function validate(event){
        if(!emailRegEx.test(emailField.value)){
            event.currentTarget.classList.add(`error`);
        } else{
            event.currentTarget.classList.remove(`error`);
        }
    }
}