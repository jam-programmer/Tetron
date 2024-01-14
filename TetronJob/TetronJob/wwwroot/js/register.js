async function StepOne() {
    var fullName = document.getElementById("fullname");
    var nationalCode = document.getElementById("nationalcode");
    var phoneNumber = document.getElementById("phonenumber");
    var email = document.getElementById("email1");
    var password = document.getElementById("password");
    var birthday = document.getElementById("flatpickr-date");


    debugger;
    if (fullName.value === "" || nationalCode.value === ""
        || phoneNumber.value === "" || email.value === ""
        || password.value === "" || birthday.value === "") {
        CustomAlert("عدم تکمیل اطلاعات", "لطفا  اطلاعات را تکمیل نمائید.","Error");
    }
    else {
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
                   
                } else {
                    CustomAlert("عملیات ناموفق", data.message, "Error");
                }

            })
            .catch(error => {
                console.log('error', 'خطا: ' + error);
            });

    }
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


