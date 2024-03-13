let array = [
    "Öz Zövqünə Uyğun Unikal Buket Yarat",
    "Qeydiyyatdan Keçərək Sifarişini Tamamla",
    "Fərqli Dizayna Malik Güllərimizdən Səndə Yararlan",
]

window.addEventListener("scroll", function () {
    if (window.scrollY >= 20) {
        document.querySelector("nav").style.backgroundColor = "white"
        document.querySelector("nav a h1").style.color = "black"
        document.querySelectorAll("nav ul li").forEach(x => {

            x.firstElementChild.style.color = "black"
        })
        document.querySelector("nav .icon i").style.color = "black"
        document.querySelectorAll("nav .icon a").forEach(y => {
            y.firstElementChild.style.color = "black"
        })
    }
    else {
        document.querySelector("nav").style.backgroundColor = ""
        document.querySelector("nav a h1").style.color = ""
        document.querySelectorAll("nav ul li").forEach(x => {

            x.firstElementChild.style.color = ""
        })
        document.querySelector("nav .icon i").style.color = ""
        document.querySelectorAll("nav .icon a").forEach(y => {
            y.firstElementChild.style.color = ""
        })
    }
    console.log(window.scrollY)
})
var sira = 0;
function append() {
    if (sira == array.length - 1) {
        sira = 0
    }
    else {
        sira++
    }
    document.querySelector("header h1").innerText = array[sira]
    document.querySelector("header h1").style.animationName = 'none'
    void document.querySelector("header").offsetWidth
    document.querySelector("header h1").style.animationName = 'anim'
}

setInterval(append, 4000);


let yazi = [
    "101 Çəhrayı qızılgüldən hazırlanan əsrarəngiz buket. 1-ci Sifarişdən sonra çatdırılmamız sizin üçün pulsuz olacaqdır.Sizdə öz zövqünüzə uyğun buketlərdən zakaz edərək yaxınlarınızı sevindirə bilərsiz.Sizdə öz zövqünüzə uyğun buketlərdən zakaz edərək yaxınlarınızı sevindirə bilərsiz. Hər bölgə üzrə çatdırılmamız uyğundur. 1-ci Sifarişdən sonra çatdırılmamız sizin üçün pulsuz olacaqdır. Və qeydiyyatdan keçən hər bir şəxs üçün ilk sifaris üçün çatdırılma tamamilə pulsuzdur. Sizdə öz zövqünüzə uyğun buketlərdən zakaz edərək yaxınlarınızı sevindirə bilərsiz. Hər bölgə üzrə çatdırılmamız uyğundur. 1-ci Sifarişdən sonra çatdırılmamız sizin üçün pulsuz olacaqdır. Və qeydiyyatdan keçən hər bir şəxs üçün ilk sifaris üçün çatdırılma tamamilə pulsuzdur. Elə isə səndə sevdiklərinlə birgə bu xoşbəxt anı yaşamaq üçün tələs.",
    "101 Çəhrayı qızılgüldən hazırlanan əsrarəngiz buket. 1-ci Sifarişdən sonra çatdırılmamız sizin üçün pulsuz olacaqdır.Sizdə öz zövqünüzə uyğun buketlərdən zakaz edərək yaxınlarınızı sevindirə bilərsiz.Sizdə öz zövqünüzə uyğun buketlərdən zakaz edərək yaxınlarınızı sevindirə bilərsiz. Hər bölgə üzrə çatdırılmamız uyğundur. 1-ci Sifarişdən sonra çatdırılmamız sizin üçün pulsuz olacaqdır. Və qeydiyyatdan keçən hər bir şəxs üçün ilk sifaris üçün çatdırılma tamamilə pulsuzdur. Sizdə öz zövqünüzə uyğun buketlərdən zakaz edərək yaxınlarınızı sevindirə bilərsiz. Hər bölgə üzrə çatdırılmamız uyğundur. 1-ci Sifarişdən sonra çatdırılmamız sizin üçün pulsuz olacaqdır. Və qeydiyyatdan keçən hər bir şəxs üçün ilk sifaris üçün çatdırılma tamamilə pulsuzdur. Elə isə səndə sevdiklərinlə birgə bu xoşbəxt anı yaşamaq üçün tələs."   
]
var siraa = 0;
function appendd() {
    if (siraa == yazi.length - 1) {
        siraa = 0
    }
    else {
        siraa++
    }
    document.querySelector(".video .img2 p").innerText = yazi[siraa]
    document.querySelector(".video .img2 p").style.animationName = 'none'
    void document.querySelector(".video").offsetWidth
    document.querySelector(".video .img2 p").style.animationName = 'anim'
}
setInterval(appendd, 4000);


document.querySelectorAll(".love i").forEach(x => {
    x.addEventListener("click", function () {
        x.classList.toggle("active").TransitionEvent(2000)
    })
});

document.querySelector(".fa-comment-dots").addEventListener("click", function () {
    document.querySelector(".yumru ul").classList.toggle("nav-active")
})
setInterval(3000)


window.onload = function () {
    $('.slider').slick({
        autoplay: true,
        autoplaySpeed: 1000,
        arrows: true,
        prevArrow: '<button type="button" class="slick-prev"></button>',
        nextArrow: '<button type="button" class="slick-next"></button>',
        centerMode: true,
        slidesToShow: 3,
        slidesToScroll: 2
    });
};

document.querySelector(".img .fa-play").addEventListener("click", function () {
    document.querySelector(".video1").classList.toggle("iframee")
})


$(".nav1 input").keyup(() => {
    if ($(".nav1 input").val() == "") {
        $(".axtaris-category").empty()
        $(".axtaris-product").css('padding', '0px').empty()
            $(".axtaris-category").hide()
            $(".axtaris-product").hide()

        }
       else {
        $.get('Home/PostData?q=' + $(".nav1 input").val(), function (res) {
            $(".axtaris-category").empty()
            $(".axtaris-product").css('padding', '30px').empty()
        $(".axtaris-category").css("display","flex")
        $(".axtaris-product").show()
          
            res.cat.forEach(x => {
                $(".axtaris-category").append(`
                       <div class="product1">
                       <a href="Home/Mehsul/${x.categoryId}">
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
                             <img src="./img/${x.photos[0].photoUrl}" />
                             <h1>${x.mehsulAd}</h1>
                             <div class="icon5">
                                   <i class="fa-solid fa-star"></i>
                                   <i class="fa-solid fa-star"></i>
                                   <i class="fa-solid fa-star"></i>
                                   <i class="fa-solid fa-star"></i>
                                   <i class="fa-solid fa-star"></i>
                             </div>
                             <p>${x.mehsulQiymeti}.00₼</p>
                            <a href="Home/Melumat/${x.mehsulId}"><i class="fa-solid fa-chevron-right"></i></a>
				</div>
                `)
            })
        })
        }   
})


$(".fa-magnifying-glass").click(function () {
    $(".axtaris").toggle("aktivee")
})

$(".fa-magnifying-glass").click(function () {
    $(".umuminav").css("display", "block");
})

$(".fa-xmark").click(function () {
    $(".umuminav").css("display", "none");
})

$(".icon .fa-bars").click(function () {
    $("header .bar").toggleClass("aktivv")
})