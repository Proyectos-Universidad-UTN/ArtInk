$(document).ready(() => {
    cargarDistritos()
})

function cargarDistritos() {
    const host = window.location.host;
    const url = host.split("/").reverse().slice(2).reverse().join("/") + "/Distrito/ObtenerDistritos";
    const valoresForm = new FormData(document.getElementsByClassName('form-object')[0])
    valoresForm.set("IdDistrito", $("#IdDistritoEdit").val())

    $.ajax({
        url: url,
        data: valoresForm,
        type: "post",
        processData: false,
        contentType: false,
        success: (result) => {
            $("#distritoSelect").html(result)
        }
    })
}
