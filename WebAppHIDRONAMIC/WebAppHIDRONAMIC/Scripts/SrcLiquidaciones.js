$(document).ready(function () {
    var today = (day) + "/" + (month) + "/" + now.getFullYear();

    $("#rbtnRangos").is(":checked") ? tipoConsulta(1) : tipoConsulta(0);

    $('#fecha1').val(today);
    $('#fecha2').val(today);
    $('#fechaActual').val(today);
    $('#nombre').val('');

});

var details = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACgAAAAoCAYAAACM/rhtAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAABmJLR0QA/wD/AP+gvaeTAAAAB3RJTUUH4gURCzsMjkzjUQAAB2RJREFUWMOtmF1sFMcdwH8ze1/+uJyNsYkDNV+SOck8gArxISQQEEOrKEoaFIU8gISJRJWXuNBK0EIaykeFUJFMeYmiuFISRbIiUjnwEglVUZqoJFFTHgioAdlQu5Bw9MA5++y73Znpw+2t1uf7wvCXRjs7uzvzm//HzH9WUEV6enrE7t27w5ZlBaq9a4xBKTWr3XEcRkdHs4cOHbIBUa0fv1Qc9NatW5w4cSLS1dV1vKGh4afGGFVrx0XgorOz87JlWX8+cODAsBCiZsiKgOfPnyeVSoWFEE+HQqH1xpi58AHQ0tKycd26dYkzZ878DvgU0LVoU1Z62NXVhdYaIQQPMemSEg6HRVtbW2LNmjV/GRgY2NXe3h4Cqs64HKAAREdHhwcnhEBK+UigdXV1RKPRjlWrVp0+depUX3d3d4OpYpaKGly2bBmA8MNJKecMKqUkFAoRi8WaV65c+fu+vr4DW7dujfb39xtXm7NKKcBZIxdr8FE0alkWoVCItra2+ng8/us9e/YcHBoaajx27NjDa7AYsBScv9Tal2VZNDU10draGuns7PxVb2/vbwYHB+sPHz48N8Bymis2eS2gQgiMMYTDYWKxGK2trZF4PL5/3759e48ePRocGBiY8X7VxdcPUojogl/768X35XxfSkkmk2FkZMTrs76+vmHFihW/PXv27O3e3t7BYg2KojJjwHImrmTySoEkpSQYDGJZ1oz2urq6+fF4/A9Hjhx52p2cAETNGiwMXEp71eqFUtwn5IMmGAxSV1dHMBjsTCQSh/v6+nYbY+4JIcScgqRYW5UCp9aIl1ISjUZZsmTJ5k2bNq2t2QeLZ1yrVPJVKO+jwWAwKIRoeGjAakFSCqJUe/F9qW/8bY/FB6tBVdNqpd2uog+6H5pqi3QtPlmpXsk//RqcNY0/nT6NFQh4nWhjoFCEQBQiND8b797/rKa6T8Na61mA5o8gd8CrEro1KEM+WTP79/OzQCCcGx9fnmprwxiDFgIDaGPQWqPddzWghchfjUEDqvDcGBSgfO8oQCnFvESCn2zf7pm8OCADADEQAraE4GULXyrR1ERDNIr+5huU1qh0GmdyMj9QOAzNzd5A9uQkuUzGA1FSIlta0IEAjgvoaM3U/fvkbBsFTAI5IVj80kszfLMYUIwBDvAE0OgDtF5/HWvXLnBNoW/fJn32LOkPPyS0fj0tZ85AKARa4ySTjH/yCXfeeoupZBKrtZUV775LJJ+ygRDY4+N8vXMnD65eRQPTQI7SO9aMIMmAyIFQrqkc90PV0oJYuhQnk8FOpbDWriV68iQqHseORAgsX46IxXByOUIrV/Lkm2/y5JEj5MJhslIS6uggtHAhdiZD9scfyabT5JQi6/Y/BWRLrBSzAJX7Qc6d1VQeGscYsG1Sx44xunUr6aEhAh0dyNWrySqFEILUhQtc3ryZb3fuZPrmTdpeeYVIdzfTSmGAyeFh/v7CC1zcsIG/Pfcc/7txwxtryjVxqZ1nFqDtwmV8xXFfyk5PMzE+Ti6ZzJsqHCbnPrOzWdL37jF24QL/HRzEamoimkiQc5epQEMD8zZsYH5PD03d3TiBALZvvIKJy6VsgQJgQXO4YI7bjpQ0bt9OKJEg9vzzqHSa8Rs3sBobKXybdd9/8N13oDWBBQvIuctS46JFJN5+GyyL+1eucL6nB/vuXW8cXWIDmLUOOmUAHRdw3o4dIARqYoLRd94h+eWXtPT0zAC0C5EtBI7jkHPXumwqxfBHH+FMTzN55w7TmQyOG4SFc2elIPEAsy7kLECluNnfT+rSJaa//577ly+TtW2ecDtRxjAFiFCIlnXrwBgeDA9jaw1CkPnhB/7xxhtMJJPeTmB8gBT7XFGQeIBTQOGg6plYCDCGu59/ztjHH3udOq7GjDFEnnqKBc88Q/uWLXS8+CITt24x+tlnKCk9EM9dfHCFugCElN6uUlaDGRcQX4dKSggEUFLmnd4H6AiBEYJFzz7Lwm3bEJEI2Xv3+OfJkySvXaO+vR0CAfDtNlBiPxUC6e5OfjPPAMy5gMECmFtuf/UVdjRKcnSUiSLA5NgY337wAcKyULbN5J07/OfiRca++CK/00xNcW1oCK0Uk9ksWR9TQXOqVh+084B6Kg+gChr893vv4bz/PkoI6ViW8PumvnKFT/fuzQ9oDMZd96SUYFkwMcHVgwfzz7XOtxWJrRTSsmYAlQQcBr0a+g381QHtgRiDXV/f8Ivjxw/MX7QoXkgCKklxjudd8zcz27SmdenS6kFyFcxVuES+ePLL114DY2Jrd+16dV5zM3MVLzB8qVkhTdNKod1dqVSQ+BPWWUfPn2/bxmQ6LYzWc/pj5J3otM67gHvVvjrGVDz4V0z5H/WXW7Fv1XIMKOmD5aQ4u30coOVgKyas5UTKmo7NDwVa7SRYMkjKieM4+URVa7TWPMov4FLij/RCvXicioCLFy/m+vXruXPnzg1GIpF/Vfsb+iiQvnpuZGTk+saNG/NapvSPbD+IAMLVJvM4mcnnLgrg/0jE4pzwDFUCAAAAJXRFWHRkYXRlOmNyZWF0ZQAyMDE4LTA1LTE3VDExOjU5OjEyLTA0OjAwSDodxQAAACV0RVh0ZGF0ZTptb2RpZnkAMjAxOC0wNS0xN1QxMTo1OToxMi0wNDowMDlnpXkAAAAASUVORK5CYII=";
var send = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACMAAAAjCAYAAAAe2bNZAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAABJ7AAASewGoqLFiAAAAB3RJTUUH4gURDBAKFBCtiAAABBZJREFUWMPtlm9olVUcxz+/85z7/949u/duTaspQjnCGWFqzkzIUimhPyC9aZaQppX1Yi8lSYiEXiQhCEVQhEsESSxLmtgUdSLDRIaBuk3N3F/n/t9t9949z+nFnXNzd7PG7IXs++aB8/zO73zO9/c753lgWtOa1gMoaWho8Cql5ohIzv1axBiTNsZcVUp1dXV1U1Q0N2uc1tr6WOAd1xC+XzBKxFVKjvYmnQ8CoXDreHF6x+HmsrdK4qFZMS+uazBTDGIpIZF0OHi+87UD5zr3hf3qx3Fhzta3h07V9bBpeT4vFdv4tOBOAZEICFBzo49dla1cbUnoeQUq3D84fnK9fVWQY3UpvjzSSOWlHrY8/xBFBX5cYzCThLKU0Nk3yN7qdvZV32J+AXyy0s/MHGUcFw6OBxPQsOYJL0/O1Ow938vmPX28vTSPtQuihP0Wzn+wSQm4Bk7X97KrspXOnn42LPKy6FGNpcBxJ56vDWAMFOYqyp4LUHUtTfnpZo5f7uGjFQU8VRiAoZh7udHSnebbqjZ+relg2WzF6yUBYgHBMfyr0svJ02dGhVkCLb2G/TVJzjUa1i6Ms25JnFhIZ3VJCQy6UHmxm93HWrHcFKULfBTPsEBGb8JjsW7J550XCEohcBhwKF99J9fdyR0D+WHhvRI/m5/xUFHTxqY9f3Gitmd4ccg0p6WE6+0ptv3UwKeHbrD4YYdtKwPMn2lx2/FRZVDi4mU58D3wJqAorbjzPptdt5MsLtTMzbc4eCHJ1gN/s2peLhuW5fFI1Etf0uWXmg6+OXmTvMAgW1f4eCxuIQKum4EdU4Y7jyiwc2i4nNIKl/LVY8s0JoFA0O/nRl+Ar0510J4Y5I2FMc5cSVDbOsD6khjLZkFqIEEi6fDbpTS1bU7WXJduOr9fbHH8CM8ODd0CyoBywNUTgWjLwrZzsCMRCj0WxYUR9v/RwXdVbTw9O8jXpbOZk+fDcQ39/QEqatrYXdVNf2q8nfHCXZbFhxwywA86+xwIBoPEojZ+ny/TS64h5FOsXxpnzXwbO2Dh0zLc1JFwCMufIul0ZOnECRUHvgBCY2A8Hk3UtomEQyg1OuvtXsqPaMzdx9WAiCAi974Hxiof2DEMIyJEQiGiuTZer2fCmZO9me+hyxrA6/USy7UJh4KZnU1SSiZNWgls0dFcGzsngkfrySQZlmsMjxf4KJrh50pbKuvRTjsmNZiprXfE8HFgE1Anzc3Naca5byaj6+0pGjvTWX5FjDl7rW/7Z4ca87DkwxEg7wK1ANLU1PSziLwMWFMBo4SspRb4Mx7zvCrrql/Bkp1DIBuBOgDKV6ONMRuBF4GCqYBxDDDWlwHghJRW16MlARwF3h8JMgT8PyrzHYqSaYubI0GmNa1pPbD6B54pdIDDDV7OAAAAJXRFWHRkYXRlOmNyZWF0ZQAyMDE4LTA1LTE3VDEyOjE2OjEwLTA0OjAwI71ILQAAACV0RVh0ZGF0ZTptb2RpZnkAMjAxOC0wNS0xN1QxMjoxNjoxMC0wNDowMFLg8JEAAAAZdEVYdFNvZnR3YXJlAHd3dy5pbmtzY2FwZS5vcmeb7jwaAAAAAElFTkSuQmCC";
var now = new Date();
var day = ("0" + now.getDate()).slice(-2);
var month = ("0" + (now.getMonth() + 1)).slice(-2);
var year = now.getFullYear();

