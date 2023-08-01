$(document).ready(function() {

	// Check user OS
	if(navigator.appVersion.indexOf('Mac') != -1) {
		$('body').addClass('mac');
	}

	// Init syntax highlighter
	SyntaxHighlighter.defaults.toolbar = false;
	SyntaxHighlighter.all();

	// Init sidebar
	$('#sidebar li').click(function(e) {

		var $li = $(this);

		// Do nothing if it's the active menu
		if( $li.hasClass('active') ) { return false; }

		// Highlight the menu item
		$li.addClass('active').siblings().removeClass('active');

		// Show new section
		$('#content > div > section').removeClass('active').eq( $li.index() ).addClass('active');

		// Scroll to top
		$('#content').scrollTop(0);

		// Filter out triggered events
		if( ! e.isTrigger ) {

			// Update hash
			document.location.hash = $li.data('hash');
		}
	});


	// JumpTo functionality
	$(window).on('hashchange', function(e) {
		e.preventDefault();

		var hash 		= document.location.hash.substr(1),
			$target 	= $('[data-target="'+hash+'"]'),
			$section 	= $target.closest('section');

		if( $target.length && $section.length ) {

			$('#sidebar li').eq( $section.index() ).trigger('click');

			var scrollTop = $('#content').scrollTop() + $target.offset().top;
				scrollTop = scrollTop < 50 ? 0 : scrollTop;

			$('#content').stop(true, true).animate({ scrollTop: scrollTop }, 500);
		}
	}).trigger('hashchange');


	// Init transition gallery
	if( typeof layerSliderTransitions !== 'undefined' ){
		window.lsTrImgPath = 'assets/img/';
		window.pluginPath = '../';
		transitionGallery.init();
	}


	// Examples
	var SliderExmaples = [{
		'title': 'Catering Christmas Slider',
		'folder': 'Catering-Christmas-Slider',
		'preview': 'catering-xmas-slider.jpg'
	},{
		'title': '	Discover the Details',
		'folder': 'Discover-the-Details',
		'preview': 'discover-the-details.jpg'
	},{
		'title': 'Rainforest',
		'folder': 'Rainforest',
		'preview': 'rainforest.jpg'
	},{
		'title': 'eCommerce Global Hover Example',
		'folder': 'eCommerce-Global-Hover-Example',
		'preview': 'ecommerce-global-hover-example.jpg'
	},{
		'title': '3D Canyon Experience',
		'folder': '3D-Canyon-Experience-Global-Hover',
		'preview': '3d-canyon-experience.jpg'
	},{
		'title': 'Discount Popup',
		'folder': 'Discount-Popup',
		'preview': 'discount-popup.jpg'
	},{
		'title': 'Vintage Photos',
		'folder': 'Vintage-Photos',
		'preview': 'vintage-photos.jpg'
	},{
		'title': 'Social Share Popup',
		'folder': 'Social-Share-Popup',
		'preview': 'popup-social-share.jpg'
	},{
		'title': 'Aquarium',
		'folder': 'Aquarium',
		'preview': 'aquarium-experiment.jpg'
	},
	{
		'title': 'What is the time?',
		'folder': 'What-is-the-time',
		'preview': 'what-is-the-time.jpg'
	},
	{
		'title': 'Personal Page PACK',
		'folder': 'Personal-Page-PACK',
		'preview': 'personal-1.jpg'
	},
	{
		'title': 'Marketing Page PACK',
		'folder': 'Marketing-Page-PACK',
		'preview': 'marketing-1.jpg'
	},
	{
		'title': 'Dynamic Slider',
		'folder': 'Dynamic-Slider',
		'preview': 'dynamic-slider.jpg'
	},
	{
		'title': 'Colorful Cases',
		'folder': 'Colorful-cases',
		'preview': 'colorful-cases.jpg'
	},
	{
		'title': 'Beauty Shop PACK',
		'folder': 'Beauty-Shop-PACK',
		'preview': 'beauty-shop-main.jpg'
	},
	{
		'title': 'Popup Guide Demo',
		'folder': 'Welcome-Guide-Popup',
		'preview': 'welcome-guide-popup.jpg'
	},
	{
		'title': 'Popup Welcome Demo',
		'folder': 'Popup-Welcome-Demo',
		'preview': 'popup-welcome-demo.jpg'
	},
	{
		'title': 'Popup Transparent Demo',
		'folder': 'Popup-Transparent-Demo',
		'preview': 'popup-transparent-demo.jpg'
	},
	{
		'title': 'Popup Sidebar Demo',
		'folder': 'Popup-Sidebar-Demo',
		'preview': 'popup-sidebar-demo.jpg'
	},
	{
		'title': 'Popup Photo Gallery',
		'folder': 'Popup-Photo-Gallery',
		'preview': 'popup-photo-gallery.jpg',
		'simple': true
	},
	{
		'title': 'Popup Modal Demo',
		'folder': 'Popup-Modal-Demo',
		'preview': 'popup-modal-demo.jpg'
	},
	{
		'title': 'Popup Infobar Demo',
		'folder': 'Popup-Inforbar-Demo',
		'preview': 'popup-inforbar-demo.jpg'
	},
	{
		'title': 'Popup Fullsize Desk Demo',
		'folder': 'Popup-Fullsize-Desk-Demo',
		'preview': 'popup-fullsize-desk-demo.jpg'
	},
	{
		'title': 'Conversation Popup',
		'folder': 'Conversation-Popup',
		'preview': 'conversation-popup.jpg'
	},
	{
		'title': 'Global Hover Example',
		'folder': 'Global-Hover-Example',
		'preview': 'global-hover-example-2.jpg'
	},
	{
		'title': 'Gastronomy',
		'folder': 'Gastronomy',
		'preview': 'hamburger2.jpg'
	},
	{
		'title': 'Police Lights',
		'folder': 'Police-Lights',
		'preview': 'policelights.jpg'
	},
	{
		'title': 'Beautiful Sunset',
		'folder': 'Beautiful-Sunset',
		'preview': 'beautiful-sunset.jpg'
	},
	{
		'title': 'Blend Mode Experiment 1',
		'folder': 'Blend-Mode-Experiment-1',
		'preview': 'blend-mode-experiment-1.jpg'
	},
	{
		'title': 'Flying Banners 2',
		'folder': 'Flying-Banners-2',
		'preview': 'flying-banners-2.jpg'
	},
	{
		'title': 'LayerSlider v6',
		'folder': 'LayerSlider-v6',
		'preview': 'v6.jpg'
	},
	{
		'title': 'Flying Banners 1',
		'folder': 'Flying-Banners-1',
		'preview': 'flying-banners-1.jpg'
	},
	{
		'title': 'Anniversary Slider',
		'folder': 'Anniversary-Slider',
		'preview': '5years.jpg'
	},
	{
		'title': 'Origami',
		'folder': 'Origami',
		'preview': 'origami.jpg',
		'simple': true
	},
	{
		'title': 'Origami Buildings',
		'folder': 'Origami-Buildings',
		'preview': 'origami-buildings-2.jpg'
	},
	{
		'title': 'Autumn Experiment',
		'folder': 'Autumn-Experiment',
		'preview': 'autumn-experiment.jpg'
	},
	{
		'title': 'Features | A Parallax Experiment',
		'folder': 'Features-A-Parallax-Experiment',
		'preview': 'features-parallax-experiment.jpg'
	},
	{
		'title': 'Furniture Slider',
		'folder': 'Furniture-Slider',
		'preview': 'furniture-slider.jpg'
	},
	{
		'title': 'Room Experiment',
		'folder': 'Room-Experiment',
		'preview': 'room-experiment.jpg'
	},
	{
		'title': 'Headphones',
		'folder': 'Headphones',
		'preview': 'headphones.jpg'
	},
	{
		'title': 'LayerSlider Editor: Drag & Drop',
		'folder': 'LayerSlider-Editor-Drag-Drop',
		'preview': 'drag-n-drop.jpg'
	},
	{
		'title': 'Play By Scroll',
		'folder': 'Play-By-Scroll-demo',
		'preview': 'play-by-scroll.jpg'
	},
	{
		'title': 'Sky Experience',
		'folder': 'Sky-Experience',
		'preview': 'sky.jpg'
	},
	{
		'title': 'Happy Halloween!',
		'folder': 'Happy-Halloween',
		'preview': 'halloween.jpg'
	},
	{
		'title': 'Creative Agency',
		'folder': 'Creative-Agency',
		'preview': 'creative-agency.jpg'
	},
	{
		'title': 'Interactive Slider',
		'folder': 'Interactive-Slider',
		'preview': 'interactive-slider.jpg'
	},
	{
		'title': 'eCommerce',
		'folder': 'Ecommerce',
		'preview': 'ecommerce.jpg'
	},
	{
		'title': 'Landing Page',
		'folder': 'Landing-Page',
		'preview': 'landing-page-intro.jpg'
	},
	{
		'title': 'Hiking',
		'folder': 'Hiking',
		'preview': 'hiking-1.jpg',
		'simple': true
	},
	{
		'title': 'Movie Slider',
		'folder': 'Movie-Slider',
		'preview': 'movie-slider.png'
	},
	{
		'title': 'Photo Studio',
		'folder': 'Photo-Studio',
		'preview': 'photo-studio.jpg'
	},
	{
		'title': 'Shoes',
		'folder': 'Shoes',
		'preview': 'shoes-1.jpg'
	},
	{
		'title': 'Mini Cooper Slider',
		'folder': 'Mini-Slider-3D-parallax',
		'preview': 'mini-slider-3d-parallax.jpg'
	},
	{
		'title': 'Merry Christmas!',
		'folder': 'Merry-Christmas',
		'preview': 'xmas-5.jpg'
	},
	{
		'title': 'Vintage Clock',
		'folder': 'Vintage-Clock-shows-valid-time',
		'preview': 'clock-1.jpg'
	},
	{
		'title': 'Car Show',
		'folder': 'Layer-Car-SHOW',
		'preview': 'car-show.jpg'
	},
	{
		'title': 'Landing Screen PACK',
		'folder': 'Landing-Screen-PACK',
		'preview': 'landing-screen-1.jpg'
	},
	{
		'title': 'Carousel',
		'folder': 'Carousel',
		'preview': 'carousel-1.jpg',
		'simple': true
	},
	{
		'title': 'Parallax Slider',
		'folder': 'Parallax-Slider',
		'preview': 'fancy-parallax-1.jpg'
	},
	{
		'title': 'Simple Slider',
		'folder': 'Simple-Slider',
		'preview': 'simple-slider.jpg',
		'simple': true
	},
	{
		'title': 'Image Slideshow',
		'folder': 'Image-slider',
		'preview': '1.jpg',
		'simple': true
	},
	{
		'title': 'Client Testimonials',
		'folder': 'Client-Testimonials',
		'preview': 'client-testimonials-1.jpg'
	},
	{
		'title': 'Fixed Background',
		'folder': 'Fixed-Background',
		'preview': 'fixed-bg-4.jpg'
	},
	{
		'title': 'Dynamic Content Slider',
		'folder': 'Dynamic-Content-Slider',
		'preview': 'dynamic-content-slider.jpg',
		'simple': true
	},
	{
		'title': 'LayerSlider 3D Demo Slider',
		'folder': 'Old-v4-demo-slider-with-3D-transitions',
		'preview': 'old-3d.jpg'
	},
	{
		'title': 'LayerSlider v5',
		'folder': 'Previous-v5-demo-slider',
		'preview': 'v5.jpg'
	},
	{
		'title': 'Video Slider',
		'folder': 'Video-Slider',
		'preview': 'video-slider.jpg',
		'simple': true
	},
	{
		'title': 'Resort',
		'folder': 'Resort',
		'preview': 'resort-2.jpg'
	}
];

	// Add examples
	$.each( SliderExmaples, function( key, slider ) {

		var $item = $('<a>').attr({
			target: '_blank',
			href: '../examples/'+slider.folder+'/slider.html',
			style: 'background: url(../examples/'+slider.folder+'/images/'+slider.preview+')'

		}).append( $('<span>'+slider.title+'</span>') );


		$item.appendTo('#slider-examples-all');

		if( slider.simple ) {
			$item.appendTo('#slider-examples-simple');
		}


		// <a class="item" target="_blank"
		// 				href="../examples/Image-Slider/slider.html"
		// 				style="background: url(../examples/Image-Slider/images/1.jpg)">
		// 					<span>Image Slider</span>
		// 			</a>
	});
});

