//var b;
//$("ul li").click(function () {
//    b = $(this).attr("class")
//    $(".umumi .buket").hide()
//    $("." + b).show()
//})
//document.querySelector(".fa-comment-dots").addEventListener("click", function () {
//    document.querySelector(".yumru ul").classList.toggle("nav-active")
//})

//$(".ul").on("click", "li", function () {
//    console.log($(this).attr("class"))
//    $.get('/Home/Hediyyeler/' + $(this).attr("class"), function (data) {
//        console.log(data)
//        $(".umumi").empty()

//        data.forEach(x => {
//            console.log(x)
//            $(".umumi").append(`
//                 <div class="buket cat-${x.mehsulCategoryId}" cat="">
//                <a href="/Home/Melumat/${x.mehsulId}">
//                        <a href="/Home/LoveGet/${x.mehsulId}">
//                            <div class="love">
//                                <i class="fa-regular fa-heart"></i>
//                            </div>
//                        </a>
//                    <img src="/img/${x.photos[0].photoUrl}" alt="" srcset="">
//						<h2><a href="/Home/Melumat/${x.mehsulId}">${x.mehsulAd}</a></h2>  
//                    <h1>${x.mehsulunKodu}</h1>
//                    <p>${x.mehsulQiymeti}.00₼</p>
//                    <form asp-action="Sebet" asp-controller="Home" asp-route-id="${x.mehsulId}">
//                    <button><i class="fa-solid fa-cart-shopping"></i>Səbətə</button>
//                    </form>
//                </a>
//            </div>
//            `)
//        })
//    })
//})