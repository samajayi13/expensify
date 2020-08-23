var sumbitBtn = document.querySelector("#sumbit-btn");

sumbitBtn.addEventListener("click", function (e) {
    e.preventDefault();
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

});