"use strict";

var sumbitBtn = document.querySelector("#sumbit-btn");

sumbitBtn.addEventListener("click", function (e) {
    e.preventDefault();
    var username = document.querySelector("#username").value;
    $.ajax({
        url: '/Home/SetUserNameCookie',
        data: { username: username },
        type: "POST",
        success: function success() {
            alert('Added');
            window.location.href = '/Home/Homepage';
        }
    });
});

alert("hello");

document.querySelector("#btn-recommendations1").addEventListener("click", function (e) {
    alert("hello");

    e.preventDefault();

    var budget = document.querySelector("#recommendations-budget").value;
    var month = document.querySelector("#recommendations-month").value;
    alert("hello");
    $.ajax({
        url: '/Home/Recommendations',
        data: { budget: budget, month: month },
        type: "POST",
        success: function success(data) {
            console.log(data);
        }
    });
});

