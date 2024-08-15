let calendar;
let urlReservas;

$(document).ready(function () {
    const viewEventModal = new bootstrap.Modal(document.getElementById('modal-view-event'), {})
    const calendarEl = document.getElementById('calendar');
    setUrlCargaReservas();
    const jwt = getCookie("JWT");

    calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'timeGridWeek',
        nowIndicator: true,
        headerToolbar: {
            left: 'title',
            center: 'timeGridWeek,dayGridMonth,multiMonthYear,',
            right: 'today prev,next'
        },
        locale: 'es',
        editable: true,
        events: function (info, successCallback, failureCallback) {
            const fechaInicio = new Date(info.start.valueOf());
            const fechaFin = new Date(info.end.valueOf());
            $.ajax({
                url: urlReservas + `?fechaInicio=${moment(fechaInicio).format("YYYY-MM-DD")}&fechaFin=${moment(fechaFin).format("YYYY-MM-DD")}`,
                type: "GET",
                contentType: 'application/json',
                headers: {
                    'Authorization': `Bearer ${jwt}`
                },
                success: function (data) {
                    successCallback(data)
                }
            })
        },
        dateClick: function () {
        },
        eventClick: function (info) {
            const url = $("#urlEvents").val();
            const idReserva = info.event.title.split("-")[0];

            $.ajax({
                url: url.replace("{0}", `Reserva/${idReserva}`),
                type: "GET",
                contentType: 'application/json',
                headers: {
                    'Authorization': `Bearer ${jwt}`
                },
                success: function (response)
                {
                    $('.event-title').html(`Reserva a nombre de: ${response.nombreCliente}`);

                    $("#Sucursal").html(response.sucursal.nombre)
                    $("#Fecha").html(response.fecha)
                    $("#Hora").html(response.hora)

                    $("#Preguntas").html('')
                    response.reservaPregunta.map((x) => cargarPregunta(x))

                    $("#Servicios").html('')
                    response.reservaServicios.map((x) => cargarServicio(x))

                    viewEventModal.show();      
                }
            })
        }
    });
    calendar.render();
});

const setUrlCargaReservas = () => {
    const url = $("#urlEvents").val();
    urlReservas = url.replace("{0}", `Sucursal/${$("#IdSucursalSearch").val()}/calendario`)
}

$("#IdSucursalSearch").on('change', function () {
    setUrlCargaReservas();
    calendar.refetchEvents();
})

const cargarPregunta = (preguntaReserva) => {
    $("#Preguntas").append(`<label class="form-label fw-bold">${preguntaReserva.pregunta}:</label>
                            <label class="form-label"> ${preguntaReserva.respuesta ?? 'N/A'}</label>`)
}

const cargarServicio = (reservaServicio) => {
    $("#Servicios").append(`<li>
                                    <label class="form-label fw-bold">${reservaServicio.servicio.nombre}: ${reservaServicio.servicio.descripcion}</label>
                                    <label class="form-label"></label>        
                                </li>
                                <li class="border-bottom border-1">
                                    <label class="form-label fw-bold">Tarifa: </label>
                                    <label class="form-label">${reservaServicio.servicio.tarifa.toLocaleString('en-US', {
                                        style: 'currency',
                                        currency: 'CRC',
                                      })}</label>        
                                </li>
                                `)
}