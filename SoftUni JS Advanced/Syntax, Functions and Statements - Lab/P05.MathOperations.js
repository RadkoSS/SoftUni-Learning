function solveExpression(firstNumber, secondNumber, operator) {
    switch(operator){
        case `+`:
            return firstNumber + secondNumber
            case `-`:
                return firstNumber - secondNumber
                case `*`:
                    return firstNumber * secondNumber
                    case `/`:
                        return firstNumber / secondNumber
                        case `%`:
                            return firstNumber % secondNumber
                            case `**`:
                                return firstNumber ** secondNumber
    }
}

console.log(solveExpression(3, 5.5, `*`))