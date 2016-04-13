<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="cvModuloTramites_Catastro.Account.Register"  %> 
<%@ OutputCache Location="None" NoStore="true"%>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   <!---Init Content--->
       <!----Meta data---->
        <meta http-equiv="Expires" content="0" />
        <meta http-equiv="Pragma" content="no-cache" />
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=none">
       <!---Styles-----> 
        <link href="../../Styles/assets/css/bootstrap.min.css" rel="stylesheet">
        <link href="../../Styles/assets/css/bootstrap-theme.min.css" rel="stylesheet">
        <link href="../../Styles/assets/css/exa.css" rel="stylesheet">  
        <link href="../../Styles/assets/css/form-elements.css" rel="stylesheet">
        <style class="cp-pen-styles">
            .progress-bar.animate 
            {
               width: 100%;
            }
        </style> 
       <!----Scripts---->
        <script src="../../Scripts/js/jquery-1.11.3.min.js"></script>
        <script src="../../Scripts/js/bootstrap.min.js"></script>
        <script src="../../Scripts/js/jquery-1.11.3.min.js"></script>
        <script src="../../Scripts/js/bootstrap.min.js"></script>
        <script src="../../Scripts/js/validator.min.js"></script>
       
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<form  id="Form1" data-toggle="validator" role="form" novalidate="true" runat="server">   
<asp:ScriptManager ID="ScriptManager1" runat="server">
                             </asp:ScriptManager>  
        <div class="container cont">
           <header class="centrado">
              <img alt="Banner"class="img-rounded centrado"  src="../../Styles/assets/images/banner alto.png" width="958">
           </header>
<hr class="featurette-divider"/>
        <div class="row featurette">
             <div class=" col-lg-12  col-md-12  col-xs-12 col-sm-12">
                 <h3 class="centrado  titulos"> Pagina de registro de datos de contacto</h3>
             </div>
        </div>
<hr class="featurette-divider"/>
         <div class="row featurette">
              <div class=" col-lg-6 col-md-7  col-xs-12 col-sm-7 ">
               <p class="lead pull-left " style="text-align: justify;">
                    <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                       <LoggedInTemplate>
                       <h3 class="centrado  titulos">Bienvenido Usuario</h2><p  class="centrado"><strong> Su Clave Catastral es:</strong>
                            <a><span class=""><asp:LoginName ID="HeadLoginName" runat="server" /></span></a>
                            [ <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" onloggedout="afterOut" 
                                    onloggingout="previewOut" LogoutText="Salir" LogoutPageUrl="~/Account/Login.aspx"/> ]</p>
                        </LoggedInTemplate>
                    </asp:LoginView>
                    <h4 class="subtitulos"><span> Informativo:</span></h4>
                 </p>
              
                 <ul>
                  <li><p class="textData" style="text-align: justify;"> Mediante el siguiente formulario usted podra establecer un nombre de contacto con el cual entrara al sitio de tramites y podra
                       solicitar cualquier servicio de su preferencia.</p></li>
                  <li><p class="textData" style="text-align: justify;"> Asegurese de que los datos que usted proporsionara sean validos.</p></li>
                  <li><p class="textData" style="text-align: justify;"> Asegurese de que los datos que usted proporsionara sean validos.</p></li>
                 </ul>
                 <p class="textData" style="text-align: justify;">De antemano, le agradecemos el uso del Modulo de Tramites, esperamos que su estadia sea de su agrado.</p><br />
                <h5 class="centrado  titulos"><p >Atentamente:</p></h5>
               <h5 class="subtitulos"> <p class="centrado"> H. Ayuntamiento de Jose Maria Morelos, Quintana Roo.</p></h5>
           
                  
                   
              </div>
              <div class="col-lg-6 col-md-5 col-sm-5 ">
              <h3 class="centrado  titulos "> Formulario de Contacto</h3>
                    <div class="form-group">
                      <label class="control-label " for="contacto">Nombre de Contacto:</label>
                      <asp:TextBox  ID="txtNombreContacto" maxlength="20" pattern="^[ .A-z0-9]{1,}" type="text" data-toggle="validator" data-match-error="Este campo es Obligatorio" runat="server" placeholder="Ejemplo: Arturo Duran" CssClass="form-control input-error" required=""></asp:TextBox>  <i class="form-control-feedback" data-fv-icon-for="number" style="display: none;"></i>
                      <div class="help-block with-errors"></div>
                    </div>
                    <div class="form-group">
                      <label class="control-label " for="email">Email:</label>
                      <asp:TextBox ID="txtEmail" type="email" data-toggle="validator"  data-match-error="Este direccion de Email es invalida"  runat="server" placeholder="Ejemplo: abc@hotmail.com" CssClass="form-control input-error" required=""></asp:TextBox>  <i class="form-control-feedback" data-fv-icon-for="number" style="display: none;"></i>
                      <div class="help-block with-errors"></div>
                    </div>
                    <div class="form-group">
                          <label class="control-label " for="telefono">Clave del Pais:</label>
                          <asp:TextBox ID="txtNumeroTelefono" type="text"  pattern="[+0-9]{13}"  maxlength="13" data-toggle="validator"  data-match-error="El numero de Caracteres debe ser igual a 13"  runat="server" placeholder="Ejemplo: +52 9831234567" CssClass="form-control input-error" required="" ></asp:TextBox>                     
                          <i class="form-control-feedback" data-fv-icon-for="number" style="display: none;"></i>
                          <div class="help-block with-errors"></div>
                    </div>
                    
                    <div class="form-group">
                      <asp:Button ID="btnRegistrarContacto" class="button_sub  btn btn-info " 
                            runat="server"  Text="Enviar Solicitud" onclick="btnRegistrarContacto_Click"/>
                             <div class="messagealert" id="alert_container"></div>
                    </div>
               
              </div>
         </div>
