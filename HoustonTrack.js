var customerLat = 29.749907;

var customerLong = -95.358421;

window.onload = function myFunction() {

    var myLatlng = { lat: customerLat, lng: customerLong };

    var mapOptions = {
        center: myLatlng,
        zoom: 7,
        mapTypeId: google.maps.MapTypeId.ROADMAP

    };

    var map = new google.maps.Map(document.getElementById("googleMap"), mapOptions)

    const marker = new google.maps.Marker({

        //this should be the growers lat/long that we need to pass in
        position: { lat: 29.749907, lng: -95.358421 },
        map: map,
        /*icon: "https://the18thstorage.blob.core.windows.net/the18thcontainer/cargovan.jpg"*/
    });


    var directionsService = new google.maps.DirectionsService();

    var directionsRenderer = new google.maps.DirectionsRenderer();

    directionsRenderer.setMap(map);

}