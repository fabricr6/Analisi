<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrese.aspx.cs" Inherits="Prueba.registrese" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="styles/style.css" rel="stylesheet" />
    <link rel="shortcut icon" href="images/favicon.ico" />
    <meta content="" charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/flexboxgrid/6.3.1/flexboxgrid.min.css" />
    <link href="https://fonts.googleapis.com/css?family=Poly" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + '</strong> <span>' + message + '</span></div>');
        }
    </script>

    <script type="text/javascript">
        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " �����abcdefghijklmn�opqrstuvwxyz";
            especiales = "8-37-39-46";

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }
            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }

        function soloNumeros(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            numeros = " 0123456789";
            especiales = "8-37-39-46";

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (numeros.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }
    </script>
</head>

<body>
    <form runat="server">
        <div class="row main-container middle-xs center-xs">
            <div class="col-md-13 col-sm-13 col-xs-13">
                <div class="box">
                    <div class="tarjeta2">
                        <header class="main-header ">
                            <!--Encabezado, una p�gina puede tener m�s de un encabezado -->
                            <nav class="main-nav">
                                <!--Definir un sistema de navegaci�n -->
                                <a href="sobreNosotros.aspx" class="nav-link">Sobre nosotros</a>
                                <a href="registrese.aspx" class="nav-link">Regístrese</a>
                                <a href="contactenos.aspx" class="nav-link">Contáctenos</a>
                            </nav>
                        </header>

                        <div class="messagealert" id="alert_container">
                        </div>
                        <article class="body">
                            <!--La etiqueta se utiliza para definir contenido independiente -->
                            <header class="modulos">
                                <h1 class="steel_blue_text promt tittle ">Sistema de consulta de matrícula Vértice</h1>
                                <a href="inicio_sesion.aspx">
                                    <img src="images/logoMEP.JPG" height="100" alt="MEP Logo" /></a>
                                <div class="row middle-xs center-xs">
                                    <div class="col-md-12 col-sm-12 col-xs-11">
                                        <div class="box">
                                            <div class="textoRegistrese">
                                                <hgroup>
                                                    <h1 class="steel_blue_text promt tittle">Solicitud de acceso</h1>
                                                </hgroup>
                                                <table class="table table-condensed table-hover table-responsive">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNombreSolicitante" runat="server" CssClass="etiquetas" Text="Nombre del solicitante:" Style="text-align: center"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNombreSolicitante" runat="server" Width="180px" CssClass="form-control" required></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCorreoElectronico" runat="server" CssClass="etiquetas" Text="Correo electrónico:" Style="text-align: center"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox type="email" ID="txtCorreoSolicitante" runat="server" Width="180px" CssClass="form-control" required></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblTelefonoSolicitante" runat="server" CssClass="etiquetas" Text="Teléfono:" Style="text-align: center"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTelefonoSolicitante" onkeypress="return soloNumeros(event);" runat="server" Width="180px" CssClass="form-control" required></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblMensajeSolicitante" runat="server" CssClass="etiquetas" Text="Mensaje:" Style="text-align: center"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMensaje" type="text" runat="server" Width="180px" CssClass="form-control" required></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td>
                                                            <button id="btnGuardar" runat="server" causesvalidation="true" class="btn btn-7 btn-7a icon-guardar"><span>Solicitar</span></button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <asp:Label ID="lblEnviado" Font-Names="Verdana" runat="server" Text="" Visible="false" Font-Bold="True"></asp:Label>
                                    </div>
                                </div>
                            </header>
                        </article>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
