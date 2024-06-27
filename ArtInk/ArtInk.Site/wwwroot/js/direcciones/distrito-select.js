$(document).ready(() => {
    cargarDistritos()
})

function cargarDistritos() {
    const host = window.location.host;
    const url = host.split("/").reverse().slice(2).reverse().join("/") + "/Distrito/ObtenerDistritos";
    $.ajax({
        url: url,
        data: { idCanton: $("#IdCanton option:selected").val() },
        type: "get",
        success: (result) => {
            $("#distritoSelect").html(result)
        }
    })
}
