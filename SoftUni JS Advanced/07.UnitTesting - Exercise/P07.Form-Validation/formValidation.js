function validate() {
    
    const usernameField = document.getElementById(`username`);
    const emailField = document.getElementById(`email`);
    const passwordField = document.getElementById(`password`);
    const confirmPasswordField = document.getElementById(`confirm-password`);
    const companyCheckBox = document.getElementById(`company`);
    const companyInfo = document.getElementById(`companyInfo`);
    const companyNumber = document.getElementById(`companyNumber`);
    const submitFormButton = document.getElementById(`submit`);
    

    companyCheckBox.addEventListener(`change`, reveal);
    companyNumber.addEventListener(`change`, validateCompanyNumber)
    submitFormButton.addEventListener(`click`, validateUserData);

    const usernameRegEx = /^[[a-zA-Z0-9]{3,20}$/g;
    const emailRegEx = /^[a-z][a-z\d_]+\@[a-z]+\.[a-z]+$/g;
    const passwordRegEx = /^\w{5,15}$/g;

    
    function validateUserData(e){
        e.preventDefault();
        if (!usernameRegEx.test(usernameField.value)) {
            usernameField.classList.add(`error`);
        } else {
            usernameField.classList.remove(`error`);
        }
        if (!emailRegEx.test(emailField.value)) {
            emailField.classList.add(`error`);
        } else{
            emailField.classList.remove(`error`);
        }
        if (!passwordRegEx.test(passwordField.value)) {
            passwordField.classList.add(`error`);
        } else{
            passwordField.classList.remove(`error`);
        } 
        if (passwordField.value !== confirmPasswordField.value) {
            confirmPasswordField.classList.add(`error`);
        } else{
            confirmPasswordField.classList.remove(`error`);
        }
        
        submit();
    }

    function reveal(){
        let companyCheckBoxIsChecked = companyCheckBox.checked;
        if(companyCheckBoxIsChecked){
            companyInfo.style.display = `block`;    
        } else{
            companyInfo.style.display = `none`;
        }
    }

    function submit(){
        const userInfo = document.getElementById(`userInfo`).children;

        let userInfoArray = Array.from(userInfo);
        debugger
        let isValid = true;

        for(let index = 0; index < userInfoArray.length; index++){
            let currentData = userInfoArray[index].children[1].classList;
            debugger
        }

    }

    function validateCompanyNumber(e){
        if(companyNumber.value < 1000 || companyNumber.value > 9999){
            e.currentTarget.classList.add(`error`);
        } else{
            e.currentTarget.classList.remove(`error`);
        }
    }
}
