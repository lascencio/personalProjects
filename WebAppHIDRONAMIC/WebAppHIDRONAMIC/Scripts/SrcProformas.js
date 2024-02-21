$(document).ready(function () {
    //var now = new Date();
    //var day = ("0" + now.getDate()).slice(-2);
    //var month = ("0" + (now.getMonth() + 1)).slice(-2);
    //var today = (day) + "-" + (month) + "-" + now.getFullYear();
    $('#fecha').val(today);

    $(".chkCondicion").click(function () {
        $("#caseta").is(":checked") ? $("#famCaseta").css("display", "block") : $("#famCaseta").css("display", "none");
        $("#empotrable").is(":checked") ? $("#famEmpotrable").css("display", "block") : $("#famEmpotrable").css("display", "none");
        $("#iluminacion").is(":checked") ? $("#famIluminacion").css("display", "block") : $("#famIluminacion").css("display", "none");
        $("#temperado").is(":checked") ? $("#famTemperado").css("display", "block") : $("#famTemperado").css("display", "none");
        $("#acabado").is(":checked") ? $("#famAcabado").css("display", "block") : $("#famAcabado").css("display", "none");
        $("#limpieza").is(":checked") ? $("#famLimpieza").css("display", "block") : $("#famLimpieza").css("display", "none");
        $("#mano").is(":checked") ? $("#famMano").css("display", "block") : $("#famMano").css("display", "none");

    });

    $('#btnRegistro').click(function () {
        if (Validar() != false) {
            $("#msgConfirm").css("display", "block");
        }
        else {
            return false;
        }
    });

    $(".chkDescuentos").click(function () {
        var fams = ["A", "C", "T", "L", "I", "E", "M"];
        var check;
        var lbl;
        var ipt;
        for (i = 0; i < fams.length; i++) {
            check = '#chkDesc';
            lbl = '#lblDesc';
            ipt = '#desc';
            check = check + fams[i];
            lbl = lbl + fams[i];
            ipt = ipt + fams[i];
            if ($(check).is(":checked")) {
                $(lbl).css("visibility", "visible");
            } else {
                $(lbl).css("visibility", "hidden");
                $(ipt).val('');
            }
        }
        if ($("#chkDescTot").is(":checked")) {
            $("#lblDescTot").css("visibility", "visible");
            $("#btnDescTot").css("visibility", "visible");
        }
        else {
            $("#btnDescTot").css("visibility", "hidden");
            $("#lblDescTot").css("visibility", "hidden");
            $("#descTot").val('');
            $("#DESCUENTO_GLOBAL").val(0);
            $('#rowDesc').remove();
        }
    });
    TipoCambio();
});

//VARIABLES GLOBALES
var now = new Date();
var day = ("0" + now.getDate()).slice(-2);
var year = now.getFullYear();
var month = ("0" + (now.getMonth() + 1)).slice(-2);
var today = (day) + "-" + (month) + "-" + now.getFullYear();

