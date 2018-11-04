<%@ Page Title="Página principal" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="inicio_sesion.aspx.cs" Inherits="Prueba.inicio_sesion" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
    <head id="Head1">

        <link href="styles/style.css" rel="stylesheet" />
        <link rel="shortcut icon" href="images/favicon.ico" />
        <meta content="" charset="UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
        <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>


        <title>Sistema de consulta de matrícula Vértice</title>

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
    </head>

    <asp:HiddenField ID="hdnOculto" runat="server" />
    <body>

        <div class="row main-container middle-xs center-xs">
            <div class="col-md-13 col-sm-13 col-xs-13">
                <div class="box">
                    <div class="tarjeta2 animated bounce ">
                        <header class="main-header ">
                            <!--Encabezado, una página puede tener más de un encabezado -->
                            <nav class="main-nav">
                                <!--Definir un sistema de navegación -->
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
                                    <img src="images/logoMEP.JPG" height="200" alt="MEP Logo" /></a>
                                <div class="row middle-xs center-xs">
                                    <div class="col-md-8 col-sm-4 col-xs-3">
                                        <div class="box">
                                            <div id='textoPr'>
                                                <hgroup>
                                                    <h1>Inicio de sesión</h1>
                                                </hgroup>
                                                <asp:Label ID="Label1" size="15" runat="server" CssClass="MiLabel" Text="Usuario" TabIndex="0"></asp:Label>
                                                <asp:TextBox ID="txtUsuario" runat="server" type="text" placeholder="Ingrese su usuario" CssClass="form-control " TabIndex="1" Style="text-align: center" autocomplete="off" AutoCompleteType="Disabled" required></asp:TextBox>
                                                <asp:Label ID="Label2" size="15" runat="server" CssClass="MiLabel" Text="Contraseña" TabIndex="0"></asp:Label>
                                                <asp:TextBox ID="txtContrasena" runat="server" type="password" CssClass="form-control" placeholder="Ingrese su contraseña" required TabIndex="2" Style="text-align: center" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                                                <button id="btnIngresar" runat="server"  causesvalidation="true" class="form-control btn btn-primary" tabindex="3"><span>Ingresar</span></button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </header>
                        </article>
                        <!--La etiqueta se utiliza para definir contenido independiente -->
                    </div>
                </div>
            </div>
        </div>

    </body>
</asp:Content>
