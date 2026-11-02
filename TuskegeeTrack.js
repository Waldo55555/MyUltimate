var customerLat = 32.429066;

var customerLong = -85.715233;

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
        position: { lat: 32.429066, lng: -85.715233 },
        map: map,
        /*icon: "https://the18thstorage.blob.core.windows.net/the18thcontainer/cargovan.jpg"*/
    });

    var directionsService = new google.maps.DirectionsService();

    var directionsRenderer = new google.maps.DirectionsRenderer();

    directionsRenderer.setMap(map);

}