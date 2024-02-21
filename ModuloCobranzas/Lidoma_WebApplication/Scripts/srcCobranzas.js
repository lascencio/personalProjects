$(document).ready(function () {
    $('.ddlPrestamos').change(function () {
        LimpiarInputs();
    });

    $('#btnAceptar').click(function () {
        if (Validar() != false) {
            MostrarCuotasCobro();
            $("#msgConfirm").css("display", "block");
        }
        else {
            return false;
        }
    });

    $('#btnSi').click(function () {
        GrabarCobranza();
        $('#msgConfirm').modal('hide');
    });

});

function Validar() {
    alert($(".chkCuotas").is(":checked"));
}

function LimpiarInputs() {
    $('#total_cuotas').val('');
    $('#total_moras').val('');
    $('#total_pago').val('');
    $('#importe').val('');
    $('#moneda').val('');
}

function ObtenerPrestamos() {
    $.ajax({
        type: "POST",
        url: "/Cobranzas/ObtenerPrestamos",
        contentType: "application/json",
        success: function (result) {
            //Limpiamos el comboBox
            $('#prestamos').empty();
            //Declaramos variables donde se almacenará el primer registro del array(result) devuelto para mostrarlos en los txt de moneda e importe total
            var importe, moneda, prestamo;
            if (result.length > 0) {
                for (var i in result) {
                    $('#prestamos').append($("<option></option>").attr("value", result[i].PRESTAMO).text(result[i].PRESTAMO));
                    //Capturo datos sólo del primer registro del array (result)
                    importe = result[0].s_TOTAL_PRESTAMO;
                    moneda = result[0].MONEDA;
                    prestamo = result[0].PRESTAMO;
                }
                //Motramos las cuotas del prestamo
                ObtenerPrestamoCuotasLista(prestamo);

                LimpiarInputs();

                //Mostramos variables
                $('#importe').val(importe);
                $('#moneda').val(moneda);
            }

            else {
                //Limpiamos contenido del form
                $("#contenidoCuotas tr").remove();
                LimpiarInputs();

                $('#MENSAJE').removeClass("alert-success");
                $('#MENSAJE').addClass("alert-warning");

                $('.message').html('El cliente no tiene préstamos vigentes.');
                $("#MENSAJE").fadeTo(7500, 700).slideUp(500, function () {
                    $("#MENSAJE").slideUp(700);
                });
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function SeleccionarPrestamo() {
    var vPrestamo = $('#prestamos').val();
    $.ajax({
        type: "POST",
        url: "/Cobranzas/SeleccionarPrestamo",
        data: JSON.stringify({ prestamo: vPrestamo }),
        contentType: "application/json",
        success: function (result) {
            $('#importe').val(result.s_TOTAL_PRESTAMO);
            $('#moneda').val(result.MONEDA);

            //Motramos las cuotas del prestamo
            ObtenerPrestamoCuotasLista(vPrestamo);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ObtenerPrestamoCuotasLista(pPrestamo) {
    var vPrestamo = pPrestamo;
    $.ajax({
        type: "POST",
        url: "/Cobranzas/ObtenerPrestamoCuotasLista",
        data: JSON.stringify({ prestamo: vPrestamo }),
        contentType: "application/json",
        success: function (result) {
            $("#contenidoCuotas tr").remove();
            var primeraCuota, ultimaCuota;
            for (var i in result) {
                var cuota = result[i].NUMERO_CUOTA;
                //Doy formato a vCuentaComercial para poder ser recibida en el método siguiente
                var vCuota = "'" + cuota + "'";

                primeraCuota = result[0].NUMERO_CUOTA;
                ultimaCuota = result[result.length - 1].NUMERO_CUOTA;

                $("#contenidoCuotas").append('<tr><td>' + result[i].NUMERO_CUOTA + '</td>' +
                    '<td>' + result[i].FECHA_VENCIMIENTO + '</td>' +
                    '<td>' + result[i].DIAS_MORA + '</td>' +
                    '<td>' + result[i].s_CUOTA_PAGO + '</td>' +
                    '<td>' + result[i].s_MORA + '</td>' +
                    '<td>' + result[i].s_TOTAL_PAGO + '</td>' +
                    '<td><input type="checkbox" class="chkCuotas" id="' + result[i].NUMERO_CUOTA + '" onClick="SeleccionarCuota(' + vCuota + ')"></td></tr>');
            }

            $('#primeraCuota').val(primeraCuota);
            $('#ultimaCuota').val(ultimaCuota);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function SeleccionarCuota(pCuota) {
    var numerador;
    var vCuota = '#' + pCuota;
    var toInt = parseInt(pCuota) - 1;
    var c = String(toInt).length;

    switch (c) {
        case 1:
            numerador = '#00' + toInt;
            break;
        case 2:
            numerador = '#0' + toInt;
            break;
        default:
            numerador = '#' + toInt;
    }

    $(vCuota).is(":checked") ? AgregarCuota(pCuota, numerador) : QuitarCuota(pCuota);
}

function SeleccionarCuotasTodas() {
    var accion = "";
    if ($('#cuotasTodas').is(":checked")) {
        $('.chkCuotas').prop('checked', true);
        accion = "AgregarCuotasTodas";
    }
    else {
        $('.chkCuotas').prop('checked', false);
        accion = "QuitarCuotasTodas";
    }
    $.ajax({
        type: "POST",
        url: "/Cobranzas/" + accion,
        contentType: "application/json",
        success: function (result) {
            $('#total_cuotas').val(result.s_CUOTA_PAGO);
            $('#total_moras').val(result.s_MORA);
            $('#total_pago').val(result.s_TOTAL_PAGO);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function AgregarCuota(pCuota, pCuotaAnterior) {
    if ($(pCuotaAnterior).is(":checked") || pCuota == $('#primeraCuota').val()) {
        $.ajax({
            type: "POST",
            url: "/Cobranzas/AgregarCuota",
            data: JSON.stringify({ cuota: pCuota }),
            contentType: "application/json",
            success: function (result) {
                $('#total_cuotas').val(result.s_CUOTA_PAGO);
                $('#total_moras').val(result.s_MORA);
                $('#total_pago').val(result.s_TOTAL_PAGO);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
    else {
        $('#' + pCuota).prop("checked", false);
    }
}

function QuitarCuota(pCuota) {
    var end = parseInt($('#ultimaCuota').val());
    var start = parseInt(pCuota) + 1;
    var rangos = range(start, end, 1);
    var validar = true;

    for (i = 0; i < rangos.length; i++) {

        var c = String(rangos[i]).length;
        var numerador = "";

        switch (c) {
            case 1:
                numerador = '#00' + rangos[i];
                break;
            case 2:
                numerador = '#0' + rangos[i];
                break;
            default:
                numerador = '#' + rangos[i];
        }

        if ($(numerador).is(":checked")) {
            validar = false;
        }
    }

    if (!validar) {
        $('#' + pCuota).prop("checked", true);
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Cobranzas/QuitarCuota",
            data: JSON.stringify({ cuota: pCuota }),
            contentType: "application/json",
            success: function (result) {
                $('#total_cuotas').val(result.s_CUOTA_PAGO);
                $('#total_moras').val(result.s_MORA);
                $('#total_pago').val(result.s_TOTAL_PAGO);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
}

function GrabarCobranza() {
    $("#cover-spin").css("display", "block");

    var prestamo = $('#prestamos').val();
    var TotalCuotas = $('#total_cuotas').val();
    var TotalPagar = $('#total_pago').val();

    $.ajax({
        type: "POST",
        url: "/Cobranzas/GrabarCobranza",
        data: JSON.stringify({ totalCuotas: TotalCuotas, totalPagar: TotalPagar }),
        contentType: "application/json",
        success: function (result) {
            if (result == "SUCCESS") {
                $('#MENSAJE').removeClass("alert-warning");
                $('#MENSAJE').addClass("alert-success");

                $('.message').html('La cobranza se registró con éxito.');
                $("#MENSAJE").fadeTo(7500, 700).slideUp(500, function () {
                    $("#MENSAJE").slideUp(700);
                });

                $('#total_cuotas').val('');
                $('#total_moras').val('');
                $('#total_pago').val('');

                ObtenerPrestamoCuotasLista(prestamo);

                $("#cover-spin").css("display", "none");
            }
            else {
                window.location.href = "/Error/Error?error=" + result;
                $("#cover-spin").css("display", "none");
            }
        },
        error: function (result) {
            $("#cover-spin").css("display", "none");
            alert("Check the error: " + Error);
        }
    });
}

function Validar() {
    if ($(".chkCuotas").is(":checked") == false) {
        alert('Seleccione una cuota.');
        return false;
    }
}

function MostrarCuotasCobro() {
    $.ajax({
        type: "POST",
        url: "/Cobranzas/MostrarCuotasCobro",
        contentType: "application/json",
        success: function (result) {
            $("#contenidoCobros tr").remove();
            for (var i in result) {
                $("#contenidoCobros").append('<tr><td>' + result[i].NUMERO_CUOTA + '</td>' +
                    '<td>' + result[i].CUOTA_PAGO + '</td>' +
                    '<td>' + result[i].MORA + '</td>' +
                    '<td>' + result[i].TOTAL_PAGO + '</td></tr>');
            }

            $('#lblTotCuot').html($('#total_cuotas').val());
            $('#lblTotMor').html($('#total_moras').val());
            $('#lblTotPag').html($('#total_pago').val());

        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

var range = function (start, end, step) {
    var range = [];
    var typeofStart = typeof start;
    var typeofEnd = typeof end;

    if (step === 0) {
        throw TypeError("Step cannot be zero.");
    }

    if (typeofStart == "undefined" || typeofEnd == "undefined") {
        throw TypeError("Must pass start and end arguments.");
    } else if (typeofStart != typeofEnd) {
        throw TypeError("Start and end arguments must be of same type.");
    }

    typeof step == "undefined" && (step = 1);

    if (end < start) {
        step = -step;
    }

    if (typeofStart == "number") {

        while (step > 0 ? end >= start : end <= start) {
            range.push(start);
            start += step;
        }

    } else if (typeofStart == "string") {

        if (start.length != 1 || end.length != 1) {
            throw TypeError("Only strings with one character are supported.");
        }

        start = start.charCodeAt(0);
        end = end.charCodeAt(0);

        while (step > 0 ? end >= start : end <= start) {
            range.push(String.fromCharCode(start));
            start += step;
        }

    } else {
        throw TypeError("Only string and number types are supported");
    }

    return range;

}



