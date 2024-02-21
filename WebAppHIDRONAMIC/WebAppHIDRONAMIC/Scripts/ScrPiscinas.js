
var delet = "data:image/png;base64,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";

function ValidarPiscina_m() {
    var decimal_regex = /^\d+\.\d{0,2}$/;

    if ($(".ubi").val().trim() == "") {
        alert("INGRESE UBICACIÓN");
        return false;
    }
    if ($(".lar").val().trim() == "" || $(".lar").val().trim() == "0") {
        alert("INGRESE LARGO DE PISCINA");
        return false;
    }
    if ($(".lar").val().trim() != "") {
        if (!decimal_regex.test($("#LARGO").val())) {
            alert("INGRESE FORMATO CORRECTO PARA LARGO. EJEMPLO 1.00");
            return false;
        }
    }
    if ($(".anc").val().trim() == "" || $(".anc").val().trim() == "0") {
        alert("INGRESE ANCHO DE PISCINA");
        return false;
    }
    if ($(".anc").val().trim() != "") {
        if (!decimal_regex.test($("#ANCHO").val())) {
            alert("INGRESE FORMATO CORRECTO PARA ANCHO. EJEMPLO 1.00");
            return false;
        }
    }
    if ($(".pro").val().trim() == "" || $(".pro").val().trim() == "0") {
        alert("INGRESE PROFUNDIDAD DE PISCINA");
        return false;
    }
    if ($(".pro").val().trim() != "") {
        if (!decimal_regex.test($("#PROFUNDIDAD").val())) {
            alert("INGRESE FORMATO CORRECTO PARA PROFUNDIDAD. EJEMPLO 1.00");
            return false;
        }
    }
}

function NuevaPisc() {
    $('#form-piscinas-m').trigger("reset");
    $("#btnModifica").css("display", "none");
    $("#btnAgrega").css("display", "block");
}

