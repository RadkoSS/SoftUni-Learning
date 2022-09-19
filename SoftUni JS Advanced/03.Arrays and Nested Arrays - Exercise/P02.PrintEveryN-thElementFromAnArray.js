function printElements(array, stepsForLoop){
    return array.filter((element, index) => {
        if(index % stepsForLoop === 0){
            return element;
        }
    });
}

console.log(printElements(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));