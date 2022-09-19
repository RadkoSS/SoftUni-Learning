function sortNumbers(numbers){
    numbers.sort((a, b) => a - b);
    
    let numbersCount = numbers.length;
    
    sortedArray = [];
    for(let index = 0; index < numbersCount; index++){

        if(index % 2 === 0){
            sortedArray.push(numbers.shift());

        } else{

            sortedArray.push(numbers.splice(numbers.length - 1, 1)[0]);
        }
    }

    return sortedArray;
}

console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));