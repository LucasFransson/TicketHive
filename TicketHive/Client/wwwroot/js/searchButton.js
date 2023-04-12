function registerSearchButton(searchButton) {
    $('.search-button', searchButton).click(function () {
        $(this).parent().toggleClass('open');
    });
}