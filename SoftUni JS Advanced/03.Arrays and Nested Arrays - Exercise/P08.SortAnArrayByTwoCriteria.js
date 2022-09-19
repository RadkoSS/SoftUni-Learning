function sortArray(namesArray){
    return namesArray.sort((a, b) => a.length - b.length || a.localeCompare(b)).join(`\n`);
}

console.log(sortArray(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
));