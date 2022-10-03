function getFibonator(){
    let result = 0;
    let firstNumber = 0;
    let secondNumber = 1;

    return () => {
        result = firstNumber + secondNumber;
        firstNumber = secondNumber;
        secondNumber = result;
        
        return firstNumber;
    }
}

let fib = getFibonator();

console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());