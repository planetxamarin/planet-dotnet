var map, selectedAuthor = null;
var markerRadius = 20;

function initializeMap() {
    var latlng = new google.maps.LatLng(40.716948, -74.003563);
    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("authorMap"), options);
}

function loadMap(markersInfo) {

    var map = new google.maps.Map(document.getElementById('authorMap'),
        {
            zoom: 2,
            center: { lat: 34.88593094075314, lng: -10.732421875 },
            streetViewControl: false,
            disableDefaultUI: true
        });

    window.map = map;

    var markers = getMarkers(markersInfo);

    var markerCluster = new MarkerClusterer(map, markers,
        {
            imagePath: 'https://cdn.rawgit.com/googlemaps/js-marker-clusterer/gh-pages/images/m',
            gridSize: 20
        });
}

function getMarkers(markersInfo) {
    var markers = [];

    markersInfo.forEach(info => {

        var marker = getMarker(info.id, info.lat, info.lng, info.name, info.gravatar);

        markers.push(marker);
    });

    return markers;
}

function getMarker(id, lat, lng, name, gravatarHash) {

    var size = markerRadius * 2;
    var radius = markerRadius;
    var pos = { lat: parseFloat(lat), lng: parseFloat(lng) };
    var marker = new google.maps.Marker({
        position: pos,
        title: name,
        shape: { coords: [radius, radius, radius], type: 'circle' },
        icon: {
            url: 'https://www.gravatar.com/avatar/' + gravatarHash + '.jpg?s=' + size + '&d=mm',
            size: new google.maps.Size(size, size)
        },
        optimized: false
    });

    marker.addListener('click', function () {
        $('.live-search-box').val('');

        $('.profileCard').each(function () {
            $(this).show();
        });

        if (selectedAuthor) {
            selectedAuthor.removeClass('active');
        }

        console.log(selectedAuthor);
        console.log(id);

        selectedAuthor = $('#' + id).addClass('active');
        $('html, body').animate({
            scrollTop: selectedAuthor.offset().top - 75
        }, 1000);
    });

    return marker;
}