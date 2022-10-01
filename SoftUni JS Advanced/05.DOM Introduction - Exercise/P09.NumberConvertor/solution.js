function solve() {
    document.querySelector(`#container button`).addEventListener(`click`, result);

    function result(){
        let number = Number(document.getElementById(`input`).value);
        let menu = document.getElementById(`selectMenuTo`);
        let output = document.getElementById(`result`);

        let optionBinary = document.createElement('option');
        optionBinary.value = 'binary';
        optionBinary.innerHTML = 'Binary';

        let optionHexadecimal = document.createElement('option');
        optionHexadecimal.value = 'hexadecimal';
        optionHexadecimal.innerHTML = 'Hexadecimal';

        menu.appendChild(optionBinary);
        menu.appendChild(optionHexadecimal);

        if(menu.value === `binary`){
            output.value = (number >>> 0).toString(2);
        } else if(menu.value === `hexadecimal`){
            output.value = number.toString(16).toUpperCase();
        } else {
            output.value = `Please select correct type!`;
        }
    }
}