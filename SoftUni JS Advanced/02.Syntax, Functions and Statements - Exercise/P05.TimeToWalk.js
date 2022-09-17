function calculateTime(stepsCount, footprintLength, velocity){

    let velocityInMs = velocity * 3.6
    let distanceInMeters = stepsCount * footprintLength

    // let timeNeededInSeconds = distanceInMeters / velocityInMs

    // let hours = 0
    // let minutes = 0
    // let seconds = 0

    // if(timeNeededInSeconds >= 60){
    //     minutes = timeNeededInSeconds / 60

    //     if(minutes >= 60){
    //         hours = minutes / 60
            
    //         minutes = 0
    //     }
    // }
    // else{
    //     seconds = timeNeededInSeconds
    // }

    let hoursFormatted = `${hours < 10 ? `0${hours}` : `${hours}`}`

    let minutesFormatted = `${minutes < 10 ? `0${minutes}` : `${minutes}`}`

    let secondsFormatted = `${seconds < 10 ? `0${seconds}` : `${seconds}`}`

    return `${hoursFormatted}:${minutesFormatted}:${secondsFormatted}`
}

console.log(calculateTime(4000, 0.60, 5))