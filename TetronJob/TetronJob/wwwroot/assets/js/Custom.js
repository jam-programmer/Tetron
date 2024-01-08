
async function LoadCity() {
   
    debugger;
    var id = document.getElementById("province").value;
    var select = document.getElementById("city");





  


    fetch('/Admin/User/Cities/' + id)
        .then(response => response.json())
        .then(data => {
            data.forEach(item => {
                var option = document.createElement("option");
                option.text = item.name;
                option.value = item.id;
                select.add(option);

            });
        })
        .catch(error => {
            console.log(error);
        });
}

