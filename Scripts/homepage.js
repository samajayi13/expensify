document.addEventListener("click", function (e) {
    e.preventDefault();
    if (e.target.id === "btn-monthly-expenses") {
        window.location.href = `/Home/monthly-expenses/8`;
        console.log("working");
    } else if (e.target.id === "btn-btn-monthly-budge") {
        window.location.href = '/Home/monthly-budget';

    } else if (e.target.id === "btn-monthly-trend") {
        window.location.href = '/Home/trendgraph';

    } else if (e.target.id === "btn-recommendations") {
        window.location.href = '/Home/monthly-recommendations';

    }
}); 