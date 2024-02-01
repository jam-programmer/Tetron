
$(document).ready(function () {

    var pageIndexData = $(".pagination").data("page-index");
    var totalPagesData = $(".pagination").data("total-pages");
    var path = $(".pagination").data("path");
    var parentId = $(".pagination").data("parent");
    var name = $(".pagination").data("name");

    var pageIndex = Number(pageIndexData);
    var totalPages = Number(totalPagesData);

    if (totalPages < 1 || !totalPages) {
        return;
    }

    var ul = document.createElement("ul");
    ul.className = "pagination";


    var count = Number(totalPages);
    var curent = Number(pageIndex);
    if (curent === 0) {
        curent = 1;
    }
    var size = curent + 1;
    if (curent === count) {
        size = curent;
    }

    if (size > count) {
        size = curent;
    }
    var start = 1;
    if (curent > 4) {
        start = curent - 3;
    }





    if (count > 1) {
        var previousPage = pageIndex - 1;
        var lipreviousPage = document.createElement("li");
        var a1 = document.createElement("a");


        var aramsObjPrevious = { Page: curent - 1, PageSize: 10 };


        var queryString = Object.keys(aramsObjPrevious).map(key => key + '=' + aramsObjPrevious[key]).join('&');
        var fullUrlPrevious = path + '?' + queryString;
        if (parentId) {
            fullUrlPrevious = fullUrlPrevious + '&id=' + parentId;
        }
        if (parentId) {
            fullUrlPrevious = fullUrlPrevious + '&id=' + parentId;
        }
        if (name) {
            fullUrlPrevious = fullUrlPrevious + '&name=' + name;
        }


        if (previousPage >= 1) {
            lipreviousPage.className = "page-item ";
            a1.href = fullUrlPrevious;
        }
        else {
            lipreviousPage.className = "page-item disabled";
            a1.href = "#";
        }






        a1.className = "page-link";
        a1.textContent = "قبلی";
        lipreviousPage.appendChild(a1);
        ul.appendChild(lipreviousPage);

        //******************************************//


        for (var i = start; i <= size; i++) {
            var liPage = document.createElement("li");
            var a = document.createElement("a");

            var params = { Page: i, PageSize: 10 };
            var queryString = Object.keys(params).map(key => key + '=' + params[key]).join('&');
            var fullUrl = path + '?' + queryString;


            if (parentId) {
                fullUrl = fullUrl + '&id=' + parentId;
            }
            if (name) {
                fullUrl = fullUrl + '&name=' + name;
            }



            if (i === curent) {
                liPage.className = "page-item active";
            } else {
                liPage.className = "page-item";
            }

            a.className = "page-link";
            a.textContent = i;
            a.href = fullUrl; // Set the href for the anchor tag
            liPage.appendChild(a);
            ul.appendChild(liPage);
        }

        // Create the "Next" button
        var linextPage = document.createElement("li");
        var aNext = document.createElement("a");

        var paramsObjNext = { Page: curent + 1, PageSize: 10 };
        var queryStringNext = Object.keys(paramsObjNext).map(key => key + '=' + paramsObjNext[key]).join('&');
        var fullUrlNext = path + '?' + queryStringNext;



        if (parentId) {
            fullUrlNext = fullUrlNext + '&id=' + parentId;
        }
        if (name) {
            fullUrlNext = fullUrlNext + '&name=' + name;
        }







        debugger;
        if (pageIndex == totalPages) {
            linextPage.className = "page-item disabled";
            aNext.href = "#";
        } else {
            linextPage.className = "page-item";
            aNext.href = fullUrlNext; // Set the href for the "Next" button
        }

        aNext.className = "page-link";
        aNext.textContent = "بعدی";
        linextPage.appendChild(aNext);
        ul.appendChild(linextPage);

        var div = document.createElement("div");
        div.appendChild(ul);
        var paginationList = document.getElementById("paginationList");
        paginationList.appendChild(div);
    }






    var paginationList = document.getElementById("paginationList");
    paginationList.appendChild(ul);
});