function tipoConsulta(x) {
    if (x == 0) {
        $("#inptMes").css("display", "block");
        $("#inptRangos").css("display", "none");
        $("#dvConsultaMes").css("display", "block");
        $("#dvConsultaRangos").css("display", "none");
    }
    else {
        $("#inptRangos").css("display", "block");
        $("#inptMes").css("display", "none");
        $("#dvConsultaMes").css("display", "none");
        $("#dvConsultaRangos").css("display", "block");
    }
    return;
}

//function Consulta(cuenta) {
//    var mes = $("#inptMes").val();
//    var fecha1 = $('#fecha1').val();
//    var fecha2 = $('#fecha2').val();
//    var cue = cuenta;
//    if ($("#rbtnMes").is(":checked")) {
//        window.location.href = "/EstadoCuenta/DetallesMes?cuenta_comercial=" + cue + "&&mes=" + mes;
//    }
//    else {
//        var date_regex = /^(0[1-9]|1\d|2\d|3[01])\/(0[1-9]|1[0-2])\/(19|20)\d{2}$/;
//        var fecha1 = $("#fecha1").val();
//        var fecha2 = $("#fecha2").val();
//        if (!(date_regex.test(fecha1)) || !(date_regex.test(fecha2))) {
//            alert('INGRESE FORMATO CORRECTO. EJEMPLO 28/05/1995');
//            return false;
//        }
//        else
//            window.location.href = "/EstadoCuenta/DetallesFechas?cuenta_comercial=" + cue + "&&fecha1=" + fecha1 + "&&fecha2=" + fecha2;
//    }
//}

