function sumAllNumbers(start, end){
    let sum = 0

    for(let number = Number(start); number <= Number(end); number++){
        sum += number
    }

    return sum
}

console.log(sumAllNumbers('-8', '20'))