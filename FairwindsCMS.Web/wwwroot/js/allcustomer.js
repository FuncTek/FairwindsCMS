$(".btnModal").on('click', function (event) {
    event.preventDefault();
    var e = $(this);
    var title = e.data('title');
    var body = e.data('value');
    $('.modal-title').html(title);
    var dataAtty = $(this).text().trim();
    var elementHtml = $("[data-modal=" + dataAtty + "]").html();
    $('.modal-body').html(elementHtml);
});