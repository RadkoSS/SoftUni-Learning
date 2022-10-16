function solve(arrayOfCars){
    class Company{
        constructor(carBrand){
            this.carBrand = carBrand;
            this.models = {};
        }
    
        addModel = (carModel, producedCars) => {
            if(!this.models[carModel]){
                this.models[carModel] = Number(producedCars);
            } else{
                this.models[carModel] += Number(producedCars);
            }
        }
    
        toString = () => {
            let report = `${this.carBrand}\n`;
    
            for(let model of Object.keys(this.models)){
                report += `###${model} -> ${this.models[model]}\n`
            }
            return report.trimEnd();
        }
    }
    
    let manufacturedCars = {};
    arrayOfCars.forEach(element => {
        let splitted = element.split(` | `);

        let carBrand = splitted[0];
        let carModel = splitted[1];
        let producedCars = splitted[2];

        if(!manufacturedCars[carBrand]){
            manufacturedCars[carBrand] = new Company(carBrand);
        } 
        manufacturedCars[carBrand].addModel(carModel, producedCars);
    });
    
    let result = ``;
    for(let car of Object.keys(manufacturedCars)){
        result += `${manufacturedCars[car].toString()}\n`
    }

    return result.trimEnd();
}

console.log(solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
));