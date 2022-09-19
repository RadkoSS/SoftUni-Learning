function printElements(array){
    array.sort((a, b) => a.localeCompare(b));

    array.forEach((element, index) => {
        console.log(`${++index}.${element}`);
    });
}

printElements(["John", "Bob", "Christina", "Ema"]);