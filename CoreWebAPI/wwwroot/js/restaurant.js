(function () {
    const apiURL = 'api/restaurants';
    window.addEventListener('load', function () {
        let boroughList = document.getElementById('boroughs');
        fetch(`${apiURL}/borough`)
            .then(res => res.json())
            .then(function (boroughs) {
                boroughs.forEach(function (borough, i) {
                    let listItem = document.createElement('li');
                    listItem.innerHTML = '<a href="#" class="borough">' + borough + '</a>';
                    boroughList.appendChild(listItem);
                });
            })
            .then(function () {
                Array.from(document.getElementsByClassName('borough')).forEach(
                    borough => {
                        borough.addEventListener("click", function () {

                            var query = borough.innerHTML;
                            let restaurantTitle = document.getElementById('restaurantTitle');
                            let restaurantList = document.getElementById('restaurants');
                            restaurantTitle.innerHTML = `Restaurants in ${query}`;
                            restaurantList.innerHTML = '';
                            fetch(`${apiURL}/${query}`)
                                .then(res => res.json())
                                .then(function (restaurants) {
                                    restaurants.forEach(function (restaurant, i) {
                                        let listItem = document.createElement('li');
                                        listItem.innerHTML = restaurant.name;
                                        restaurantList.appendChild(listItem);
                                    });
                                })
                                .catch(err => console.error('Fout: ' + err));
                        });
                    });
            })
            .catch(err => console.error('Fout: ' + err));
    });
}());