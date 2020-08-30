
var actualAmounts;
var budgetAmounts;
$.ajax({
    url: '/Home/TrendGraphJson',
    data: {},
    type: "POST",
    success: function (data) {
        console.log(data);
        actualAmounts = data.AcutalAmounts;
        budgetAmounts = data.BudgetAmounts;
        console.log(actualAmounts);
        console.log(budgetAmounts);
        drawGraph();
    }
})
let drawGraph = function () {

    // chart colors
    var colors = ['red', '#28a745', '#333333', '#c3e6cb', '#dc3545', '#6c757d'];

    /* large line chart */
    var chLine = document.getElementById("chLine");
    var chartData = {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        datasets: [{
            data: actualAmounts,
            backgroundColor: 'white',
            borderColor: colors[0],
            borderWidth: 4,
            pointBackgroundColor: colors[0]
        },
            {
                data: budgetAmounts,
            backgroundColor: 'white',
            borderColor: colors[1],
            borderWidth: 4,
            pointBackgroundColor: colors[1]
        }]
    };

    if (chLine) {
        new Chart(chLine, {
            type: 'line',
            data: chartData,
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: false
                        }
                    }]
                },
                legend: {
                    display: false
                }
            }
        });
    }
}