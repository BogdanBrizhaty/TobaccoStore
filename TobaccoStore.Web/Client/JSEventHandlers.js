// ALERT: NO ANGULAR STUFF HERE!
function HideButton() {
    var container = event.currentTarget.parentElement;

    if ($(container).first().find(".btn-container").is(':hover'))
        return;

    var cont = $(container).find(".btn-container").first();
    cont.html('<span class="add-to-cart-unactive">&nbsp;</span>');
}
function HideButton2() {
    $(event.currentTarget).html('<span class="add-to-cart-unactive">&nbsp;</span>');
}

function addToCartEventHandler() {
    angular.element(document.getElementById('productContainer')).scope().addToCartHndlr();
}
function removeFromCartEventHandler() {
    // yep, another dirty call. If you're viewing this shit-code and you're my job interviewer, I apologize =/
    angular.element(document.getElementById('productContainer')).scope().removeFromCartHndlr();
}
function changeHeader(event, imageName) {
    $(document).find(".hdr-img").each((i, el) => {
        $(el).fadeOut('fast');

        var sender = event.currentTarget;

        setTimeout((sender) => {
            el.style.background = 'url(/Content/' + imageName + ') no-repeat center center';
            $('.menu-item').each((i, el) => {
                $(el).removeClass('active-link');
            });
            $(sender.parentElement).addClass('active-link');
            $(el).fadeIn('fast')
        }, 150, sender);
    });
}
function fumariClick() {
    changeHeader(event, 'fumariBackground.jpg');

}
function serbentliClick() {
    changeHeader(event, 'serbentliBackground.png');
}
function alfakherClick() {
    changeHeader(event, 'alfakherBackground.png');
}
function darksideClick() {
    changeHeader(event, 'darksideBackground.png');
}