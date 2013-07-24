function resizeImages(el) {
    jQuery(el).each(function () {         
         $(this).css({ height: 'auto', width: 'auto',
        });
    });
}


function TopMenuToggle(a) {
    var b = document.getElementById("menu");
    var c = document.getElementById("menu_btn");
    var d = document.getElementById("search");
    var e = document.getElementById("search_btn");
    if ("menu" == a) {
        d.style.display = "none";
        if ("none" == b.style.display || "" == b.style.display) {
            b.style.display = "block";
            c.style.background = "url(/images/mobile/button_pressed_bg.jpg) top left repeat-x";
            e.style.background = "url(/images/mobile/button_unpressed_bg.jpg) top left repeat-x"
        }
        else {
            b.style.display = "none";
            c.style.background = "url(/images/mobile/button_unpressed_bg.jpg) top left repeat-x"
        }
    }
    if ("search" == a) {
        b.style.display = "none";
        if ("none" == d.style.display || "" == d.style.display) {
            d.style.display = "block";
            e.style.background = "url(/images/mobile/button_pressed_bg.jpg) top left repeat-x";
            c.style.background = "url(/images/mobile/button_unpressed_bg.jpg) top left repeat-x"
        }
        else {
            d.style.display = "none";
            e.style.background = "url(/images/mobile/button_unpressed_bg.jpg) top left repeat-x"
        }
    }
}

function CloseMenu() {
    var a = document.getElementById("menu");
    var b = document.getElementById("menu_btn");
    a.style.display = "none";
    b.style.background = "url(/images/mobile/button_unpressed_bg.jpg) top left repeat-x" 
} 

function DMSToggle() {
    var b = document.getElementById("dmsBtn"); 
    var a = document.getElementById("dmsdetails");      
    if ("none" == a.style.display || "" == a.style.display) { 
        a.style.display = "block"; 
        b.className = "opened" 
    } 
    else { 
        a.style.display = "none"; 
        b.className = "closed" 
    } 
}