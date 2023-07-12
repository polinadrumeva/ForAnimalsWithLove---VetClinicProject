/*
Template Name: Woof!
Author: Ingrid Kuhn
Author URI: themeforest/user/ingridk
Version: 2.0
*/

		//----------------------------------- Document ready -----------------------------------//

		$(document).ready(function() {	


			//active link

			var links = $('.navbar ul li a');
			$.each(links, function (key, va) {
				if (va.href == document.URL) {
					$(this).addClass('active');
				}
			});
			$('.active').closest('li.dropdown').addClass('active');
			

			//Effects on scroll
			
			AOS.init({
				disable: 'mobile',
				duration: 1500,
				once: true
			});

			//Scrolling feature 

			$('.page-scroll a').on('click', function(event) {
				var $anchor = $(this);
				$('html, body').stop().animate({
					scrollTop: $($anchor.attr('href')).offset().top
				}, 1500, 'easeInOutExpo');
				event.preventDefault();
			});

			//Dropdown on hover
						
			if ($(window).width() >= 1200) {
			$(".navbar .dropdown").on({
				mouseenter: function () {
				$(this).find('.dropdown-menu').first().stop(true, true).delay(50).slideDown();

				},  
				mouseleave: function () {
				$(this).find('.dropdown-menu').first().stop(true, true).delay(200).slideUp();
				}
			});
			}

			//	Back Top Link

			var offset = 200;
			var duration = 500;
			$(window).scroll(function() {
				if ($(this).scrollTop() > offset) {
					$('.back-to-top').fadeIn(400);
				} else {
					$('.back-to-top').fadeOut(400);
				}
			});

			//Owl-carousels
			
			$("#owl-services2").owlCarousel({
				nav: true,
				navText: ["<i class='fa fa-chevron-left'></i>", "<i class='fa fa-chevron-right'></i>"],
				dots: true,
				margin: 10,
				loop: false,
				autoplay: false,
				navRewind: true,
				responsiveClass: true,
				responsive: {
					0: {
						items: 1,
					},
					600: {
						items: 1,
					},
					991: {
						items: 2,
					},

				}
			});

			$('#owl-featured').owlCarousel({
				loop: true,
				margin: 0,
				autoplay: true,
				nav: true,
				navText: [" <i class='fas fa-chevron-left'></i>", " <i class='fas fa-chevron-right'></i>"],
				autoplayHoverPause: true,
				dots: true,

				responsive: {
					0: {
						items: 1,
						stagePadding: 0
					},
					767: {
						items: 2,
						stagePadding: 60
					},
					1200: {
						items: 4,
						stagePadding: 120
					},
				}
			})
			$("#owl-services").owlCarousel({
				nav: true,
				navText: ["<i class='fa fa-chevron-left'></i>", "<i class='fa fa-chevron-right'></i>"],
				dots: true,
				loop: false,
				autoplay: false,
				navRewind: true,
				responsiveClass: true,
				responsive: {
					0: {
						items: 1,
					},
					600: {
						items: 1,
					},
					991: {
						items: 2,
					},
					1200: {
						items: 4,
					}
				}
			});

			$('#owl-adopt-single').owlCarousel({
				loop: true,
				margin: 0,
				items: 1,
				autoplay: true,
				nav: true,
				navText: [" <i class='fas fa-chevron-left'></i>", " <i class='fas fa-chevron-right'></i>"],
				autoplayHoverPause: true,
				dots: true,
				
			});
			$('#owl-gallery').owlCarousel({
				loop: true,
				margin: 0,
				autoplay: true,
				nav: true,
				navText: [" <i class='fas fa-chevron-left'></i>", " <i class='fas fa-chevron-right'></i>"],
				dots: true,
				responsive: {
					0: {
						items: 1,
						stagePadding: 20
					},
					767: {
						items: 2,
						stagePadding: 60
					},
					1200: {
						items: 4,
						stagePadding: 120
					},
				}
			});

			$('#owl-testimonial').owlCarousel({
				loop: true,
				margin: 0,
				autoplay: true,
				nav: true,
				navText: [" <i class='fas fa-chevron-left'></i>", " <i class='fas fa-chevron-right'></i>"],
				autoplayHoverPause: true,
				dots: true,
				responsiveClass: true,
				responsive: {
					0: {
						items: 1,
					},
					991: {
						items: 2,
					},

				}
			});
			$("#owl-team1,#owl-team2,#owl-team3").owlCarousel({
				nav: true,
				navText: ["<i class='fa fa-chevron-left'></i>", "<i class='fa fa-chevron-right'></i>"],
				dots: true,
				margin: 30,
				loop: true,
				autoplay: false,
				responsiveClass: true,
				responsive: {
					0: {
						items: 1,
					},
					600: {
						items: 2,
					},
					1200: {
						items: 4,
					},

				}
			});

			 // Magnific Popup

			$('#owl-gallery,#owl-adopt-single,#owl-featured,#gallery-isotope').magnificPopup({
				delegate: 'a', // child items selector, by clicking on it popup will open
				type: 'image',
				gallery: {
					enabled: true
				},
				titleSrc: 'title',
				titleSrc: function(item) {
					return '<a href="' + item.el.attr('href') + '">' + item.el.attr('title') + '</a>';
				}
			});
			

			
			 //------- Window scroll function -------//
			 			
	
			$(window).on('scroll',function() {

					//Collapse the top bar on scroll and add fixed class
					
					if ($("#main-nav").offset().top > 60) {
						$('.top-bar').slideUp({
							duration: 250,
							easing: "easeInOutSine"
						}).fadeOut(120);
					} else {
						$('.top-bar').slideDown({
							duration: 0,
							easing: "easeInOutSine"
						}).fadeIn(120);
					}
	
  
					var scroll = $(window).scrollTop();
					if (scroll >= 60) {
						$(".navbar-expand-xl").addClass("fixed-top");
					} else {
						$(".navbar-expand-xl").removeClass("fixed-top");
					}
			  
					
					
				}); // end window scroll
		         

		}); // end document ready


		//----------------------------------- Window load function -----------------------------------//

    $(window).on('load', function(){ 
	
		    // Page Preloader 	

		    $("#preloader").fadeOut("slow"); 


           //Portfolio Isotope 

			 var $container = $('#gallery-isotope');
				$container.isotope({
					filter: '*',
					animationOptions: {
						duration: 750,
						easing: 'linear',
						queue: false,
						layoutMode: 'grid'
					}

				});	
				
			//Isotope Nav Filter

			$('.cat a').on('click', function() {
			$('.cat .active').removeClass('active');
			$(this).addClass('active');

			var selector = $(this).attr('data-filter');
			$container.isotope({
			filter: selector,
			animationOptions: {
				duration: 750,
				easing: 'linear',
				queue: false
			}
			});
			return false;
			});
				

		
		}); // end window load function
	
