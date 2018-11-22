<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administracionUsuarios.aspx.cs" Inherits="Prueba.administracionUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="styles/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/flexboxgrid/6.3.1/flexboxgrid.min.css" />
    <link href="https://fonts.googleapis.com/css?family=Poly" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css" />
    <title></title>
</head>
    <script type="text/javascript">
        /*Filtra las coincidencias de la palabra en la lista*/
        function filtrar_info(texto, id) {
            var palabras = texto.value.toLowerCase().split(" ");
            var tabla = document.getElementById(id);
            var filas;
            for (var r = 0; r < tabla.rows.length; r++) {
                filas = tabla.rows[r].innerHTML.replace(/<[^>]+>/g, "");
                var displayStyle = 'none';
                for (var i = 0; i < palabras.length; i++) {
                    if (filas.toLowerCase().indexOf(palabras[i]) >= 0)
                        displayStyle = '';
                    else {
                        displayStyle = 'none';
                        break;
                    }
                }
                tabla.rows[r].style.display = displayStyle;
            }
        }
    </script>

    <script type="text/javascript">
     function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
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

<body>
    <form id="form1" runat="server">
        <div class="row main-container middle-xs center-xs">
            <div class="col-md-13 col-sm-13 col-xs-13">
                <div class="box">
                    <div class="tarjetaFrm ">
                        <header class="main-header ">
                            <nav class="main-nav">
                                <a href="administracionUsuarios.aspx" class="nav-link">Usuarios</a>
                                <a href="cargaArchivos.aspx" class="nav-link">Carga Archivos</a>
                                <asp:LinkButton ID="LinkButton1" runat="server" class="nav-link" Text="Cerrar Sesión"></asp:LinkButton>
                            </nav>
                        </header>
                        <div class="messagealert" id="alert_container">
                        </div>
                        <article class="body">
                            <header class="modulos">
                                <h1 class="steel_blue_text promt tittle ">Administración de usuarios</h1>
                                <a href="menuAdministrador.aspx">
                                    <img src="images/logoMEP.JPG" height="100" alt="MEP Logo" /></a>
                                <div class="contenedor-info">
                                    <div class="info-izquierda">
                                        <div class="subtitulo">
                                            <asp:Label ID="lbltituloUsuarios" runat="server" Text="Información"></asp:Label>
                                        </div>
                                        <div>
                                            <table class="table table-condensed table-hover table-responsive">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblNombre" runat="server" CssClass="etiquetas" Text="Nombre:" Style="text-align: center"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNombre" runat="server" Width="180px" class="txtFiltro buscar-lista" onkeypress="return soloLetras(event);" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblApellido1" runat="server" CssClass="etiquetas" Text="Apellido 1:" Style="text-align: center"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtApellido1" runat="server" Width="180px" class="txtFiltro buscar-lista" onkeypress="return soloLetras(event);" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblApellido2" runat="server" CssClass="etiquetas" Text="Apellido 2:" Style="text-align: center"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtApellido2" runat="server" Width="180px" class="txtFiltro buscar-lista" onkeypress="return soloLetras(event);" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCorreo" runat="server" CssClass="etiquetas" Text="Correo:" Style="text-align: center"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCorreo" runat="server" Width="180px" class="txtFiltro buscar-lista" onkeypress="return soloLetras(event);" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTelefono" runat="server" CssClass="etiquetas" Text="Telefono:" Style="text-align: center"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTelefono" runat="server" Width="180px" class="txtFiltro buscar-lista" onkeypress="return soloNumeros(event);" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCelular" runat="server" CssClass="etiquetas" Text="Celular:" Style="text-align: center"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCelular" runat="server" Width="180px" class="txtFiltro buscar-lista" onkeypress="return soloNumeros(event);" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </td>
                                                </tr>           
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRol" runat="server" CssClass="etiquetas" Text="Rol:" Style="text-align: center"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRol" runat="server" AutoPostBack="True" Width="180px" CssClass="texto "  OnSelectedIndexChanged="ddlRol_SelectedIndexChanged"></asp:DropDownList>
                                                        <%-- Cargar comboBox de roles --%> 
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblUsuario" runat="server" CssClass="etiquetas" Text="Usuario:" Style="text-align: center"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUsuario" runat="server" Width="180px" CssClass="texto textoTxt" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblContrasena" runat="server" CssClass="etiquetas" Text="Contraseña:" Style="text-align: center"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtContrasena" runat="server" Width="180px" CssClass="texto textoTxt" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </td>
                                                </tr>               
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblEstado" runat="server" CssClass="etiquetas" Text="Estado:" Style="text-align: center"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkEstadoActivo" CssClass="checkbox" AutoPostBack="true" Text="Activo" runat="server"></asp:CheckBox>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkEstadoInactivo" CssClass="checkbox" AutoPostBack="true" Text="Inactivo" runat="server"></asp:CheckBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="botones">
                                            <div class="btn-guardar">
                                                <button id="btnGuardar" runat="server" class="btn btn-7 btn-7a icon-guardar"><span>Guardar</span></button>
                                            </div>
                                            <div class="btn-limpiar">
                                                <button id="btnLimpiar" runat="server" class="btn btn-7 btn-7a icon-limpiar"><span>Limpiar</span></button>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="info-derecha">
                                        <div class="subtitulo">
                                            <asp:Label ID="lblTituloListado" runat="server" Text="Listado de usuarios"></asp:Label>
                                        </div>
                                        <div class="buscar">

                                            <asp:Label ID="lblEncabezado" runat="server" CssClass="etiquetas" Text="Nombre de usuario"></asp:Label>
                                            <input name="txtBusquedaUsu" class="txtFiltro buscar-lista"  onkeyup="filtrar_info(this, '<%=gridUsuarios.ClientID %>')"  type="text" placeholder="Buscar por nombre de usuario." />
                                        </div>
                                        <div class="listado">
                                            <div>
                                                <asp:Label ID="lblTitUsuarios" runat="server" CssClass="etiquetas" Text="Usuarios"></asp:Label>
                                            </div>
                                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="500px" Width="370px">
                                                <asp:GridView ID="gridUsuarios"  OnRowDataBound="OnRowDataBound" runat="server" Height="20px" Width="223px" OnSelectedIndexChanged="gridUsuarios_SelectedIndexChanged"  CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="XX-Small">
                                                    <AlternatingRowStyle CssClass="fila-alternada-lista" />
                                                    <RowStyle CssClass="fila-lista" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        <div class="btn-limpiar">
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
    </form>
</body>
</html>