//MIS ICONOS
var select = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACgAAAAoCAYAAACM/rhtAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAABmJLR0QA/wD/AP+gvaeTAAAAB3RJTUUH4gURCzIT0oZV7QAACXxJREFUWMO1mGuMXVUVx39rn8c9987MnU47nU5fUgqthdIiSEWJRSUg4BuNohGNkvDFaKLRL2r0iya+HzERxRA0ihGIDyBEeSig9ZXSALa0RSlQHi2tnZnOdOY+z95r+eHcO31MW2dG3Mm6M/fknqzf+f/XWuecLcxzXbpmOW//5Bd4+Gc3Lar2VTZVsvQqgXVABkyp6laf53fWJsZ2xWnJ377lH/PKI3M94Xbg7ssuwlnoCVH2Hq9ygxPbGBH6NATBDHGCi2J1Ufyiwa98u3Xj4Nkb9+x/fAu/euSpOeWL5grYd8UmEsewRek3gw+fr9Xqq/N2s4QG0RBQVUII+DwXn7f7Ve11uPiyqZGXnupZcc4za6uw68VD/x8Fr7/8QjDrDRJ/H9MPN5o5tVbAOSGNBewUJzoHLnrKgr7PhMf708BPHtoxq5xutnA3XH4B9baRK9eIhvdHFhCBgspQNdROESEQfL4mqN6QNEZlvGGzTTt7QAP6UhLM3h2JpQCRE9avHubqS9bRUy7h1VDjpGFqqOqmRtxftdnzEc8FMKj1xY5VAL2VEpvXn8nFF5xJtS9j+ZIBfvfn3RwYPUIIOu22CMh0JdkCoKImEy87oADOiWFoVkq46o0X8KoNq4hiBwYXX7SGM1YO8c9nDjA2XqPWaHFw9AjP7h+l0coRETByICCzl3DWgB3IWjDdv3LZ4IUbz19LkiZYxy8RWL6ywvKVw0U9BqXRaPOPnXv55f2PMHakjiAHRZji/2FxZ7VNbdvioUVvy3r6MGzGGBAgQoiApAc2bx7g4HiNO+9/BIQdQa0euVmX/uyb5ObfPwZAnucPlsrlCZdkuKQ8IyQpI0lWRJwRZxXWrVtNkiTtYPZHEH67befLD9hd27c/+Whayv6iLsElGS4+fUiSUe7tI07iXe22/+sc3J0f4NZH760tWTr8Y6JSUzoApwsXl2l6UOOOizdtOGBzmTFzBbz594/RaHnWn7/xwTTrebyw+fRBXCJOsj+Njk3cun3n0zzw2O45Ac61SUhKFSTOxkzze0BeO4tT/Lpz1v1wy64tL1xwxqa5ppv70wxA7blHADYgci+w7L/8/F+YXgXybM88AOdcgwASpSCyU+LSLS4ph9NYPClx+tVkwYpnJUrmk2p+CgI0DuwGC/0W/C9c2nM1zh19mhFAQzD1X5Q4+7qFti8vWTevPHOuwe5qvrQdC74lSZm4d5CkugyXlAHQvE4+sS/3jcPbRJxfsOFd800zf8BiIMsaTF8V6oexvElU7gcgNMbRvJmJiy9Ew/1373kv+2SnG8jOWh67SlXNh3YYf7EU901t238nX3v1qfPMqwbre+6nf/3bcXH6PolLSyUuYRbw9TF8fQwzReISEqUfdKWeNQvj1fSXXvF6r7V7a/m+h5r+0J9Eoq+1/GS2fvEbXl4Fb9xtVMrwtx1PXPHKNLk+jU/9IC1wXlvlu+3Dn/n0VP8Vl+Rh7Fy1HBCSqPfNpWjhIkP3nS7frBW8/MY/AhDZ1KqbpvjS9njdT7b6s5eNhB5UElx0fJgkjIUK2/Iz37KntOieVvvqa4PmmDnMhLavucnWCzLV2v+/KfjKL93DhpUD1Jr5gnfcvOUDf9v59Mc3nrXqnN6eqjwjK9kfBhny4yySSSouR4CGxYxqLwdlgEZUIXKcJTpE6OpaLOu+LswbcPN37mOi3ora3m/urySfDSZvGpmoJX/ftYfVSxezfGgxeZrxvC3leVuKdO6zJoLE4MTwrTrPHTqMuRGWDhfqAZi5aKq+OEmTFnBql086B1/x2dvYsGqIWrM9ONBb/kQcRR9rBxvMA0RRhHNF9FUyhhdWGeyvUskynIswAx9y6s0Gh8Yn+ff4EabqOSuG7+DMlT/HzAFGq7043/Xkp27b9+/lXz5v1cZ/PbVwjPsuXfvfAdd+8Q42rz+DvQcPn1etlL5uyJWNXB3iiKKIyMXHQTrnSOOYrJSQxjHVnh0srO7Eh0BQLYw0SNIduGRrJ6WBLSA0rySOWruGFr64VcQUkFaYfHai8dwPRKKRz5y3+3iLL/nGXfSWM55+aeSiaiW7uZWH85teiVxEdJJXfBEQEdSMZlvxOs6K4dtJSo/j1B+ngVrAq5s+JkyRVO5CcOcempJzu8fTuCfE0vtcHGU/nVGDZsb4VH24XEq+VW/l5+fBiDpkdsyHTf8t5LFOQJtmfoBAjZkDQmYc8yGfcdGtvBWJRANOGsc3yWu+8muiKMLMfyT3YXPQot66vYYZxlGYbqgpmIAGQoDcn6h2tylkRkWJ6AzA4uK1TqfnpwENpdVuDTlx15qZdBU6GZSZoioIxfuvAoiR52VGDr+Vam8P3QTFhUESj5ImI1jnLVk1ptZYhmo07R6E0FMZuSsrTd7XPX7UYgPD1hp2duGcnSIUM8FM0A6dACZF6vGJNzBx5LWYBdQMUyUoDA7cw9DgnWAOxGi2FvDkng/RbFZR9QQNqGpdpPXtEErPX3rJl09QsFBrpWGVmap1oFTR4vqPWifgurpI184YLEJNMVNCAB9ivHedOjS8j/AhwYcEVUcIAdXQVounBPjGpTtPCpgYJkdVKhQwkaO1ZsXoKHw1RAwz12Gb3uKgcKEAVKMDGWEmiBghOEyPEaDQ+2GwvcfeW46pQQPjDyZ2u5ldo2YlMUVNQBVBsONqrjjHiRXFLjK9B2Mc7W7t1GsI4L3DcAiGD66z+6WY2QsYP8K4yYmb8OZnAu4+IpzbL/tytRtS4W4zu17VLgbtAwHRDllHJzEEN117Isd36HSDdXa8fDDyYwDzIGYWnjflN2rcMtq2JypxZDs+9+4Zw4lbb7212ydJKixInfXtbUQrnm7Gbxz10RWTGq9vWFT1EkWIw4krtnmlAOvGCQ13dBSpUC4/wdCiXxK7pgGShaE9iybe9b2z4sqjWRTG2ypTBoeBye7Eve66644f1AJLc+OdeZBXL051yZK03W/Q21RpTASXjIU4PRzieFIjV9eYNg7feXwyOXbOGc6MCCORQCUO9IcVtmzqmtCbHPGCs96wuJQl2UcNvbalMgrsBR4AHgTqMyzurElgO1ADligMAJXMWbXsQjychpJZq8+bRG0TmuZomUjLHN5EultJgpGKWUnUyk7JREnEzLGkhR+eBIKhLcOOdHKOAQc6kP4E0YrVtbkzB2IgAdLO/yWKDfcUKEuxVWjF0CiwTihBzEARFAgm0rkh5UCjM8U90Oocyzvf/bH2AvwHQoJYNsu1ss0AAAAldEVYdGRhdGU6Y3JlYXRlADIwMTgtMDUtMTdUMTE6NTA6MTktMDQ6MDC2KGL1AAAAJXRFWHRkYXRlOm1vZGlmeQAyMDE4LTA1LTE3VDExOjUwOjE5LTA0OjAwx3XaSQAAAABJRU5ErkJggg==";
var eliminar = "data:image/png;base64,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";
var details = "data:image/png;base64,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";
var info = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA8AAAAPCAMAAAAMCGV4AAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAB41BMVEX6//9l/2lw/3Zw/3Zw/3Ze6WBUtlT///9EREBEQkAAAABRpU9Sq1BSrFFSrVFSrVFSrFFSq1BRpE8AAABEQkBEREBEQUA6CzRRp1BSrFFSrFFSrFFSrFFSrFFSrFFSrFFSrFFSrFFRp1A5CTNEQUBRqFBSrFFSrFFRqFBOkUxRqFBSrFFSrFFRqFAAAABRpU9SrFFSrFFRp1BRplBSrFFSrFFQpE9Sq1FSrFFSrFFRpVBRpVBSrFFSrFFSq1FSrFFRpVBRpVBSrFFSrFFSrVFSrFFRplBRpVBSrFFSrVFSrVFSrFFRp1BRp1BSrFFSrVFSrVFSrFFSrFFSq1FSrFFSrFFSrVFSrFFSrFFSrFFRqlBSrFFSrFFSrFFSq1FSrFFSrFFQoE5QoE5SrFFSrFFSq1FRpE9SrFFSrFFJe0Y4ADJJfEZSrFFSrFFQpE9RqFBSrFFSrFFRqVBPm05RqVBSrFFSrFFRqFBEQT85CjNRp1BSrFFSrFFSrFFSrFFSrFFSrFFSrFFRqFA5CTNEQUBEREBEQkAxAClQo09Sq1BSrFFSrVFSrVFSrVFSrFFSq1FQo08mABtEQT9EREBSrVFSrFFSrFFSrFFSrFFSrFFSrFFSrFFSrFFSrFFSrFFSrFH///8PyuDAAAAAlHRSTlMAAAAAAAAAAAIDABhxx/T0x3EYAAMCAwI4vvv/4c3h//q+OQIDONjxRw5I8dk5ABi97C8v7L0YcfrsMDDs+nHGMDDsxvHsMDDs8f3uMjPu/fH8tY61/PHG+7Bxr/vGcfrDFRXD+nAYvakEAgSpvRg52eVQFVHm2ToDAjm++u/V8Pq+OgIDAgMBGHHH8//zx3AYAQMC7dp+ZwAAAAFiS0dEBxZhiOsAAAAHdElNRQfiBAYQAxEaCDl0AAAA8ElEQVQI12Pg4OTi5uHlm8IvICgkLCLKICYuISklLSMrJ6+gqKSswsCgqjZ1mrqGppb2tKk6unoM+gbTZ8wwNGI0Npk5Y6qpGYO5xYwZ0yytmKxtps2YYWvHYD8TxHdgdnQC8mc6M7jMAlKubizuHkD+bE8GrzlAeW8fVl8/IH+uP0MAUH5GYFBwSCiQnh3GEA7UPyMiMio6BkjPjGWIi58xY15CIltS8rwZM1JSGdLSp8+Yn5GZlZ0zf8bU3DwG9vyCqfMLi4pLSudPLSvXY6iorKqumV9bVz+/obGpuYWhta29o7Oru6e3r3/CxEmTAQL2V5PTJ+XfAAAAJXRFWHRkYXRlOmNyZWF0ZQAyMDE4LTA0LTA2VDE2OjAzOjE3LTA0OjAw/yjSOwAAACV0RVh0ZGF0ZTptb2RpZnkAMjAxOC0wNC0wNlQxNjowMzoxNy0wNDowMI51aocAAAAASUVORK5CYII=";

