document.addEventListener("DOMContentLoaded", function () {
    // Sayfa yüklendiğinde sepete ekleme alert'i kontrolü
    checkAndAnimateAlert();
});

function checkAndAnimateAlert() {
    var alertDiv = document.getElementById("alertDiv");
    if (alertDiv) {
        // Alert div'i varsa animasyonlu bir şekilde göster
        alertDiv.classList.add("animateanimated", "animateslideInDown");

        // Belirli bir süre sonra alert'i gizle
        setTimeout(function () {
            alertDiv.classList.remove("animateslideInDown");
            alertDiv.classList.add("animateslideOutUp");

            // Belirli bir süre sonra alert div'ini tamamen kaldır
            setTimeout(function () {
                alertDiv.remove();
            }, 1000); // 1000 milisaniye (1 saniye)
        }, 3000); // 3000 milisaniye (3 saniye)
    }
}