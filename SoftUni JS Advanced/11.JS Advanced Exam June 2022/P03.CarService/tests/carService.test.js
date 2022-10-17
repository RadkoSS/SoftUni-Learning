const carService = require(`../03. Car Service_Resources`);
const { assert } = require(`chai`);

describe("Tests …", () => {
    describe("Testing isItExpensive function", () => {
        
        it("passing `Engine`", () => {
            //Arrange & Act
            let result = carService.isItExpensive(`Engine`);

            //Assert
            assert.equal(result, `The issue with the car is more severe and it will cost more money`);
        });

        it("passing `Transmission`", () => {
            //Arrange & Act
            let result = carService.isItExpensive(`Transmission`);

            //Assert
            assert.equal(result, `The issue with the car is more severe and it will cost more money`);
        });

        it("passing whatever else", () => {
            //Arrange & Act
            let result = carService.isItExpensive(`Front brakes`);

            //Assert
            assert.equal(result, `The overall price will be a bit cheaper`);
        });
     });

     describe("Testing discount function", () => {
        it(`Invalid data`, () =>{
            assert.throws(() => {
                carService.discount(`String`, `Another String`)
            }, `Invalid input`);
        })

        it(`Invalid data`, () =>{
            assert.throws(() => {
                carService.discount([], {})
            }, `Invalid input`);
        })

        it(`Invalid data`, () =>{
            assert.throws(() => {
                carService.discount()
            }, `Invalid input`);
        })

        it(`Valid data`, () =>{
            let result = carService.discount(0, 100);

            assert.equal(result, `You cannot apply a discount`);
        })

        it(`Valid data`, () =>{
            let result = carService.discount(1, 100);

            assert.equal(result, `You cannot apply a discount`);
        })

        it(`Valid data`, () =>{
            let result = carService.discount(2, 100);

            assert.equal(result, `You cannot apply a discount`);
        })

        it(`Valid data`, () =>{
            let result = carService.discount(3, 100);

            assert.equal(result, `Discount applied! You saved 15$`);
        })

        it(`Valid data`, () =>{
            let result = carService.discount(5, 100);

            assert.equal(result, `Discount applied! You saved 15$`);
        })

        it(`Valid data`, () =>{
            let result = carService.discount(7, 100);

            assert.equal(result, `Discount applied! You saved 15$`);
        })

        it(`Valid data`, () =>{
            let result = carService.discount(8, 100);

            assert.equal(result, `Discount applied! You saved 30$`);
        })
     });

     describe("Testing partsToBuy function", () => {
        it(`Invalid data`, () =>{
            assert.throws(() =>{
                carService.partsToBuy();
            }, `Invalid input`)
        })

        it(`Invalid data`, () =>{
            assert.throws(() =>{
                carService.partsToBuy({}, {});
            }, `Invalid input`)
        })

        it(`Invalid data`, () =>{
            assert.throws(() =>{
                carService.partsToBuy(1, `string`);
            }, `Invalid input`)
        })

        it(`Valid data`, () =>{
            let partsCatalog = [{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }];

            let neededParts = ["blowoff valve", "coil springs"];

            let result = carService.partsToBuy(partsCatalog, neededParts);

            assert.equal(result, 375);
        })

        it(`Valid data`, () =>{
            let partsCatalog = [];

            let neededParts = ["blowoff valve", "coil springs"];

            let result = carService.partsToBuy(partsCatalog, neededParts);

            assert.equal(result, 0);
        })

        it(`Valid data`, () =>{
            let partsCatalog = [];

            let neededParts = [];

            let result = carService.partsToBuy(partsCatalog, neededParts);

            assert.equal(result, 0);
        })

        it(`Valid data`, () =>{
            let partsCatalog = [{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }];

            let neededParts = [];

            let result = carService.partsToBuy(partsCatalog, neededParts);

            assert.equal(result, 0);
        })

        it(`Valid data`, () =>{
            let partsCatalog = [{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }];

            let neededParts = ["blowoff valve", "coil springs", "front brakes"];

            let result = carService.partsToBuy(partsCatalog, neededParts);

            assert.equal(result, 375);
        })
     }); 
});