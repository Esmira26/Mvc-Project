document.querySelector(".fa-comment-dots").addEventListener("click", function () {
    document.querySelector(".yumru ul").classList.toggle("nav-active")
})

document.querySelectorAll(".gul1 img").forEach(x => {
    x.addEventListener('click', function () {
        document.querySelector(".gul img").src = x.src;
    })
})