//FUNCIONES BÁSICAS PARA EL FORMULARIO DE REGISTRO DE CONSTANCIAS DE MANTENIMIENTO
$(document).ready(function () {
    var today = (day) + "-" + (month) + "-" + now.getFullYear();
    var today2 = (day) + "/" + (month) + "/" + now.getFullYear();

    //FUNCIONES PARA LISTADO DE CONSTANCIAS
    $('#fecha1').val(today2);
    $('#fecha2').val(today2);
    $('#fechaActual1').val(today2);
    $('#fechaActual2').val(today2);

    $('#btnSi').click(function () {
        $('#msgConfirm').modal('hide');
    });

    $('#btnRegistro').click(function () {
        if (Validar() != false) {
            $("#msgConfirm").css("display", "block");
        }
        else {
            return false;
        }
    });

    //FUNCIONES PARA FORMULARIO DE REGISTRO
    $('#fecha').val(today);

    $("#btnQuimicos").click(function (ev) {
        var pisc = $("#PISCINA").val();
        $("#modal-quimicos").load("/Piscinas/InfoQuimicos", { piscina: pisc });
    });

    $(".iptNumbers").on("keypress", function (evt) {
        var keycode = evt.charCode || evt.keyCode;
        if (keycode == 46 || keycode == 43 || keycode == 45) {
            return false;
        }
    });

    $(".iptDates").on("keypress", function (evt) {
        var keycode = evt.charCode || evt.keyCode;
        if (keycode == 46 || keycode == 43 || keycode == 45 || !(keycode >= 48 && keycode <= 57)) {
            return false;
        }
    });

    //ASIGNAR VALOR A LOS CAMPOS EN BASE A LOS CHECKBOXES SELECCIONADOS    
    $(".chkCondicion").click(function () {
        $("#PISC").is(":checked") ? $("#INDICA_PISCINA").val("SI") : $("#INDICA_PISCINA").val("NO");
        $("#SAUN").is(":checked") ? $("#INDICA_SAUNA").val("SI") : $("#INDICA_SAUNA").val("NO");
        $("#PRES").is(":checked") ? $("#INDICA_PRESION").val("SI") : $("#INDICA_PRESION").val("NO");
        $("#INCE").is(":checked") ? $("#INDICA_INCENDIO").val("SI") : $("#INDICA_INCENDIO").val("NO");
    });

    $("#SI_INDICA").is(":checked") ? $("#INDICA_CLIENTE").val("SI") : $("#INDICA_CLIENTE").val("NO");
    $("#SI_CONDICION").is(":checked") ? $("#INDICA_CONDICION").val("SI") : $("#INDICA_CONDICION").val("NO");
    $("#NO_FIRMA").is(":checked") ? $("#INDICA_FIRMA").val("NO") : $("#INDICA_FIRMA").val("SI");

    $(".rbtnCliente").click(function () {
        $("#SI_INDICA").is(":checked") ? $("#INDICA_CLIENTE").val("SI") : $("#INDICA_CLIENTE").val("NO");
    });

    $(".rbtnFirma").click(function () {
        $("#SI_FIRMA").is(":checked") ? $("#INDICA_FIRMA").val("SI") : $("#INDICA_FIRMA").val("NO");
    });

});

//MIS ICONOS
var select = "data:image/png;base64,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";
var eliminar = "data:image/png;base64,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";
var details = "data:image/png;base64,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";
var now = new Date();
var day = ("0" + now.getDate()).slice(-2);
var month = ("0" + (now.getMonth() + 1)).slice(-2);
var year = now.getFullYear();

