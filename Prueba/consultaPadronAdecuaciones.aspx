<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consultaPadronAdecuaciones.aspx.cs" Inherits="Prueba.consultaCedulaEstudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="styles/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/flexboxgrid/6.3.1/flexboxgrid.min.css" />
    <link href="https://fonts.googleapis.com/css?family=Poly" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css" />
    <link rel="stylesheet" href="https://formden.com/static/cdn/bootstrap-iso.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

    <title>Padrones Padron Adecuaciones </title>
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

    function isNumber(evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if ((charCode > 31 && charCode < 48) || charCode > 57) {
            return false;
        }
        return true;
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


    <form id="formConsultaPadronAdecuaciones" runat="server">
        <div>
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
                                <div class="jumbotron jumbotron-fluid">
                                    <div class="container">
                                        <h3 class="display-4">Padrón General Adecuaciones Curriculares  </h3>
                                        <p class="lead">Selecciones los datos conforme se le solicita</p>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="exampleFormControlSelect1">Provincia </label>
                                    <select class="form-control" id="selectProvinciaAdecuacion">
                                        <option>--Seleccione--</option>

                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="exampleFormControlSelect1">Region </label>
                                    <select class="form-control" id="selectRegionAdecuacion">
                                        <option>--Seleccione--</option>

                                    </select>
                                </div>

                                <div class="form-group">
                                    <label for="exampleFormControlSelect1">Sede </label>
                                    <select class="form-control" id="selectSedeAdecuacion">
                                        <option>--Seleccione--</option>

                                    </select>
                                </div>

                                

                                <button class="btn btn-primary" type="submit">Buscar</button>
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th scope="col">Padron</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:GridView ID="GridPadronAdecuaciones" runat="server"></asp:GridView>
                                        </tbody>
                                    </table>
                                </div>

                            </article>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>

