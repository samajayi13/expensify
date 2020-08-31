var sumbitBtn = document.querySelector("#sumbit-btn");

document.addEventListener("click", function (e) {
    e.preventDefault();
    if (e.target.id === "sumbit-btn") {
        let username = document.querySelector("#username").value;
        $.ajax({
            url: '/Home/SetUserNameCookie',
            data: { username: username },
            type: "POST",
            success: function () {
                alert('Added');
                window.location.href = '/Home/Homepage';

            }
        });

    } else if (e.target.id === "view-recom") {
        let budget = document.querySelector("#recommendations-budget").value;
        let month = document.querySelector("#recommendations-month").value;

        console.log(budget);
        console.log(month);
        alert("hello");
        $.ajax({
            url: '/Home/Recommendations',
            data: { budget: parseInt(budget), month: parseInt(month) },
            type: "POST",
            success: function (data) {
                var recommendations = document.querySelector(".recommendations");
                var para1 = document.createElement("h2");
                para1.innerText = "Miscellaneous recommendation : £" + data.MiscellaneousRecommendation;

                var para2 = document.createElement("h2");
                para2.innerText = "Personal recommendation : £" + data.PersonalRecommendation;

                var para3 = document.createElement("h2");
                para3.innerText = "Savings recommendation: £" + data.SavingsRecommendation;

                recommendations.appendChild(para1);
                recommendations.appendChild(para2);
                recommendations.appendChild(para3);


            }
        })

    }
});




