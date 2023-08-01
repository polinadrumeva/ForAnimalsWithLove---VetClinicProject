(function($) {
"use strict";


/* ==============================================
LIGHTBOX -->
=============================================== */   

  jQuery('a[data-gal]').each(function() {
    jQuery(this).attr('rel', jQuery(this).data('gal')); });     
    jQuery("a[data-rel^='prettyPhoto']").prettyPhoto({animationSpeed:'slow',theme:'light_square',slideshow:true,overlay_gallery: true,social_tools:false,deeplinking:false});


/* ==============================================
SCROLL -->
=============================================== */

$(function() {
  $('a[href*=#]:not([href=#])').click(function() {
    if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
      var target = $(this.hash);
      target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
      if (target.length) {
        $('html,body').animate({
          scrollTop: target.offset().top
        }, 1000);
        return false;
      }
    }
  });
});

/* ==============================================
VIDEO FIX -->
=============================================== */

    $(document).ready(function(){
      // Target your .container, .wrapper, .post, etc.
      $(".media").fitVids();
    });

})(jQuery);