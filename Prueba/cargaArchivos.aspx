<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cargaArchivos.aspx.cs" Inherits="Prueba.cargaArchivos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="styles/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/flexboxgrid/6.3.1/flexboxgrid.min.css" />
    <link href="https://fonts.googleapis.com/css?family=Poly" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css" />
    <title>Cargar archivos</title>
</head>
<body>
    <form id="form1" runat="server">    
       <div class="row main-container middle-xs center-xs">
        <div class="col-md-13 col-sm-13 col-xs-13">
          <div class="box">
            <div class="tarjetaFrm ">
              <header class="main-header "><!--Encabezado, una página puede tener más de un encabezado -->
                  <nav class="main-nav"> <!--Definir un sistema de navegación --> 
                      <a href="administracionUsuarios.aspx" class="nav-link">Usuarios</a>                    
                      <a href="cargaArchivos.aspx" class="nav-link">Carga Archivos</a>
                      <asp:LinkButton ID="LinkButton1" runat="server" class="nav-link"  Text="Cerrar Sesión"></asp:LinkButton>
                  </nav>
              </header>

              <article class="body"><!--La etiqueta se utiliza para definir contenido independiente -->
                <header class="modulos">
                    <h1 class="steel_blue_text promt tittle ">Actualización de convocatorias</h1>
                    <a href="menuAdministrador.aspx">
                    <img src="images/logoMep.jpg" height="100" alt="MEP Logo" /></a>
                    <div class="contenedor-info">
                              
                        <div>
                            <asp:Label ID="seleccionarArchivoEstudiante" runat="server" CssClass="etiquetas" Text="Buscar el archivo de estudiantes"></asp:Label>
                            <asp:FileUpload ID="FUBuscarEstudiante" runat="server" />
                            <asp:Label ID="cargarArchivoEstudiante" runat="server" CssClass="etiquetas" Text="Cargar los datos de los estudiantes"></asp:Label>
                            <asp:Button ID="btnCargarEstudiante" runat="server" Text="Cargar datos" OnClick="btnCargarDatos_Click"/>
                        </div>
                         <div>
                            <asp:Label ID="seleccionarArchivoMatricula" runat="server" CssClass="etiquetas" Text="Buscar el archivo de matrícula"></asp:Label>
                            <asp:FileUpload ID="FUBuscarMatricula" runat="server" />
                            <asp:Label ID="cargarArchivoMatricula" runat="server" CssClass="etiquetas" Text="Cargar los datos de la matrícula"></asp:Label>
                            <asp:Button ID="btnCargarArchivosMatricula" runat="server" OnClick="btnCargarArchivosMatricula_Click" Text="Cargar datos" />

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
