document.addEventListener("DOMContentLoaded", function() {
    const getWeatherBtn = document.getElementById('getWeatherBtn');
    getWeatherBtn.addEventListener('click', function() {
        fetch('http://localhost:5197/weatherforecast')
            .then(response => response.json())
            .then(data => {
                const forecastDiv = document.getElementById('forecast');
                forecastDiv.innerHTML = '';
                data.forEach(forecast => {
                    const forecastItem = document.createElement('div');
                    forecastItem.innerHTML = `
                        <p>Date: ${forecast.date}</p>
                        <p>Temperature (C): ${forecast.temperatureC}</p>
                        <p>Temperature (F): ${forecast.temperatureF}</p>
                        <p>Summary: ${forecast.summary}</p>
                    `;
                    forecastDiv.appendChild(forecastItem);
                });
            })
    });

    const postButton = document.getElementById('postBtn');
    postButton.addEventListener('click', async function(){
        try{
            const response = await axios.post("http://localhost:5197/submitdata", {
                "Name": "Максим",
                "Age": 22
            });
            const postResultContainer = document.getElementById('postResult');
            postResultContainer.innerHTML = '';
            postResultContainer.innerHTML = JSON.stringify(response.data);
        }
        catch(error){
            console.log(error);
        }

    });
});