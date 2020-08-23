document.addEventListener("click", function (e) {
    e.preventDefault();
    let number = getMonth();
    if (e.target.id === "btn-monthly-expenses") {
        window.location.href = `/Home/monthly-expenses/ ${number + 1}`;
    } else if (e.target.id === "btn-btn-monthly-budge") {
        window.location.href = '/Home/monthly-budget';

    } else if (e.target.id === "btn-monthly-trend") {
        window.location.href = '/Home/monthly-trend';

    } else if (e.target.id === "btn-recommendations") {
        window.location.href = '/Home/monthly-recommendations';

    }
}); 