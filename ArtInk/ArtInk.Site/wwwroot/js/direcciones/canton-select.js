$(document).ready(() => {
    cargarCantones()
})

$("#IdProvincia").on("change", () => {
    cargarCantones()
})

const cargarCantones = () => {
    const host = window.location.host;
    const url = host.split("/").reverse().slice(2).reverse().join("/") + "/Canton/ObtenerCantones";
    $.ajax({
        url: url,
        data: { idProvincia: $("#IdProvincia option:selected").val() },
        type: "get",
        success: (result) => {
            $("#cantonSelect").html(result)
        }
    })
}