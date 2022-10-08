function notify(message) {
    let notificationDiv = document.getElementById(`notification`);

    notificationDiv.textContent = message;

    let currentState = notificationDiv.style.display;
    notificationDiv.style.display = currentState === `none` || currentState === `` ? `block` : `none`;
    
    notificationDiv.addEventListener(`click`, toggleOff);

    function toggleOff(){
        notificationDiv.style.display = `none`;
    }
}