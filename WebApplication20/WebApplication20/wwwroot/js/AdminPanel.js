$(".input i").click(() => {
            $("tbody").empty()
    $.get('/Admin/AdminData?search=' + $(".input input").val(), function (res) {
        console.log(res)
        res.forEach(x => {
            console.log(x)
            $("tbody").append(`
                   <tr>
                            <td>${x.mehsulunKodu}</td>
                            <td><img src="/img/${x.photos[0].photoUrl}" alt=""></td>
                            <td>${x.mehsulAd}</td>
                                <td>${x.mehsulQiymeti}.00₼</td>
                            <td>
                                <a href="/Admin/Active/${x.mehsulId}">
                                        <div class="yumru" style=${x.mehsulStatus=="Active"?"background-color:green":"background-color:#2e2e2e"}>
                                        <div class="yumru1" style=${x.mehsulStatus=="Active"?"right:10px":"left:0"}></div>
										</div>
									</a>
                            </td>
                            <td>${x.mehsulCategory.categoryName}</td>
                            <td>
                                <div class="del">
										<div class="edit"><a href="/Admin/Duzelis/${x.mehsulId}"><i class="fa-regular fa-pen-to-square"></i></a></div>
                                        <div class="delete"><a href="/Admin/Silmek/${x.mehsulId}"><i class="fa-solid fa-minus"></i></a></div>
                                </div>
                            </td>
                        </tr>
            `)
        })
    })
})
