const { notify } = require(`../app`);
const { expect } = require(`chai`);

describe(`notify function test`, () => {

    it(`should return todo (for now)`, () =>{
        
        //Arrange & Act
        let result = notify();

        //Assert
        expect(result).to.be.equal(`todo`);
    });
});