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

                    document.getElementById("boxStep1").classList.remove("active");
                    document.getElementById("boxStep2").classList.add("active");


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
                    var $disabledResults = $(".search-j2");
                    $disabledResults.select2();
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

                document.getElementById("boxStep2").classList.remove("active");
                document.getElementById("boxStep3").classList.add("active");

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
                , 3000);


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
                window.location.href = "/Profile/Dashboard";
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




async function SendOtp() {
    var nationalCode = document.getElementById("username");
    if (!nationalCode.value) {
        CustomAlert("ورودی نامعتبر","کد ملی را وارد کنید","Warning");
        return;
    }
    var formOne = document.getElementById("otpForm1");
    var formTwo = document.getElementById("otpForm2");

    var model = { NationalCode: nationalCode.value}
    await fetch('/Identity/SendOtp', {
        body: JSON.stringify(model),
        method: 'POST',
        headers: { 'Content-Type': 'application/json' }
        })
        .then(response => response.json())
        .then(data => {
            if (data.isSuccess) {

                formOne.classList.add("hide-form");
             
                var count = 59;
                var againLink = document.getElementById("again-link");
                var deactiveLink = document.getElementById("deactive-link");
                var interval =
                    setInterval(function () {
                        document.getElementById("timer").innerHTML = count;
                        count--;
                        if (count === 0) {
                            clearInterval(interval);
                            document.getElementById("timer").innerHTML = "00";
                            deactiveLink.classList.add("hide-form");
                            againLink.classList.remove("hide-form");
                        }
                    }, 1000);
                formTwo.classList.remove("hide-form");

                //window.location.href = "/Profile/Dashboard";
            } else {
                CustomAlert("ورود ناموفق", data.message, "Error");
            }

        })
        .catch(error => {
            console.log('error', 'خطا: ' + error);
        });
}
function BackFormOne() {
    var formOne = document.getElementById("otpForm1");
    var formTwo = document.getElementById("otpForm2");
    formOne.classList.remove("hide-form");
    formTwo.classList.add("hide-form");
}

async function AgainOtp() {
    var againLink = document.getElementById("again-link");
    var deactiveLink = document.getElementById("deactive-link");
    var nationalCode = document.getElementById("username");
    if (!nationalCode.value) {
        CustomAlert("ورودی نامعتبر", "کد ملی را وارد کنید", "Warning");
        return;
    }
    deactiveLink.classList.remove("hide-form");
    againLink.classList.add("hide-form");
    var model = { NationalCode: nationalCode.value }
    await fetch('/Identity/SendOtp', {
            body: JSON.stringify(model),
            method: 'POST',
            headers: { 'Content-Type': 'application/json' }
        })
        .then(response => response.json())
        .then(data => {
            if (data.isSuccess) {

               

                var count = 59;
               
                var interval =
                    setInterval(function () {
                        document.getElementById("timer").innerHTML = count;
                        count--;
                        if (count === 0) {
                            clearInterval(interval);
                            document.getElementById("timer").innerHTML = "00";
                            deactiveLink.classList.add("hide-form");
                            againLink.classList.remove("hide-form");
                        }
                    }, 1000);
               

                //window.location.href = "/Profile/Dashboard";
            } else {
                CustomAlert("ورود ناموفق", data.message, "Error");
            }

        })
        .catch(error => {
            console.log('error', 'خطا: ' + error);
        });
}

 async function SignInOtp() {
     var otp = document.getElementById("otpCode");
     if (!otp.value) {
         CustomAlert("ورودی نامعتبر", "کد یکبار مصرف را وارد کنید", "Warning");
         return;
     }
     var nationalCode = document.getElementById("username");

     var model = { NationalCode: nationalCode.value, OtpCode: otp.value }
     await fetch('/Identity/SignInOtp', {
             body: JSON.stringify(model),
             method: 'POST',
             headers: { 'Content-Type': 'application/json' }
         })
         .then(response => response.json())
         .then(data => {
             if (data.isSuccess) {
                 window.location.href = "/Profile/Dashboard";
             } else {
                 CustomAlert("ورود ناموفق", data.message, "Error");
             }

         })
         .catch(error => {
             console.log('error', 'خطا: ' + error);
         });
 }