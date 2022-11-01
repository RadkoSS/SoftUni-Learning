const weatherEnum = {
    "Sunny": "&#x2600;",
    "Partly sunny": "&#x26C5;",
    "Overcast": "&#x2601;",
    "Rain": "&#x2614;",
    "Degrees": "&#176;"
}

function attachEvents() {
    const weatherBtn = document.getElementById(`submit`);
    const location = document.getElementById(`location`);

    const forecastDiv = document.getElementById(`forecast`);
    const currentDiv = document.getElementById(`current`);
    const upcomingDiv = document.getElementById(`upcoming`);

    const currDivLabel = document.querySelector(`.label`);

    const locationsUrl = `http://localhost:3030/jsonstore/forecaster/locations`;

    weatherBtn.addEventListener(`click`, sendRequest);

    async function sendRequest() {
        try {
            const request = await fetch(locationsUrl);
            const data = await request.json();

            const searchedCity = data.find(city => city.name === location.value);

            const currentWeather = await getCurrentConditions(searchedCity);
            const upcomingWeather = await getUpcomingConditions(searchedCity);

            resetHtml(currentDiv, upcomingDiv);
            currDivLabel.textContent = `Current conditions`;

            appendDataForCurrentDay(currentDiv, currentWeather);

            appendDataForUpcomingDays(upcomingDiv, upcomingWeather);
        } catch (error) {
            currDivLabel.textContent = `Error`;

            resetHtml(currentDiv, upcomingDiv);
        } finally {
            forecastDiv.style.display = `block`;
        }
    }
}

async function getCurrentConditions(searchedCity) {
    const url = `http://localhost:3030/jsonstore/forecaster/today/${searchedCity.code}`

    const request = await fetch(url);
    const currentData = await request.json();

    return currentData;
}

async function getUpcomingConditions(searchedCity) {
    const url = `http://localhost:3030/jsonstore/forecaster/upcoming/${searchedCity.code}`

    const request = await fetch(url);
    const upcomingData = await request.json();

    return upcomingData;
}

function appendDataForCurrentDay(currentDiv, currentWeather) {
    const currentForecastInfo = currentWeather.forecast;
    const condition = weatherEnum[currentForecastInfo.condition];
    const location = currentWeather.name;
    const temperatures = `${currentForecastInfo.low}${weatherEnum[`Degrees`]}/${currentForecastInfo.high}${weatherEnum[`Degrees`]}`;

    const forecastsDiv = elementFactory(`div`, `forecasts`, currentDiv);

    elementFactory(`span`, `condition symbol`, forecastsDiv, condition);

    const spanContainer = elementFactory(`span`, `condition`, forecastsDiv);

    elementFactory(`span`, `forecast-data`, spanContainer, ``, `${location}`);
    elementFactory(`span`, `forecast-data`, spanContainer, `${temperatures}`);
    elementFactory(`span`, `forecast-data`, spanContainer, ``, `${currentForecastInfo.condition}`);
}

function appendDataForUpcomingDays(upcomingDiv, upcomingWeather) {
    const currentForecastInfo = upcomingWeather.forecast;

    elementFactory(`div`, `label`, upcomingDiv, ``, `Three-day forecast`);

    const upcomingForecastDiv = elementFactory(`div`, `forecast-info`, upcomingDiv);
    
    currentForecastInfo.forEach(({ condition, high, low }) => {
        const spanContainer = elementFactory(`span`, `upcoming`, upcomingForecastDiv);
        
        const conditionAsEmoji = weatherEnum[condition];

        const temperatures = `${low}${weatherEnum[`Degrees`]}/${high}${weatherEnum[`Degrees`]}`;

        elementFactory(`span`, `symbol`, spanContainer, `${conditionAsEmoji}`);
        elementFactory(`span`, `forecast-data`, spanContainer, `${temperatures}`);
        elementFactory(`span`, `forecast-data`, spanContainer, ``, `${condition}`);
    });
}

function elementFactory(tag, className, parent, html = ``, content = ``) {
    const element = document.createElement(tag);
    element.textContent = content;

    if (className) {
        element.setAttribute(`class`, `${className}`)
    }
    if (html) {
        element.innerHTML = html;
    }
    if (parent) {
        parent.appendChild(element);
    }

    return element;
}

function resetHtml(currentDiv, upcomingDiv){
    Array.from(currentDiv.children).forEach((element, index) => {
        if(index === 0){
            return
        }
        element.remove();
    });

    Array.from(upcomingDiv.children).forEach(element => {
        element.remove();
    });
}

attachEvents();