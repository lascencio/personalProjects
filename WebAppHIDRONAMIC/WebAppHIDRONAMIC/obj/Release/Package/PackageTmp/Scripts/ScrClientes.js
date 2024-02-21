$(document).ready(function () {
    Listar();

    ValIndica();

    ClientesPorRazon();

    $('#btnRegCliente').click(function () {
        if (Validar() != false) {
            $("#msgConfirm").css("display", "block");
        }
        else {
            return false;
        }
    });

    $('#TIPO_DOCUMENTO').on('change', function (e) {
        var optionSelected = $("option:selected", this);
        var valueSelected = this.value;
    });

    $('#btnSi').click(function () {
        $('#msgConfirm').modal('hide');
    });

});

var delet = "data:image/png;base64,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";
var editClie = "data:image/png;base64,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";
var edit = "data:image/png;base64,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";
var audi = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACMAAAAjCAYAAAAe2bNZAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAABmJLR0QA/wD/AP+gvaeTAAAAB3RJTUUH4gURDA0pSRuw5gAACItJREFUWMOtln9sldUZx7/nnPd973t/F4ql9Af9QalU8ScUCi4FoZANwTk0zpmQuCyaTOeyHzEuc8nM5txGjFv0j2Vszo2pW6Y4tzhxExQRJxVBYcgvbenV2hZoe3t7b+973x/nefZHL0RWSm/NnuTJTW7OeZ9Pvuf7nPOIjo6VEoBAibFx4yq9ZcvzFUEQbIhGo19USl2ntS6j8UgR0TYi2hqN2kfi8ajQmkr9NouOjpWqFBghBIiYM5nc9UEQfF9rfV00GrWklNBag4hARNBaMxF1MdNjSqkna2oqnULBLQWIVWNjfUnKhMMhSqdzNzPzFiK6AmBlWSEIIcDMn07BzDOZeXUQaNNxCnvi8ZgmmlohWYp+yWSEhoezLUKInwCYAwCaGER8sW0WM9/jOO6q7du36lLqlArDgPgSgPnMDCkFlrUuwNLFzWC+KFCcmdfcdtvdJdUxSlmUSg2aAK5kZswqT2Dj+iW46YY2+IHG7556Fa+9cRjZXB6aCJoIOB+wKpXqM+LxKE0BXhoMADCzSCYi+O7d69C+vAVSjlvg3jvXYMXyZnzQ3Y+RzBg+6RvGu//pwenBzNmtWkrJpdQoCaasLBJks4XU5QuqsKy1AYAPKrogbAPLFtejbVEdiBieH+Dg4Y+w+bEX8eHJAQD4uK3tquDQoeNqqjolneW2bS+RH+h91ZVJ31QE1h6Yiqk96MAFkQfAR8hktC2uw03rroYQQgN479FHf12SMiXBbNiwRqYz+b2RsOrS2gWzNzGLcFT8bWooh22bHwHYd+edm0qqU9Iix/FlT9f7vWUJ66+BVwDoU8pMkgIBTEP9KyDVk0r1/v9gikHz5ib+xOz1MvkAeQD5F0zWHgqFQo/rBr+/9csbginuo3NR8g1cMbtaGoqGF11RcZWSfCWYANYXTKIAvh9sfvDnf3kubFtyqpaetjKxqIkfPPSU5zjO80Ru4YK+KSZpbzAZV68A0ERUsvTTOSbEZ12mulODr7tu4bXJvELaJcdx/viPnR8evmbRsml9f1qLl15dIdpv/EV6OJ17wPfcbibvPDPTuFee604NPXzP/Xu88hmhkkeTacOMR4XQHBqQRrhALKG1D9IeSPtgKEDau5at++Vgx6raaX+75OfgbDCfooEjj1xjGFY9hA3SHpgCCGlCKhMs6Jqbb1xu7NjxFgHA3LlVYt68eUKpKS/g6SnTued92v/3+8Jh294klBkR0oIyYzBCZVBmFEJaMExr/eM/23T9seMn53R3d9c/++zzycbGJu7p6ZnyoSxh0hPgfJZ3/vsd+tqBzsTqZOaOVar3oaQKYgyAi2sABoSCDNVAhC/7RJqz8xAIEdGA7/v/HBwcfLKhoSG1evUKKcQFy00xduoA+V17dOGhF6y1K5asrGzS384pZ8Vsb9i+OuhDjRhDRASQAFgomNGFUJEF0CQx5hWgCQibJmzTgB8EnSMjI1+vrq4+WJy7J8BM6hk9dIopUsHl27ouhxW590RW3hr0mGWVlRJnIgovqwSifh4JcmBSgBa7HFeEGjFa8LB/ZAi9OaAvbUAHhBvqo1hYEVsaj8c3Hziw//Zrr1003NGxcoIAE2GYkd35uq74w76YLK/exFJ9B8A8nxhHzwToyyjUzIiibIaJgm0hq2IIKWB5+BJ4PmF3Xw5HciFk8hKFgOCTxJPHcrjHkKhLWiuqqmrWMvPTa1a3G5DqIjBMSO/crWtfONmEUPRBBm4RDIvPOkMAIx5hZACwzxhIhAyETMb8hMCMqERvtoDtPT7SgULW8wEwyiyJiKHw1qkC5sYN80QO39z48qET9pF9++WCRRKGeaFuYgzu3K3nvti7WNixpyHE7YCwJtp5PJyA0Z8jdA0RzowyQIS046M/W0DaJfjE8DTjtKORdglDLkNrjbSrlxiW/Yy3ed8XjK4DBAomwozueJ0a/tZTL0z7cQjRehZw0h4TgCxmziPkXR8JU8DWLpgJQgic7ZqMq1FuAaw10o4PYjRBmY9nf7y3ddare/R5MOw5KPvKHVLY0bshxNKJOuCiUP0OoWfUQ4Ut0D7HAnJpBL4HrTUC30e97aN1pkDO9XFoyEPx6WyAYX6r74dPhEVukM95ZmR3J9W98OdGIeTG0h7783GzWuCVPh/VIcL6hjhiCnh7YBQFLVBfHsLn6+O4xGJ0nnJxcGRczXHRRbuuvbIuuffw8ZGOlcIAgHeY6ZaXTy0ERO3FjmaykADeyRhIpFysmyOxti6C9poINDHChgARYSzvIuqcRBN5OIpmFM8mCakuWQ8cfQpQBgAEACBkLQTMz8ACANAssGPYQs+Yh9ayPGrCAqYUGHYJBzMSLfIE1qU3oyVw8StxF3aJFQB5Dgpj2VeLfjAAwBQCN237ICvDcQ+GaX02HIAgcNSxcNwxYAuCYIZLCnkyMKzz+JyXRhwO7hBPIAN77G1n/m+s1HsfDCxpkUBx7KxPSInZ87tEOD4EoAlCzoCc7AmZ2kMMwGcJjwU0BCQYZ0QFEHhoCo4gxqO4Nug8vTbY/qMHHig72dCSVedgRCQpgsO7vLHDezuN2gXbGdzLpMMgTgKw+RyVmKTB/vd/gXNbmMDaZ+35p0+6FS+1ea91RTjfbMJLRoXT/NVVx3bdt/XykcbarDh3A8tYUoR0VuQevq2roPUjZd947Leqov4yEYq2wbBaYZiXQqpKCJlgIUOAUOOvNo9LwYzxIZ0YmnzSQZa138+++z55hTeQz+w5eqLvmFuXnpmPkWEpWgegPWyItTz2zJY1a1YqA59uH2XAWrBQWEwi2Hp/xu3rf/NUlt+suut+SzW3zRTRZBWMUC2kqoZUsxmiDECEAYOZA2bKstZnWPsfs+92c340xV37BzNbHnarmyvFpbPmyGVbUv37f1r9vViI5gKwxzz1rhCMjo7r+b+qP7xWiqmr3QAAACV0RVh0ZGF0ZTpjcmVhdGUAMjAxOC0wNS0xN1QxMjoxMzo0MS0wNDowMCsDhrkAAAAldEVYdGRhdGU6bW9kaWZ5ADIwMTgtMDUtMTdUMTI6MTM6NDEtMDQ6MDBaXj4FAAAAAElFTkSuQmCC";
var pool = "data:image/png;base64,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";
function ValIndica() {
    var rowCount = $('#piscinas').children('tr').length;
    rowCount != 0 ? $("#INDICA_PISCINA").val("SI") : $("#INDICA_PISCINA").val("NO");
}

