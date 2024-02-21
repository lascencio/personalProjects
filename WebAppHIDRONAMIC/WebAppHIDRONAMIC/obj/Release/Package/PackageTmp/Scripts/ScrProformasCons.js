$(document).ready(function () {

    var today = (day) + "/" + (month) + "/" + now.getFullYear();

    //FUNCIONES PARA LISTADO DE CONSTANCIAS
    $('#fecha1').val(today);
    $('#fecha2').val(today);
    $('#fechaActual1').val(today);
    $('#fechaActual2').val(today);

});

var details = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACgAAAAoCAYAAACM/rhtAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAABmJLR0QA/wD/AP+gvaeTAAAAB3RJTUUH4gURCzsMjkzjUQAAB2RJREFUWMOtmF1sFMcdwH8ze1/+uJyNsYkDNV+SOck8gArxISQQEEOrKEoaFIU8gISJRJWXuNBK0EIaykeFUJFMeYmiuFISRbIiUjnwEglVUZqoJFFTHgioAdlQu5Bw9MA5++y73Znpw+2t1uf7wvCXRjs7uzvzm//HzH9WUEV6enrE7t27w5ZlBaq9a4xBKTWr3XEcRkdHs4cOHbIBUa0fv1Qc9NatW5w4cSLS1dV1vKGh4afGGFVrx0XgorOz87JlWX8+cODAsBCiZsiKgOfPnyeVSoWFEE+HQqH1xpi58AHQ0tKycd26dYkzZ878DvgU0LVoU1Z62NXVhdYaIQQPMemSEg6HRVtbW2LNmjV/GRgY2NXe3h4Cqs64HKAAREdHhwcnhEBK+UigdXV1RKPRjlWrVp0+depUX3d3d4OpYpaKGly2bBmA8MNJKecMKqUkFAoRi8WaV65c+fu+vr4DW7dujfb39xtXm7NKKcBZIxdr8FE0alkWoVCItra2+ng8/us9e/YcHBoaajx27NjDa7AYsBScv9Tal2VZNDU10draGuns7PxVb2/vbwYHB+sPHz48N8Bymis2eS2gQgiMMYTDYWKxGK2trZF4PL5/3759e48ePRocGBiY8X7VxdcPUojogl/768X35XxfSkkmk2FkZMTrs76+vmHFihW/PXv27O3e3t7BYg2KojJjwHImrmTySoEkpSQYDGJZ1oz2urq6+fF4/A9Hjhx52p2cAETNGiwMXEp71eqFUtwn5IMmGAxSV1dHMBjsTCQSh/v6+nYbY+4JIcScgqRYW5UCp9aIl1ISjUZZsmTJ5k2bNq2t2QeLZ1yrVPJVKO+jwWAwKIRoeGjAakFSCqJUe/F9qW/8bY/FB6tBVdNqpd2uog+6H5pqi3QtPlmpXsk//RqcNY0/nT6NFQh4nWhjoFCEQBQiND8b797/rKa6T8Na61mA5o8gd8CrEro1KEM+WTP79/OzQCCcGx9fnmprwxiDFgIDaGPQWqPddzWghchfjUEDqvDcGBSgfO8oQCnFvESCn2zf7pm8OCADADEQAraE4GULXyrR1ERDNIr+5huU1qh0GmdyMj9QOAzNzd5A9uQkuUzGA1FSIlta0IEAjgvoaM3U/fvkbBsFTAI5IVj80kszfLMYUIwBDvAE0OgDtF5/HWvXLnBNoW/fJn32LOkPPyS0fj0tZ85AKARa4ySTjH/yCXfeeoupZBKrtZUV775LJJ+ygRDY4+N8vXMnD65eRQPTQI7SO9aMIMmAyIFQrqkc90PV0oJYuhQnk8FOpbDWriV68iQqHseORAgsX46IxXByOUIrV/Lkm2/y5JEj5MJhslIS6uggtHAhdiZD9scfyabT5JQi6/Y/BWRLrBSzAJX7Qc6d1VQeGscYsG1Sx44xunUr6aEhAh0dyNWrySqFEILUhQtc3ryZb3fuZPrmTdpeeYVIdzfTSmGAyeFh/v7CC1zcsIG/Pfcc/7txwxtryjVxqZ1nFqDtwmV8xXFfyk5PMzE+Ti6ZzJsqHCbnPrOzWdL37jF24QL/HRzEamoimkiQc5epQEMD8zZsYH5PD03d3TiBALZvvIKJy6VsgQJgQXO4YI7bjpQ0bt9OKJEg9vzzqHSa8Rs3sBobKXybdd9/8N13oDWBBQvIuctS46JFJN5+GyyL+1eucL6nB/vuXW8cXWIDmLUOOmUAHRdw3o4dIARqYoLRd94h+eWXtPT0zAC0C5EtBI7jkHPXumwqxfBHH+FMTzN55w7TmQyOG4SFc2elIPEAsy7kLECluNnfT+rSJaa//577ly+TtW2ecDtRxjAFiFCIlnXrwBgeDA9jaw1CkPnhB/7xxhtMJJPeTmB8gBT7XFGQeIBTQOGg6plYCDCGu59/ztjHH3udOq7GjDFEnnqKBc88Q/uWLXS8+CITt24x+tlnKCk9EM9dfHCFugCElN6uUlaDGRcQX4dKSggEUFLmnd4H6AiBEYJFzz7Lwm3bEJEI2Xv3+OfJkySvXaO+vR0CAfDtNlBiPxUC6e5OfjPPAMy5gMECmFtuf/UVdjRKcnSUiSLA5NgY337wAcKyULbN5J07/OfiRca++CK/00xNcW1oCK0Uk9ksWR9TQXOqVh+084B6Kg+gChr893vv4bz/PkoI6ViW8PumvnKFT/fuzQ9oDMZd96SUYFkwMcHVgwfzz7XOtxWJrRTSsmYAlQQcBr0a+g381QHtgRiDXV/f8Ivjxw/MX7QoXkgCKklxjudd8zcz27SmdenS6kFyFcxVuES+ePLL114DY2Jrd+16dV5zM3MVLzB8qVkhTdNKod1dqVSQ+BPWWUfPn2/bxmQ6LYzWc/pj5J3otM67gHvVvjrGVDz4V0z5H/WXW7Fv1XIMKOmD5aQ4u30coOVgKyas5UTKmo7NDwVa7SRYMkjKieM4+URVa7TWPMov4FLij/RCvXicioCLFy/m+vXruXPnzg1GIpF/Vfsb+iiQvnpuZGTk+saNG/NapvSPbD+IAMLVJvM4mcnnLgrg/0jE4pzwDFUCAAAAJXRFWHRkYXRlOmNyZWF0ZQAyMDE4LTA1LTE3VDExOjU5OjEyLTA0OjAwSDodxQAAACV0RVh0ZGF0ZTptb2RpZnkAMjAxOC0wNS0xN1QxMTo1OToxMi0wNDowMDlnpXkAAAAASUVORK5CYII=";
var eliminar = "data:image/png;base64,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";