<hr class="featurette-divider"/>
         <footer>
              <div class="row">
                   <div class="col-sm-8 col-sm-offset-2 text " >
                       <img alt="Footer" class="img-rounded"  src="../../Styles/assets/images/banner abajo(1).jpg" width="958"><br>
                       <p class="text_tam">© 2015 Company, Inc. · <a href="http://getbootstrap.com/examples/carousel/#">Privacy</a> · <a href="http://getbootstrap.com/examples/carousel/#">Terms</a></p>
                   </div>
              </div>
         </footer>
    </div> 
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
                                                <p id="mensajeCuerpo" style="font-family: 'Roboto', sans-serif; font-size: 16px; font-weight: 300; color : #888; line-height : 30px; text-align: center; " runat="server"></p>
                                               
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
 <!-- Modal -->

<div class="modal js-loading-bar" aria-hidden="true" style="display: none;">
 <div class="modal-dialog">
   <div class="modal-content">
      <div class="modal-header">
         <h4 class="modal-title">Cargando Datos....<span class="glyphicon glyphicon-search"></span></h4>
      </div>
     <div class="modal-body">
         <div class="progress">
           <div class="progress-bar progress-bar-striped progress-bar-success active" role="progressbar" >100% Cargando...</div>
         </div>
     </div>
   </div>
 </div>
</div>

<script src="../../Scripts/progress/stopExecutionOnTimeout.js"></script>
 <script type="text/javascript">
     this.$('.js-loading-bar').modal({
         backdrop: 'static',
         show: false
     });
     $('#MainContent_btnRegistrarContacto').click(function () {

         if ($('#MainContent_txtNombreContacto').val() == "" && $('#MainContent_txtNombreContacto').val() == null &&
            $('#MainContent_txtEmail').val() == "" || $('#MainContent_txtEmail').val() == null ||
            $('#MainContent_txtNumeroTelefono').val().length < 13 || $('#MainContent_txtNumeroTelefono').val() == null || $('#MainContent_txtNumeroTelefono').val() == "") {

         } else {
             var $modal = $('.js-loading-bar'), $bar = $modal.find('.progress-bar');
             $modal.modal('show');
             $bar.addClass('animate');
             setTimeout(function () {
                 $bar.removeClass('animate');
                 $modal.modal('hide');
             }, 5000);
         }

     });
   
</script> 
<script src="../../Scripts/progress/css_live_reload_init.js"></script>
</asp:Content>
