const lookupChar = require(`../charLookUp`);
const { assert } = require(`chai`);

describe(`Test charLookup function with incorrect data`, () => {
    it(`Returns undefined if first param is not string`, () => {
        //Arrange & Act
        let result = lookupChar(['String in array'], 2);

        //Assert
        assert.equal(result, undefined);
    });

    it(`Returns undefined if second param is not integer`, () => {
        //Arrange & Act
        let result = lookupChar(`Correct string`, 2.0000001);

        //Assert
        assert.equal(result, undefined);
    });
    
    it(`Returns "Incorrect index" if second param is greater or equal to string length`, () => {
        //Arrange 
        let expectedResult = `Incorrect index`;
        //Act
        let result = lookupChar(`CorrectString`, 13);

        //Assert
        assert.equal(result, expectedResult);
    });

    it(`Returns "Incorrect index" if second param is a negative number`, () => {
        //Arrange 
        let expectedResult = `Incorrect index`;
        //Act
        let result = lookupChar(`CorrectString`, -1);

        //Assert
        assert.equal(result, expectedResult);
    });
});

describe(`Test charLookup function with correct data`, () => {
    it(`Should return the correct character when correct data is passed to function`, () => {
        //Arrange 
        let expectedResult = `d`;
        //Act
        let result = lookupChar(`Radko`, 2);

        //Assert
        assert.equal(result, expectedResult);
    });
});