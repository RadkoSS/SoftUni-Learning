const isOddOrEven = require(`../evenOrOdd`);
const { assert } = require(`chai`);

describe(`Test function with incorrect input`, () => {
    it(`Test with array, should return undefined`, () => {
        //Arrange & Act
        let result = isOddOrEven([`Array with string`]);
        //Assert
        assert.equal(result, undefined);
    });

    it(`Test with object, should return undefined`, () => {
        //Arrange & Act
        let result = isOddOrEven({
            name: `Radko`,
            position: `Boss`
        });
        //Assert
        assert.equal(result, undefined);
    });
});

describe(`Test function with correct input`, () => {
    it(`Should return even`, () => {
        //Arrange
        let expected = `even`;

        //Act
        let result = isOddOrEven(`evenString`);
        //Assert
        assert.equal(result, expected);
    });

    it(`Should return odd`, () => {
        //Arrange
        let expected = `odd`;

        //Act
        let result = isOddOrEven(`oddString`);
        //Assert
        assert.equal(result, expected);
    });
});