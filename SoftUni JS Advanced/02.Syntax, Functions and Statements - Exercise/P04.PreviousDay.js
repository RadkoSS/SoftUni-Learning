function calculatePreviousDay(...date){
    let format = `${date[0]}/${date[1]}/${date[2]}`

    let currDate = new Date(format)

    currDate.setDate(currDate.getDate() - 1)

    let year = currDate.getFullYear()
    let month = currDate.getMonth() + 1
    let day = currDate.getDate()

    return `${year}-${month}-${day}`
}

console.log(calculatePreviousDay(2016, 10, 1))