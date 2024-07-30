// **********************************Función para inicializar DataTables**********************
document.addEventListener('DOMContentLoaded', function () {
    const tables = document.querySelectorAll(".artink-tables");
    tables.forEach(table => {
        const tableInstance = new DataTable(table, {
            pageLength: 10,
            layout: {
                topStart: {
                    buttons: ['copy', 'excel', 'pdf', 'colvis']
                }
            },
            language: {
                url: 'https://cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json'
            },
            responsive: true,
        });
    });

    const toast = $('.toast');

    toast.toast('show');

    setTimeout(function () {
        toast.fadeOut(1000, function () {
            $(this).remove();
        });
    }, 3000);

    const elems = document.querySelectorAll('.datepicker-fechas');
    elems.forEach(elem => {
        const datepicker = new Datepicker(elem, {
            format: 'dd/mm/yyyy',
            language: 'es'
        });
    })
});

document.addEventListener('DOMContentLoaded', function () {

    const datepickerEl = document.getElementById('datepicker');
    if (datepickerEl) {
        new Datepicker(datepickerEl, {
            format: 'dd/mm/yyyy',
            language: 'es',
            autoHide: true
        });
    }
});
