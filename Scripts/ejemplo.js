var tablas = [].slice.call(document.querySelectorAll("table"));

$(document).ready(function () {

    tablas.map(function (data) {
        let table = new DataTable(data, {
            autoWidth: true,
            searching: true,
            ordering: false,
            info: true,
            responsive: true,
            lengthChange: false,
            pageLength: 5,
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Hay un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });

        $('button[data-bs-toggle="tab"]').on('shown.bs.tab', function (event) {
            var tabID = $(event.target).attr('data-bs-target');
            if (tabID === '#ContentPanel1') {
                table.columns.adjust().responsive.recalc();
            }
            if (tabID === '#ContentPanel2') {
                table.columns.adjust().responsive.recalc();
            }
            if (tabID === '#ContentPanel3') {
                table.columns.adjust().responsive.recalc();
            }
        });

    });

});


