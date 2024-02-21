<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirmaConstancia.aspx.cs" Inherits="WebAppHIDRONAMIC.Reports.FirmaConstancia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../fonts/signature-pad.css" rel="stylesheet" />
    <link href="../Content/admin2-css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .botons {
            height: 55px;
            width: 190px;
            font-size: 25px;
            font-weight: bold;
        }

        .mensaje {
            font-size: 20px;
            color: black;
            font-weight: bold;
        }
    </style>
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script>
        function Regresar() {
            var constancia = $("#cod").text();
            window.location.href = "/Constancia/ModificarConstancia?constancia=" + constancia;
            //alert(constancia);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" style="width: 100%; height: 100%">
        <asp:Image ID="Image1" runat="server" />
        <div style="padding-bottom: 7px;">
            <a href="#" onclick="Regresar();">
                <button type="button" class="btn btn-default botons" aria-label="Left Align">
                    <img src="../Imagenes/return_icon.png" />
                    <strong>REGRESAR</strong>
                </button>
            </a>
        </div>
        <asp:HiddenField ID="hfimg" runat="server" />
        <div id="signature-pad" class="signature-pad" style="max-width: 100%; max-height: 100%; width: 100%; height: 100%; background-color: darkgrey;">
            <div class="signature-pad--body">
                <canvas style="background-color: white;"></canvas>
            </div>
            <div class="signature-pad--footer">
                <div class="description mensaje">Firme arriba</div>

                <div class="signature-pad--actions form-group">
                    <div>
                        <button type="button" class="button clear btn btn-danger btn-lg botons" data-action="clear">REHACER</button>
                    </div>
                    <div>
                        <asp:Button ID="Button1" runat="server" Text="GRABAR" data-action="save" OnClick="Button1_Click" class="btn btn-primary btn-lg botons" />
                    </div>
                </div>
            </div>
        </div>
        <script src="../Scripts/signature_pad.umd.js"></script>
        <script src="../Scripts/app.js"></script>
    </form>
</body>
</html>
