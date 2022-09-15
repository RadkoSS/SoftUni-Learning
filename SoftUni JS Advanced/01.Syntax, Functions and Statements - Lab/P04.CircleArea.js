calculateCircleArea(5)

function calculateCircleArea(expectedNumber){

    if (typeof expectedNumber !== `number`) {
        console.log(`We can not calculate the circle area, because we receive a ${typeof expectedNumber}.`)
    }
    else {
        console.log((Math.PI * Math.pow(expectedNumber, 2)).toFixed(2))
    }
}