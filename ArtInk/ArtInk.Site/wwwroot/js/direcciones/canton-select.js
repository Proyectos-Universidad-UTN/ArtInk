$("#IdProvincia").on("click", () => {
    $.ajax({
        url: "~/Canton/ObtenerCantones",
        data: { idProvincia: $("#IdProvincia option:selected").val() },
        type: "get",
        success: (result) => {
            $("#cantonSelect").html(result)
        }
    })
})