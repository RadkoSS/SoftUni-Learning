function countPopulation(array){
    let registry = [];

    array.forEach(element => {
        let splitted = element.split(` <-> `);

        let cityName = splitted[0];
        let population = Number(splitted[1]);

        if(registry[cityName] === undefined){
            registry[cityName] = population;
        }else{
            registry[cityName] += population;
        }
    });

    let result = ``;

    for (let [key, value] of Object.entries(registry)) {
        result += `${key} : ${value}\n`;
    }

    return result.trim();
}

console.log(countPopulation(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
))