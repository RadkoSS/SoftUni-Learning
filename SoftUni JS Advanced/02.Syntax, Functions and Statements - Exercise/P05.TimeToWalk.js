function calculateTime(stepsCount, footprintLength, velocity){

    let velocityInMs = velocity / 3.6;
    let distanceInMeters = stepsCount * footprintLength;
    let restsCount = Math.floor(distanceInMeters / 500);

    let restTime = restsCount * 60;

    let timeNeededInSeconds = distanceInMeters / velocityInMs + restTime;

    let time = secondsToTime(timeNeededInSeconds);
    
    return time;
}

function secondsToTime(secs)
{
    let date = new Date(secs * 1000);

    let hours = date.getUTCHours();
    let minutes = date.getUTCMinutes();
    let seconds = date.getSeconds();
    
    if (hours < 10) {
        hours = `0${hours}`;
        }
    if (minutes < 10) { 
        minutes = `0${minutes}`; 
        }
    if (seconds < 10) { 
        seconds = `0${seconds}`; 
    }

    let timeFormatted = `${hours}:${minutes}:${seconds}`;

    return timeFormatted;
}

console.log(calculateTime(4000, 0.60, 5));