class Garden{
    constructor(spaceAvailable){
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant = (plantName, spaceRequired) => {
        let difference = this.spaceAvailable - Number(spaceRequired);
        if(difference < 0){
            throw new Error("Not enough space in the garden.");
        }

        this.plants.push({
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        });

        this.spaceAvailable = difference;

        return `The ${plantName} has been successfully planted in the garden.`
    }

    ripenPlant = (plantName, quantityString) => {
        let quantity = Number(quantityString);

        let searchedPlant = this.findPlant(plantName);

        if(searchedPlant.ripe){
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if(quantity <= 0){
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        searchedPlant.ripe = true;

        searchedPlant.quantity += quantity;

        if(quantity === 1){
            return `${quantity} ${plantName} has successfully ripened.`;
        } 
        return `${quantity} ${plantName}s have successfully ripened.`;
    }

    harvestPlant = (plantName) => {
        let searchedPlant = this.findPlant(plantName);

        if(!searchedPlant.ripe){
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }
        let quantity = searchedPlant.quantity;

        this.spaceAvailable += searchedPlant.spaceRequired;

        this.plants.splice(this.plants.findIndex(p => p.plantName === plantName), 1);

        this.storage.push({
            plantName, 
            quantity
        });

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport = () => {
        let report = `The garden has ${this.spaceAvailable} free space left.\n`;

        report += `Plants in the garden: ${this.plants.sort((plantA, plantB) => {
            return plantA.plantName - plantB.plantName
        }).map(p => {
            return p.plantName
        }).join(`, `)}\n`;

        if(this.storage.length === 0){
            report += `Plants in storage: The storage is empty.`;
            return report;
        }

        report += `Plants in storage: ${this.storage.map(plant => {
            return `${plant.plantName} (${plant.quantity})`
        }).join(`, `)}`;

        return report;
    }

    findPlant = (plantName) => {
        let searchedPlant = this.plants.find(plant => plant.plantName === plantName);

        if(!searchedPlant){
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        return searchedPlant;
    }
}

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());