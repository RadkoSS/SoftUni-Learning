function returnDaysCount(month, year) {
    return new Date(year, month, 0).getDate();
}

console.log(returnDaysCount(1, 2012))