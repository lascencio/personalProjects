//FUNCIONES QUE SE INICIAN/PROGRAMAN AL ABRIR LA PÁGINA
$(document).ready(function () {
    $("#razon_social").focus(function () {
        $("#documento").val('');
    });

    $("#documento").focus(function () {
        $("#razon").val('');
    });

});

//IMAGENES EN CODIGOS
var imgSeleccion = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACoAAAAqCAYAAADFw8lbAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAABmJLR0QA/wD/AP+gvaeTAAAAB3RJTUUH4gURDDgh5fH6YgAACjRJREFUWMO1mX+MXNdVxz/n3vfmx65n17v27trbrJ04TpzUbqibJnZMo7gltTBCtEoppWCKKkFEUYSoCAhkqiJBoUAqhPpDVSVEsdxKUBoV3KKklaMiRbhObG/sxEnskvhH7bXjrNe7O7M7M++9ew5/vNnJetexMxuyo6P7Zt6P87nfe865990V3sbfjs0bODl6go33vW9geU/33aVCtEPgdoQyRk3NRrM02TczPX2sWC6l337q0JJ9yVJv/I0P3QsalltU+ESm8qnIsdFb6FENYmaICM5H6qJozIzvZ2ny9cunXjxWGbzJvnvw5Xce9A92bGLCeohJb8/wX0zS8Mu12UYciRH7xY8TEVwU43x0Kqh+PqlNfTsqlMK//8+xjvz6TkHvuHkEb9law/2ThWxns5n4JAs4Jzi3GNQADYGgoQ94gCh+VQpdx+9Y3cdL5y69Zb+uE8hP/8J7KUvqM+WzzsJ2R2COTdVQexPDUA2ELO0PITya1qtDwToTqCNQVZjJ5FYx/agXQ1qRMzLYy503DwKCKpi9mRmm+m5V26iqHYFGHYGaIbDeO1YDFOOITbfdxP33rGdZd4Ef/Pglnjl+lkaSAa0EEPIOtZQ3s5Iqwx0K2hlo5ASBkgiuXCywfeu7ed9dN1PuKgDwsV+6m3UjAxw9cZ7J6iyNJGOm3qQ628QURMDy/Oo4NzoC9XlATphZsnHDmui+rRuJIo9Zrk+lt8T92zbx/s230WimJEnG5NQMo8fP8PRzrzBTTxAhA15/R0EBzOyM9+61detuuqXYtYygelWNc0B3oUx3a7SHR+DW29ZQ7irzH08dQc0mBDnbqd+Oksk5x2y9eT6O4yNdlQoSl3ALTOISEheRqAgtK1d62LJlE72VLlTtZTU7o9ZZlHak6PCqAerNZtJoNPfhoo9IVIzcW3S4fMUKenoqXByf3u99VHXSWdZ3pOhf7HkCcY4kyX4YFcvHJCoiUemG5uIS4otEcTyWJOk+5+DJIy+9c6AAaZrxtf86eGFo9fBefNFcVOTGVqKRgfPR40+//OoLXV2lTt0ubVEyfeJHgGxA5Elg7Q2diDA+fuXZL39t767e3srJz39lT8c+O1YUyBPF+f+VqLTfRSVuZOKLrBgc+sGXvvLXJ7dv37YUl0tf5s2cPQzYTnD/ClSuf7VdxOwhRA50r7l7Sf46rqPtHvoYM/2xuGiPiPs9sGvMNgLYjJn+jWXJQfHxUt0tXVGA2umDAMPio+/7Us9mxOerj7lJXjM0Sx5zcWm3aZaUh+5Ysq8lKwqQTp7FzLy4qDtaNkDcsxoX5xmtSZ10aoysfuVVEUmWv+ejb8fV2wMVX0CQLWBrw+wEms7iS70AhPoUljUQcfeKL3xj4vj3wrOrDzA+M9pXjgeHRSKXhMnJidnnz8e+or9zy3PX97VUyLxE0W0a9gAPAfmwX/V0AbiIyK+fi57/7+eKP1wBfD1Y4wEwnBTGncSPiMRPXam/yO+vf+X/V9E9z0+yc7rX/XPpwCdXFWZ/UUR4s4lUYJXBY252xyN1v0/TMPZgpjPLAZzEA8Wob7ta9pRZuK7PjkAfe+YCSW1MQrmy4TcjHj6g7/nUnemZrlviK5S9IiLzBskwMxrBcTpd/v4X3a3faTT+9LC6zxTnrgmWMZu87vM3q+uX9LcEuu0ffsTtw73sHz05FEf+tzdx7uG1w8PrZv0yOax3cCqdYji7zApXpywpAE2LmNAy562fy64Pc34kksGRppUw0nkdwhABvf7i5oagD351P/UkK07VGjt7y/EfN4NtOX56zE/O1Ln1XatY1l1hwvUzbv14zfDkqyLFEVyEOHCm1GaqjE9fYOWA4v0bypuJlEtVLk2MAOc7B9346LfY+ZF7OHbszLpVveVHvXe76mmoZCo4B+fGp5io1lnd38vqFX0s6+pCfIxK/khVI2QJ0zMzXJyY5OJEjTiepq9fEBHMBBHj0viWDx06+odbn34+PvhzfzljRz/3wWvyXDPr7/v7fVyarLnb37VyR1ep8IWgbG5kKuDw3uN9hHMe5xzOOQpRRHe5RKWrSCGKiaLLlAqnaCQJ9WZKFhRTKBTOMrDym4ir52Epxkz1g9Smt/1sYMWJb4wMnfupmRO1jFrz4k9/NnlgdFlxSHe/d2wx6Ae+tI/qbDNa1V/5dFex8FeNVAeTYHjn2oDe+7x1Hudd3jqHOE/kU24Z/iYrew+hll2lhZFST8eZn+GFaDmxqwCqIvk7tIgTJ/HpejLxcURG/2jT0auH/r6/+x7lUgGBX/Uif1utJ32ZgvcOEAwDjLlaZK0Dm1ecnMzi/ItM1c8sKquItPYC3sjwejJF3SbJf5T2iciX1oj4dQ43uihGzYzp2ux659zuaiPpE8mHtg3TYrRW6ZkrQWaGmuJUCKo00yZFcSwqOa1+3jj4oJmmQLo4me794ndxzpOF7JNmtklV23tJOZO1YOfBqSFovr/UcpplBWbra/Hu3JtQ2NU/2xu0c31oTR/nRThlC0FNjSQ0+5xzO3MY2orNhzNTzKRtagatV2YTQzXmtfHfYrp2N5DMuw/i6DVW9j+BSEK+f6JMTG3i8sRdmClqiqrhXPPC0MoXPvPhB54YffbonQtAc7JVZrbOWuq194vmq2gGpmACKnOBiSitmUkJSR+N5geu6lwIUCqepLeyH++z/H4xqtURLry2DbWMEAKqAVWtnTq77YWfHHnYjvz5Q9cE7QfKC9VTU8QEU8VaSWUo5vJ6CQ4Ry1Vq7zHlI6I69xwwC4TgMBy06qiaYZKBZa0ACoBeErHq/IBZCFoHambWs1jJloqmvBGUIJKfF5FrzvVzHVaFoEYWHM5cu1MhCKat6/LPK8CXewo9U9PJ9GLQFuwxET4L9mdmepeaOGmrIbky2mJ0gBoiuZoLQRcnHqgqWeZwzrczPigtxW0Cs8eBf0zT7HiVKod3/1qbrV0/jnzuE9Rx2aHf3fhvDn7FYX/iTJ8xtdmgRlAl6FzAa74x22rz40AIgaAZQbO5Xeb2edU8TtPgSIPkbebAstc9/EuEfazb6yNF7174woYpO7T744ur2N69e+e+x8BgJAwAvZcSt/5c4n/+UhptnQx+zYxF5RTvTFy+N+9a7VwhX1CN2nFqhqkhrspQ/+NUyq8aQGTFZKh5z3duTjc/WXDZeDBqBpeBMWB6rmLt2rVr0aJkObAjM+4HbloRa9/KWMtKWm6qNKrB2WTwhUmN/HTwUjdPEy+pOTQPgKsUEDO8qBVE6YqC9ToYaDwY+uxy6kQttlKzrL1bkWxzZkwD48AJ4D+BnzCv4i8ErQGHgSvAkEG/QTdQKTnrKrvgBuOwzEjKCpKYSKKOBCE1kdRcu5w7zGIxCmJWFKUoRiRmgs9MV1WBBCwYVm35nWr5HQNOt9L/6qFfMPxC/t+SaJ4VWmEhQLn1HQc4MeZWAgvnobw4CAqotV9XtFVd0tYlSes4BbKWtbf6du3aBcD/ATspn4oxbEWjAAAAJXRFWHRkYXRlOmNyZWF0ZQAyMDE4LTA1LTE3VDEyOjU2OjMzLTA0OjAw4KkmTwAAACV0RVh0ZGF0ZTptb2RpZnkAMjAxOC0wNS0xN1QxMjo1NjozMy0wNDowMJH0nvMAAAAASUVORK5CYII=";

