//$("body").on("keyup", ".elaqe2 input", function () {
//    // if ($(this).val() == "") {
//    //     $(this).parents(".inpt1").children().eq(1).css("top","%50")
//    // }
//    // else{
//    //     $(this).parents(".inpt1").children().eq(1).css("top","0px")
//    // }
//    $(".elaqe2 input").each(x => {
//        if ($(this).val() == "") {
//            $(this).parents(".inpt1").children().eq(1).css("top", "50%")
//        }
//        else {
//            $(this).parents(".inpt1").children().eq(1).css("top", "-5px")
//        }
//    })
//})
document.querySelector('#photoselect').addEventListener('change', function () {
    alert()
    let photo1 = document.createElement('div');
    photo1.className = 'photo1'
    let img = document.createElement('img')
    img.src = URL.createObjectURL(this.files[0])
    photo1.appendChild(img)
    photo1.appendChild(this.cloneNode(true))
    this.value = null
    photo1.addEventListener('click', function () {
        this.remove()
    })
    document.querySelector('.photoarea').appendChild(photo1);
})
ClassicEditor.create(document.querySelector("#editor")).catch((error) => {
    console.error(error);
});
