let thumbnails = document.querySelectorAll("#slider .thumbnail");

for (let i = 0; i < thumbnails.length; i++) {
    thumbnails[i].addEventListener("click", handleThumbnailClick);
}

function handleThumbnailClick(e) {
    let thumbnail = e.currentTarget;

    selectThumbnail(thumbnail);

}

function selectThumbnail(thumbnail) {
    let currentSelectedThumbnail = document.querySelector("#slider .thumbnail.selected");
    currentSelectedThumbnail.classList.remove("selected");

    thumbnail.classList.add("selected");
    let clickedLargeImagePath = thumbnail.getAttribute("data-large-img-url");

    let mainImage = document.querySelector("#slider-main-picture-container img");
    mainImage.src = clickedLargeImagePath;
}




