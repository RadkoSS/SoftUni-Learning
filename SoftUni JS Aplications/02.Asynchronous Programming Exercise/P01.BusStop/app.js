function getInfo() { 
    const busStopInput = document.getElementById(`stopId`);
    const busesList = document.getElementById(`buses`);
    const stopName = document.getElementById(`stopName`);

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${busStopInput.value}`).then((response) => {
        if (!response.ok || response.status !== 200) {
            throw new Error();
        }
        return response.json();
    }).then((data) => {
        appendData(data);
    }).catch(() => {
        stopName.textContent = `Error`;
    }).finally(clearData());

    function appendData(data) {
        stopName.textContent = data.name;
        
        Object.entries(data.buses).forEach(([busNumber, busTimeForArrival]) => {
            let busInfo = document.createElement(`li`);
            busInfo.textContent = `Bus ${busNumber} arrives in ${busTimeForArrival} minutes`;
            
            busesList.appendChild(busInfo);
        });
    }
    
    function clearData() {
        busStopInput.value = ``;

        Array.from(busesList.children).forEach(li => {
            li.remove();
        });
    }
}