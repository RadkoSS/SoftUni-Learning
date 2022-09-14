function aggregateElements(...numbers) {

    let sum = function (...numbers) {
        let temp = 0
        
        for(let i = 0; i < numbers.length; i++) {
            temp += numbers[i]
        }
        
        return temp.toString()
    }
    
    let inverseSum = function (...numbers) {
        let temp = 0

        for(let i = 0; i < numbers.length; i++) {
            temp += 1 / numbers[i]
        }

        return temp.toString()
    }

    let concat = function (...numbers) {
        let concatenated = new String()

        for(let i = 0; i < numbers.length; i++) {
            concatenated += numbers[i]
        }

        return concatenated
    }

    let result = `${sum(...numbers)}\n${inverseSum(...numbers)}\n${concat(...numbers)}`
    
    return result
}

console.log(aggregateElements(2,4,8,16))