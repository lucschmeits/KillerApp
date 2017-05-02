$(function () {
    $(".product").hover(function () {
        $(this).find(".product-overlay").fadeIn();
    }, function () {
        $(this).find(".product-overlay").fadeOut();
    });
});
$(function () {
    $('a[href="' + this.location.pathname + '"]').parent().addClass('active');
    $('a[href="' + this.location.pathname + '"]').addClass("menu-icon-active");
});
$(function () {
    $(".product").hover(function () {
        $(this).find(".img-product").css("opacity", "0.3");
    }, function () {
        $(this).find(".img-product").css("opacity", "1");
    }
    );
});