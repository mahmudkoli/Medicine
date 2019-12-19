$(document).ready(function($) {
    $("a.btn-medicine").click(function() {

        $(".medicine-price").fadeIn(300);
        $(".ambulence-search").fadeOut(0);
        $(".donar-search").fadeOut(0);
        return false;
    });
   
    $("a.btn-b-donar").click(function() {
        $(".medicine-price").fadeOut(0);
        $(".ambulence-search").fadeOut(0);
        $(".donar-search").fadeIn(300);
        return false;
    });

    // Chanegs Bg
    $(".btn-medicine").click(function() {
        $(".header-section").css('background-image', 'url(images/bg-1.jpg)');
        return false;
    });
   
    $(".btn-b-donar").click(function() {
        $(".header-section").css('background-image', 'url(images/bg-3.jpg)');
        return false;
    });

    // Login Popup

    $(".btn-login").click(function() {
        $('body').find(".popup-login").addClass("show");

        $(".popup-close").click(function() {
            $(this).parent(".popup-login").removeClass("show");
            return false;
        });

        $(".btn-re-sign").click(function() {
            $(this).parents(".popup-login").removeClass("show");
            $(".popup-register").addClass("show");

            $('#blood_doanr').change(function() {
                if (this.checked)
                    $('.blood-donar-box').addClass('show');
                else
                    $('.blood-donar-box').removeClass('show');

            });
            return false;
        });

        return false;
    });
    // Registr Pop Up
    $(".btn-register").click(function() {
        $('body').find(".popup-register").addClass("show");

        $(".popup-close").click(function() {
            $(this).parent(".popup-register").removeClass("show");
            return false;
        });

        $('#blood_doanr').change(function() {
            if (this.checked)
                $('.blood-donar-box').addClass('show');
            else
                $('.blood-donar-box').removeClass('show');

        });
        return false;
    });

    // reset Passowrd
    $(".btn-forget-pass").click(function() {
        $(this).parents(".popup-login").removeClass("show");
        $('body').find(".popup-reset").addClass("show");

        $(".popup-close").click(function() {
            $(this).parent(".popup-reset").removeClass("show");
            return false;
        });
        return false;
    });


    // Custom File
    $(".custom-file-input").on("change", function() {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);


    });




}(jQuery));