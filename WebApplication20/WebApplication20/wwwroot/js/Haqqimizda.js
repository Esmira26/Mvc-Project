let array = [
    "Haqqımızdakı Məlumatlar"
    "Öz Zövqünə Uyğun Unikal Buket Yarat",
    "Qeydiyyatdan Keçərək Sifarişini Tamamla",
]
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
