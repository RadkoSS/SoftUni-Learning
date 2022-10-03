function argumentInfo(...arguments){
    let tally = {};

    for(arg of arguments){
        let type = typeof(arg);
        
        if(!tally.hasOwnProperty(type)){
            tally[type] = 0;
        }
        tally[type]++;

        console.log(`${type}: ${arg}`);
    }
    let result = ``;

    for([key, value] of Object.entries(tally)){
        result += `${key}: ${value}\n`
    }

    return result.trim();
}

console.log(argumentInfo('cat', 42, function () { console.log('Hello world!'); }));