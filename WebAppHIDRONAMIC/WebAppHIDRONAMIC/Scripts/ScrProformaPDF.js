var del = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAABmJLR0QA/wD/AP+gvaeTAAAAB3RJTUUH4ggJDh8cCeVruQAAA5pJREFUOMuNlVtMXGUUhb/9nzMz3FoLpSAULNALpkjUVhpsGYWCtY9GQWz7oEaCD1ZjjIlJ44OaGBN8wJpYE6vG+IbBmPhoENtAlUZKFdNSmsI0oBBucinXmTP/9mG4DFCT7uS8rPxnnbXX2vv8UlVV7rBSqiQM99mp42+ZxbwDBbgJT6rIIZAcwICOoNol0fAF32hfz87PXo5MPxI0atYoZJlQsFHub22L9ja25GogpU7F1CLkAz7WVxRlCOyPElk8l3u2+sZszj6jPj+AOgUFeQYbldS2Nnvr0/bD6k88jzEnEdIBh81lEO5D5BDGVzVTWvt3YOx2r5kZFhwfBqCgtS0aamwvVcf/NSKlgHAvJRSq434+XV7/zNaOyxbrIadAbja2ZNuELU2IHImzE1BAkBV6Bd2IxfBb4i1Vv/t68E8TBmwg5aV4MqtKRrKPE8WZbE9ysaqoQqLPULM/g91pCVir8Ur3qOt/o+HMFwlO8tkLeer6PkQkc0VZZrKftw/ncrI4gx1Jfq4Oz6Kq1B/M5tXHsnkwPYlrY3P8u+CtKRXJsinb21z1BR5HZO+aeqU0ZyvBXdsAeHp3KiIwueDx3P50HAMPZ6bwVEEa/ZND8Y5mqnGPuSrmIJAQH2FraIq9aYnUFGXgGDhWkLrsXKxa+if5vmcMVeK9FKDEADs3JMdsOMq5zqHVl3S1K+Hi7WkaLg0wOhdeH8xy2+b/JsKq4sUbvzLVVrkLvErpAuuMQCHJZ6g7kMXzRTvWqVBVKvK3EbFK42+DTMSHEjswbERtF7C4qgylMj+VF4ozcE3sdGtoih96xokue3Z8TxrVGz62PLSdrnhLv6ovqQ+hKGah0Dl0h47BGZ7YtY2W/kk+vjTAfMSy5FlqH8rg+tgcv4SmNoYyJtb7ySn5/ZuZmaOvpCNSHvMVZsIef43MMTEf4dvuEcbmI3gWukdnmVr0aLo2Su/4PMas86PZP3zjvLwIcv2Tn3NtIKVpeY/jVm8lvPjV24DF8JBEl6qbTwe7zD9V5ebRNysHJeq9g9IXT7LyxI/UJgzGRb0zOR8E/6irKHMMQP/RoPPA+0faJRquQ/UK91pKv0S917Zc/q55vrDE4Lix3xfG4U5x0BSeLrtoluZqUNuAEgK8u40oMIzqlxJZeDbrq/pmN9SBDSTHmlh/BVhSbl614yc+chZzivfhBio3XQHoFfEirb6Jge68906FxyvKjDruKsV/qXuBtj1Z4VQAAAAldEVYdGRhdGU6Y3JlYXRlADIwMTgtMDgtMDlUMTQ6MzE6MjgtMDQ6MDAUh9EbAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDE4LTA4LTA5VDE0OjMxOjI4LTA0OjAwZdpppwAAAABJRU5ErkJggg==";


function Enviar() {
    var asunto = $('#asunto').val().trim();
    var cuerpo = $('#cuerpo').val().trim();
    if (asunto == '') {
        alert("INGRESE ASUNTO");
        return false;
    }
    else if(cuerpo == ''){
        alert("INGRESE MENSAJE");
        return false;
    }
    else {
        if (confirm('¿Desea enviar esta proforma?')) { window.location.href = "/Proformas/EnviarProforma?proforma=" + proforma + "&asunto=" + asunto + "&cuerpo=" + cuerpo; }
    }
}

function VerPDF() {
    window.location.href = "/Proformas/DescargarPdf?proforma=" + proforma;
}

function Modificar() {
    window.location.href = "/Proformas/ModificarProforma?proforma=" + proforma + "&accion=modificar";
}

function Reutilizar() {
    window.location.href = "/Proformas/ModificarProforma?proforma=" + proforma + "&accion=consultar";
}

function ValidarTipoCambio() {
    var val;
    $.ajax({
        type: "POST",
        url: "/Proformas/ValidarTipoCamHoy",
        contentType: "application/json",
        success: function (result) {
            if (result.DESCRIPCION == 'NO') {
                alert('REGISTRE PRIMERO TIPO DE CAMBIO PARA HOY');
            }
            else {
                $('#msgConfirm3').modal('show');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ConstruirTabla(result) {
    $("#tablaCorreo tr").remove();
    $("#tablaCorreo").append('<tr><th style="width:215px;">l.lopez@hidronamic.com</th><td style="width:30px;"><a href="#"><img src=' + del + ' /></a></td></tr>');
    $("#tablaCorreo").append('<tr><th style="width:215px;">'+clie+'</th><td style="width:30px;"><a href="#"><img src=' + del + ' /></a></td></tr>');
    for (var i in result) {
        var usu = "'" + result[i] + "'";
        $("#tablaCorreo").append('<tr><th>' + result[i] + '</th><td><a href="#" onclick="EliminarCorreo(' + usu + ')"><img src=' + del + ' /></a></td></tr>');
    }
    $('#otros').val('');
}

function AgregarCorreo() {
    var usuario = $('#USUARIO').val();
    var email_regex = /\S+@\S+\.\S+/;
    if (usuario == 'otros') {
        var correo = $('#otros').val().trim();
        if (correo == '') {
            alert('INGRESE CORREO');
            return false;
        }
        else if (!email_regex.test(correo)) {
            alert("FORMATO DE CORREO INCORRECTO. EJEMPLO: correo@dominio.com");
            return false;
        }
        else {
            usuario = correo;
        }
    }
    $.ajax({
        type: "POST",
        url: "/Proformas/AgregarCorreosLiq",
        data: JSON.stringify({ usuario: usuario }),
        contentType: "application/json",
        success: function (result) {
            ConstruirTabla(result);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function EliminarCorreo(correo) {
    $.ajax({
        type: "POST",
        url: "/Proformas/EliminarCorreoLiq",
        data: JSON.stringify({ correo: correo }),
        contentType: "application/json",
        success: function (result) {
            ConstruirTabla(result);
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function Cambio() {
    var usu = $('#USUARIO').val();
    usu == 'otros' ? $('#otros').css('display', 'inline-block') : $('#otros').css('display', 'none');
}
