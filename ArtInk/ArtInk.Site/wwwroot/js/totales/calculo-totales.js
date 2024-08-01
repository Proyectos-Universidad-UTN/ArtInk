const numberFormat = new Intl.NumberFormat('en-US', { minimumFractionDigits: 2});

$(".valor-impuesto").on('change', function () {
    var impuestosDetalle = document.getElementsByClassName("calculo-detalle");
    setTimeout(() => {
        $(impuestosDetalle).each((ind, el) => {
            calcularTotalesLinea(el);
        })
    }, 100);
})

const calcularTotalesLinea = (element) => {
    const valueCantidad = $(element).val();
    const numeroLinea = $(element).data("linea");
    const cantidad = parseInt(valueCantidad == "" ? 0 : valueCantidad.replace(",", ""));
    const tarifa = parseFloat($(`#TarifaServicioDetalle-${numeroLinea}`).val().replace(",", ""));
    const subtotal = tarifa * cantidad;

    $(`#SubTotalDetalle-${numeroLinea}`).val(numberFormat.format(subtotal))
    calcularImpuestoLinea(numeroLinea, subtotal);
}

const calcularImpuestoLinea = (numeroLinea, subtotal) => {
    const valuePorcentajeImpuesto = $("#PorcentajeImpuesto").val().replace("%", "");
    const porcentajeImpuesto = parseFloat(valuePorcentajeImpuesto == "" ? 0 : valuePorcentajeImpuesto);
    const montoImpuesto = subtotal * (porcentajeImpuesto / 100);

    $(`#ImpuestoDetalle-${numeroLinea}`).val(numberFormat.format(montoImpuesto));
    calcularTotalLinea(numeroLinea, subtotal, montoImpuesto);
}

const calcularTotalLinea = (numeroLinea, subtotal, impuesto) => {
    const total = subtotal + impuesto
    $(`#TotalDetalle-${numeroLinea}`).val(numberFormat.format(total))
    actualizarTotales();
}

const actualizarTotales = () => {
    const valoresSubtotales = document.getElementsByClassName("subtotal")
    const valoresImpuestos = document.getElementsByClassName("impuesto")
    const valoresTotales = document.getElementsByClassName("total")

    var arraySubtotal = []
    $(valoresSubtotales).each((ind, el) => parseFloat(arraySubtotal.push($(el).val().replace(",", ""))))
    const subtotal = SumarArray(arraySubtotal)

    var arrayImpuesto = []
    $(valoresImpuestos).each((ind, el) => parseFloat(arrayImpuesto.push($(el).val().replace(",", ""))))
    const impuesto = SumarArray(arrayImpuesto)

    var arrayTotal = []
    $(valoresTotales).each((ind, el) => parseFloat(arrayTotal.push($(el).val().replace(",", ""))))
    const total = SumarArray(arrayTotal)

    $("#SubTotal").text(numberFormat.format(subtotal))
    $("#MontoImpuesto").text(numberFormat.format(impuesto))
    $("#MontoTotal").text(numberFormat.format(total))
}

const SumarArray = (arr) => {
    return arr.reduce((total, current) => {
        return parseFloat(total) + parseFloat(current);
    }, 0)
}