// ALERT: NO ANGULAR STUFF HERE!
//function HideButton() {
//    var container = event.currentTarget.parentElement;

//    if ($(container).first().find(".btn-container").is(':hover'))
//        return;

//    var cont = $(container).find(".btn-container").first();
//    cont.html('<span class="add-to-cart-unactive">&nbsp;</span>');
////}
//function HideButton2() {
//    $(event.currentTarget).html('<span class="add-to-cart-unactive">&nbsp;</span>');
//}

function addToCartEventHandler() {
    angular.element(document.getElementById('productContainer')).scope().addToCartHndlr();
}
function removeFromCartEventHandler() {
    // yep, another dirty call. If you're viewing this shit-code and you're my job interviewer, I apologize =/
    angular.element(document.getElementById('productContainer')).scope().removeFromCartHndlr();
}
function changeHeader(event, newHref) {
    $(document).find(".hdr-img").each((i, el) => {

        var sender = event.currentTarget;

        var path = location.hash;
        path = path.replace('#!/', '');

        if (path !== newHref && path !== '')
        {
            $('#content-holder').removeClass('d-block').addClass('d-none');
            $('#preloader-holder').removeClass('d-none').addClass('d-block');

            $(el).fadeOut('fast');

            setTimeout((sender) => {
                el.style.background = 'url(/Content/' + newHref + 'Background.png' + ') no-repeat center center';
                $('.menu-item').each((i, el) => {
                    $(el).removeClass('active-link');
                });
                $(sender.parentElement).addClass('active-link');
                $(el).fadeIn('fast')
            }, 350, sender);
        }
    });
}

function menuButtonClicked(category) {
    openUpBannerZone();
    changeHeader(event, category);
}

function toStoreBtnClick() {
    $('html, body').animate({
        scrollTop: $(".body-content").offset().top
    }, 'fast');
}

$(document).ready(() => {
    var cart = JSON.parse(localStorage.getItem('cart'));
    //console.log(cart);
    $('#cart-count').html(cart.length);
    //console.log(cart.length);
    

    // disable horizontal scroll
    //var $body = $(document);
    //$body.bind('scroll', function () {
    //    // "Disable" the horizontal scroll.
    //    if ($body.scrollLeft() !== 0) {
    //        $body.scrollLeft(0);
    //    }
    //});
})

function termsOfTransactioningClick() {
    $('.msg-box-background').removeClass('d-none').addClass('d-block');
    disableScrolling();

}


// MSG BOX EVENTS
function msgBoxOk() {

}

function closeTermsClick() {
    $('.msg-box-background').removeClass('d-block').addClass('d-none');
    enableScrolling();
}

var scrollPosition = null;

function disableScrolling() {
    $('html, body').css({
        overflow: 'hidden',
        height: '100%'
    });
}

function enableScrolling() {
    $('html, body').css({
        overflow: 'auto',
        height: 'auto'
    });
}

// if cart clicked or home
function hideBannerZone() {
    $('.hdr-img').animate({ height: '90px' }, 'fast');
    $('#main-menu-container').animate({ height: '90px' }, 'fast');
    $('#toStoreBtn').fadeOut();
}

function openUpBannerZone() {
    var height = $('.hdr-img').first().height();
    if (height < 540)
    {
        $('.hdr-img').animate({ height: '540px' }, 'fast');
        $('#main-menu-container').animate({ height: '540px' }, 'fast');
        $('#toStoreBtn').fadeIn();
    }
}

function onProductOpen() {
    hideBannerZone();
    $('html, body').animate({
        scrollTop: $(".body-content").offset().top
    }, 'fast');
}