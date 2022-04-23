// add map

// google map
var GoogleNormalMap = L.tileLayer.chinaProvider('Google.Normal.Map', {
        maxZoom: 23,
        minZoom: 0
    }),
    // layer
    GoogleTerrainMap = L.tileLayer.chinaProvider('Google.Terrain.Map', {
        maxZoom: 23,
        minZoom: 0
    }),
    GoogleTerrainAnnotion = L.tileLayer.chinaProvider('Google.Terrain.Annotion', {
        maxZoom: 23,
        minZoom: 0
    }),
    // satellite
    GoogleSatelliteMap = L.tileLayer.chinaProvider('Google.Satellite.Map', {
        maxZoom: 23,
        minZoom: 0
    }),
    GoogleSatelliteAnnotion = L.tileLayer.chinaProvider('Google.Satellite.Annotion', {
        maxZoom: 23,
        minZoom: 0
    });


var google_streets = L.layerGroup([GoogleNormalMap]),
    google_satellite = L.layerGroup([GoogleSatelliteMap]),
    google_hybrid = L.layerGroup([GoogleSatelliteMap, GoogleSatelliteAnnotion]);


var baseLayers = {
    "World map city names": google_streets,
    "Satellite map": google_satellite,
    "Satellite map with city names": google_hybrid,
};

var overlayLayers = {};


var map = L.map("map", {
    center: [32.21656017118938, -110.90441372658621],
    zoom: 10,
    layers: [google_streets],
    zoomControl: true,
    worldCopyJump: true,
    zoomSnap: 0.5,
    zoomDelta: 0.5,
    wheelPxPerZoomLevel: 120
});


L.control.layers(baseLayers).addTo(map);


/* add_marker */
 
function add_marker( $marker, map ) {
  
  var ppicon = $marker.attr('data-icon');
  
    var latlng = new google.maps.LatLng( $marker.attr('data-lat'), $marker.attr('data-lng') );

    var marker = new google.maps.Marker({
        position    : latlng,
        map         : map,
        icon        : ppicon,
        animation   : google.maps.Animation.DROP
    });
 
    map.markers.push( marker );
 
    if( $marker.html() )
    {
    
        var infowindow = new google.maps.InfoWindow({
            content     : $marker.html(),
            maxWidth    : 300
        });
        
        // show info window on click 
        google.maps.event.addListener(marker, 'click', function() {
        
            infowindow.open( map, marker );
 
        });
        
        // hide info window on drag map
        google.maps.event.addListener(map, 'drag', function(event) {
        
            if (infowindow.open()) {
                infowindow.close();
            }
        }); 
        
    }
 
}