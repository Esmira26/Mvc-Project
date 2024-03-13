document.querySelector(".fa-comment-dots").addEventListener("click", function () {
    document.querySelector(".yumru ul").classList.toggle("nav-active")
})

document.querySelector(".ode").addEventListener("click", function () {
    document.querySelector(".pencere").style.display = "block"
});

$(".nav1 input").keyup(() => {
    if ($(".nav1 input").val() == "") {
        $(".axtaris-category").empty()
        $(".axtaris-product").css('padding', '0px').empty()
        $(".axtaris-category").hide()
        $(".axtaris-product").hide()

    }
    else {
        $.get('/Home/PostData?q=' + $(".nav1 input").val(), function (res) {
            $(".axtaris-category").empty()
            $(".axtaris-product").css('padding', '30px').empty()
            $(".axtaris-category").css("display", "flex")
            $(".axtaris-product").show()

            res.cat.forEach(x => {
                $(".axtaris-category").append(`
                       <div class="product1">
                       <a href="/Home/Mehsul/${x.categoryId}">
                                 <i class="fa-solid fa-align-right"></i>
                                 <h1>${x.categoryName}</h1>
                                 </a>
                             </div>
                `)
            })
            res.prp.forEach(x => {
                console.log(x)
                $(".axtaris-product").append(`
                        <div class="productt1">
                             <img src="/img/${x.photos[0].photoUrl}" />
                             <h1>${x.mehsulAd}</h1>
                             <div class="icon5">
                                   <i class="fa-solid fa-star"></i>
                                   <i class="fa-solid fa-star"></i>
                                   <i class="fa-solid fa-star"></i>
                                   <i class="fa-solid fa-star"></i>
                                   <i class="fa-solid fa-star"></i>
                             </div>
                             <p>${x.mehsulQiymeti}.00₼</p>
                            <a href="/Home/Melumat/${x.mehsulId}"><i class="fa-solid fa-chevron-right"></i></a>
				</div>
                `)
            })
        })
    }
})

$(".fa-magnifying-glass").click(function () {
    $(".axtaris").toggle("aktivee")
    $(".nav1 input").val("")
})

$(".fa-magnifying-glass").click(function () {
    $(".umuminav").css("display", "block");
})

$(".fa-xmark").click(function () {
    $(".umuminav").css("display", "none");
})