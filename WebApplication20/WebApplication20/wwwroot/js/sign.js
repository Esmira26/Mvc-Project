$(".mobil #mobill").change(function () {
    $(".giris input").each(function () {
        $(this).val("")
    })
    $(".umumi53").css("display", "none")
    $(".umumi52").css("display", "block")
})
$(".email #emaill").change(function () {
    $(".giris input").each(function () {
        $(this).val("")
    })
    $(".umumi52").css("display", "none")
    $(".umumi53").css("display", "block")
})
