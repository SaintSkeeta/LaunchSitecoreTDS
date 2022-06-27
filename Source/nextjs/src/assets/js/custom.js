jQuery.noConflict();
jQuery(document).ready(function ($) {

 // Start the carousel
 jQuery('.carousel').carousel({ pause: "hover" });

 // make menu open on hover
 jQuery(".dropdown").hover(
		function () {
		 jQuery(this).addClass("open");
		},
		function () {
		 jQuery(this).removeClass("open");
		}
	);
});

jQuery(document).ready(function() {
    jQuery('#mtp-toggle').click(function(e) {
        if (jQuery(this).is('.mtp-toggle-close')) {
            jQuery('#mtp-wrapper, #mtp-toggle').stop(true, true).animate({ 'right': '-260px' }, 300);
            setTimeout(function() {
                jQuery('#mtp-toggle').toggleClass('mtp-toggle-close');
            }, 500);

            // on close we should collapse all
            jQuery('.accordion-group').each(function() {
                jQuery(this).children(".accordion-heading").children("a").addClass('collapsed');
                jQuery(this).children(".accordion-body").css('height', '0px');
                jQuery(this).children(".accordion-body").removeClass('in');
            });
        } else {
            jQuery('#mtp-wrapper, #mtp-toggle').stop(true, true).animate({ 'right': 0 }, 300);
            jQuery('#mtp-toggle').toggleClass('mtp-toggle-close');
        }
        e.stopPropagation();
    });
});

