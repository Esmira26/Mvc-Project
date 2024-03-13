
$(".mobil #mobill").change(function () {
    $(".giris input").each(function () {
        $(this).val("")
    })
    $(".umumi53").css("display","none")
    $(".umumi52").css("display", "block")
})
$(".email #emaill").change(function () {
    $(".giris input").each(function () {
        $(this).val("")
    })
    $(".umumi52").css("display", "none")
    $(".umumi53").css("display", "block")
})


var swiper = new Swiper(".mySwiper", {
    spaceBetween: 30,
    centeredSlides: true,
    autoplay: {
        delay: 2500,
        disableOnInteraction: false,
    },
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});


//document.querySelector(".span2").addEventListener("click", function () {
//    document.querySelector(".up").classList.toggle("aktiv")
//    document.querySelector(".orta1").classList.toggle("orta1-aktiv")
//})

$("body").on("keyup", ".orta1 input", function () {
    // if ($(this).val() == "") {
    //     $(this).parents(".inpt1").children().eq(1).css("top","%50")
    // }
    // else{
    //     $(this).parents(".inpt1").children().eq(1).css("top","0px")
    // }
    $(".orta1 input").each(x => {
        if ($(this).val() == "") {
            $(this).parents(".mobil").children().eq(1).css("top", "50%")
        }
        else {
            $(this).parents(".mobil").children().eq(1).css("top", "-10px")
        }
    })
})