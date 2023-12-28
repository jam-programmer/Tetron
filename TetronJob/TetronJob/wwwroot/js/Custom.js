

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
