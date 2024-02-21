$(document).ready(function () {
    $("#MES").val(month);
    $("#EJERCICIO").val(year);

    Consultar(year, month, 0);
    ListarDias(year, month,1);

    $('.fechas').on('change', function (e) {
        Consultar(0, 0, 0);
        ListarDias(0, 0,0);
    });

});

//VARIABLES GLOBALES
var editar = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACMAAAAjCAYAAAAe2bNZAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JQAAgIMAAPn/AACA6QAAdTAAAOpgAAA6mAAAF2+SX8VGAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4gcUEDYD9jBvTgAAAwpJREFUWMO92E9oXFUUx/HPGwexxUoVoWipWkQ7dTFUKhaSSCUaFAX/YNCu7FboLFIQ3GgKAd2If5Boq2ChJVo0qCiiIJqN2bioluAiiLYIVaaLGGyhxLZJXNw74TnMTN7Le/EHD+577/75cu69555zEz00ODa9UsRh3CmfFvA7PsA7mJsaHehaOckA0o/3cFdOkLSu4EOMYL4bUEeYFMhABNkZ30/iKJYyQmzCQ7g/vj+PN6ETUDUHCPyGd7HYy9xt/RzHBB7Ek3gfFzq1qeQAyaUU7Dl8G8tbcG23NiuWKRMkDRT7vSRM7df4a+nyZbV6IxGWyTKWZ2fGA8x6gLTpCo5IkkNTL/VfqtUb/diHrTiNiVq9car6P4DAl5Jk4tiLfeeHJhvDwiLemvr/KA60pmndQKZGB9TqjTNIhiZPDOMt3NRWrYbRiuDQjmQEWRDmOLNq9QZhbTzVBaSlXVW8HclW03l8JbuPyQMCF6spkJP4VWdH+E8E+axl+pJBFvFJ2ukdFc6PqzpUXm5ZZB1AljGJl9MwrcEWVx2tXJCPcRDNyqq9rz/ICJqzM+NKgykC0vpYVYKKWqSlwpaJIIqCFIYpAtKpQhnTdDdeK2KRUiwT9QhuLQpSFsyNWUBmZ8abNw/v2zE4Nr0pFSn8R2uaprhWNuIO/Cy483bPvQKy8bbtzcHh6QcE5/acLGFnTu3Gq/gJn7f9W8JHGLl+T19z8z177hVi5x16nPq5LROtUsEzGMJZjOEU7osg3+AY5jZsuwX6cDt+6dX3Wi2zE4/F8n68ju/xRHzewFxqsSZZOs1lmZRfeRrbhLUyG0H+xEXotWNKgUmBbMfj+EHIib7AH2KEX0Rr2U034BV8h7kiligD5kchKiwNIg2zgGuwmZBDdYrmUgNnDshTzu3q1Oeu7Ss4E8sPi+dLNw+ZR6k+tgh5NuGAvNCtTVVIyg8JPuKEkIL+XQYQrhNuIfYKO+/T1WAOCztkf2y0twyKNrXuZ47TPaivYh4vCDnvs8IJvKEkiPabq/le2cW/LHQNNxR+VBUAAAAldEVYdGRhdGU6Y3JlYXRlADIwMTgtMDctMjBUMTY6NTQ6MDMtMDQ6MDBwvT4HAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDE4LTA3LTIwVDE2OjU0OjAzLTA0OjAwAeCGuwAAAABJRU5ErkJggg==";
var now = new Date();
var day = ("0" + now.getDate()).slice(-2);
var year = now.getFullYear();
var month = ("0" + (now.getMonth() + 1)).slice(-2);
var today = (day) + "-" + (month) + "-" + now.getFullYear();