function Validar() {
    var email_regex = /\S+@\S+\.\S+/;
    var tipo = $("#TIPO_DOCUMENTO").val();
    var doc = $("#NRO_DOCUMENTO").val().trim();
    if (doc == "") {
        alert("INGRESE NÚMERO DE DOCUMENTO");
        return false;
    }
    if ($("#NRO_DOCUMENTO").val().trim() != "") {
        if (tipo == "01") {
            if (doc.length != 8) {
                alert("EL DNI DEBE TENER 8 CARÁCTERES");
                return false;
            }
        }
        if (tipo == "06") {
            if (doc.length != 11) {
                alert("EL RUC DEBE TENER 11 CARÁCTERES");
                return false;
            }
        }
    }
    if ($("#RAZON_SOCIAL").val().trim() == "") {
        alert("INGRESE NOMBRE O RAZÓN SOCIAL");
        return false;
    }
    if ($("#DOMICILIO").val().trim() == "") {
        alert("INGRESE DIRECCIÓN");
        return false;
    }
    if ($("#EMAIL").val().trim() == "") {
        alert("INGRESE CORREO ELECTRONICO");
        return false;
    }
    if (!email_regex.test($("#EMAIL").val())) {
        alert("FORMATO DE CORREO INCORRECTO. EJEMPLO: correo@dominio.com");
        return false;
    }
}

