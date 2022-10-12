function validate() {
    const usernameField = document.getElementById(`username`);
    const emailField = document.getElementById(`email`);
    const passwordField = document.getElementById(`password`);
    const confirmPasswordField = document.getElementById(`confirm-password`);
    const companyCheckBox = document.getElementById(`company`);
    const companyInfo = document.getElementById(`companyInfo`);
    const companyNumber = document.getElementById(`companyNumber`);
    const submitFormButton = document.getElementById(`submit`);
    const validDiv = document.getElementById(`valid`);

    companyCheckBox.addEventListener(`change`, revealCompanyInfo);
    submitFormButton.addEventListener(`click`, validateUserData);

    const usernameRegEx = /^[a-zA-Z0-9]{3,20}$/g;
    const emailRegEx = /^[a-z][a-z\d_]+\@[a-z]+\.[a-z]+$/g;
    const passwordRegEx = /^\w{5,15}$/g;

    
    function validateUserData(e){
        e.preventDefault();
        
        let isValid = true;
        if (!usernameRegEx.test(usernameField.value)) {
            isValid = false;
            usernameField.style.borderColor = `red`;
        }
        if(!passwordRegEx.test(passwordField.value)){
            isValid = false;
            passwordField.style.borderColor = `red`;
            confirmPasswordField.style.borderColor = `red`;
        }
        if (passwordField.value !== confirmPasswordField.value) {
            isValid = false;
            passwordField.style.borderColor = `red`;
            confirmPasswordField.borderColor = `red`;
        }
        if(!emailRegEx.test(emailField.value)){
            isValid = false;
            emailField.style.borderColor = `red`;
        }
        if(companyCheckBox.checked && (companyNumber.value < 1000 || companyNumber.value > 9999)){
            isValid = false;
            companyNumber.style.borderColor = `red`;
        }
        
        submit(isValid);
    }

    function revealCompanyInfo(){
        let companyCheckBoxIsChecked = companyCheckBox.checked;
        if(companyCheckBoxIsChecked){
            companyInfo.style.display = `block`;
        } else{
            companyInfo.style.display = `none`;
        }
    }
    
    function submit(isValid){
        if(isValid){
            validDiv.style.display = `block`;
        } else{
            validDiv.style.display = `none`;
        }
    }
}
