let hamburger = document.querySelector(".hamburger");

hamburger.addEventListener("click", () => {
    let navLinks = document.querySelector(".nav-area");

    navLinks.classList.toggle("show");
})