function checkDigits(number){

    let numberAsString = `${number}`
    let checker = true

    let sum = Number(numberAsString[0])

    for(let digit = 0; digit < numberAsString.length - 1; digit++){
        let lastDigit = Math.floor(number % 10)

        let preLastDigit = Math.floor(number / 10 % 10)

        if(lastDigit !== preLastDigit){
            checker = false
        }
        sum += lastDigit

        number /= 10
    }

    return `${checker}\n${sum}`
}

console.log(checkDigits(2222222))