function Clientes() {
    $("#ventanaClientes").css("display", "block");
}

function ClientesPorRazon() {
    var vRazon = $("#razon").val();
    $.ajax({
        type: "POST",
        url: "/Clientes/ClientesPorRazon",
        data: JSON.stringify({ razon_social: vRazon }),
        contentType: "application/json",
        success: function (result) {
            $("#contenidoClientes tr").remove();
            for (var i in result) {
                var vCuentaComercial = result[i].cuenta_comercial;
                //Doy formato a vCuentaComercial para poder ser recibida en el método siguiente
                var vCuenta = "'" + vCuentaComercial + "'";
                $("#contenidoClientes").append('<tr><td align="center"><a href="#" onclick="SeleccionarCliente(' + vCuenta + ')"><img src=' + imgSeleccion + ' /></a></td>' +
                    '<td>' + result[i].nro_documento + '</td>' +
                    '<td>' + result[i].razon_social + '</td>' +
                    '<td>' + result[i].domicilio + '</td>' +
                    '<td>' + result[i].estado + '</td></tr>');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function ClientesPorCuenta() {
    var vDocumento = $("#documento").val();
    $.ajax({
        type: "POST",
        url: "/Clientes/ClientesPorCuenta",
        data: JSON.stringify({ documento: vDocumento }),
        contentType: "application/json",
        success: function (result) {
            $("#contenidoClientes tr").remove();
            for (var i in result) {
                var vCuentaComercial = result[i].cuenta_comercial;
                //Doy formato a vCuentaComercial para poder ser recibida en el método siguiente
                var vCuenta = "'" + vCuentaComercial + "'";
                $("#contenidoClientes").append('<tr><td align="center"><a href="#" onclick="SeleccionarCliente(' + vCuenta + ')"><img src=' + imgSeleccion + ' /></a></td>' +
                    '<td>' + result[i].nro_documento + '</td>' +
                    '<td>' + result[i].razon_social + '</td>' +
                    '<td>' + result[i].domicilio + '</td>' +
                    '<td>' + result[i].estado + '</td></tr>');
            }
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

function SeleccionarCliente(pCuenta) {
    var vCuenta = pCuenta;
    $.ajax({
        type: "POST",
        url: "/Clientes/SeleccionarCliente",
        data: JSON.stringify({ cuenta: vCuenta }),
        contentType: "application/json",
        success: function (result) {
            //Cerrar la ventana Modal y limpiamos los input text
            $('#ventanaClientes').modal('hide');
            $("#razon").val('');
            $("#documento").val('');
            $("#contenidoClientes tr").remove();

            $("#nro_documento").val(result.nro_documento);
            $('#razon_social').val(result.razon_social);

            //Luego de obtener el cliente, mostramos los valores de cabecera de préstamo
            ObtenerPrestamos();
        },
        error: function (result) {
            alert("Check the error: " + Error);
        }
    });
}

