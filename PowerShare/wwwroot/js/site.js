// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var map;
var latlongArray = [new google.maps.LatLng(42.8605, -112.4332),
new google.maps.LatLng(42.860154, -112.432232)]; 1
var latlng = new google.maps.LatLng(42.8605, -112.4332);
var myOptions = {
    zoom: 15,
    center: latlng
};
map = new google.maps.Map(document.getElementById("map"),
    myOptions);
google.maps.event.addDomListener(window, "load");

var searchKeyWord = document.getElementById("keyword");
var searchButton = document.getElementById("search");

var searchBox = new google.maps.places.SearchBox(searchKeyWord);

map.controls[google.maps.ControlPosition.TOP_CENTER].push(searchKeyWord);
map.controls[google.maps.ControlPosition.TOP_CENTER].push(searchButton);

searchButton.onclick = function () {
    google.maps.event.trigger(searchKeyWord, 'focus');
    google.maps.event.trigger(searchKeyWord, 'keydown', { keyCode: 13 });
};

var markers = [];
// Listen for the event fired when the user selects a prediction and retrieve
// more details for that place.
searchBox.addListener('places_changed', function () {
    var places = searchBox.getPlaces();

    if (places.length == 0) {
        return;
    }

    // Clear out the old markers.
    markers.forEach(function (marker) {
        marker.setMap(null);
    });
    markers = [];

    // For each place, get the icon, name and location.
    var bounds = new google.maps.LatLngBounds();
    places.forEach(function (place) {
        if (!place.geometry) {
            console.log("Returned place contains no geometry");
            return;
        }
        var icon = {
            url: place.icon,
            size: new google.maps.Size(71, 71),
            origin: new google.maps.Point(0, 0),
            anchor: new google.maps.Point(17, 34),
            scaledSize: new google.maps.Size(25, 25)
        };

        // Create a marker for each place.
        markers.push(new google.maps.Marker({
            map: map,
            icon: icon,
            title: place.name,
            position: place.geometry.location
        }));

        if (place.geometry.viewport) {
            // Only geocodes have viewport.
            bounds.union(place.geometry.viewport);
        } else {
            bounds.extend(place.geometry.location);
        }
    });
    map.fitBounds(bounds);
});

for (var i = 0; i < latlongArray.length; i++) {
    var marker = new google.maps.Marker({
        position: latlongArray[i],
        map: map
    });
    marker.setMap(map);
}