function Consulta(cuenta) {
    var cue = cuenta;
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
            window.location.href = "/EstadoCuenta/DetallesFechas?cuenta_comercial=" + cue + "&&fecha1=" + fecha1 + "&&fecha2=" + fecha2;
        }
    }
        //CONSULTA POR UN MES
    else if (tipo == 'UM') {
        $('#rango1').css('display', 'none');
        $('#rango2').css('display', 'none');
        $('#meses').css('display', 'inline-block');
        var mes = $("#cboMes").val();
        window.location.href = "/EstadoCuenta/DetallesMes?cuenta_comercial=" + cue + "&&mes=" + mes;
    }
        //CONSULTA POR TODOS
    else if (tipo == 'TO') {
        var mes = '';
        window.location.href = "/EstadoCuenta/DetallesMes?cuenta_comercial=" + cue + "&&mes=" + mes;
    }
        //CONSULTA POR ESTA SEMANA
    else if (tipo == 'ES') {
        window.location.href = "/EstadoCuenta/DetallesEstaSemana?cuenta_comercial=" + cue;
    }
        //CONSULTA POR SEMANA ANTERIOR
    else if (tipo == 'SA') {
        window.location.href = "/EstadoCuenta/DetallesSemanaPasada?cuenta_comercial=" + cue;
    }
        //CONSULTA POR ESTE MES
    else if (tipo == 'EM') {
        window.location.href = "/EstadoCuenta/DetallesMes?cuenta_comercial=" + cue + "&&mes=" + month;
    }
        //CONSULTA POR MES ANTERIOR
    else if (tipo == 'MA') {
        var mes = month - 1;
        window.location.href = "/EstadoCuenta/DetallesMes?cuenta_comercial=" + cue + "&&mes=" + mes;
    }
        //CONSULTA POR ESTE AÑO
    else if (tipo == 'EA') {
        window.location.href = "/EstadoCuenta/DetallesEsteAnio?cuenta_comercial=" + cue;
    }
        //CONSULTA POR HOY
    else {
        var fechaActual = $("#fechaActual").val();
        window.location.href = "/EstadoCuenta/DetallesFechas?cuenta_comercial=" + cue + "&&fecha1=" + fechaActual + "&&fecha2=" + fechaActual;
    }
}

