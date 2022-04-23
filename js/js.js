(function($) {
 
function render_map( $el ) {

	var $markers = $el.find('.marker');
 
	var args = {
		zoom		: 15,
		center		: new google.maps.LatLng(54.8, 0),
		mapTypeId	: google.maps.MapTypeId.ROADMAP
	};
        	
	var map = new google.maps.Map( $el[0], args);
  
  // Prevent dragging
  /*
  map.setOptions({
    draggable: false,
    zoomControl: true,
    scrollwheel: false,
    disableDoubleClickZoom: false
  }); */
  
	map.markers = [];

	$markers.each(function(){
 
    	add_marker( $(this), map );
 
	});

	center_map( map );
  
  // Set Styling
  var styles = [
  {
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#ebe3cd"
      }
    ]
  },
  {
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#523735"
      }
    ]
  },
  {
    "elementType": "labels.text.stroke",
    "stylers": [
      {
        "color": "#f5f1e6"
      }
    ]
  },
  {
    "featureType": "administrative",
    "elementType": "geometry.stroke",
    "stylers": [
      {
        "color": "#c9b2a6"
      }
    ]
  },
  {
    "featureType": "administrative.land_parcel",
    "elementType": "geometry.stroke",
    "stylers": [
      {
        "color": "#dcd2be"
      }
    ]
  },
  {
    "featureType": "administrative.land_parcel",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#ae9e90"
      }
    ]
  },
  {
    "featureType": "landscape.natural",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#dfd2ae"
      }
    ]
  },
  {
    "featureType": "poi",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#dfd2ae"
      }
    ]
  },
  {
    "featureType": "poi",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#93817c"
      }
    ]
  },
  {
    "featureType": "poi.park",
    "elementType": "geometry.fill",
    "stylers": [
      {
        "color": "#a5b076"
      }
    ]
  },
  {
    "featureType": "poi.park",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#447530"
      }
    ]
  },
  {
    "featureType": "road",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#f5f1e6"
      }
    ]
  },
  {
    "featureType": "road.arterial",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#fdfcf8"
      }
    ]
  },
  {
    "featureType": "road.highway",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#f8c967"
      }
    ]
  },
  {
    "featureType": "road.highway",
    "elementType": "geometry.stroke",
    "stylers": [
      {
        "color": "#e9bc62"
      }
    ]
  },
  {
    "featureType": "road.highway.controlled_access",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#e98d58"
      }
    ]
  },
  {
    "featureType": "road.highway.controlled_access",
    "elementType": "geometry.stroke",
    "stylers": [
      {
        "color": "#db8555"
      }
    ]
  },
  {
    "featureType": "road.local",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#806b63"
      }
    ]
  },
  {
    "featureType": "transit.line",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#dfd2ae"
      }
    ]
  },
  {
    "featureType": "transit.line",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#8f7d77"
      }
    ]
  },
  {
    "featureType": "transit.line",
    "elementType": "labels.text.stroke",
    "stylers": [
      {
        "color": "#ebe3cd"
      }
    ]
  },
  {
    "featureType": "transit.station",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#dfd2ae"
      }
    ]
  },
  {
    "featureType": "water",
    "elementType": "geometry.fill",
    "stylers": [
      {
        "color": "#b9d3c2"
      }
    ]
  },
  {
    "featureType": "water",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#92998d"
      }
    ]
  }
];
  
  // Apply Styling
  map.setOptions({styles: styles});

}

/* add_marker */
 
function add_marker( $marker, map ) {
  
  var ppicon = $marker.attr('data-icon');
  
	var latlng = new google.maps.LatLng( $marker.attr('data-lat'), $marker.attr('data-lng') );

	var marker = new google.maps.Marker({
		position	: latlng,
		map			: map,
		icon		: ppicon,
		animation	: google.maps.Animation.DROP
	});
 
	map.markers.push( marker );
 
	if( $marker.html() )
	{
	
		var infowindow = new google.maps.InfoWindow({
			content		: $marker.html(),
			maxWidth	: 300
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
 
/* center_map */
 
function center_map( map ) {

	var bounds = new google.maps.LatLngBounds();
 
	$.each( map.markers, function( i, marker ){
 
		var latlng = new google.maps.LatLng( marker.position.lat(), marker.position.lng() );
 
		bounds.extend( latlng );
 
	});
 
	if( map.markers.length == 1	 )
	{
	    map.setCenter( bounds.getCenter() );
	    map.setZoom( 15 );
	}
	else
	{
		map.fitBounds( bounds );
	}
 
}
 
/* document ready */
 
$(document).ready(function(){
 
	$('.venue_map').each(function(){
 
		render_map( $(this) );
 
	});
 
});

})(jQuery);