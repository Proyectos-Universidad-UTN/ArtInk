$(document).ready(() => {
    cargarCantones()
})

$("#IdProvincia").on("change", () => {
    cargarCantones()
})

const cargarCantones = () => {
    const host = window.location.host;
    const url = host.split("/").reverse().slice(2).reverse().join("/") + "/Canton/ObtenerCantones";
    const valoresForm = new FormData(document.getElementsByClassName('form-object')[0])

    $.ajax({
        url: url,
        data: valoresForm,
        type: "post",
        processData: false,
        contentType: false,
        success: (result) => {
            $("#cantonSelect").html(result);
            cargarDistritos()
        }
    })
}