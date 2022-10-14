function sortTickets(ticketArray, criteria){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    let allTickets = [];
    for (let ticket of ticketArray){
        let ticketInfo = ticket.split(`|`);

        allTickets.push(new Ticket(ticketInfo[0], Number(ticketInfo[1]), ticketInfo[2]));
    }

    switch (criteria) {
        case `destination`:
            return allTickets.sort((a, b) => {
                return a.destination.localeCompare(b.destination);
            });
        case `price`:
            return allTickets.sort((a, b) => {
                return a.price - b.price;
            });
        case `status`:
            return allTickets.sort((a, b) => {
                return a.status.localeCompare(b.status);
            });
    }
}

console.table(sortTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'));