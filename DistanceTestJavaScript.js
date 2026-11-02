
/*oklahoma*/
/*var myLatlng = { lat: 33.9535263, lng: -98.6683527 };*/

/*Milwaukee*/
//var myLatlng = { lat: 43.12496770000001, lng: -88.0652288 };

var myLat = document.getElementById("anotherLat");

var myLong = document.getElementById("anotherLong");

var myLatlng = { lat: myLat, lng: myLong };


var mapOptions = {
    center: myLatlng,
    zoom: 7,
    mapTypeId: google.maps.MapTypeId.ROADMAP
    
};


//Create Map

var map = new google.maps.Map(document.getElementById("googleMap"), mapOptions)

//Direction Result Object

var directionsService = new google.maps.DirectionsService();

//Directions Renderer

var directionsRenderer = new google.maps.DirectionsRenderer();

//Bind renderer to the map

directionsRenderer.setMap(map);


//Function


function calcRoute() {

    var request = {

        origin: document.getElementById("from").value,
        destination: document.getElementById("to").value,
        travelMode: google.maps.TravelMode.DRIVING,
        unitSystem: google.maps.UnitSystem.IMPERIAL
     }



    directionsService.route(request, (result, status) => {

        if (status == google.maps.DirectionStatus.Ok) {

            const output = document.querySelector('#output');
            output.innerHTML = "<div class='alert-info'> From: " + document.getElementById("from").value + ".<br />To: " + document.getElementById("to").value + ". <br /> Driving Distance <li class=''>icon here</li>" + result.routes[0].legs[0].distance.text + ".<br />Duration <li class=''>icon here</li> : " + result.routes[0].legs[0].duration.text + ". </div>";
            
            directionsRenderer.setDirections(result);
            
        }

        else {

            directionsRenderer.setDirections({ routes: [] });

            map.setCenter(myLatlng);
            
            //error message
            output.innerHTML = "<div class= 'alert-danger'><li class=''>icon here</li> Error. </div>";

        }
        

    });
    

}


