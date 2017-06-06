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

$(document).ready(function () {
    $("#submit-coupon").click(UpdateCoupon);
});
function UpdateCoupon() {
    var code = $("#coupon-code").val();
   
    $.ajax({
        type: "POST",
        url: "Cart/ApplyCoupon",
        data: { code: code },
        success: function (response) {
            window.location.href = response.Url;
        },
        error: function () {
        }
    });
   // alert(code);
  
} 
$(document).ready(function () {
    $("#update").click(UpdateCart);
});
function UpdateCart() {
    var id = $("#id").attr('aria-valuenow');
    var aantal = $("#aantal").val();

    $.ajax({
        type: "POST",
        url: "Cart/UpdateCart",
        data: { id: id, aantal : aantal},
        success: function (response) {
            window.location.href = response.Url;
        },
        error: function () {
        }
    });
    // alert(id + " " + aantal);

} 