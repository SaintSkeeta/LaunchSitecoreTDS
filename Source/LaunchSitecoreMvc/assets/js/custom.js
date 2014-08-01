jQuery.noConflict();
jQuery(document).ready(function ($) {

 // Start the carousel
 jQuery('.carousel').carousel({ pause: "hover" });

 /** Dropdown menu more information: http://twitter.github.com/bootstrap/javascript.html#dropdowns */
 jQuery('.dropdown-toggle').dropdown();

 // make menu open on hover
 jQuery(".dropdown").hover(
		function () {
		 jQuery(this).addClass("open");
		},
		function () {
		 jQuery(this).removeClass("open");
		}
	);

 // make bootstrap fix for ipad
 jQuery('body').on('touchstart.dropdown', '.dropdown-menu', function (e) { e.stopPropagation(); })

 // Toggle Boxes - more information: http://twitter.github.com/bootstrap/javascript.html#collapse
 jQuery('.accordion').collapse();
 // make correction status icons Toggle Boxes
 jQuery('.accordion').on('shown', function () {
  colorSwitcherPosition();
  jQuery('.accordion-group').each(function () {
   if (jQuery(this).children(".accordion-body").hasClass("in")) jQuery(this).children(".accordion-heading").children("a").removeClass("collapsed");
   else jQuery(this).children(".accordion-heading").children("a").addClass('collapsed');
  });
 })
 jQuery('.accordion').css('height', 'auto');
});

jQuery(document).ready(function () {
 resizeBanner();
 colorSwitcherPosition();
 jQuery('#mtp-toggle').click(function (e) {
  if (jQuery(this).is('.mtp-toggle-close')) {
   jQuery('#mtp-wrapper, #mtp-toggle').stop(true, true).animate({ 'right': '-260px' }, 300);
   setTimeout(function () {
    jQuery('#mtp-toggle').toggleClass('mtp-toggle-close');
   }, 500);

   // on close we should collapse all
   jQuery('.accordion-group').each(function () {
    jQuery(this).children(".accordion-heading").children("a").addClass('collapsed');
    jQuery(this).children(".accordion-body").css('height', '0px');
    jQuery(this).children(".accordion-body").removeClass('in');
    //resize the over tag on close
    colorSwitcherPosition();
   });
  }
  else {
   jQuery('#mtp-wrapper, #mtp-toggle').stop(true, true).animate({ 'right': 0 }, 300);
   jQuery('#mtp-toggle').toggleClass('mtp-toggle-close');
  }
  e.stopPropagation();
 });
})

jQuery(document).ready(function () {
 colorSwitcherPosition();
 resizeBanner();
});

jQuery(window).resize(function () {
 resizeBanner();
})

function resizeBanner() { 
 var w = jQuery('#enhanced-carousel').width();
 var h = w / 2.5; 
 if (h > 100) {
  jQuery('#enhanced-carousel').height(h);
  jQuery('#enhanced-carousel').children('.carousel-inner').children('.item').height(h);
  jQuery('#enhanced-carousel').children('.carousel-inner').children('.item').children('img').height(h);
 }
}

function colorSwitcherPosition() {
 var h = jQuery(window).height();
 if (h < jQuery("#mtp-wrapper").height()) {
  jQuery("#mtp-toggle, #mtp-wrapper").addClass('absolute');
 } else {
  jQuery("#mtp-toggle, #mtp-wrapper").removeClass('absolute');
 }
 jQuery("#over").animate({ 'min-height': jQuery("#mtp-wrapper").height() + 200 + "px" }, 300);
}
jQuery(window).resize(function () {
 colorSwitcherPosition();
})