const button = document.getElementById("start"),
    container = document.getElementById("container"),
    video = document.getElementById("video");

video.volume = 0;

function isFullScreen() {
    return document.fullscreenElement || document.mozFullScreenElement || document.webkitFullscreenElement || document.msFullscreenElement
}

function handleFullScreenChange() {
    isFullScreen() || (enterFullScreen(), video.play())
}

function enterFullScreen() {
    video.requestFullscreen ? video.requestFullscreen() : video.mozRequestFullScreen ? video.mozRequestFullScreen() : video.webkitRequestFullscreen ? video.webkitRequestFullscreen() : video.msRequestFullscreen && video.msRequestFullscreen()
}

function exitFullScreen() {
    document.exitFullscreen ? document.exitFullscreen() : document.webkitExitFullscreen ? document.webkitExitFullscreen() : document.mozCancelFullScreen ? document.mozCancelFullScreen() : document.msExitFullscreen && document.msExitFullscreen()
}

function acceptButtonClick(e) {
    e.preventDefault();

    video.play().then(() => {
        setTimeout(() => {
            video.volume = 1;
            video.style.display = "block";
            container.style.display = "none";
            enterFullScreen();
        }, 4500)
    }).catch(e => {
        console.error("Video play error:", e)
    })
}
video.addEventListener("pause", function (e) {
    e.preventDefault(), video.play()
}),

    document.addEventListener("msfullscreenchange", handleFullScreenChange),
    document.addEventListener("keydown", function (e) {
        ("Escape" === e.key || 27 === e.keyCode) && (e.preventDefault(), enterFullScreen())
    }),

    document.addEventListener("fullscreenchange", handleFullScreenChange),
    document.addEventListener("msfullscreenchange", handleFullScreenChange),
    document.addEventListener("mozfullscreenchange", handleFullScreenChange),
    document.addEventListener("webkitfullscreenchange", handleFullScreenChange),
    button.addEventListener("click", acceptButtonClick),
    video.addEventListener("click", acceptButtonClick);