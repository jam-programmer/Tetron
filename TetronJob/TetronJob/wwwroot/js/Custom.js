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


function ChangeImage(input, id) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imagePath_' + id).attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#image_" + id).change(function () {
    readURL(this);
});


function SignInError() {
    CustomAlert("ورود به سیستم", "جهت ثبت آگهی وارد حساب کاربری خود شوید.", "Error");
}
function Delete(id, controller) {
    Swal.fire({
        title: 'آیا عملیات حذف انجام شود؟',

        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            debugger;
            fetch('/Admin/' + controller + '/Delete/' + id)
                .then(response => response.json())
                .then(data => {
           
                    if (data.isSuccess) {
                        $("#item_" + id).hide('slow');

                        Swal.fire({
                            title: 'حذف با موفقیت انجام شد',
                            icon: 'success',
                            confirmButtonColor: '#3085d6',
                            confirmButtonText: 'باشه'

                        });
                    } else {
                        Swal.fire({
                            title: 'حذف انجام نشد',
                            icon: 'error',
                            text: 'مشکلی در عملیات حذف وجود دارد',
                            confirmButtonColor: '#3085d6',

                            confirmButtonText: 'باشه'

                        });
                    }
                })
                .catch(error => {
                    Swal.fire({
                        title: 'خطای سرور',
                        icon: 'error',
                        text: 'به ثبت وقایع مراجعه کنید',
                        confirmButtonColor: '#3085d6',

                        confirmButtonText: 'باشه'

                    });
                });



        }
    });
}
