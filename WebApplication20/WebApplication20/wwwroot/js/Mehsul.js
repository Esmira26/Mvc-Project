document.querySelector(".fa-comment-dots").addEventListener("click", function () {
    document.querySelector(".yumru ul").classList.toggle("nav-active")
})
var pagId
$(".ul").on("click", "li", function () {
    console.log($(this).attr("class"))
    pagId = $(this).attr("class")
    $.get('/Home/MehsulData/' + $(this).attr("class"), function (data) {
        console.log(data)
        $(".umumi").empty()
       
        data.forEach(x => {
            console.log(x)
            $(".umumi").append(`
                 <div class="buket cat-${x.mehsulCategoryId}" cat="">
                <a href="/Home/Melumat/${x.mehsulId}">
                        <a href="/Home/LoveGet/${x.mehsulId}">
                            <div class="love">
                                <i class="fa-regular fa-heart"></i>
                            </div>
                        </a>
                    <img src="/img/${x.photos[0].photoUrl}" alt="" srcset="">
						<h2><a href="/Home/Melumat/${x.mehsulId}">${x.mehsulAd}</a></h2>  
                    <h1>${x.mehsulunKodu}</h1>
                    <p>${x.mehsulQiymeti}.00₼</p>
                    <form asp-action="Sebet" asp-controller="Home" asp-route-id="${x.mehsulId}">
                    <button><i class="fa-solid fa-cart-shopping"></i>Səbətə</button>
                    </form>
                </a>
            </div>
            `)
        })
    })
})

$(".pagCat").on("click", "li", function () {
    
    console.log($(this).attr("dataId"))

    $.get('/Home/MehsulData/'+pagId + $(this).attr("dataId"), function (data) {
        console.log(data)
        $(".umumi").empty()

        data.forEach(x => {
            console.log(x)
            $(".umumi").append(`
                 <div class="buket cat-${x.mehsulCategoryId}" cat="">
                <a href="/Home/Melumat/${x.mehsulId}">
                        <a href="/Home/LoveGet/${x.mehsulId}">
                            <div class="love">
                                <i class="fa-regular fa-heart"></i>
                            </div>
                        </a>
                    <img src="/img/${x.photos[0].photoUrl}" alt="" srcset="">
						<h2><a href="/Home/Melumat/${x.mehsulId}">${x.mehsulAd}</a></h2>  
                    <h1>${x.mehsulunKodu}</h1>
                    <p>${x.mehsulQiymeti}.00₼</p>
                    <form asp-action="Sebet" asp-controller="Home" asp-route-id="${x.mehsulId}">
                    <button><i class="fa-solid fa-cart-shopping"></i>Səbətə</button>
                    </form>
                </a>
            </div>
            `)
        })
    })
})


$(".cat").on('click', "p", function () {
    console.log($(this).attr("catId"))
    $.get('/Home/MehsulSubCatData/' + $(this).attr("catId"), function (data) {
        console.log(data)
        $(".umumi").empty()

        data.forEach(x => {
            console.log(x)
            $(".umumi").append(`
                 <div class="buket cat-${x.mehsulCategoryId}" cat="">
                <a href="/Home/Melumat/${x.mehsulId}">
                        <a href="/Home/LoveGet/${x.mehsulId}">
                            <div class="love">
                                <i class="fa-regular fa-heart"></i>
                            </div>
                        </a>
                    <img src="/img/${x.photos[0].photoUrl}" alt="" srcset="">
						<h2><a href="/Home/Melumat/${x.mehsulId}">${x.mehsulAd}</a></h2>  
                    <h1>${x.mehsulunKodu}</h1>
                    <p>${x.mehsulQiymeti}.00₼</p>
                    <form asp-action="Sebet" asp-controller="Home" asp-route-id="${x.mehsulId}">
                    <button><i class="fa-solid fa-cart-shopping"></i>Səbətə</button>
                    </form>
                </a>
            </div>
            `)
        })
    })
})

//var b;
//$(".ul ul li").click(function () {
//    b = $(this).attr("class")
//    console.log(b)
//    $(".umumi .buket").hide()
//    $(".cat-"+b).show()
//})

var c;
$(".cat p").click(function () {
    c = $(this).attr("class")
    $(".umumi .buket").hide()
    $(".cat-" + c).show()
})

