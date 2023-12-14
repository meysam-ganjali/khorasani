
// number count for stats, using jQuery animate

$('.counting').each(function () {
    var $this = $(this),
        countTo = $this.attr('data-count');

    $({ countNum: $this.text() }).animate({
        countNum: countTo
    },

    {

        duration: 3000,
        easing: 'linear',
        step: function () {
            $this.text(Math.floor(this.countNum));
        },
        complete: function () {
            $this.text(this.countNum);
            //alert('finished');
        }

    });


});



//collapsible
$(document).ready(function () {
    var coll = document.getElementsByClassName("collapsible");
    var i;

    for (i = 0; i < coll.length; i++) {
        coll[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var content = this.nextElementSibling;
            if (content.style.maxHeight) {
                content.style.maxHeight = null;
            } else {
                content.style.maxHeight = content.scrollHeight + "px";
            }
        });
    }

});



//Tejarat vizhe 
function mainslider() {
    jQuery('#owl-mainslider').owlCarousel({
        items: 1,
        nav: true,
        dots: false,
        //margin: 10,
        autoplay: true,
        loop: true,
        mouseDrag: true,
        touchDrag: true,
        autoplayHoverPause: true,
        smartSpeed: 1500,
        autoplayTimeout: 5000,
    });
}


//popular doctors_index_page
function owltoparticle() {
    jQuery('#owl-toparticle').owlCarousel({
        rtl: true,
        loop: true,
        nav: true,
        autoplay: true,
        smartSpeed: 2000,
        autoplayTimeout: 4000,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            480: {
                items: 1,
            },
            768: {
                items: 2,
            },

            1200: {
                items:4
            }
              , 1367: {
                  items:4,
              }
        }
    });
}


//popular doctors_index_page
function owlproject() {
    jQuery('#owl-project').owlCarousel({
        rtl: true,
        loop: true,
        nav: true,
        autoplay: true,
        smartSpeed: 2000,
        autoplayTimeout: 4000,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            480: {
                items: 1,
            },
            768: {
                items: 2,
            },

            1200: {
                items: 3
            }
              , 1367: {
                  items:3,
              }
        }
    });
}


//popular doctors_index_page
function owlblog() {
    jQuery('#owl-blog').owlCarousel({
        rtl: true,
        loop: true,
        nav: true,
        autoplay: true,
        smartSpeed: 2000,
        autoplayTimeout: 4000,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            480: {
                items: 1,
            },
            768: {
                items: 2,
            },

            1200: {
                items: 3
            }
              , 1367: {
                  items: 4,
              }
        }
    });
}



//popular doctors_index_page
function owlblogd3() {
    jQuery('#owl-blogd3').owlCarousel({
        rtl: true,
        loop: true,
        nav: true,
        autoplay: true,
        smartSpeed: 2000,
        autoplayTimeout: 4000,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            480: {
                items:2,
            },
            768: {
                items: 3,
            },

            1200: {
                items: 4
            }
              , 1367: {
                  items: 5,
              }
        }
    });
}




//popular doctors_index_page
function owldecoproject() {
    jQuery('.owl-decoproject').owlCarousel({
        rtl: true,
        loop: true,
        nav: true,
        autoplay: true,
        smartSpeed: 2000,
        autoplayTimeout: 4000,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            480: {
                items: 2,
            },
            768: {
                items: 3,
            },

            1200: {
                items: 4
            }
              , 1367: {
                  items: 5,
              }
        }
    });
}


//popular doctors_index_page
function owloutproject() {
    jQuery('.owl-outproject').owlCarousel({
        rtl: true,
        loop: true,
        nav: true,
        autoplay: true,
        smartSpeed: 3000,
        autoplayTimeout: 5000,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            480: {
                items: 2,
            },
            768: {
                items: 3,
            },

            1200: {
                items: 4
            }
              , 1367: {
                  items: 5,
              }
        }
    });
}
//popular doctors_index_page
function customers() {
    jQuery('#owl-customers').owlCarousel({
        rtl: true,
        loop: true,
        nav: true,
        autoplay: true,
        smartSpeed: 2000,
        autoplayTimeout: 4000,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            480: {
                items:3,
            },
            768: {
                items: 4,
            },

            1200: {
                items: 6
            }
              , 1367: {
                  items:6,
              }
        }
    });
}

function customershoz() {
    jQuery('#owl-customershoz').owlCarousel({
        rtl: true,
        loop: true,
        nav: true,
        autoplay: true,
        smartSpeed: 2000,
        autoplayTimeout: 4000,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            480: {
                items: 1,
            },
            768: {
                items: 2,
            },

            1200: {
                items: 3
            }
              , 1367: {
                  items:3,
              }
        }
    });
}

//popular doctors_index_page
function customerscomnt() {
    jQuery('#owl-customerscomnt').owlCarousel({
        rtl: true,
        loop: true,
        nav: true,
        autoplay: true,
        smartSpeed: 2000,
        autoplayTimeout: 4000,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            480: {
                items: 1,
            },
            768: {
                items: 2,
            },

            1200: {
                items: 4
            }
              , 1367: {
                  items: 4,
              }
        }
    });
}
/**** All function are called here ******/
$(document).ready(function () {

    mainslider();
    //owlNtejari(),
    //owlTamin(),
    //owlStory(),
    //owlevent1(),
    //owlevent4(),
    //owlevent5(),
 
    //owlcustomer(),
    //owldemo5(),
    //owlcourse(),
    //teletype(),
    //prcingtable(),
    customers(),
    customershoz(),
    customerscomnt(),
    owlblog(),
    owlblogd3(),
    owldecoproject(),
    owloutproject(),
    owlproject(),
    owltoparticle();
});




//popupgallery
$('.popup-gallery').magnificPopup({
    delegate: 'a',
    type: 'image',
    tLoading: 'Loading image #%curr%...',
    mainClass: 'mfp-with-zoom mfp-img-mobile',
    gallery: {
        enabled: true,
        navigateByImgClick: true,
        preload: [0, 1]
    },
    zoom: {
        enabled: true,
        duration: 300
    },
    image: {
        tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
    }
});


