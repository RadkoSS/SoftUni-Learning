function makeSquare(argument = 5){

    let square = new String()

    for(let row = 0; row < argument; row++) {

        for(let column = 0; column < argument; column++) {
            if(column == argument - 1) {
                square += `*`
            }
            else {
                square += '* '
            }
        }
        square += `\n`
    }

    return square
}

console.log(makeSquare())