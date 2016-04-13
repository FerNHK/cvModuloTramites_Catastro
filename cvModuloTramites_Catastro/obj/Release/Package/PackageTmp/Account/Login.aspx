<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="cvModuloTramites_Catastro.Account.Login" %>
<%@ OutputCache Location="None" NoStore="true"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <!---Init Content--->
       <!----Meta data---->
        <meta http-equiv="Expires" content="0" />
        <meta http-equiv="Pragma" content="no-cache" />
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, user-scalable=no">
        <meta http-equiv=”Content-Type” content=”text/html; charset=iso-8859-2″>
       <!---Styles----->   
        <link href="../Styles/assets/css/bootstrap.min.css" rel="stylesheet">
        <link href="../Styles/assets/css/exa.css" rel="stylesheet">
        <link rel="stylesheet" href="../Styles/assets/css/form-elements.css">
        <link rel="stylesheet" href="../Styles/assets/css/style.css">
        <style class="cp-pen-styles">
            .progress-bar.animate 
            {
                width: 100%;
            }
        </style> 
       <!----Scripts---->
        <script src="../Scripts/js/jquery-1.11.3.min.js"></script>
        <script src="../Scripts/js/bootstrap.min.js"></script>
        <script src="../Scripts/js/validator.min.js"></script>
                                                                                                               
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container black  cont">
     <header>
         <img alt="Banner" class="img-rounded"  src="../Styles/assets/images/banner alto.png" width="958">
     </header>
         <div class="row ">
             <hr class="featurette-divider">
                <h1 class="head_principal"><strong>Modulo de Tramites de Catastro</strong> </h1>   
                     <hr class="featurette-divider">
                        <div class="col-lg-10 col-lg-offset-1  col-xs-10 col-xs-offset-1
                                 col-sm-10 col-sm-offset-1  col-md-10  col-md-offset-1 form-box">
                                <p class="lead " >
                                    Bienvenido al modulo de tramites de catastro. Por favor proporcione su 
                                    clave catastral para iniciar su session y acceda a su informacion personal.
                                </p>
                        <div class="panel panel-primary elevacionD">
                            <div class="panel-heading">
                                 <h3 class="panel-title">Propircione Su Clave Catastral.</h3>
                            </div>
                             <div class="panel-body">
                             <form id="form1"  class="login-form" data-toggle="validator" role="form" novalidate="true" runat="server">
                             <asp:ScriptManager ID="ScriptManager1" runat="server">
                             </asp:ScriptManager>
                               <div class="form-group ">
                                 <label class="control-label " for="contacto">Clave Catastral:</label>
                                 <div class="input-group">
		    				    <span class="input-group-addon "><span class="glyphicon glyphicon-user"></span></span>
		    				   
                                   <asp:TextBox TextMode="password"
                                          pattern="[0-9]{17}" 
                                          maxlength="17" 
                                          data-toggle="validator" 
                                          data-match-error="Este campo es Obligatorio" 
                                          ID="ClaveCat" runat="server" 
                                          placeholder="Clave Catastral....." 
                                          CssClass="form-control" 
                                          required="">
                                   </asp:TextBox> 
                                 </div>
                                   
                                   <div class="row">
                                       <div class="col-lg-7 col-md-6 col-sm-6 col-xs-12">
                                          <div class="text_tam help-block "><p>Se Requieren 17 caracteres numericos.</p></div> 
                                       </div>
                                       <div class= "col-lg-5 col-md-6 col-sm-5 col-xs-12">
                                          <div class="text_tam help-block with-errors"></div>
                                          <i class="glyphicon form-control-feedback" data-fv-icon-for="number" ></i>
                                       </div>
                                   </div>
                                 </div>
                                 <div class="form-group  ">
                                      <asp:Button ID="Button1" CssClass="button_sub btn btn-info " runat="server"  Text="Inicio" 
                                             onclick="btnInicio_Click"  />
                                      
                                 </div>                     
                                 <!---Alertaa--->
                                     <!-- Modal -->
                                      <div class="modal fade" id="alert" role="dialog" data-keyboard="false" data-backdrop="static" >
                                        <div class="modal-dialog">
    
                                          <!-- Modal content-->
                                          <div class="modal-content">
                                            <div id="tipeError" class="" runat="server">
                                             
                                              <h4 class="modal-title"><asp:Label ID="mensajeTitulo" runat="server" Text=""></asp:Label></h4>
                                            </div>
                                            <div class="modal-body">
                                              
                                                <asp:Label ID="mensajeUsuario" style="" runat="server" Text=""></asp:Label><br />
                                                <p ID="mensajeCuerpo" style="" runat="server"></p>
                                               
                                            </div>
                                            <div class="modal-footer">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                              </div>
                            </div>
                        </div>
                     </div>
<hr class="featurette-divider">
    <footer>
      <div class="row">
          <div class="col-lg-12 col-lg-offset-0  col-sm-12 col-sm-offset-0  col-md-12 col-md-offset-0 col-xs-12 col-xs-offset-0 text ">
               <img alt="Footer" class="img-rounded"  src="../Styles/assets/images/banner abajo(1).jpg" width="958">
               <br>
               <p class="text_tam">© 2015 Company, Inc. · <a href="http://getbootstrap.com/examples/carousel/#">Privacy</a> · <a href="http://getbootstrap.com/examples/carousel/#">Terms</a></p>
          </div>
      </div>
    </footer>
</div>
 <!-- Modal -->

<div class="modal js-loading-bar  " aria-hidden="true" style="display: none;">
  <div class="modal-dialog">
    <div class="">
     <div class="">
         <h3 class=""><span class=""></span></h3>
     </div>
     <div class="">
       <div class="progress">
          <div class="progress-bar progress-bar-striped progress-bar-success active" role="progressbar" >100% Cargando...</div>
       </div>
     </div>
    </div>
  </div>
</div>
<script src="../Scripts/progress/stopExecutionOnTimeout.js"></script>
<script type="text/javascript">
    this.$('.js-loading-bar').modal({
        backdrop: 'static',
        show: false
    });
    $('#MainContent_Button1').click(function () {

        if ($('#MainContent_ClaveCat').val() == "" || $('#MainContent_ClaveCat').val() == null || $('#MainContent_ClaveCat').val().length < 17 || isNaN($('#MainContent_ClaveCat').val())) {

        } else {
            var $modal = $('.js-loading-bar'), $bar = $modal.find('.progress-bar');
            $modal.modal('show');
            $bar.addClass('animate');
            setTimeout(function () {
                $bar.removeClass('animate');
                $modal.modal('hide');
            }, 3000);
        }

    });
   
</script>
<script src="../Scripts/progress/css_live_reload_init.js"></script>

</asp:Content>

