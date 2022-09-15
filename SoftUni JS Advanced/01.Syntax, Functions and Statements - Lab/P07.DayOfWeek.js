function matchDayWithNumber(day) {
    let daysOfWeek = {
        'Monday': 1,
        'Tuesday': 2,
        'Wednesday': 3,
        'Thursday': 4,
        'Friday': 5,
        'Saturday': 6,
        'Sunday': 7
    }

    if (daysOfWeek[day] === undefined) {
        return `error`
    }

    return daysOfWeek[day]
}

console.log(matchDayWithNumber(`Friday`))