function Validar_modifica() {
    var email_regex = /\S+@\S+\.\S+/;
    var tipo = $(".tipdoc").val();
    var doc = $(".numdoc").val().trim();
    if (doc == "") {
        alert("INGRESE NÚMERO DE DOCUMENTO");
        return false;
    }
    if (doc != "") {
        if (tipo == "01") {
            if (doc.length != 8) {
                alert("EL DNI DEBE TENER 8 CARÁCTERES");
                return false;
            }
        }
        if (tipo == "06") {
            if (doc.length != 11) {
                alert("EL RUC DEBE TENER 11 CARÁCTERES");
                return false;
            }
        }
    }
    if ($(".nomraz").val().trim() == "") {
        alert("INGRESE NOMBRE O RAZÓN SOCIAL");
        return false;
    }
    if ($(".direxac").val().trim() == "") {
        alert("INGRESE DIRECCIÓN");
        return false;
    }
    if ($(".correo").val().trim() == "") {
        alert("INGRESE CORREO ELECTRONICO");
        return false;
    }
    if (!email_regex.test($(".correo").val())) {
        alert("FORMATO DE CORREO INCORRECTO. EJEMPLO: correo@dominio.com");
        return false;
    }
}

function Listar() {
    $.ajax({
        type: "POST",
        url: "/Clientes/Clientes",
        contentType: "application/json",
        success: function (result) {
            ConstruirTablaClientes(result);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ConstruirTablaClientes(result) {
    $("#contenidoClientes tr").remove();
    for (var i in result) {
        var cuec = "'" + result[i].CUENTA_COMERCIAL + "'";
        var raz = "'" + result[i].RAZON_SOCIAL + "'";
        var rs = result[i].RAZON_SOCIAL;
        var fec = result[i].FECHA_REGISTRO;
        $("#contenidoClientes").append('<tr><td>' + rs + '</td>' +
            '<td style="text-align:center;"><a data-toggle="modal" href="#ventanaCliente" onclick="Cliente(' + cuec + ')"><img src=' + editClie + ' /></a></td>' +
            '<td style="text-align:center;"><a data-toggle="modal" href="#ventanaAuditoria" onclick="Auditoria(' + cuec + ')"><img src=' + audi + ' /></a></td>' +
            '<td style="text-align:center;"><a data-toggle="modal" href="#ventanaPiscinasCliente" onclick="Piscinas(' + cuec + ','+raz+')"><img src=' + pool + ' /></a></td></tr>');
    }
}

function piscina(x) {
    if (x == 0) {
        $("#form_piscina").css("display", "block");
        $("#INDICA_PISCINA").val("SI");
    }
    else {
        $("#form_piscina").css("display", "none");
        $("#INDICA_PISCINA").val("NO");
    }
    return;
}

function Departamentos(tipo) {
    var clase = "";
    var depa = "";
    if (tipo == 'R') {
        clase = '.prov_r';
        depa = $('.depa_r').val();
    } else {
        clase = '.prov_m';
        depa = $('.depa_m').val();
    }
    $.ajax({
        type: "POST",
        url: "/Clientes/Provincias",
        data: JSON.stringify({ depa: depa }),
        contentType: "application/json",
        success: function (result) {
            $(clase).empty();
            for (var i in result) {
                $(clase).append($("<option></option>").attr("value", result[i].ID).text(result[i].DESCRIPCION));
            }
            Provincias(tipo);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function Provincias(tipo) {
    var prov = "";
    var clase = "";
    if (tipo == 'R') {
        prov = $('.prov_r').val();
        clase = '.dist_r';
    } else {
        prov = $('.prov_m').val();
        clase = '.dist_m';
    }
    $.ajax({
        type: "POST",
        url: "/Clientes/Distritos",
        data: JSON.stringify({ prov: prov }),
        contentType: "application/json",
        success: function (result) {
            $(clase).empty();
            for (var i in result) {
                $(clase).append($("<option></option>").attr("value", result[i].ID).text(result[i].DESCRIPCION));
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function Cliente(cuec) {
    var cuenta = cuec;
    $("#modal-cliente").load("/Clientes/ModificarCliente", { id: cuenta });
}

function Modificar() {
    if (Validar_modifica() != false) {
        var cliente = {
            CUENTA_COMERCIAL: $('.cuentc').val(),
            TIPO_DOCUMENTO: $('.tipdoc').val(),
            NRO_DOCUMENTO: $('.numdoc').val(),
            ALIAS: $('.nomraz').val(),
            DOMICILIO: $('.direxac').val(),
            TELEFONO: $('.telefo').val(),
            CELULAR: $('.celula').val(),
            EMAIL: $('.correo').val(),
            DEPARTAMENTO: $('.depa_m').val(),
            PROVINCIA: $('.prov_m').val(),
            DISTRITO: $('.dist_m').val()
        };

        $.ajax({
            type: "POST",
            url: "/Clientes/Modificar",
            data: JSON.stringify({ cliente: cliente }),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                $('#ventanaCliente').modal('hide');
                $("#msg").html('Cliente modificado!');
                $("#MENSAJE_M").css("display", "block");
                Listar();
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
    else {
        return false;
    }
    
}

function Auditoria(cuec) {
    var cuenta = cuec;
    $("#auditorias tr").remove();
    $.ajax({
        type: "POST",
        url: "/Clientes/Auditoria",
        data: JSON.stringify({ cuenta: cuenta }),
        contentType: "application/json",
        success: function (result) {
            var fem = result.FECHA_MODIFICA;
            var usu = result.USUARIO_MODIFICA;
            $("#auditorias").append('<tr><td>' + fem + '</td><td>' + usu + '</td></tr>');
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ClientesPorRazon() {
    var razon_social = $("#razon_social").val();
    $.ajax({
        type: "POST",
        url: "/Clientes/ClientesPorRazon",
        data: JSON.stringify({ razon_social: razon_social }),
        contentType: "application/json",
        success: function (result) {
            ConstruirTablaClientes(result);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}


