writeLength('pasta', '5', '22.3')

function writeLength(...param){
    let sum = 0

    param.forEach(element => {
        sum += element.length
    });

    console.log(sum)
    console.log(Math.floor(sum / param.length))
}