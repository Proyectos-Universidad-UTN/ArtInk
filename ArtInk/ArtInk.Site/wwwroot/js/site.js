// Importar Bootstrap y DataTables

var scriptDataTables = document.createElement('script');
scriptDataTables.src = 'https://cdn.datatables.net/2.0.8/js/dataTables.js';
document.head.appendChild(scriptDataTables);

var scriptDataTablesBootstrap = document.createElement('script');
scriptDataTablesBootstrap.src = 'https://cdn.datatables.net/2.0.8/js/dataTables.bootstrap5.js';
document.head.appendChild(scriptDataTablesBootstrap);

var scriptButtons = document.createElement('script');
scriptButtons.src = 'https://cdn.datatables.net/buttons/3.0.2/js/dataTables.buttons.js';
document.head.appendChild(scriptButtons);

var scriptButtonsBootstrap = document.createElement('script');
scriptButtonsBootstrap.src = 'https://cdn.datatables.net/buttons/3.0.2/js/buttons.bootstrap5.js';
document.head.appendChild(scriptButtonsBootstrap);

var scriptJsZip = document.createElement('script');
scriptJsZip.src = 'https://cdnjs.cloudflare.com/ajax/libs/jszip/3.10.1/jszip.min.js';
document.head.appendChild(scriptJsZip);

var scriptPdfMake = document.createElement('script');
scriptPdfMake.src = 'https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.2.7/pdfmake.min.js';
document.head.appendChild(scriptPdfMake);

var scriptPdfMakeFonts = document.createElement('script');
scriptPdfMakeFonts.src = 'https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.2.7/vfs_fonts.js';
document.head.appendChild(scriptPdfMakeFonts);

var scriptButtonsHtml5 = document.createElement('script');
scriptButtonsHtml5.src = 'https://cdn.datatables.net/buttons/3.0.2/js/buttons.html5.min.js';
document.head.appendChild(scriptButtonsHtml5);

var scriptButtonsPrint = document.createElement('script');
scriptButtonsPrint.src = 'https://cdn.datatables.net/buttons/3.0.2/js/buttons.print.min.js';
document.head.appendChild(scriptButtonsPrint);

var scriptButtonsColVis = document.createElement('script');
scriptButtonsColVis.src = 'https://cdn.datatables.net/buttons/3.0.2/js/buttons.colVis.min.js';
document.head.appendChild(scriptButtonsColVis);

// **********************************Función para inicializar DataTables**********************
document.addEventListener('DOMContentLoaded', function () {
    const tables = document.querySelectorAll(".artink-tables");
    tables.forEach(table => {
        new DataTable(table, {
            pageLength: 3,
            layout: {
                topStart: {
                    buttons: ['copy', 'excel', 'pdf', 'colvis']
                }
            },
            language: {
                url: '//cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json'
            },
            scrollY: '400px',
            scrollCollapse: true
        });
    });
});
