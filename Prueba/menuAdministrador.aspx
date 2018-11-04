<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menuAdministrador.aspx.cs" Inherits="Prueba.menuAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <meta name="viewport" content="width=device-width, initial-scale=1.0" /> 
     <link href="styles/style.css" rel="stylesheet" />
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/flexboxgrid/6.3.1/flexboxgrid.min.css"/>
      <link href="https://fonts.googleapis.com/css?family=Poly" rel="stylesheet"/>
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css"/>
    <title></title>
</head>
    <body>
    <form id="form1" runat="server">
      <div class="row main-container middle-xs center-xs">
        <div class="col-md-14 col-sm-14 col-xs-14">
          <div class="box">
            <div class="tarjeta ">
              <header class="main-header "><!--Encabezado, una página puede tener más de un encabezado -->
                  <nav class="main-nav"> <!--Definir un sistema de navegación -->
                      <a href="administracionUsuarios.aspx" class="nav-link">Usuarios</a>                    
                      <a href="cargaArchivos.aspx" class="nav-link">Carga Archivos</a>
                      <asp:LinkButton ID="LinkButton1" runat="server"    class="nav-link"  Text="Cerrar Sesión"></asp:LinkButton>
                  </nav>
              </header>
              <article class="body"><!--La etiqueta se utiliza para definir contenido independiente -->
                <header class="modulos">
                  <h1 class="steel_blue_text promt tittle ">Sistema de consulta de matrícula Vértice</h1>
                  <a href="#">
                  <img src="images/logoMEP.JPG" height="200" alt="MEP Logo"/></a>
                  <h1 class="steel_blue_text promt tittle ">Módulo Administrador</h1>
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
