async function StepOne() {
    var fullName = document.getElementById("fullname");
    var nationalCode = document.getElementById("nationalcode");
    var phoneNumber = document.getElementById("phonenumber");
    var email = document.getElementById("email1");
    var password = document.getElementById("password");
    var birthday = document.getElementById("flatpickr-date");

 
    if (fullName.value === "" ||
        nationalCode.value === "" ||
        phoneNumber.value === "" ||
        email.value === "" ||
        password.value === "" ||
        birthday.value === "") {
        CustomAlert("عدم تکمیل اطلاعات", "لطفا  اطلاعات را تکمیل نمائید.", "Error"); return;
    } if (password.value.length < 6) {
        CustomAlert("رمز عبور", "طول رمز عبور کوتاه است.", "Error");
        return;
    }

    var user= {

            FullName: fullName.value,
            Birthday: birthday.value,
            UserName: nationalCode.value,
            Email: email.value,
            Password: password.value,
            PhoneNumber: phoneNumber.value
        }
        await fetch('/Identity/SignUpStepOne', {
            body: JSON.stringify(user),
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                }

            })
            .then(response => response.json())
            .then(data => {
                if (data.isSuccess) {

                    var user = document.getElementById("UserId");
                    user.value = data.data;

                    var nextBody = document.getElementById("BodyStep2");
                    var prevBody = document.getElementById("BodyStep1");
                    var nextIcon = document.getElementById("boxStep2");
                    var prevIcon = document.getElementById("boxStep1");

                    nextIcon.classList.add("active");
                    prevIcon.classList.remove("active");

                    nextBody.classList.add("active");
                    nextBody.classList.add("dstepper-block");

                    prevBody.classList.remove("active");
                    prevBody.classList.remove("dstepper-block");
                  
                } else {
                    CustomAlert("عملیات ناموفق", data.message, "Error");
                }

            })
            .catch(error => {
                console.log('error', 'خطا: ' + error);
            });

    

}

async function StepTwo() {
    var user = document.getElementById("UserId");
    var province = document.getElementById("province");
    var city = document.getElementById("city");
    if (province.value === "" || city.value === "") {
        CustomAlert("عدم تکمیل اطلاعات", "لطفا استان و شهر را انتخاب کنید.", "Error");
    } else {
        var model = {
            ProvinceId: province.value,
            CityId: city.value,
            UserId:user.value
        }

    
        try {
            const response = await fetch('/Identity/SetAddress', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(model)
            });
     
            if (response.ok) {
                const data = await response.json();

                var nextBody = document.getElementById("BodyStep3");
                var prevBody = document.getElementById("BodyStep2");
                var nextIcon = document.getElementById("boxStep3");
                var prevIcon = document.getElementById("boxStep2");

                nextIcon.classList.add("active");
                prevIcon.classList.remove("active");

                nextBody.classList.add("active");
                nextBody.classList.add("dstepper-block");

                prevBody.classList.remove("active");
                prevBody.classList.remove("dstepper-block");
            } else {
                CustomAlert("عدم ثبت اطلاعات", "متاسفانه مشکلی رخ داده با پشتیبان ارتباط بگیرید.", "Error");
            }
        } catch (error) {
            console.error('Error: ' + error);
        }



    }
}


async function StepThree() {
    // Get all checkboxes
    var checkboxes = document.querySelectorAll('input[type="checkbox"]');
    var user = document.getElementById("UserId");
    var model={
        UserId: user.value,
        CategoryIds:[]
     }
    // Loop through each checkbox
    for (var i = 0; i < checkboxes.length; i++) {
        var checkbox = checkboxes[i];
          if (checkbox.checked) {
              model.CategoryIds.push(checkbox.value);
          }
    }
    if (model.CategoryIds.length === 0) {
        CustomAlert("عدم ثبت اطلاعات", "یک حوزه یا چند حوزه فعالیت انتخاب کنید.", "Error");
        return;
    }


    try {
        const response = await fetch('/Identity/SetCategories', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(model)
        });
        debugger;
        if (response.ok) {
            Swal.fire({
                icon: "success",
                title: "ثبت نام با موفقیت انجام شد",
                text: "به حانواده تترون جاب خوش آمدید",
                showConfirmButton: false

            });
            setInterval(
                window.location.href="/"
                , 2000);


        } else {
            CustomAlert("عدم ثبت اطلاعات", "متاسفانه مشکلی رخ داده با پشتیبان ارتباط بگیرید.", "Error");
        }
    } catch (error) {
        console.error('Error: ' + error);
    }

}

async function SignIn() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    var remember = document.getElementById("remember").checked;
    if (username === "" || password === "") {
        CustomAlert("عدم تکمیل اطلاعات", "لطفا کدملی و رمز عبور را وارد کنید.", "Error");
        return;
    }
    var user = { UserName: username, Password: password, Remember: remember }

    await fetch('/Identity/SignIn', {
            body: JSON.stringify(user), method: 'POST', headers: { 'Content-Type': 'application/json' }
        })
        .then(response => response.json())
        .then(data => {
            if (data.isSuccess) {
                // do something on success
            } else {
                CustomAlert("ورود ناموفق", data.message, "Error");
            }

        })
        .catch(error => {
            console.log('error', 'خطا: ' + error);
        });
}
const status = {
    Warning: "Warning",
    Error: "Error",
    Info: "Info",
    Success: "Success"
}

function CustomAlert(title, body, status) {
    let cardDiv = $('<div></div>').attr({
        'class': 'bs-toast toast toast-placement-ex m-2 fade top-50 start-50 translate-middle show toast-top-left',
        'role': 'alert',
        'aria-live': 'assertive',
        'aria-atomic': 'true',
        'data-bs-delay': '2000',
    });
    let haderDiv = $('<div></div>');
    haderDiv.attr({
        'class': 'toast-header'
    });

    switch (status) {
    case "Warning":
        haderDiv.addClass("bg-warning");
        break;

    case "Error":
        haderDiv.addClass("bg-danger");
        break;

    case "Info":
        haderDiv.addClass("bg-primary");
        break;

    case "Success":
        haderDiv.addClass("bg-success");
        break;
    }

    let titleDiv = $('<div></div>').attr({
        'class': 'me-auto fw-semibold'
    }).text(title);
    let closeButton = $('<button></button>').attr({
        'type': 'button',
        'class': 'btn-close',
        'data-bs-dismiss': 'toast',
        'aria-label': 'Close'
    });

    haderDiv.append(titleDiv);
    haderDiv.append(closeButton);
    cardDiv.append(haderDiv);

    if (body) {
        let bodyDiv = $('<div></div>')
            .attr({
                'class': 'toast-body'
            }).text(body);

        bodyDiv.text(body);
        cardDiv.append(bodyDiv);
    }

    cardDiv.appendTo('body');
}

