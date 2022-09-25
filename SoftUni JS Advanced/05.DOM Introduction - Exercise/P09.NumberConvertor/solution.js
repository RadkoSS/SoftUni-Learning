function solve() {
    document.querySelector(`#container button`).addEventListener(`click`, result);

    function result(){
        let number = Number(document.getElementById(`input`).value);

        let convertType = document.getElementById(`selectMenuTo`).value;
        
        let result = ``;

        if(convertType === `binary`){
            result = (number >>> 0).toString(2);
        } else if(convertType === `hexadecimal`){
            result = number.toString(16).toUpperCase();
        } else {
            result = `Please select correct type!`;
        }

        document.getElementById(`result`).value = result;
    }
}