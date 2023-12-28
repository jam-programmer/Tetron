const addPaginationEvent = () => {
    // find all pagination box in page.
    var paginationBoxes = $('.pagination').toArray();
    if (!paginationBoxes || paginationBoxes.length <= 0) {
        return;
    }
    paginationBoxes.forEach((paginationBox) => {
        var pageIndex = paginationBox.getAttribute('data-page-index') * 1;
        var totalpages = paginationBox.getAttribute('data-total-pages') * 1;
        if (!totalpages || totalpages < 2)
            return;
        var urlPath = paginationBox.getAttribute('data-path');

        // First page pagination.
        paginationBox.innerHTML += `<li class="page-item first">
        <a class="page-link" href="/Admin/Role/Index" asp-route-search="" asp-route-page="1"><i class="tf-icon bx bx-chevrons-left"></i></a>
        </li>`
        // Previus page pagination.
        paginationBox.innerHTML += `<li class="page-item prev">
        <a class="page-link" href="/Admin/Role/Index" asp-route-page="1"><i class="tf-icon bx bx-chevron-left"></i></a>
        </li>`
        // Prepare each pagination.
        for (var i = 1; i <= totalpages; i++) {
            // Prepare pagination button link href.
            var linkUrl;
            if (urlPath && urlPath.length > 0) {
                linkUrl = new URL(window.location.origin);
                linkUrl.pathname = urlPath;
                linkUrl.searchParams.append('page', i);
            }
            // create pagination button.
            paginationBox.innerHTML += `<li class="page-item ${(pageIndex == i ? 'active' : '')}"><a href="${linkUrl}" asp-route-page="1" asp-route-search="" class="page-link">${i}</a></li>`;
        }
        // Next page pagination.
        paginationBox.innerHTML += `<li class="page-item next">
        <a class="page-link" href="/Admin/Role/Index" asp-route-search="" asp-route-page="1"><i class="tf-icon bx bx-chevron-right"></i></a>
        </li>`
        // Last page pagination.
        paginationBox.innerHTML += `<li class="page-item last">
        <a class="page-link" href="/Admin/Role/Index" asp-route-page="1"><i class="tf-icon bx bx-chevrons-right"></i></a>
        </li>`
    });
};

addPaginationEvent();