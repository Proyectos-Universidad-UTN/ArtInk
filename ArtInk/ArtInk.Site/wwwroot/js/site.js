// **********************************Función para inicializar DataTables**********************
document.addEventListener('DOMContentLoaded', function () {
    const tables = document.querySelectorAll(".artink-tables");
    tables.forEach(table => {
        new DataTable(table, {
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
            scrollY: '400px',
            scrollCollapse: true
        });
    });

    const toast = $('.toast');

    toast.toast('show');

    setTimeout(function () {
        $toast.fadeOut(1000, function () {
            $(this).remove();
        });
    }, 3000);
});
