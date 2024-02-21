//FUNCIONES BÁSICAS PARA LA PÁGINA REGISTRAR
$(document).ready(function () {
    var now = new Date();
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = (day) + "-" + (month) + "-" + now.getFullYear();

    $('#fecha').val(today);

    $("#btnBuscarCliente").click(function (ev) {
        $("#modal-clientes").load("/Constancia/Clientes");
    });

    $("#btnQuimicos").click(function (ev) {
        $("#modal-quimicos").load("/Constancia/InfoPiscina", { cuen: $("#CUENTA_COMERCIAL").val() });
    });

    $(".iptNumbers").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            // Allow: Ctrl+A, Command+A
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });

    $(".chkCondicion").click(function () {
        $("#PISC").is(":checked") ? $("#INDICA_PISC").val("SI") : $("#INDICA_PISC").val("NO");
        $("#SAUN").is(":checked") ? $("#INDICA_SAUN").val("SI") : $("#INDICA_SAUN").val("NO");
        $("#PRES").is(":checked") ? $("#INDICA_PRES").val("SI") : $("#INDICA_PRES").val("NO");
        $("#INCE").is(":checked") ? $("#INDICA_INCE").val("SI") : $("#INDICA_INCE").val("NO");
    });

    $("#SI_INDICA").is(":checked") ? $("#INDICA_CLIENTE").val("SI") : $("#INDICA_CLIENTE").val("NO");
    $("#SI_CONDICION").is(":checked") ? $("#INDICA_CONDICION").val("SI") : $("#INDICA_CONDICION").val("NO");

    $(".rbtnCliente").click(function () {
        $("#SI_INDICA").is(":checked") ? $("#INDICA_CLIENTE").val("SI") : $("#INDICA_CLIENTE").val("NO");
    });

});

//var mensaje = '@ViewBag.mensaje';
//mensaje != "" || mensaje != "@ViewBag.mensaje" ? alert(mensaje):jQuery.noop();

function validar() {
    if ($("#CUENTA_COMERCIAL").val() == "") {
        alert("SELECCIONE CLIENTE");
        return false;
    }
    if ($(".ddlServicios").val() == " " && $(".ddlProductos").val() == " ") {
        alert("INGRESE POR LO MENOS UN SERVICIO");
        return false;
    }
    if ($(".ddlServicios").val() != " ") {
        if ($("#cantS").val() == "") {
            alert("INGRESE CANTIDAD DE SERVICIOS");
            return false;
        } 
    }
    if ($(".ddlProductos").val() != " ") {
        if ($("#cantP").val() == "") {
            alert("INGRESE CANTIDAD DE PRODUCTOS");
            return false;
        }
    }
    if ($("#SI_CONDICION").is(":checked")) {
        if ($("#NIVEL_PH").val() == "") {
            alert("INGRESE NIVEL DE PH");
            return false;
        }
        if ($("#NIVEL_CLORO").val() == "") {
            alert("INGRESE NIVEL DE CLORO");
            return false;
        }
    }
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

//FUNCIONES AJAX PARA LA PÁGINA CLIENTES
function ClientesPorRazon() {
    var raz = $("#raz").val();
    $.ajax({
        type: "POST",
        url: "/Constancia/ClientesPorRazon",
        data: JSON.stringify({ raz: raz }),
        contentType: "application/json",
        success: function (result) {
            $("#contenido tr").remove();
            for (var i in result) {
                var cc = result[i].CUENTA_COMERCIAL;
                var cuec = "'" + cc + "'";
                var rs = result[i].RAZON_SOCIAL;
                $("#contenido").append('<tr><td><a href="#" id="cuen" onclick="ClientePorCuenta(' + cuec + ')">Seleccionar</a></td><td>' + rs + '</td></tr>');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ClientePorCuenta(cuenta) {
    var cuen = cuenta;
    $.ajax({
        type: "POST",
        url: "/Constancia/ClientePorCuenta",
        data: JSON.stringify({ cuen: cuen }),
        contentType: "application/json",
        success: function (result) {
            $('#ventanaClientes').modal('hide');
            $('#CUENTA_COMERCIAL').val(result.CUENTA_COMERCIAL);
            $('#RAZON').val(result.RAZON_SOCIAL);
            $('#DOMICILIO').val(result.DOMICILIO);
            $("#PISCINA_INFO").css("display", "block");
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function GabDetallesS() {
    var serv = $(".ddlServicios").val();
    var cantS = $("#cantS").val().trim();
    var servs = new Array();
    servs = serv.split("|");
    var s_cod = servs[0];
    var s_des = servs[1];
    $.ajax({
        type: "POST",
        url: "/Constancia/GrabarDetalle",
        data: JSON.stringify({ serv: s_cod, cant: cantS, desc: s_des }),
        contentType: "application/json",
        success: function (result) {
            $("#detalles tr").remove();
            for (var i in result) {
                var cant = result[i].CANTIDAD + '';
                var servicio = "'" + result[i].SERVICIO + "'";
                //result[i].USUARIO_REGISTRO-->MUESTRA INFORMACIÓN DE DESCRIPCIÓN DEL PRODUCTO/SERVICIO. NO MUESTRA USUARIO_REGISTRO.
                $("#detalles").append('<tr><td>' + result[i].USUARIO_REGISTRO + '</td><td>' + cant + '</td><td><a href="#/" ' +
                    'onclick="ElimDetalle(' + servicio + ')">Borrar</a></td></tr>');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function GabDetallesP() {
    var serv = $(".ddlProductos").val();
    var cantS = $("#cantP").val().trim();
    var servs = new Array();
    servs = serv.split("|");
    var s_cod = servs[0];
    var s_des = servs[1];
    $.ajax({
        type: "POST",
        url: "/Constancia/GrabarDetalle",
        data: JSON.stringify({ serv: s_cod, cant: cantS, desc: s_des }),
        contentType: "application/json",
        success: function (result) {
            $("#detalles tr").remove();
            for (var i in result) {
                var cant = result[i].CANTIDAD + '';
                var servicio = "'" + result[i].SERVICIO + "'";
                //result[i].USUARIO_REGISTRO-->MUESTRA INFORMACIÓN DE DESCRIPCIÓN DEL PRODUCTO/SERVICIO. NO MUESTRA USUARIO_REGISTRO.
                $("#detalles").append('<tr><td>' + result[i].USUARIO_REGISTRO + '</td><td>' + cant + '</td><td><a href="#/" ' +
                    'onclick="ElimDetalle(' + servicio + ')">Borrar</a></td></tr>');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ElimDetalle(servicio) {
    var serv = servicio;
    $.ajax({
        type: "POST",
        url: "/Constancia/EliminarDetalle",
        data: JSON.stringify({ serv: serv }),
        contentType: "application/json",
        success: function (result) {
            $("#detalles tr").remove();
            for (var i in result) {
                var cant = result[i].CANTIDAD + '';
                var servicio = "'" + result[i].SERVICIO + "'";
                //result[i].USUARIO_REGISTRO-->MUESTRA INFORMACIÓN DE DESCRIPCIÓN DEL PRODUCTO/SERVICIO. NO MUESTRA USUARIO_REGISTRO.
                $("#detalles").append('<tr><td>' + result[i].USUARIO_REGISTRO + '</td><td>' + cant + '</td><td><a href="#/" ' +
                    'onclick="ElimDetalle(' + servicio + ')">Borrar</a></td></tr>');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}
