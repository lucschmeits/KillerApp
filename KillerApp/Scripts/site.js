$(function () {
    $(".product").hover(function () {
        $(this).find(".product-overlay").fadeIn();
    }, function () {
        $(this).find(".product-overlay").fadeOut();
    });
});