function Piscina(pisc) {
    var piscina = pisc;
    $.ajax({
        type: "POST",
        url: "/Piscinas/Consultar",
        data: JSON.stringify({ piscina: piscina }),
        contentType: "application/json",
        success: function (result) {
            $('#UBICACION').val(result.UBICACION);
            //$("#CUENTA_COMERCIAL").val(result.CUENTA_COMERCIAL);
            $('#LARGO').val(result.s_LARGO);
            $('#ANCHO').val(result.s_ANCHO);
            $('#PROFUNDIDAD').val(result.s_PROFUNDIDAD);
            //$('#VOLUMEN').val(result.s_VOLUMEN);
            $('#PISCINA').val(result.PISCINA);
            $('#CLIENTE').val(result.CUENTA_COMERCIAL);
            $('#FRECUENCIA').val(result.FRECUENCIA);
            $('#TIPO_PISCINA').val(result.TIPO_PISCINA);
            $("#btnModifica").css("display", "block");
            $("#btnAgrega").css("display", "none");
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ModificarPiscinaBD() {
    if (ValidarPiscina_m() != false) {
        var piscina = {
            PISCINA: $("#PISCINA").val(),
            CUENTA_COMERCIAL: $("#CUENTA_COMERCIAL").val(),
            TIPO_PISCINA: $(".tip").val(),
            UBICACION: $(".ubi").val(),
            LARGO: $(".lar").val(),
            ANCHO: $(".anc").val(),
            PROFUNDIDAD: $(".pro").val(),
            //VOLUMEN: $(".vol").val(),
            FRECUENCIA: $(".fre").val()
        };

        $.ajax({
            type: "POST",
            url: "/Piscinas/Modificar",
            data: JSON.stringify({ piscina: piscina }),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                NuevaPisc();
                $("#piscinasModificadas tr").remove();
                for (var i in result) {
                    var pisc = "'" + result[i].PISCINA + "'";
                    var clie = "'" + result[i].CUENTA_COMERCIAL + "'";
                    $("#piscinasModificadas").append('<tr><td>' + result[i].TIPO_PISCINA + '</td><td>' + result[i].FRECUENCIA + '</td>' + '<td>' + result[i].UBICACION + '</td>' +
                        '<td>' + result[i].s_LARGO + '</td><td>' + result[i].s_ANCHO + '</td><td>' + result[i].s_PROFUNDIDAD + '</td><td>' + result[i].s_VOLUMEN + '</td></tr>');
                        //'<td style="text-align:center;"><a href="#" onclick="Piscina(' + pisc + ')"><img src=' + edit + ' /></a></td></tr>');
                        //'<td style="text-align:center;"><a href="#" onclick="ElimPiscinaBD(' + pisc + ',' + clie + ')"><img src=' + delet + ' /></a></td></tr>');
                }
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
}

function AgregarPiscinaBD() {
    if (ValidarPiscina_m() != false) {
        var piscina = {
            CUENTA_COMERCIAL: $("#CUENTA_COMERCIAL").val(),
            TIPO_PISCINA: $(".tip").val(),
            UBICACION: $(".ubi").val(),
            LARGO: $(".lar").val(),
            ANCHO: $(".anc").val(),
            PROFUNDIDAD: $(".pro").val(),
            //VOLUMEN: $(".vol").val(),
            FRECUENCIA: $(".fre").val()
        };

        $.ajax({
            type: "POST",
            url: "/Piscinas/GrabarPiscinaBD",
            data: JSON.stringify({ piscina: piscina }),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                NuevaPisc();
                $("#piscinasModificadas tr").remove();
                for (var i in result) {
                    var pisc = "'" + result[i].PISCINA + "'";
                    var clie = "'" + result[i].CUENTA_COMERCIAL + "'";
                    $("#piscinasModificadas").append('<tr><td>' + result[i].TIPO_PISCINA + '</td><td>' + result[i].FRECUENCIA + '</td>' + '<td>' + result[i].UBICACION + '</td>' +
                        '<td>' + result[i].s_LARGO + '</td><td>' + result[i].s_ANCHO + '</td><td>' + result[i].s_PROFUNDIDAD + '</td><td>' + result[i].s_VOLUMEN + '</td></tr>');
                        //'<td style="text-align:center;"><a href="#" onclick="Piscina(' + pisc + ')"><img src=' + edit + ' /></a></td></tr>');
                        //'<td style="text-align:center;"><a href="#" onclick="ElimPiscinaBD(' + pisc + ',' + clie + ')"><img src=' + delet + ' /></a></td></tr>');
                }
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
}

function ElimPiscinaBD(pisc, cli) {
    var piscina = pisc;
    var cliente = cli;
    $.ajax({
        type: "POST",
        url: "/Piscinas/EliminarPiscinaBD",
        data: JSON.stringify({ piscina: piscina, cliente:cliente }),
        contentType: "application/json",
        success: function (result) {
            $("#btnModifica").css("display", "none");
            $("#btnAgrega").css("display", "block");
            $("#piscinasModificadas tr").remove();
            for (var i in result) {
                var pisc = "'" + result[i].PISCINA + "'";
                var clie = "'" + result[i].CUENTA_COMERCIAL + "'";
                $("#piscinasModificadas").append('<tr><td>' + result[i].TIPO_PISCINA + '</td><td>' + result[i].UBICACION + '</td>' + '<td>' + result[i].FRECUENCIA + '</td>' +
                        '<td>' + result[i].s_LARGO + '</td><td>' + result[i].s_ANCHO + '</td><td>' + result[i].s_PROFUNDIDAD + '</td><td>' + result[i].s_VOLUMEN + '</td>');
                        //'<td style="text-align:center;"><a href="#" onclick="Piscina(' + pisc + ')"><img src=' + edit + ' /></a></td></tr>');
                        //'<td style="text-align:center;"><a href="#" onclick="ElimPiscinaBD(' + pisc + ',' + clie + ')"><img src=' + delet + ' /></a></td></tr>');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function Piscinas(cuen, raz) {
    var cuenta = cuen;
    $("#modal-piscinasCliente").load("/Piscinas/ModificarPiscina", { cuenta: cuenta, razon : raz });
}