function Consultar(anio, mes, dia) {
    var cambio;
    var tip;
    if (dia == '0') {
        tip = 'LISTA';
        cambio = {
            TIPO_OPERACION: 'LIST',
            EJERCICIO: $("#EJERCICIO").val(),
            MES: $("#MES").val(),
            DIA: null
        };
    }
    else {
        tip = 'CONSULTA';
        cambio = {
            TIPO_OPERACION: 'CONS',
            EJERCICIO: anio,
            MES: mes,
            DIA: dia
        };
    }
    $.ajax({
        type: "POST",
        url: "/Proformas/ListaTiposCambio",
        data: JSON.stringify({ tipo: cambio }),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            if (tip == 'LISTA') {
                $("#CambiosDet tr").remove();
                for (var i in result) {
                    var anio = "'" + result[i].EJERCICIO + "'";
                    var mes = "'" + result[i].MES + "'";
                    var dia = "'" + result[i].DIA + "'";
                    var com_i = parseFloat(result[i].COMPRA).toFixed(3);
                    var ven_i = parseFloat(result[i].VENTA).toFixed(3);
                    var pro_i = parseFloat(result[i].PROMEDIO).toFixed(3);
                    $("#CambiosDet").append('<tr><td>' + result[i].DIA + '</td><td style="text-align:right;">' + com_i + '</td>' +
                        '<td style="text-align:right;">' + ven_i + '</td><td style="text-align:right;">' + pro_i + '</td>' +
                        '<td style="text-align:center;"><a href="#/" onclick="Consultar(' + anio + ',' + mes + ',' + dia + ')"><img src=' + editar + ' /></a></td></tr>');
                }
            } else {
                BloquearDate();
                for (var i in result) {
                    $('#compra').val(result[i].COMPRA);
                    $('#venta').val(result[i].VENTA);
                    $('#promedio').val(result[i].PROMEDIO);
                    $('#dias').val(result[i].DIA);
                }
            }

        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ListarDias(anio, mes, tipo) {
    //var now = new Date();
    //var day = ("0" + now.getDate()).slice(-2);
    if (anio == '0') {
        anio = $("#EJERCICIO").val();
        mes = $("#MES").val();
    }
    $.ajax({
        type: "POST",
        url: "/Proformas/ListarDias",
        data: JSON.stringify({ anio: anio, mes: mes }),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $("#dias").empty();
            for (var i in result) {
                $("#dias").append($("<option></option>").attr("value", result[i].ID).text(result[i].DESCRIPCION));
            }
            if (tipo == '1') {
                $("#dias").val(day);
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function BloquearDate() {
    $("#MES").prop('disabled', true);
    $("#EJERCICIO").prop('disabled', true);
    $("#dias").prop('disabled', true);
    $('#tipo').val('ACT');
}

function nuevo() {
    $("#MES").prop('disabled', false);
    $("#EJERCICIO").prop('disabled', false);
    $("#dias").prop('disabled', false);
    $('#compra').val('');
    $('#venta').val('');
    $('#promedio').val('');
    $('#tipo').val('REG');
}

function Grabar() {
    var venta = $('#venta').val();
    var compra = $("#compra").val();

    if ($('#compra').val().trim() == "" || compra == '0' || compra == '0.00' || compra == '0.00' || compra == '0.000') {
        alert("INGRESE VALOR DE COMPRA");
        return false;
    }
    else if ($('#venta').val().trim() == "" || venta == '0' || venta == '0.0' || venta == '0.00' || venta == '0.000') {
        alert("INGRESE VALOR DE VENTA");
        return false;
    }
    else if (venta < compra) {
        alert("El valor de venta no puede ser menor al de compra");
        return false;
    }
    else {
        var cambio = {
            TIPO_OPERACION: $("#tipo").val(),
            EJERCICIO: $("#EJERCICIO").val(),
            MES: $("#MES").val(),
            DIA: $("#dias").val(),
            COMPRA: compra,
            VENTA: venta,
            PROMEDIO: $("#promedio").val()
        };

        $.ajax({
            type: "POST",
            url: "/Proformas/MantenimientoCambio",
            data: JSON.stringify({ tipo: cambio }),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var msg;
                $("#CambiosDet tr").remove();
                for (var i in result) {
                    var anio = "'" + result[i].EJERCICIO + "'";
                    var mes = "'" + result[i].MES + "'";
                    var dia = "'" + result[i].DIA + "'";
                    var com_i = parseFloat(result[i].COMPRA).toFixed(3);
                    var ven_i = parseFloat(result[i].VENTA).toFixed(3);
                    var pro_i = parseFloat(result[i].PROMEDIO).toFixed(3);
                    $("#CambiosDet").append('<tr><td>' + result[i].DIA + '</td><td style="text-align:right;">' + com_i + '</td>' +
                        '<td style="text-align:right;">' + ven_i + '</td><td style="text-align:right;">' + pro_i + '</td>' +
                        '<td style="text-align:center;"><a href="#/" onclick="Consultar(' + anio + ',' + mes + ',' + dia + ')"><img src=' + editar + ' /></a></td></tr>');

                    var fecha = result[i].DIA + "-" + result[i].MES + "-" + result[i].EJERCICIO;
                    if (today == fecha) {
                        $("#cambio").val(result[i].VENTA);
                    }
                }

                if (cambio.TIPO_OPERACION == 'REG') {
                    msg = "Tipo de cambio para <strong>" + cambio.DIA + "/" + cambio.MES + "/" + cambio.EJERCICIO + "</strong> añadido";
                } else {
                    msg = "Tipo de cambio para <strong>" + cambio.DIA + "/" + cambio.MES + "/" + cambio.EJERCICIO + "</strong> actualizado";
                }
                $(".message_s").html(msg);
                $("#MENSAJE_S").fadeTo(4500, 500).slideUp(500, function () {
                    $("#MENSAJE_S").slideUp(500);
                });

                nuevo();
            },
            error: function (result) {
                var mensaje = "Ya existe tipo de cambio para <strong>" + cambio.DIA + "/" + cambio.MES + "/" + cambio.EJERCICIO + "</strong> (Actualice)";
                $(".message_w").html(mensaje);
                $("#MENSAJE_W").fadeTo(5500, 500).slideUp(500, function () {
                    $("#MENSAJE_W").slideUp(500);
                });
            }
        });
    }
}

function calcularPromedio() {
    var compra = parseFloat($("#compra").val());
    var venta = parseFloat($("#venta").val());

    var promedio = (compra + venta) / 2;
    $("#promedio").val(parseFloat(promedio).toFixed(3));
}