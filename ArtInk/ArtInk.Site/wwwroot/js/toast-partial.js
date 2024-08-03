// **********************************Función para inicializar DataTables**********************
$(document).ready(function () {
    const toastPartial = $('.toastPartial');

    toastPartial.toast('show');

    setTimeout(function () {
        toastPartial.fadeOut(1000, function () {
            $(this).remove();
        });
    }, 3000);
});