//FUNCIONES AJAX PARA LA PÁGINA CLIENTES
function Clientes() {
    $("#ventanaClientes").css("display", "block");
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
    var cantidad_piscinas;
    $.ajax({
        type: "POST",
        url: "/Clientes/ClientePorCuenta",
        data: JSON.stringify({ cuenta_comercial: cuenta_comercial }),
        contentType: "application/json",
        success: function (result) {
            var pop = $("#iconInfo");
            $("#INDICA_PISCINA").val("SI")
            $('#ventanaClientes').modal('hide');
            $('#CUENTA_COMERCIAL').val(result.CUENTA_COMERCIAL);
            $('#RAZON').val(result.RAZON_SOCIAL);
            $('#DOMICILIO').val(result.DOMICILIO);
            $('#RAZON_C').val(result.RAZON_SOCIAL);
            $('#DOMICILIO_C').val(result.DOMICILIO);
            $('#CANTIDAD_PISCINAS').val(result.CANTIDAD_PISCINAS);
            cantidad = result.CANTIDAD_PISCINAS;
            if (cantidad == 0) {
                $("#QUIMICOS_INFO").css("display", "none");
                $("#PISCINAS_INFO").css("display", "none");
                $('#PISCINA').val("");
                $("#PISC").prop("disabled", true);
                $("#iconInfo").show();
                $('#PISC').prop('checked', false);
                $('#CANT_PISC').val("0");
                pop.attr('data-content', 'Registre una piscina para utilizar esta opción!');
            }
            else if (cantidad > 1) {
                $("#QUIMICOS_INFO").css("display", "none");
                $("#PISCINAS_INFO").css("display", "block");
                $("#PISC").prop("disabled", true);
                $('#PISCINA').val("");
                $("#iconInfo").show();
                $('#PISC').prop('checked', false);
                $('#CANT_PISC').val(cantidad);
                pop.attr('data-content', 'Seleccione una piscina para utilizar esta opción!');
            } else {
                $('#CANT_PISC').val("1");
                $("#QUIMICOS_INFO").css("display", "block");
                $("#iconInfo").hide();
                $('#PISCINA').val(result.PISCINA);
                result.VOLUMEN_PISCINA == '0.00' ? $("#QUIMICOS_INFO").css("display", "none") : $("#QUIMICOS_INFO").css("display", "block");
                $("#PISCINAS_INFO").css("display", "none");
                $('#PISC').prop('checked', true);
                $("#PISC").prop("disabled", false);
            };
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function cond_cliente(x) {
    if (x == 0) {
        $("#datos_referencia").css("display", "block");
        $("#INDICA_CLIENTE").val("SI");
    }
    else {
        $("#datos_referencia").css("display", "none");
        $("#INDICA_CLIENTE").val("NO");
    }
    return;
}

function condicion(x) {
    if (x == 0) {
        $("#condiciones").css("display", "block");
        $("#INDICA_CONDICION").val("SI");
    }
    else {
        $("#condiciones").css("display", "none");
        $("#INDICA_CONDICION").val("NO");
    }
    return;
}

function ConstanciasPorClientes() {
    var cliente = $("#nombre").val();
    $.ajax({
        type: "POST",
        url: "/Constancia/ConstanciasPorCliente",
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

function ConstruirTablas2(detTable, result, tipo, table) {
    var rowCount;
    for (var i in result) {
        if (result[i].TIPO == tipo) {
            var tip = "'" + result[i].TIPO + "'";
            var cant = result[i].CANTIDAD + '';
            var servicio = "'" + result[i].SERVICIO + "'";
            $(detTable).append('<tr><td>' + result[i].DESCRIPCION_SERVICIO + '</td><td style="text-align:center;">' + cant + '</td>' +
                                '<td style="text-align:center;"><a href="#/" onclick="ElimDetalle(' + servicio + ', ' + tip + ')"><img src=' + eliminar + ' /></a></td></tr>');
            rowCount = $(detTable + ' tr').length;
        }
    }

    if (rowCount >= 1) {
        $(table).css("display", "block");
    }
}

function ConstruirTablas(result) {
    $("#contenidoConstancias tr").remove();
    //PORCION PARA CONSTRUIR PARA EL DESARROLLADOR
   
    for (var i in result) {
        var constancia = result[i].CONSTANCIA + result[i].ESTADO;
        var cons = "'" + result[i].CONSTANCIA + "'";
        $("#contenidoConstancias").append('<tr><td>' + result[i].FECHA_REGISTRO + '</td><td>' + result[i].FECHA_MODIFICA + '</td>' +
            '<td>' + result[i].CUENTA_COMERCIAL + '</td><td>' + result[i].CONSTANCIA + '</td><td>' + result[i].USUARIO_REGISTRO + '</td>' +
            '<td style="text-align:center;"><a href="/Constancia/Detalles?constancia=' + constancia + '"><img src=' + details + ' /></a></td>' + PorcionDevelop(cons) + '</tr>');
    }
}

function PorcionDevelop(constancia) {
    var porcion = "";
    if (perfil == 4) {
        porcion = '<td style="text-align:center;"><a href="#msgConfirm" data-toggle="modal" onclick="SelecCons(' + constancia + ')"><img src=' + eliminar + ' /></a></td>';
    }
    return porcion;
}

function ConsultarConstancias() {
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
                url: "/Constancia/ConstanciasPorFechas",
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
            url: "/Constancia/ConstanciasPorMes",
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
            url: "/Constancia/ConstanciasPorMes",
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
            url: "/Constancia/ConstanciasPorSemanaActual",
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
            url: "/Constancia/ConstanciasPorSemanaPasada",
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
            url: "/Constancia/ConstanciasPorMes",
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
            url: "/Constancia/ConstanciasPorMes",
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
            url: "/Constancia/ConstanciasPorAnio",
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
            url: "/Constancia/ConstanciasPorFechas",
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

function ElimDetalle(servicio, tipo) {
    var rowCount;
    var serv = servicio;
    var detTable = "#detalles";
    var table = "#detallesTable";
    if (tipo == 'P') {
        table = table + tipo;
        detTable = detTable + tipo;
    }
    else {
        table = table + tipo;
        detTable = detTable + tipo;
    }
    $.ajax({
        type: "POST",
        url: "/Constancia/EliminarDetalle",
        data: JSON.stringify({ serv: serv }),
        contentType: "application/json",
        success: function (result) {
            $(detTable + " tr").remove();
            for (var i in result) {
                if (result[i].TIPO == tipo) {
                    var tip = "'" + result[i].TIPO + "'";
                    var cant = result[i].CANTIDAD + '';
                    var servicio = "'" + result[i].SERVICIO + "'";
                    $(detTable).append('<tr><td>' + result[i].DESCRIPCION_SERVICIO + '</td><td style="text-align:center;">' + cant + '</td>' +
                        '<td style="text-align:center;"><a href="#/" onclick="ElimDetalle(' + servicio + ', ' + tip + ')"><img src=' + eliminar + ' /></a></td></tr>');
                }
            }
            rowCount = $(detTable + ' tr').length;
            if (rowCount == 0) {
                $(table).css("display", "none");
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function GabDetalles(tipo) {
    var rowCount;
    var serv = ".ddl";
    var cant = "#cant";
    var detTable = "#detalles";
    var table = "#detallesTable";
    if (tipo == 'P') {
        serv = $(serv + "Productos").val();
        cant = $(cant + tipo).val().trim();
        table = table + tipo;
        detTable = detTable + tipo;
    }
    else {
        serv = $(serv + "Servicios").val();
        cant = $(cant + tipo).val().trim();
        table = table + tipo;
        detTable = detTable + tipo;
    }

    var servs = new Array();
    servs = serv.split("|");
    var s_cod = servs[0];
    var s_des = servs[1];
    var s_tipo = servs[2];
    if (serv == " ") {
        alert('SELECCIONE PRODUCTO');
        return false;
    }
    else if (cant == "") {
        alert('INGRESE CANTIDAD PRODUCTOS');
        return false;
    }
    else if (!cant.match(/^[0-9]+$/)) {
        alert("INGRESE SÓLO NÚMEROS");
        return false;
    }
    else if (cant.length > 2) {
        alert('INGRESE SÓLO DOS CIFRAS');
        return false;
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Constancia/GrabarDetalle",
            data: JSON.stringify({ servicio: s_cod, cantidad: cant, descripcionServicio: s_des, tipo: s_tipo }),
            contentType: "application/json",
            success: function (result) {
                $(detTable + " tr").remove();
                for (var i in result) {
                    if (result[i].TIPO == tipo) {
                        var tip = "'" + result[i].TIPO + "'";
                        var cant = result[i].CANTIDAD + '';
                        var servicio = "'" + result[i].SERVICIO + "'";
                        $(detTable).append('<tr><td>' + result[i].DESCRIPCION_SERVICIO + '</td><td style="text-align:center;">' + cant + '</td>' +
                            '<td style="text-align:center;"><a href="#/" onclick="ElimDetalle(' + servicio + ', ' + tip + ')"><img src=' + eliminar + ' /></a></td></tr>');
                        rowCount = $(detTable + ' tr').length;
                    }
                }
                if (rowCount >= 1) {
                    $(table).css("display", "block");
                }
            },
            error: function (result) {
                alert("Check the error: " + Error);
            }
        });
    }
}

function SelecCons(constancia) {
    $('#constancia').val('');
    $('#constancia').val(constancia);
    $('#tipoAccion').val('1');
    $('#contenido').text('¿Esta seguro de eliminar constancia N°'+constancia+'?');
}

function SelecCons2(constancia) {
    $('#constancia').val('');
    $('#constancia').val(constancia);
    $('#tipoAccion').val('2');
    $('#contenido').text('¿Esta seguro de eliminar constancia N°' + constancia + '?');
}

function Eliminar() {
    var constancia = $('#constancia').val();
    $.ajax({
        type: "POST",
        url: "/Constancia/Eliminar",
        data: JSON.stringify({ constancia: constancia}),
        contentType: "application/json",
        success: function (result) {
            ConstruirTablas(result);
            $('#msgConfirm').modal('hide');
            $('.message').html('Constancia ' + constancia + ' eliminada correctamente');
            $("#MENSAJE").fadeTo(4500, 500).slideUp(500, function () {
                $("#MENSAJE").slideUp(500);
            });

        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

//LIMPIAR DATASET DE DETALLES DE CONSTANCIAS
function LimpiarDsDetalles() {
    $.ajax({
        type: "POST",
        url: "/Constancia/LimpiarDSDetalles",
        contentType: "application/json",
        success: function (result) {

        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ListarDetalles() {
    var detTable;
    var table;
    var tipos = ["S", "P"];
    var rowCount;

    $.ajax({
        type: "POST",
        url: "/Constancia/ListarDSDetalles",
        contentType: "application/json",
        success: function (result) {
            for (i = 0; i < tipos.length; i++) {
                table = '#detallesTable';
                detTable = '#detalles';
                detTable = detTable + tipos[i];
                table = table + tipos[i];
                $(detTable + ' tr').remove();
                ConstruirTablas2(detTable, result,tipos[i], table);
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

//ESTE MÉTODO HACE REFERENCIA AL BOTON 'ELEGIR PISCINA'


function SeleccionarPiscina(piscina) {
    $('#ventanaPiscinas').modal('hide');
    $('#PISCINA').val(piscina);
    $("#QUIMICOS_INFO").css("display", "block");
    $("#iconInfo").hide();
    $("#PISC").prop("disabled", false);

}


//VALIDAR EL INGRESO DE LOS CAMPOS DEL FORMULARIO
function Validar() {
    var decimal_regex = /^\d+\.\d{0,1}$/;
    var checkboxs = document.getElementsByName("CHK");
    var doc = $("#REFERENCIA_DNI").val().trim();
    var tipos = ["S", "P"];
    var rows = 0;
    var okay = false;
    for (var i = 0, l = checkboxs.length; i < l; i++) {
        if (checkboxs[i].checked) {
            okay = true;
            break;
        }
    }

    if ($("#CUENTA_COMERCIAL").val() == "") {
        alert("SELECCIONE CLIENTE");
        return false;
    }
    if ($("#PISCINA").val() == "") {
        alert("SELECCIONE PISCINA");
        return false;
    }
    if (okay == false) {
        alert("SELECCIONE UN PROCESO");
        return false;
    }

    if ($("#SI_CONDICION").is(":checked")) {
        if ($("#NIVEL_PH").val().trim() == "") {
            alert("INGRESE NIVEL DE PH");
            return false;
        }
        if ($("#NIVEL_CLORO").val().trim() == "") {
            alert("INGRESE NIVEL DE CLORO");
            return false;
        }
        if (!decimal_regex.test($("#NIVEL_PH").val())) {
            alert("INGRESE FORMATO CORRECTO PARA PH. EJEMPLO 8.2");
            return false;
        }
        if (!decimal_regex.test($("#NIVEL_CLORO").val())) {
            alert("INGRESE FORMATO CORRECTO PARA CLORO. EJEMPLO 3.0");
            return false;
        }
    }
    //if (!$("#SERV").is(":checked") && !$("#PROD").is(":checked")) {
    //    alert("SELECCIONE POR LO MENOS UN SERVICIO Y/O PRODUCTO");
    //    return false;
    //}
    if ($("#cantS").val().trim() == "") {
        alert("INGRESE CANTIDAD DE SERVICIOS");
        return false;
    }
    if ($("#cantP").val().trim() == "") {
        alert("INGRESE CANTIDAD DE PRODUCTOS");
        return false;
    }
    if ($("#NO_INDICA").is(":checked")) {
        if ($("#REFERENCIA_DNI").val().trim() != "") {
            if (doc.length != 8) {
                alert("EL DNI DEBE TENER 8 CARÁCTERES");
                return false;
            }
        }
    }
    if ($("#SI_INDICA").is(":checked")) {
        $("#REFERENCIA_DNI").val('');
        $("#REFERENCIA_NOMBRE").val('');
    }
    if ($("#NO_CONDICION").is(":checked")) {
        $("#NIVEL_PH").val('');
        $("#NIVEL_CLORO").val('');
    }

    for (i = 0; i < tipos.length; i++) {
        table = '#detallesTable';
        detTable = '#detalles';
        detTable = detTable + tipos[i];
        table = table + tipos[i];
        if (!$(detTable).is(':empty')) {
            rows = rows + 1;
        }
    }

    if (rows == 0) {
        alert("AGREGE PRODUCTO(S) Y/O SERVICIO(S)");
        return false;
    }
}

function CambioTipoConsulta() {
    var tipo = $('#cboTiposConsulta').val();
    if (tipo == 'UR') {
        $('#rangos').css('display', 'inline-block');
        $('#meses').css('display', 'none');
    }
    else if (tipo == 'UM') {
        $('#rangos').css('display', 'none');
        $('#meses').css('display', 'inline-block');
    }
    else {
        $('#rangos').css('display', 'none');
        $('#meses').css('display', 'none');
    }
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




