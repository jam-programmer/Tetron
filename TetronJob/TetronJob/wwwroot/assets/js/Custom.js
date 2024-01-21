
async function LoadCity() {
   
    debugger;
    var id = document.getElementById("province").value;
    var select = document.getElementById("city");


    select.options.length = 0;



  


    fetch('/Admin/User/Cities/' + id)
        .then(response => response.json())
        .then(data => {
            data.forEach(item => {
                var option = document.createElement("option");
                option.text = item.name;
                option.value = item.id;
                select.add(option);

            }); var $disabledResults = $(".search-j2");
            $disabledResults.select2();
        })
        .catch(error => {
            console.log(error);
        });
}

