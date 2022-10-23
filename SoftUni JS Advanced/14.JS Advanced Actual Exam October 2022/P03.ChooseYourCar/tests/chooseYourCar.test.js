const chooseYourCar = require("../chooseYourCar");
const { assert } = require("chai");

describe("Testing chooseYourCar object", () => {
    describe("Testing choosingType func with invalid data", () => {
        it("Invalid year", () => {
            assert.throws(() => {
                chooseYourCar.choosingType("Sedan", "Red", 1899);
            }, "Invalid Year!");
        });

        it("Invalid year", () => {
            assert.throws(() => {
                chooseYourCar.choosingType("Sedan", "Red", 2023);
            }, "Invalid Year!");
        });

        it("Invalid type", () => {
            assert.throws(() => {
                chooseYourCar.choosingType("InvalidType", "Red", 2000);
            }, "This type of car is not what you are looking for.");
        });

        it("Invalid type and year", () => {
            assert.throws(() => {
                chooseYourCar.choosingType("InvalidType", "Red", 2023);
            }, "Invalid Year!");
        });
     });

     describe("Testing choosingType func with valid data", () => {
        it("Valid data", () => {
            let result = `This red Sedan meets the requirements, that you have.`;

            assert.equal(chooseYourCar.choosingType("Sedan", "red", 2010), result);
        });

        it("Valid data", () => {
            let result = `This red Sedan meets the requirements, that you have.`;

            assert.equal(chooseYourCar.choosingType("Sedan", "red", 2022), result);
        });

        it("Valid data", () => {
            let result = `This Sedan is too old for you, especially with that red color.`;

            assert.equal(chooseYourCar.choosingType("Sedan", "red", 2009), result);
        });
     });

     describe("Testing brandName func with invalid data", () => {
        it("Invalid index - not integer", () => {
            assert.throw(() =>{
                chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 1.000009)
            }, "Invalid Information!");
        });

        it("Invalid index - negative number", () => {
            assert.throw(() =>{
                chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], -1)
            }, "Invalid Information!");
        });

        it("Invalid index - out of range number", () => {
            assert.throw(() =>{
                chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 3)
            }, "Invalid Information!");
        });

        it("Invalid index - undefined", () => {
            assert.throw(() =>{
                chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"])
            }, "Invalid Information!");
        });

        it("Invalid index - out of range number", () => {
            assert.throw(() =>{
                chooseYourCar.brandName([], 3)
            }, "Invalid Information!");
        });

        it("First argument string", () => {
            assert.throw(() =>{
                chooseYourCar.brandName("someText", 2)
            }, "Invalid Information!");
        });

        it("First argument integer", () => {
            assert.throw(() =>{
                chooseYourCar.brandName(1, 2)
            }, "Invalid Information!");
        });
     });

     describe("Testing brandName func with valid data", () => {
        it("Valid data", () => {
            let expected = "BMW, Peugeot";
            let result = chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 1);

            assert.equal(expected, result);
        });

        it("Valid data", () => {
            let expected = "";
            let result = chooseYourCar.brandName(["BMW"], 0);

            assert.equal(expected, result);
        });
     });

     describe("Testing carFuelConsumption func with invalid data", () => {
        it("Invalid data", () => {
            assert.throw(() =>{
                chooseYourCar.carFuelConsumption("String", 2);
            }, "Invalid Information!")
        });

        it("Invalid data", () => {
            assert.throw(() =>{
                chooseYourCar.carFuelConsumption(0, 2);
            }, "Invalid Information!")
        });

        it("Invalid data", () => {
            assert.throw(() =>{
                chooseYourCar.carFuelConsumption(-1, 2);
            }, "Invalid Information!")
        });

        it("Invalid data", () => {
            assert.throw(() =>{
                chooseYourCar.carFuelConsumption(2, "String");
            }, "Invalid Information!")
        });

        it("Invalid data", () => {
            assert.throw(() =>{
                chooseYourCar.carFuelConsumption(2, 0);
            }, "Invalid Information!")
        });

        it("Invalid data", () => {
            assert.throw(() =>{
                chooseYourCar.carFuelConsumption(2, -1);
            }, "Invalid Information!")
        });
     });

     describe("Testing carFuelConsumption func with valid data", () => {
        it("Valid data", () => {
            let expected = "The car is efficient enough, it burns 7.00 liters/100 km.";

            let result = chooseYourCar.carFuelConsumption(100, 7);

            assert.equal(expected, result);
        });

        it("Valid data", () => {
            let expected = "The car is efficient enough, it burns 3.00 liters/100 km.";

            let result = chooseYourCar.carFuelConsumption(100, 3);

            assert.equal(expected, result);
        });

        it("Valid data", () => {
            let expected = "The car burns too much fuel - 7.50 liters!";

            let result = chooseYourCar.carFuelConsumption(100, 7.5);

            assert.equal(expected, result);
        });
     });
});