function AplicarDescuento(accion) {
    var des = $("#descTot").val();
    var arreglo = new Array();
    var tot = $("#total").text();
    arreglo = tot.split(' ');

    if (accion == 'apli') {
        if (arreglo[1] == '0.00') {
            alert('NO HAY PRODUCTOS INGRESADOS');
        }
        else if (des.trim() == '') {
            alert('INGRESE DESCUENTO');
        }
        else {
            ConstruirTabDesc(arreglo);
        }
    }
    else {
        ConstruirTabDesc(arreglo);
    }
}

function CambioMoneda() {
    var tipo = $('#TIPO_MONEDA').val();
    var table;
    var detTable;
    var fams = ["A", "C", "T", "L", "I", "E"];
    var rows = $('#detallesTot tr').length;

    $.ajax({
        type: "POST",
        url: "/Proformas/ListarDSDetalle",
        contentType: "application/json",
        success: function (result) {
            for (i = 0; i < fams.length; i++) {
                table = '#detallesTable';
                detTable = '#detalles';
                detTable = detTable + fams[i];
                table = table + fams[i];
                if ($(detTable + ' tr').length != 0) {
                    ConstruirTablas(table, detTable, result, fams[i], tipo);
                    if (rows == 2) {
                        AplicarDescuento('calc');
                    }
                }
            }

        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function CambioMoneda2() {
    var tipo = $('#TIPO_MONEDA').val();
    var table;
    var detTable;
    var fams = ["A", "C", "T", "L", "I", "E"];
    var rows = $('#detallesTot tr').length;

    $.ajax({
        type: "POST",
        url: "/Proformas/ListarDSDetalleCons",
        contentType: "application/json",
        success: function (result) {
            for (i = 0; i < fams.length; i++) {
                table = '#detallesTable';
                detTable = '#detalles';
                detTable = detTable + fams[i];
                table = table + fams[i];
                if ($(detTable + ' tr').length != 0) {
                    ConstruirTablas(table, detTable, result, fams[i], tipo);
                    if (rows == 2) {
                        AplicarDescuento('calc');
                    }
                }
            }

        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function CleanIptPisc() {
    //$("#TIPO_PISCINA").val('');
    //$("#FORMA_PISCINA").val('');
    $("#LARGO").val('');
    $("#ANCHO").val('');
    $("#PROFUNDIDAD").val('');
    $("#PISCINA").val('');
}

function Clientes() {
    $('#razon_social').val('');
    $.ajax({
        type: "POST",
        url: "/Clientes/Clientes",
        contentType: "application/json",
        success: function (result) {
            $("#contenidoClientes tr").remove();
            for (var i in result) {
                var cc = result[i].CUENTA_COMERCIAL;
                var cuec = "'" + cc + "'";
                var rs = result[i].RAZON_SOCIAL;
                $("#contenidoClientes").append('<tr><td align="center"><a href="#" id="cuen" onclick="ClientePorCuenta(' + cuec + ')"><img src=' + select + ' /></a></td>' +
                    '<td>' + rs + '</td></tr>');
            }
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
            $("#contenidoClientes tr").remove();
            for (var i in result) {
                var cc = result[i].CUENTA_COMERCIAL;
                var cuec = "'" + cc + "'";
                var rs = result[i].RAZON_SOCIAL;
                $("#contenidoClientes").append('<tr><td align="center"><a href="#" id="cuen" onclick="ClientePorCuenta(' + cuec + ')"><img src=' + select + ' /></a></td>' +
                    '<td>' + rs + '</td></tr>');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ClientePorCuenta(cuenta) {
    var cuenta_comercial = cuenta;
    $.ajax({
        type: "POST",
        url: "/Clientes/ClientePorCuenta",
        data: JSON.stringify({ cuenta_comercial: cuenta_comercial }),
        contentType: "application/json",
        success: function (result) {
            //IptClieConfig(true);
            $('#ventanaClientes').modal('hide');
            $('#CUENTA_COMERCIAL').val(result.CUENTA_COMERCIAL);
            $('#RAZON_SOCIAL').val(result.ALIAS);
            $('#DOMICILIO').val(result.DOMICILIO);
            $('#TELEFONO').val(result.TELEFONO);
            $('#CELULAR').val(result.CELULAR);
            $('#EMAIL').val(result.EMAIL);
            cantidad = result.CANTIDAD_PISCINAS;
            if (cantidad == 0) {
                //IptPiscConfig(false);
                CleanIptPisc();
                $("#PISCINAS_INFO").css("display", "none");
            }
            else if (cantidad > 1) {
                //IptPiscConfig(false);
                CleanIptPisc();
                $("#PISCINAS_INFO").css("display", "block");

            } else {
                $("#PISCINAS_INFO").css("display", "none");
                if (result.VOLUMEN_PISCINA != '0.00') {
                    //$("#TIPO_PISCINA").val(result.TIPO_PISCINA);
                    //$("#FORMA_PISCINA").val(result.FORMA_PISCINA);
                    $("#LARGO").val(result.LARGO_PISCINA);
                    $("#ANCHO").val(result.ANCHO_PISCINA);
                    $("#PROFUNDIDAD").val(result.PROFUNDIDAD_PISCINA);
                    $("#PISCINA").val(result.PISCINA);
                }
                else {
                    CleanIptPisc();
                }
                //IptPiscConfig(true);
            };
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ConstruirTablas(table, detTable, result, familia, tipo) {
    $(detTable + ' tr').remove();
    $('#detallesTot tr').remove();
    var rowCount;
    var tot = 0.0;
    var igv;
    var sub;
    var iptTot;
    var simb;
    tipo == '1' ? simb = 'S/ ' : simb = '$ ';
    for (var i in result) {
        var unitDesc;
        var totDesc;
        var iptUnit;

        if (tipo == '1') {
            iptUnit = result[i].PRECIO_UNITARIO_MN;
            iptTot = result[i].IMPORTE_TOTAL_MN;
        } else {
            iptUnit = parseFloat(result[i].PRECIO_UNITARIO_ME).toFixed(2);
            iptTot = result[i].IMPORTE_TOTAL_ME;
        }

        if (result[i].DESCUENTO_PORCENTUAL != '0') {
            unitDesc = parseFloat(iptUnit - (iptUnit * (result[i].DESCUENTO_PORCENTUAL / 100))).toFixed(2);
            totDesc = result[i].CANTIDAD * unitDesc;
        }
        else {
            unitDesc = iptUnit;
            totDesc = iptTot;
        }


        if (result[i].FAMILIA == familia) {
            var servicio = "'" + result[i].PRODUCTO + "'";
            var fam = "'" + result[i].FAMILIA + "'";

            var params = "'" + iptUnit + "|" + parseFloat(iptTot).toFixed(2) + "|" + result[i].DESCUENTO_PORCENTUAL + "|" + totDesc + "|" + simb + "'";

            if (result[i].DESCUENTO_PORCENTUAL != '0') {
                $(detTable).append('<tr><td>' + result[i].DESCRIPCION + '</td><td><a href="#/" onclick="Informacion(' + params + ')"><img src=' + info + ' /></a></td>' +
               '<td style="text-align:center;">' + result[i].CANTIDAD + '</td><td style="text-align:right;">' + parseFloat(unitDesc).toFixed(2) + '</td><td style="text-align:right;">' + parseFloat(totDesc).toFixed(2) + '</td>' +
               '<td style="text-align:center;"><a href="#/" onclick="ElimDetalle(' + servicio + ',' + fam + ')"><img src=' + eliminar + ' /></a></td></tr>');
            }
            else {
                $(detTable).append('<tr><td>' + result[i].DESCRIPCION + '</td><td></td><td style="text-align:center;">' + result[i].CANTIDAD + '</td><td style="text-align:right;">' + parseFloat(iptUnit).toFixed(2) + '</td>' +
               '<td style="text-align:right;">' + parseFloat(iptTot).toFixed(2) + '</td><td style="text-align:center;"><a href="#/" onclick="ElimDetalle(' + servicio + ',' + fam + ')">' +
               '<img src=' + eliminar + ' /></a></td></tr>');
            }
            rowCount = $(detTable + ' tr').length;
        }
        tot = tot + totDesc;
    }
    igv = tot * 0.18;
    sub = tot - (tot * 0.18);
    var IGV = parseFloat(igv).toFixed(2);
    var SUBTOT = parseFloat(sub).toFixed(2);
    var TOT = parseFloat(tot).toFixed(2);
    $("#detallesTot").append('<tr><td style="text-align:right;"><strong>Precio final:</strong></td><td id="sTotal" style="text-align:right;">' + simb + SUBTOT + '</td><td id="igv" style="text-align:right;">' + simb + IGV + '</td><td id="total" style="text-align:right;">' + simb + TOT + '</td></tr>');
    if (rowCount >= 1) {
        $(table).css("display", "block");
    }
    else {
        $(table).css("display", "none");
    };
}

function ConstruirTabDesc(arreglo) {
    var des = $("#descTot").val();
    var tipo = $('#TIPO_MONEDA').val();
    $("#DESCUENTO_GLOBAL").val(des);
    var TOT = arreglo[1] - (arreglo[1] * (des / 100));
    var IGV = TOT * 0.18;
    var SUBTOT = TOT - IGV;
    var simb;

    tipo == '1' ? simb = 'S/ ' : simb = '$ ';

    var a = simb + parseFloat(TOT).toFixed(2);
    var b = simb + parseFloat(IGV).toFixed(2);
    var c = simb + parseFloat(SUBTOT).toFixed(2);

    $('#rowDesc').remove();
    $("#detallesTot").append('<tr id="rowDesc"><td style="text-align:right;"><strong>Precio final con descuento:</strong></td><td id="sTotal" style="text-align:right;">' +
        c + '</td><td id="igv" style="text-align:right;">' + b + '</td><td id="total" style="text-align:right;">' + a + '</td></tr>');
}

function ElimDetalle(servicio, familia) {
    var tipo = $('#TIPO_MONEDA').val();
    var tot = 0.0;
    var igv;
    var sub;

    var table = '#detallesTable';
    var detTable = '#detalles';
    switch (familia) {
        case "C":
            table = table + 'C';
            detTable = detTable + 'C';
            break;
        case "E":
            table = table + 'E';
            detTable = detTable + 'E';
            break;
        case "I":
            table = table + 'I';
            detTable = detTable + 'I';
            break;
        case "T":
            table = table + 'T';
            detTable = detTable + 'T';
            break;
        case "A":
            table = table + 'A';
            detTable = detTable + 'A';
            break;
        default:
            table = table + 'L';
            detTable = detTable + 'L';
            break;
    }
    var serv = servicio;
    $.ajax({
        type: "POST",
        url: "/Proformas/EliminarDetalle",
        data: JSON.stringify({ producto: serv }),
        contentType: "application/json",
        success: function (result) {
            ConstruirTablas(table, detTable, result, familia, tipo);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function GabDetalles(familia) {
    var tipo = $('#TIPO_MONEDA').val();
    var cant;
    var cbo;
    var table = '#detallesTable';
    var detTable = '#detalles';
    var desc = '#desc';
    var chk = '#chkDesc';
    switch (familia) {
        case "C":
            cant = '#cantC';
            cbo = '#prdCas';
            table = table + 'C';
            detTable = detTable + 'C';
            desc = desc + 'C';
            chk = chk + 'C';
            break;
        case "E":
            cant = '#cantE';
            cbo = '#prdEmp';
            table = table + 'E';
            detTable = detTable + 'E';
            desc = desc + 'E';
            chk = chk + 'E';
            break;
        case "I":
            cant = '#cantI';
            cbo = '#prdIlum';
            table = table + 'I';
            detTable = detTable + 'I';
            desc = desc + 'I';
            chk = chk + 'I';
            break;
        case "T":
            cant = '#cantT';
            cbo = '#prdTemp';
            table = table + 'T';
            detTable = detTable + 'T';
            desc = desc + 'T';
            chk = chk + 'T';
            break;
        case "A":
            cant = '#cantA';
            cbo = '#prdAcab';
            table = table + 'A';
            detTable = detTable + 'A';
            desc = desc + 'A';
            chk = chk + 'A';
            break;
        default:
            cant = '#cantL';
            cbo = '#prdLimp';
            table = table + 'L';
            detTable = detTable + 'L';
            desc = desc + 'L';
            chk = chk + 'L';
            break;
    }

    var serv = $(cbo).val();
    var servs = new Array();
    servs = serv.split("|");
    var s_cod = servs[0];
    var s_des = servs[1] + " - " + servs[3];
    var p_ser = servs[2];
    var cantP = $(cant).val().trim();
    var indica = 'NO';
    var descuento = null;
    if ($("#cambio").val().trim() == '') {
        alert('INGRESE TIPO DE CAMBIO PARA HOY');
        return false;
    }
    else if (cantP == "") {
        alert('INGRESE CANTIDAD PRODUCTOS');
        return false;
    }
    else if ($(chk).is(":checked") && $(desc).val().trim() == "") {
        alert("INGRESE DESCUENTO");
        return false;
    }
    else {
        $(chk).is(":checked") ? descuento = $(desc).val() : descuento = '0';
        //descuento = $(desc).val();
        $.ajax({
            type: "POST",
            url: "/Proformas/GrabarDetalle",
            data: JSON.stringify({ producto: s_cod, descripcion: s_des, cantidad: cantP, precio: p_ser, familia: familia, descuento: descuento }),
            contentType: "application/json",
            success: function (result) {
                $('#chkDescTot').prop('checked', false);
                $("#btnDescTot").css("visibility", "hidden");
                $("#lblDescTot").css("visibility", "hidden");
                $("#descTot").val('');
                $("#DESCUENTO_GLOBAL").val(0);
                $('#rowDesc').remove();
                ConstruirTablas(table, detTable, result, familia, tipo);
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
}

//params: 0-> Precio Unit, 1-> Precio Tot, 2-> Descuento, 3-> Total descuento, 4-> Símbolo
function Informacion(params) {
    var par = new Array();
    par = params.split("|");
    //PRECIOS DE LOS PRODUCTOS SIN DESCUENTOS

    var desc = par[1] * (par[2] / 100);
    alert(" Precio Unit.: " + par[4] + parseFloat(par[0]).toFixed(2) + " \n Precio Total: " + par[4] + par[1] + "\n Descuento: " +
        par[4] + parseFloat(desc).toFixed(2) + " (" + par[2] + "%) \n Precio Total con Descuento: " + par[4] + parseFloat(par[3]).toFixed(2));
}

function IptClieConfig(tipe) {
    $("#RAZON_SOCIAL").prop('disabled', tipe);
    $("#DOMICILIO").prop('disabled', tipe);
    $("#CELULAR").prop('disabled', tipe);
    $("#TELEFONO").prop('disabled', tipe);
    $("#EMAIL").prop('disabled', tipe);
}

function IptPiscConfig(tipe) {
    $("#TIPO_PISCINA").prop('disabled', tipe);
    $("#FORMA_PISCINA").prop('disabled', tipe);
    $("#LARGO").prop('disabled', tipe);
    $("#ANCHO").prop('disabled', tipe);
    $("#PROFUNDIDAD").prop('disabled', tipe);
}

function LimpiarDsDetalles() {
    $.ajax({
        type: "POST",
        url: "/Proformas/LimpiarDSDetalles",
        contentType: "application/json",
        success: function (result) {

        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ListarDsDetalles() {
    var tipo = $('#TIPO_MONEDA').val();
    var table;
    var detTable;
    var fams = ["A", "C", "T", "L", "I", "E"];

    $.ajax({
        type: "POST",
        url: "/Proformas/ListarDSDetalle",
        contentType: "application/json",
        success: function (result) {
            for (i = 0; i < fams.length; i++) {
                table = '#detallesTable';
                detTable = '#detalles';
                detTable = detTable + fams[i];
                table = table + fams[i];
                ConstruirTablas(table, detTable, result, fams[i], tipo);
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function NuevoCliente() {
    IptClieConfig(false);
    IptPiscConfig(false);
    $("#CELULAR").val('');
    $("#RAZON_SOCIAL").val('');
    $("#DOMICILIO").val('');
    $("#TELEFONO").val('');
    $("#EMAIL").val('');
    $("#TIPO_PISCINA").val('');
    $("#FORMA_PISCINA").val('');
    $("#LARGO").val('');
    $("#ANCHO").val('');
    $("#PROFUNDIDAD").val('');
    $('#INDICA_CLIENTE_NUEVO').val('SI');
    $("#PISCINAS_INFO").css("display", "none");
    $('#CUENTA_COMERCIAL').val('');
    $("#PISCINA").val('');
}

function NuevaPiscina() {
    IptPiscConfig(false);
    $("#PISCINAS_INFO").css("display", "none");
    $("#TIPO_PISCINA").val('');
    $("#FORMA_PISCINA").val('');
    $("#LARGO").val('');
    $("#ANCHO").val('');
    $("#PROFUNDIDAD").val('');
    $("#PISCINA").val('');
}

function Piscinas() {
    var cuenta_comercial = $("#CUENTA_COMERCIAL").val();
    $.ajax({
        type: "POST",
        url: "/Clientes/SeleccionPiscina",
        data: JSON.stringify({ cuenta_comercial: cuenta_comercial }),
        contentType: "application/json",
        success: function (result) {
            $("#ventanaPiscinas").css("display", "block");
            $("#contenidoPiscina tr").remove();
            for (var i in result) {
                var value = result[i].PISCINA;
                var pisc = "'" + value + "'";
                var tipo = result[i].TIPO_PISCINA;
                var dir = result[i].UBICACION;
                $("#contenidoPiscina").append('<tr><td><a href="#" onclick="SeleccionarPiscina(' + pisc + ')"><strong><u>' + tipo + '</u></strong></a></td>' +
                    '<td>' + dir + '</td></tr>');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function Productos(familia) {
    var fam;
    var cbo;
    switch (familia) {
        case "C":
            fam = '#CAS';
            cbo = '#prdCas';
            break;
        case "E":
            fam = '#EMP';
            cbo = '#prdEmp';
            break;
        case "I":
            fam = '#ILUM';
            cbo = '#prdIlum';
            break;
        case "T":
            fam = '#TEMP';
            cbo = '#prdTemp';
            break;
        case "A":
            fam = '#ACAB';
            cbo = '#prdAcab';
            break;
        default:
            fam = '#LIMP';
            cbo = '#prdLimp';
    }
    var fami = $(fam).val();
    $.ajax({
        type: "POST",
        url: "/Proformas/Productos",
        data: JSON.stringify({ familia: fami }),
        contentType: "application/json",
        success: function (result) {
            $(cbo).empty();
            for (var i in result) {
                $(cbo).append($("<option></option>").attr("value", result[i].ID).text(result[i].DESCRIPCION));
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function SeleccionarPiscina(piscina) {
    var pisc = piscina;
    $.ajax({
        type: "POST",
        url: "/Piscinas/Consultar",
        data: JSON.stringify({ piscina: pisc }),
        contentType: "application/json",
        success: function (result) {
            $('#ventanaPiscinas').modal('hide');
            //$("#TIPO_PISCINA").val(result.TIPO_PISCINA);
            $("#FORMA_PISCINA").val(result.FORMA_PISCINA);
            $("#LARGO").val(result.s_LARGO);
            $("#ANCHO").val(result.s_ANCHO);
            $("#PROFUNDIDAD").val(result.s_PROFUNDIDAD);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function Validar() {
    var decimal_regex = /^\d+\.\d{0,2}$/;
    var email_regex = /\S+@\S+\.\S+/;
    var fams = ["A", "C", "T", "L", "I", "E"];
    var table;
    var detTable;
    var rows = 0;
    var descuento = $("#DESCUENTO_GLOBAL").val();
    if ($("#RAZON_SOCIAL").val().trim() == "") {
        alert("SELECCIONE O INGRESE CLIENTE");
        return false;
    }

    if ($("#DOMICILIO").val().trim() == "") {
        alert("INGRESE DOMICILIO");
        return false;
    }

    if ($("#REFERENCIA").val().trim() == "") {
        alert("INGRESE REFERENCIA");
        return false;
    }

    if ($("#EMAIL").val().trim() == "") {
        alert("INGRESE CORREO ELECTRÓNICO");
        return false;
    }

    if ($("#EMAIL").val().trim() != "") {
        if (!email_regex.test($("#EMAIL").val())) {
            alert("FORMATO DE CORREO INCORRECTO. (Ejm. correo@dominio.com)");
            return false;
        }
    }

    if ($("#TIPO_PISCINA").val().trim() == "") {
        alert("INGRESE TIPO DE PISCINA");
        return false;
    }

    if ($("#FORMA_PISCINA").val().trim() == "") {
        alert("INGRESE FORMA DE PISCINA");
        return false;
    }


    if ($("#TIEMPO_FILTRADO").val().trim() == "" || $("#TIEMPO_FILTRADO").val().trim() == '0.00') {
        alert("INGRESE TIEMPO DE FILTRADO");
        return false;
    }

    //if ($("#TIEMPO_FILTRADO").val().trim() != "") {
    //    if (!decimal_regex.test($("#TIEMPO_FILTRADO").val())) {
    //        alert("Ingrese formato correcto para tiempo de filtrado. Ejm 1.30");
    //        return false;
    //    }
    //}

    if ($("#LARGO").val().trim() == "" || $("#LARGO").val().trim() == '0.00') {
        alert("INGRESE LARGO DE PISCINA");
        return false;
    }

    //if ($("#LARGO").val().trim() != "") {
    //    if (!decimal_regex.test($("#LARGO").val())) {
    //        alert("Ingrese formato correcto para largo. Ejm 1.30");
    //        return false;
    //    }
    //}

    if ($("#ANCHO").val().trim() == "" || $("#ANCHO").val().trim() == '0.00') {
        alert("INGRESE ANCHO DE PISCINA");
        return false;
    }

    //if ($("#ANCHO").val().trim() != "") {
    //    if (!decimal_regex.test($("#ANCHO").val())) {
    //        alert("Ingrese formato correcto para ancho. Ejm 1.30");
    //        return false;
    //    }
    //}

    if ($("#PROFUNDIDAD").val().trim() == "" || $("#PROFUNDIDAD").val().trim() == '0.00') {
        alert("INGRESE PROFUNDIDAD DE PISCINA");
        return false;
    }

    //if ($("#PROFUNDIDAD").val().trim() != "") {
    //    if (!decimal_regex.test($("#PROFUNDIDAD").val())) {
    //        alert("Ingrese formato correcto para profundidad. Ejm 1.30");
    //        return false;
    //    }
    //}

    //if ($('#detalles').is(':empty')) {
    //    alert("Agrege por lo menos un producto");
    //    return false;
    //}

    for (i = 0; i < fams.length; i++) {
        table = '#detallesTable';
        detTable = '#detalles';
        detTable = detTable + fams[i];
        table = table + fams[i];
        if (!$(detTable).is(':empty')) {
            rows = rows + 1;
        }
    }

    if (rows == 0) {
        alert("AGREGE PRODUCTOS A LA PROFORMA");
        return false;
    }

    if ($("#chkDescTot").is(":checked") && $("#DESCUENTO_GLOBAL").val() == 0) {
        alert("APLIQUE EL DESCUENTO TOTAL INGRESADO");
        return false;
    }

}

function TipoCambio() {
    var cambio = {
        TIPO_OPERACION: 'LIST',
        EJERCICIO: year,
        MES: month
    };

    $.ajax({
        type: "POST",
        url: "/Proformas/ListaTiposCambio",
        data: JSON.stringify({ tipo: cambio }),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            for (var i in result) {
                var fecha = result[i].DIA + "-" + result[i].MES + "-" + result[i].EJERCICIO;
                if (today == fecha) {
                    $("#cambio").val(result[i].VENTA);
                }
            }
        },
        error: function (result) {
            alert('Check the error: ' + result);
        }
    });
}