var transitionGallery = {

	init : function() {

		var self =  this;

		// Add transition list
		self.appendTransitions(layerSliderTransitions['t2d'], $('#slide-transitions-2d tbody'));
		self.appendTransitions(layerSliderTransitions['t3d'], $('#slide-transitions-3d tbody'));

		// Show transitions
		jQuery('.ls-transition-list').on('mouseenter', 'a', function() {
			lsShowTransition( this );
		});

		// Hide transitions
		jQuery('.ls-transition-list').on('mouseleave', 'a', function() {
			lsHideTransition( this );
		});
	},

	appendTransitions : function(transitions, target) {
		for(c = 0; c < transitions.length; c+=2) {

			// Append new table row
			var tr = jQuery('<tr>').appendTo(target).append('<td class="c light"></td><td></td><td class="c"></td><td></td>');


			// Append transition col 1 & 2
			tr.children().eq(0).text((c+1));
			tr.children().eq(1).append( jQuery('<a>', { 'href' : '#', 'html' : transitions[c]['name'], 'data-key' : (c+1) } ) )
			if(transitions.length > (c+1)) {
				tr.children().eq(2).text((c+2));
				tr.children().eq(3).append( jQuery('<a>', { 'href' : '#', 'html' : transitions[(c+1)]['name'], 'data-key' : (c+2) } ) )
			}
		}
	}
};