function Enviar(cuenta) {
    var mes = $("#inptMes").val();
    var fecha1 = $('#fecha1').val();
    var fecha2 = $('#fecha2').val();
    var cue = cuenta;
    if ($("#rbtnMes").is(":checked")) {
        window.location.href = "/EstadoCuenta/EnviarEstadosMes?cuenta_comercial=" + cue + "&&mes=" + mes;
    }
    else {
        var date_regex = /^(0[1-9]|1\d|2\d|3[01])\/(0[1-9]|1[0-2])\/(19|20)\d{2}$/;
        var fecha1 = $("#fecha1").val();
        var fecha2 = $("#fecha2").val();
        if (!(date_regex.test(fecha1)) || !(date_regex.test(fecha2))) {
            alert('INGRESE FORMATO CORRECTO. EJEMPLO 28/05/1995');
            return false;
        }
        else
            window.location.href = "/EstadoCuenta/EnviarEstadosRangos?cuenta_comercial=" + cue + "&&fecha1=" + fecha1 + "&&fecha2=" + fecha2;
    }
}

function ClientesPorRazon() {
    var razon_social = $("#nombre").val();
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
                $("#contenidoClientes").append('<tr><td>' + rs + '</td><td style="text-align:center;"><a href="#" ' +
                    'onclick="Consulta(' + cuec + ')"><img src=' + details + ' /></a></td></a></td></tr>');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
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