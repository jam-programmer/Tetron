async function SendRequestRecruitment() {
    debugger;
    var title = document.getElementById("title");
    var type = document.getElementById("type");
    var phone = document.getElementById("phone");
    var masterImage = document.getElementById("MasterImage");
    var gallery = document.getElementById("Gallery");
    var description = document.getElementById("description");
    var address = document.getElementById("address");
    if (title.value === "" || type.value === "" || phone.value === "" || description.value === "" || address.value === "") {
        CustomAlert("عدم تکمیل اطلاعات", "لطفا اطلاعات را تکمیل نمائید.", "Error");
        return;
    }
    var formData = new FormData();
    formData.append('RecruitmentImage', masterImage.files[0]);

    var galleryFiles = gallery.files;
    for (var i = 0; i < galleryFiles.length; i++) {
        formData.append('Gallery', galleryFiles[i]);
    }
    formData.append('UserId', "01");
    formData.append('RecruitmentDescription', description.value);
    formData.append('RecruitmentAddress', address.value);
    formData.append('RecruitmentPhoneNumber', phone.value);
    formData.append('RecruitmentType', type.value);
    formData.append('RecruitmentTitle', title.value);
    //for (var pair of formData.entries()) {
    //    console.log(pair[0] + ': ' + pair[1]);
    //}


    try {

        const timerInterval = setInterval(() => {
            const timer = Swal.getPopup().querySelector("b");
            if (timer) {
                timer.textContent = `${Swal.getTimerLeft()}`;
            }
        }, 100);

        Swal.fire({
            title: "پردازش اطلاعات آگهی",
            html: "لطفا منتظر بمانید.",
            timer: 5000,
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
            willClose: () => {
                clearInterval(timerInterval);
            }
        }).then((result) => {
            if (result.dismiss === Swal.DismissReason.timer) {
                console.log("I was closed by the timer");
            }
        });
        const response = await fetch('/Advertising/RequestRecruitment', {
            method: 'POST',
            body: formData,
            headers: {
                'enctype': 'multipart/form-data'
            }
        });
        const data = await response.json();
        if (data.isSuccess) {
            setTimeout(() => {
                CustomAlert("آگهی ثبت شد", "آگهی شما ثبت شد و پس از تائید کارشناسان منتشر میشود.", "Success");
                setTimeout(() => {
                    window.location.href = "/";
                }, 3000);
            }, 5000);
        } else {
            CustomAlert("آگهی ثبت نشد", data.message, "Error");
        }
    } catch (error) {
        console.log('error', 'خطا: ' + error);
    }
}


async function SendRequestPlacement() {


    debugger;
    var fullname = document.getElementById("fullname");
    var phone = document.getElementById("phone");
    var masterImage = document.getElementById("MasterImage");
    var gallery = document.getElementById("Gallery");
    var description = document.getElementById("description");
    if (fullname.value === "" || phone.value === "" || description.value === "") {
        CustomAlert("عدم تکمیل اطلاعات", "لطفا اطلاعات را تکمیل نمائید.", "Error");
        return;
    }
    var formData = new FormData();
    formData.append('PlacementImage', masterImage.files[0]);

    var galleryFiles = gallery.files;
    for (var i = 0; i < galleryFiles.length; i++) {
        formData.append('Gallery', galleryFiles[i]);
    }
    formData.append('UserId', "01");
    formData.append('PlacementDescription', description.value);
    formData.append('PlacementNumber', phone.value);
    formData.append('PlacementFullName', fullname.value);
    //for (var pair of formData.entries()) {
    //    console.log(pair[0] + ': ' + pair[1]);
    //}


    try {

        const timerInterval = setInterval(() => {
            const timer = Swal.getPopup().querySelector("b");
            if (timer) {
                timer.textContent = `${Swal.getTimerLeft()}`;
            }
        }, 100);

        Swal.fire({
            title: "پردازش اطلاعات آگهی",
            html: "لطفا منتظر بمانید.",
            timer: 5000,
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
            willClose: () => {
                clearInterval(timerInterval);
            }
        }).then((result) => {
            if (result.dismiss === Swal.DismissReason.timer) {
                console.log("I was closed by the timer");
            }
        });
        const response = await fetch('/Advertising/RequestPlacement', {
            method: 'POST',
            body: formData,
            headers: {
                'enctype': 'multipart/form-data'
            }
        });
        const data = await response.json();
        if (data.isSuccess) {
            setTimeout(() => {
                CustomAlert("آگهی ثبت شد", "آگهی شما ثبت شد و پس از تائید کارشناسان منتشر میشود.", "Success");
                setTimeout(() => {
                    window.location.href = "/";
                }, 3000);
            }, 5000);
        } else {
            CustomAlert("آگهی ثبت نشد", data.message, "Error");
        }
    } catch (error) {
        console.log('error', 'خطا: ' + error);
    }


}








async function SendRequestIntroduction() {

    debugger;
    var skills = document.getElementById("Skill");
    var title = document.getElementById("title");
    var phone = document.getElementById("phone");
    var masterImage = document.getElementById("MasterImage");
    var gallery = document.getElementById("Gallery");
    var description = document.getElementById("description");
    if (title.value === "" || phone.value === "" || description.value === "") {
        CustomAlert("عدم تکمیل اطلاعات", "لطفا اطلاعات را تکمیل نمائید.", "Error");
        return;
    }
    var formData = new FormData();
    formData.append('IntroductionImage', masterImage.files[0]);


    if (skills) {
        var selectedValues = Array.from(skills.selectedOptions).map(option => option.value);
        selectedValues.forEach(value => {
            formData.append('Skills', value);
        });


    }


    var galleryFiles = gallery.files;
        for (var i = 0; i < galleryFiles.length; i++) {
            formData.append('Gallery', galleryFiles[i]);
        }
        formData.append('UserId', "01");
        formData.append('IntroductionDescription', description.value);
        formData.append('IntroductionPhoneNumber', phone.value);
        formData.append('IntroductionTitle', title.value);
        for (var pair of formData.entries()) {
            console.log(pair[0] + ': ' + pair[1]);
        }


        try {

            const timerInterval = setInterval(() => {
                const timer = Swal.getPopup().querySelector("b");
                if (timer) {
                    timer.textContent = `${Swal.getTimerLeft()}`;
                }
            }, 100);

            Swal.fire({
                title: "پردازش اطلاعات آگهی",
                html: "لطفا منتظر بمانید.",
                timer: 5000,
                timerProgressBar: true,
                didOpen: () => {
                    Swal.showLoading();
                },
                willClose: () => {
                    clearInterval(timerInterval);
                }
            }).then((result) => {
                if (result.dismiss === Swal.DismissReason.timer) {
                    console.log("I was closed by the timer");
                }
            });
            const response = await fetch('/Advertising/RequestIntroduction', {
                method: 'POST',
                body: formData,
                headers: {
                    'enctype': 'multipart/form-data'
                }
            });
            const data = await response.json();
            if (data.isSuccess) {
                setTimeout(() => {
                    CustomAlert("آگهی ثبت شد", "آگهی شما ثبت شد و پس از تائید کارشناسان منتشر میشود.", "Success");
                    setTimeout(() => {
                        window.location.href = "/";
                    }, 3000);
                }, 5000);
            } else {
                CustomAlert("آگهی ثبت نشد", data.message, "Error");
            }
        } catch (error) {
            console.log('error', 'خطا: ' + error);
        }


    }