var now = new Date();
var day = ("0" + now.getDate()).slice(-2);
var month = ("0" + (now.getMonth() + 1)).slice(-2);
var year = now.getFullYear();

function ProformasPorCliente() {
    var cliente = $("#nombre").val();
    $.ajax({
        type: "POST",
        url: "/Proformas/ProformasPorCliente",
        data: JSON.stringify({ cliente: cliente }),
        contentType: "application/json",
        success: function (result) {
            ConstruirTablas(result);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ConstruirTablas(result) {
    $("#contenidoProformas tr").remove();
    for (var i in result) {
        var cotizacion = result[i].COTIZACION;
        var coti = "'" + cotizacion + "'";
        $("#contenidoProformas").append('<tr><td>' + result[i].FECHA_REGISTRO + '</td><td>' + result[i].RAZON_SOCIAL + '</td>' +
            '<td>' + result[i].COTIZACION + '</td><td>' + result[i].USUARIO_REGISTRO + '</td><td>' + result[i].TIPO + '</td><td style="text-align:center;">' + result[i].TIPO_MONEDA +
            '</td><td style="text-align:right;">' + parseFloat(result[i].IMPORTE_TOTAL_MN).toFixed(2) + '</td>' +
            '<td style="text-align:center;"><a href="/Proformas/ProformaPDF?proforma=' + cotizacion + '" &cliente=""><img src=' + details + ' /></a></td>' + PorcionDevelop(coti) + '</tr>');
    }
}

function SelecProf(proforma) {
    $('#proforma').val('');
    $('#proforma').val(proforma);
    $('#contenido').text('¿Esta seguro de eliminar proforma N°' + proforma + '?');
}

function PorcionDevelop(proforma) {
    var porcion = "";
    if (perfil == 4) {
        porcion = '<td style="text-align:center;"><a href="#msgConfirm" data-toggle="modal" onclick="SelecProf(' + proforma + ')"><img src=' + eliminar + ' /></a></td>';
    }
    return porcion;
}

function ConsultarProformas() {
    var tipo = $('#cboTiposConsulta').val();
    //jQuery('#btnConsulta').unbind('click');
    //COONSULTA POR UN RANGO DE FECHAS
    if (tipo == 'UR') {
        var date_regex = /^(0[1-9]|1\d|2\d|3[01])\/(0[1-9]|1[0-2])\/(19|20)\d{2}$/;
        var fecha1 = $("#fecha1").val();
        var fecha2 = $("#fecha2").val();
        if (!(date_regex.test(fecha1)) || !(date_regex.test(fecha2))) {
            alert('INGRESE FORMATO CORRECTO. EJEMPLO 28/05/1995');
            return false;
        }
        else {
            $.ajax({
                type: "POST",
                url: "/Proformas/ProformasPorFechas",
                data: JSON.stringify({ fecha1: fecha1, fecha2: fecha2 }),
                contentType: "application/json",
                success: function (result) {
                    ConstruirTablas(result);
                },
                error: function (result) {
                    alert("Check the error: " + Error);
                }
            });
        }
    }
        //CONSULTA POR UN MES
    else if (tipo == 'UM') {
        $('#rango1').css('display', 'none');
        $('#rango2').css('display', 'none');
        $('#meses').css('display', 'inline-block');
        var mes = $("#cboMes").val();
        $.ajax({
            type: "POST",
            url: "/Proformas/ProformasPorMes",
            data: JSON.stringify({ mes: mes }),
            contentType: "application/json",
            success: function (result) {
                ConstruirTablas(result);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
        //CONSULTA POR TODOS
    else if (tipo == 'TO') {
        var mes = '';
        $.ajax({
            type: "POST",
            url: "/Proformas/ProformasPorMes",
            data: JSON.stringify({ mes: mes }),
            contentType: "application/json",
            success: function (result) {
                ConstruirTablas(result);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
        //CONSULTA POR ESTA SEMANA
    else if (tipo == 'ES') {
        $.ajax({
            type: "POST",
            url: "/Proformas/ProformasPorSemanaActual",
            contentType: "application/json",
            success: function (result) {
                ConstruirTablas(result);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
        //CONSULTA POR SEMANA ANTERIOR
    else if (tipo == 'SA') {
        $.ajax({
            type: "POST",
            url: "/Proformas/ProformasPorSemanaPasada",
            contentType: "application/json",
            success: function (result) {
                ConstruirTablas(result);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
        //CONSULTA POR ESTE MES
    else if (tipo == 'EM') {
        $.ajax({
            type: "POST",
            url: "/Proformas/ProformasPorMes",
            data: JSON.stringify({ mes: month }),
            contentType: "application/json",
            success: function (result) {
                ConstruirTablas(result);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
        //CONSULTA POR MES ANTERIOR
    else if (tipo == 'MA') {
        var mes = month - 1;
        $.ajax({
            type: "POST",
            url: "/Proformas/ProformasPorMes",
            data: JSON.stringify({ mes: mes }),
            contentType: "application/json",
            success: function (result) {
                ConstruirTablas(result);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
        //CONSULTA POR ESTE AÑO
    else if (tipo == 'EA') {
        $.ajax({
            type: "POST",
            url: "/Proformas/ProformasPorAnio",
            data: JSON.stringify({ anio: year }),
            contentType: "application/json",
            success: function (result) {
                ConstruirTablas(result);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
        //CONSULTA POR HOY
    else {
        var fecha1 = $("#fechaActual1").val();
        var fecha2 = $("#fechaActual2").val();
        $.ajax({
            type: "POST",
            url: "/Proformas/ProformasPorFechas",
            data: JSON.stringify({ fecha1: fecha1, fecha2: fecha2 }),
            contentType: "application/json",
            success: function (result) {
                ConstruirTablas(result);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
}

function CambioTipoConsulta() {
    var tipo = $('#cboTiposConsulta').val();
    if (tipo == 'UR') {
        $('#rango1').css('display', 'inline-block');
        $('#rango2').css('display', 'inline-block');
        $('#meses').css('display', 'none');
    }
    else if (tipo == 'UM') {
        $('#rango1').css('display', 'none');
        $('#rango2').css('display', 'none');
        $('#meses').css('display', 'inline-block');
    }
    else {
        $('#rango1').css('display', 'none');
        $('#rango2').css('display', 'none');
        $('#meses').css('display', 'none');
    }
}

function EliminarUbi() {
    var proforma = $('#proforma').val();
    $.ajax({
        type: "POST",
        url: "/Proformas/EliminarUbicacion",
        data: JSON.stringify({ proforma: proforma }),
        contentType: "application/json",
        success: function (result) {
            //ConstruirTablas(result);
            $('#msgConfirm').modal('hide');
            if (result == 'SUCCESS') {
                $('.message').html('PDF de proforma ' + proforma + ' eliminada correctamente');
            }
            else {
                $('.message').html(result);
            }
            $("#MENSAJE").fadeTo(4500, 500).slideUp(500, function () {
                $("#MENSAJE").slideUp(500);
            });

        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function Eliminar() {
    var proforma = $('#proforma').val();
    $.ajax({
        type: "POST",
        url: "/Proformas/Eliminar",
        data: JSON.stringify({ proforma: proforma }),
        contentType: "application/json",
        success: function (result) {
            ConstruirTablas(result);
            $('#msgConfirm').modal('hide');
            $('.message').html('Proforma ' + proforma + ' eliminada correctamente');
            $("#MENSAJE").fadeTo(4500, 500).slideUp(500, function () {
                $("#MENSAJE").slideUp(500);
            });

        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}