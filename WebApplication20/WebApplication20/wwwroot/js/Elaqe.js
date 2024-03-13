document.querySelector(".fa-comment-dots").addEventListener("click", function () {
    document.querySelector(".yumru ul").classList.toggle("nav-active")
})


$("body").on("keyup", ".elaqe2 input", function () {
    // if ($(this).val() == "") {
    //     $(this).parents(".inpt1").children().eq(1).css("top","%50")
    // }
    // else{
    //     $(this).parents(".inpt1").children().eq(1).css("top","0px")
    // }
    $(".elaqe2 input").each(x => {
        if ($(this).val() == "") {
            $(this).parents(".inpt1").children().eq(1).css("top", "50%")
        }
        else {
            $(this).parents(".inpt1").children().eq(1).css("top", "-10px")
        }
    })
})
