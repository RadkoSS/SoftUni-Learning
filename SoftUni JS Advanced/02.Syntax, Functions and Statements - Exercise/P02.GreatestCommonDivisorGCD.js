function findGCD(firstNum, secondNum){
    let smallerNumber = firstNum >= secondNum ? secondNum : firstNum

    let greatestCommonDivisor = 1

    for(let number = 2; number <= smallerNumber; number++){

        if(firstNum % number === 0 && secondNum % number === 0){
            greatestCommonDivisor = number
        }
    }

    return greatestCommonDivisor
}

console.log(findGCD(2200, 460))