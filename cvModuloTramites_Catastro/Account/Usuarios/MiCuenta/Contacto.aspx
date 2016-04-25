<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="cvModuloTramites_Catastro.Account.Usuarios.MiCuenta.Contacto" %>
<%@ OutputCache Location="None" NoStore="true"%>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, user-scalable=no">
    <!-- Bootstrap core CSS -->
    <link href="../../../Styles/assets/css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../../../Styles/assets/css/bootstrap-theme.min.css" rel="stylesheet">
   
    <link href="../../../Styles/assets/css/exa.css" rel="stylesheet">
    
    <link rel="stylesheet" href="../../../Styles/assets/css/form-elements.css">
      
<script src="../../../Scripts/js/jquery-1.11.3.min.js"></script>
<script src="../../../Scripts/js/bootstrap.min.js"></script>
<script src="../../../Scripts/js/validator.min.js"></script>
<script src="../../../Scripts/JScript1.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<form id="Form1" data-toggle="validator" role="form" novalidate="true" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<div class="container cont">
     <header class="centrado">
     <img alt="Banner" class="img-rounded centrado"  src="../../../Styles/assets/images/banner alto.png" width="958">
</header>

<nav class="navbar navbar-inverse  bs-docs-nav">
            <div class="container-fluid">
              <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                  <span class="sr-only">Toggle navigation</span>
                  <span class="icon-bar"></span>
                  <span class="icon-bar"></span>
                  <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="Principal.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;Modulo de Tramites 
                  </a>
              &nbsp;</div>
              <div id="navbar" class="navbar-collapse collapse">
                <ul class="nav navbar-nav navbar-right">
                  <li><a id="A1" runat="server" href="Contacto.aspx"><span class="glyphicon glyphicon-comment"></span>&nbsp;Contacto <span class="sr-only">(current)</span></a></li>
                 
                  <li class="dropdown " >
                     <asp:LoginView ID="LoginView1" runat="server" EnableViewState="false">
                        <LoggedInTemplate>
                            <a href="#" 
                               class="dropdown-toggle" 
                               data-toggle="dropdown" 
                               role="button" 
                               aria-haspopup="true" 
                               aria-expanded="false"><span class="glyphicon glyphicon-user"></span>
                            <asp:LoginName ID="HeadLoginName" runat="server" /><span class="caret"></span></a>
                            <ul class="dropdown-menu">
                              
                              <li >   
                                      <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" onloggedout="afterOut" 
                                    onloggingout="previewOut" LogoutText="<span class='	glyphicon glyphicon-log-in'></span> Sair" LogoutPageUrl="~/Account/Login.aspx"/>
                              </li>
                            </ul>
                            </LoggedInTemplate>
                     </asp:LoginView>
                  </li>
                </ul>
              </div>
           </div>
        </nav>

      <div >
         <hr class="featurette-divider"/>
           <div class="row featurette">
             
              <div class=" col-lg-12 col-md-12  col-xs-12 col-sm-12">
              <h2 class="centrado titulos"><strong>Proporcione  sus datos de contacto</strong></h2>
                
              </div>
            </div>
             <hr class="featurette-divider"/>
             <div class="row featurette">
              
              <div class="col-lg-6 col-md-5 col-sm-5 ">
                       <div class="form-group">
                       <div class='message-dialog bg-color-blue fg-color-white' style='width: 50%; z-index:1000;' runat="server" id="myDiv" />
                       <asp:Label ID="EXITOERRO_warning" runat=server></asp:Label>
                       </div>
                      <div class="form-group">
                      <label class="control-label " for="contacto">Nombre de Contacto:</label>
                             <asp:TextBox 
                             type="text" data-toggle="validator"  maxlength="20" pattern="^[ A-z0-9]{1,}$"
                              data-match-error="Este campo es Obligatorio" ID="txtName" 
                              runat="server" placeholder="Nombre de Contacto"
                               CssClass="form-control input-error" required=""></asp:TextBox>
                                <i class="form-control-feedback" data-fv-icon-for="number" style="display: none;"></i>
                              <div class="help-block with-errors"></div>
                        </div>
                        <div class="form-group">
                        <label class="control-label " for="email">Email:</label>
                         <asp:TextBox type="email" data-toggle="validator"  data-match-error="Este direccion de Email es invalida" ID="txtEmail" runat="server" placeholder="Ejemplo: abc@hotmail.com" CssClass="form-control input-error" required=""></asp:TextBox>  <i class="form-control-feedback" data-fv-icon-for="number" style="display: none;"></i>
                           <div class="help-block with-errors"></div>
                           </div>
                        <div class="form-group">
                        <label class="control-label " for="telefono">Numero de Telefono:</label>
                        <asp:TextBox type="tel" pattern="[+0-9]{13}"  maxlength="13" data-toggle="validator" data-match-error="El numero de Caracteres debe ser igual a 13" ID="txtTel" runat="server" placeholder="Numero de telefono" CssClass="form-control input-error" required="" data-fv-field="number"></asp:TextBox>
                        <i class="form-control-feedback" data-fv-icon-for="number" style="display: none;"></i>
                          <div class="help-block with-errors"></div>
                            </div>
                            <div class="form-group">
                         <label class="control-label " for="email">Comentarios:</label>
                        <asp:textbox id="txtComentario" 
                                    TextMode="multiline" Columns="50" Rows="10" style="max-width:100%; height:100px;" data-match-error="Campo obligatorio" runat="server" data-toggle="validator" CssClass="form-control input-error" required="" data-fv-field="number" />
                        
                           <i class="form-control-feedback" data-fv-icon-for="number" style="display: none;"></i>
                            <div class="help-block with-errors"></div>
                        
                     </div>
          
                     <div class="form-group">
                         <div class="row" >
		          <div  class="col-lg-8 col-lg-offset-2
                   col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1 col-xs-12 " >
            <label class="Centrado" style=" text-align: center;">Proporcione su archivo de pago. De preferencia PDF</label> 
         
                   </div>
                </div>
                         <div class="row">
                          <div class="col-lg-12 col-md-9  col-sm-8 col-xs-8">
                                 <span class="file-input centrado">Buscar Archivo… </span>

                                 <div class="input-group">
                                     <span class="input-group-addon btn btn-warning"  style="color:white; border-color: #101010; background: #4aaf51;">Archivo<span class="glyphicon glyphicon-file"></span></span>  <asp:FileUpload ID="UpFile"  runat="server"  CssClass="form-control "  style="border-color: #101010; overflow:hidden;" />
                                        
                                       
                                </div>
                                           <asp:RegularExpressionValidator
                                                id="RegularExpressionValidator1" runat="server"
                                                ErrorMessage="¡Solo se permiten archivos PDF menores de 1mb!"
                                               
                                                ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                ControlToValidate="UpFile" CssClass="btn btn-danger" Style="color:white; display:block !Important;">
                                             </asp:RegularExpressionValidator>
  
                              
                            </div>
                         </div>
                     </div>
                         <div class="form-group">
                         <asp:Button ID="btnEditar" class="button_sub  btn btn-info " runat="server"  
                                 Text="Enviar Solicitud" onclick="btnEditar_Click" />
                                                   
                        </div>
                      
               
              </div>
              <div class=" col-lg-6 col-md-7  col-xs-12 col-sm-7 ">
                <h4 class="centrado">¡¡Bienvenido a este apartado.!!</h4>
                <p class=" pull-left " style="text-align: justify;">
                    Mediante este formulario podra enviar dudas a la direccion de correo <a>fer_nhk@hotmail.com</a>
                    Se mantendra en contacto con el personal de soprte para resolver cualquier aclaracion con sus tramites realizados 
                    con anterioridad.
                </p>
                <p>De antemano, le agradecemos el uso del Modulo de Tramites, esperamos que su estadia sea de su agrado.</p><br />
                <h2><p class="centrado">Atentamente:</p></h3>
               <h4> <p class="centrado"><strong> H. Ayuntamiento de Jose Maria Morelos, Quintana Roo.</strong></p></h4>
                  <br>
              </div>

            </div>
            <hr class="featurette-divider"/>
            <footer>
                          <div class="row">
                             <div class="col-sm-8 col-sm-offset-2 text " >
                               <img alt="footer" class="img-rounded"  src="../../../Styles/assets/images/banner abajo(1).jpg" width="958">
                             <br>
                            <p class="text_tam">© 2015 Company, Inc. · <a href="http://getbootstrap.com/examples/carousel/#">Privacy</a> · <a href="http://getbootstrap.com/examples/carousel/#">Terms</a></p>
                             </div>
                          </div>
                            
                            
                          </footer>
          
          </div>  </div> 
 <!---Alertaa--->
                                     <!-- Modal -->
                                      <div class="modal fade" id="alert" role="dialog" data-keyboard="false" data-backdrop="static">
                                        <div class="modal-dialog">
    
                                          <!-- Modal content-->
                                          <div class="modal-content">
                                            <div id="tipeError" class="" runat="server">
                                             
                                              <h4 class="modal-title centrado"><asp:Label ID="mensajeTitulo" runat="server" CssClass=""  Text=""></asp:Label></h4>
                                            </div>
                                            <div class="modal-body">
                                   
                                                <p id="mensajeUsuario" style="font-family: 'Roboto', sans-serif; font-size: 16px; font-weight: 300; color : #888; line-height : 30px; text-align: center; " runat="server"></p><br />
                                                <p ID="mensajeCuerpo" style="font-family: 'Roboto', sans-serif; font-size: 16px; font-weight: 300; color : #888; line-height : 30px; text-align: center; " runat="server"></p>
                                               
                                            </div>
                                            <div class="modal-footer">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                 <ContentTemplate>
                                                <asp:Button ID="btnCloseModalAction" runat="server" Text="Aceptar" OnClick="btnCloseModalAction_onClick" />
                                                </ContentTemplate>


                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnCloseModalAction" />
                                                </Triggers>
                                           </asp:UpdatePanel>

                                            </div>
                                          </div>
      
                                        </div>
                                      </div>    



   </form>
</asp:Content>
