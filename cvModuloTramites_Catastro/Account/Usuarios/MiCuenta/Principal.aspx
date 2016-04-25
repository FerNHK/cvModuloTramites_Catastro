<%@ Page Title="Principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="Principal.aspx.cs" Inherits="cvModuloTramites_Catastro.Account.Usuarios.MiCuenta.Principal" 
EnableEventValidation="false" %>
<%@ OutputCache Location="None" NoStore="true"%>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <!---Init Content--->
    
        <!----Meta data---->
         <meta name="viewport" content="width=device-width, user-scalable=no">
	     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
         <meta http-equiv="X-UA-Compatible" content="IE=edge">
         <meta http-equiv="Expires" content="0" />
         <meta http-equiv="Pragma" content="no-cache" />
         <meta http-equiv=”Content-Type” content=”text/html; charset=iso-8859-2″>
        <!---Styles----->
         <link href="../../../Styles/assets/css/bootstrap.min.css" rel="stylesheet">
         <link href="../../../Styles/assets/css/bootstrap-theme.min.css" rel="stylesheet">
         <link href="../../../Styles/assets/css/exa.css" rel="stylesheet">
         <link rel="stylesheet" href="../../../Styles/assets/css/form-elements.css">
         
         <style type="text/css">
       
        td
        {
            cursor: pointer;
        }
        .hover_row
        {
            background-color: #FFFFBF;
        }
     </style>
        <!----Scripts---->
         <script src="../../../Scripts/js/jquery-1.11.3.min.js"></script>
         <script src="../../../Scripts/js/bootstrap.min.js"></script>
         <script src="../../../Scripts/js/validator.min.js"></script>
        
      
        
<!---End Content--->  
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <form  id="frmGlobal" data-toggle="validator" role="form" novalidate="true" runat="server">
      <span class="ir-arriba" runat="server" title="Subir" ><span class="glyphicon glyphicon-chevron-up"></span></span>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="container cont">
      <header class="centrado">
         <img alt="HEADER" class="img-rounded centrado"  src="../../../Styles/assets/images/banner alto.png" width="958">
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
                              <li ><a data-toggle="modal" href="#ActualizarUsuario" ><span class="glyphicon glyphicon-edit"></span>Editar Usuario</a></li>
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
<div class="black" >
 
      <div class="page-header">
           <div class="row featurette">
           <asp:Label ID="err" runat="server" Text=""></asp:Label>
            <hr class="featurette-divider"/>
 		        <div class=" col-lg-12 col-md-12  col-xs-12 col-sm-12">
 		          <h2 class="centrado titulos"><strong>Mi información Personal</strong></h2>
 		        </div>   	
           </div>	
      </div>

      <div class="row">
        <div class="col-sm-5 col-md-4  col-xs-12 col-lg-4 ">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h3 class="panel-title centrado ">Datos Generales del Predio</h3>
            </div>
            <div class="panel-body">
             	<div class="row centrado" >
		            <div class="col-sm-4  col-md-5 col-xs-12   " >
		              <label class="lbl_text" style="font-size:12px;">Clave Catastral</label>
		            </div>
		            <div class="col-md-7 col-xs-12 col-sm-7 ">
                       <asp:TextBox ID="txtClaveCatastral" type="text" CssClass="form-control form-control input-error" 
                                    placeholder="Clave Catastral..."  runat="server" Enabled="false"></asp:TextBox>
		            </div>
		             <br><br>
		         </div>
             	 <div class="row centrado" >
		            <div class="col-sm-4  col-md-5 col-xs-12   " >
		              <label style="font-size:12px;">Cuenta</label>
		            </div>
		            <div class="col-md-7 col-xs-12 col-sm-7 ">
                       <asp:TextBox ID="txtCuenta" type="text" CssClass="form-control form-control input-error" 
                                    placeholder="Cuenta..."  runat="server" Enabled="false">
                       </asp:TextBox>
		            </div><br><br>
		         </div>
             	 <div class="row centrado" >
		            <div class="col-sm-4  col-md-5 col-xs-12   " >
		              <label style="font-size:12px;">Cve Catastral ant</label >
		             </div>
		             <div class="col-md-7 col-xs-12 col-sm-7 ">
                       <asp:TextBox ID="txtCCataAnt" type="text" CssClass="form-control form-control input-error" 
                                    placeholder="Clave Catastral Ant"  runat="server" Enabled="false"></asp:TextBox>
		             </div>
		             <br><br>
             	 </div>
             	 <div class="row centrado" >
		            <div class="col-sm-4  col-md-5 col-xs-12   " >
		              <label style="font-size:12px;">Tipo Predio</label >
		             </div>
		             <div class="col-md-7 col-xs-12 col-sm-7 ">
		               <asp:TextBox ID="txtTiPredio" type="text" CssClass="form-control form-control input-error" 
                                    placeholder="Tipo Predio...."  runat="server" Enabled="false"></asp:TextBox>
		             </div><br><br>
		         </div>
              </div>
		    </div>
        </div><!-- /.col-sm-4 -->
        <div class=" col-sm-7 col-md-8 col-xs-12 ">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h3 class="panel-title centrado">Datos del Propietario</h3>
            </div>
            <div class="panel-body">
              <div class="row centrado ">
             		<div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
             		         <label  style="font-size:12px;">Persona</label>
                             <asp:TextBox ID="txtTiPersona" type="text" CssClass="form-control form-control input-error" 
                                    placeholder="Tipo Persona...."  runat="server" Enabled="false"></asp:TextBox>
             	        </div>
	             		<div class="col-lg-6 col-md-6 col-sm-4">
	             		     <label  style="font-size:11px;">Nombre/D./Razon S</label>
                             <asp:TextBox ID="txtRazonS" type="text" CssClass="form-control form-control input-error" 
                                    placeholder="Nombre/Denomianación/Razon Social...."  runat="server" Enabled="false"></asp:TextBox>
	             	    </div>
             	        <div class="col-lg-3 col-md-3 col-sm-4">
	             		     <label  style="font-size:12px;">RFC</label>
	             		     <asp:TextBox ID="txtRFC" type="text" CssClass="form-control form-control input-error" 
                                    placeholder="RFC...."  runat="server" Enabled="false"></asp:TextBox>
             	    	</div>
             	</div>
             	<div style="height:30px;"></div>
             	    <div class="row centrado ">
             		    <div class="col-lg-3 col-md-3 col-sm-3">
             		         <label  style="font-size:12px;">Primer Nombre</label>
             		     
                             <asp:TextBox ID="txtNombre_uno" type="text" CssClass="form-control form-control input-error" 
                                        placeholder="Primer Nombre...."  runat="server" Enabled="false"></asp:TextBox> 
             	        </div>
             	        <div class="col-lg-3 col-md-3 col-sm-3">
             		         <label  style="font-size:12px;">Segundo Nombre</label>
             		         <asp:TextBox ID="txtNombre_dos" type="text" CssClass="form-control form-control input-error" 
                                    placeholder="Segundo Nombre...."  runat="server" Enabled="false"></asp:TextBox>
             	        </div>
             	        <div class="col-lg-3 col-md-3 col-sm-3">
             		         <label  style="font-size:12px;">Primer Apellido</label>
             		         <asp:TextBox ID="txtApellidoPaterno" type="text" CssClass="form-control form-control input-error" 
                                    placeholder="Primer Apellido...."  runat="server" Enabled="false"></asp:TextBox>
             	        </div>
             	        <div class="col-lg-3 col-md-3 col-sm-3">
             		      <label  style="font-size:12px;">Segundo Apellido</label>
             		     
                          <asp:TextBox ID="txtApellidoMaterno" type="text" CssClass="form-control form-control input-error" 
                                    placeholder="Segundo Apellido...."  runat="server" Enabled="false"></asp:TextBox>
             	        </div>
				   </div>
		       </div>
             <div style="height:7px;"></div>
         </div>         
      </div>
   </div>
   <hr class="featurette-divider"/>
   <div class="row featurette">
            
 		        <div class=" col-lg-12 col-md-12  col-xs-12 col-sm-12">
 		          <h2 class="centrado titulos"><strong>Tramites realizados</strong></h2>
 		        </div>   	
           </div>
 <hr class="featurette-divider"/>

      <div class="row">
       
        <div class="col-sm-7 col-md-7 ">
       
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h3 class="panel-title centrado">Tabla de Tramites Realizados</h3>
            </div>
            <div class="panel-body">       	
               <div class="scrolling-table-container" >
                <!---TABLA DATAGRIDVIEW -->
                      <asp:UpdatePanel ID="actTramites" runat="server" >    
                        <ContentTemplate>          
                        <asp:GridView ID="gvCustomers" CssClass="table table-bordered "  runat="server" 
                               AutoGenerateColumns="false" EmptyDataText="Sin Datos" 
                               ShowHeaderWhenEmpty="True" ToolTip="Tramites Realizados" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" >
                            <Columns>
                                <asp:BoundField DataField="Folio" HeaderText="Folio"  />
                                <asp:BoundField DataField="FechaTramite" HeaderText="Fecha" />
                                <asp:BoundField DataField="Total" HeaderText="Total" />
                                <asp:BoundField DataField="StatusTramite" HeaderText="Estado" />
                            </Columns>
                        </asp:GridView>
                        </ContentTemplate>
                       </asp:UpdatePanel>
                        <script type="text/javascript">
                            $(function () {
                                $("[id*=gvCustomers] td").hover(function () {
                                    $("td", $(this).closest("tr")).addClass("hover_row");
                                }, function () {
                                    $("td", $(this).closest("tr")).removeClass("hover_row");
                                });
                            });
                         </script>
                 
                
               
		       </div>
               <br />
               <div class="row centrado">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                 <button type="button"  class="btn btn-lg btn-primary" data-toggle="modal" data-target="#myModal">Nuevo</button>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                <asp:UpdatePanel ID="genAcuse" runat="server">
                    <ContentTemplate>
                     <asp:Button ID="btnGenerarAcuse" class="btn btn-lg btn-info" 
                                runat="server"  Text="Imprimir" OnClick="btnGenerarAcuse_clicklistener" ToolTip="Generar acuse"  />
                     </ContentTemplate>
                     <Triggers>
                          <asp:PostBackTrigger  ControlID="btnGenerarAcuse" />
                     </Triggers>
                 </asp:UpdatePanel>           
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"> 
                 <asp:UpdatePanel ID="cancelartramite" runat="server">
                    <ContentTemplate>
                 <asp:Button ID="btnCancelar" class="btn btn-lg btn-danger" 
                            runat="server"  Text="Cancelar" OnClick="btnCancelar_clicklistener" ToolTip="Cancelar Tramite" />
                              </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="btnCancelar" />
                     </Triggers>
                 </asp:UpdatePanel>
                </div>
                      
              </div>
                <asp:Label ID="MesajeStauts" runat="server" Text=""></asp:Label>
             
             </div>
          </div>
        </div>
        <div class="col-sm-5 col-md-5 ">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h3 class="panel-title centrado">Denominación del Tramite</h3>
            </div>
            <div class="panel-body">
               <div class="row" >
		          <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		            <label class="checks_left centrado ">
                    <asp:UpdatePanel ID="Actreg1" runat="server">
                    <ContentTemplate>    
		                <asp:CheckBox ID="chkRegistroPredio" Enabled="false" runat="server"/>Registro de Predio
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </label>
                  </div>
		       		 <div class="col-lg-7 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left pull-left">
                      <asp:UpdatePanel ID="actDropCopias" runat="server">
                    <ContentTemplate> 
		                   <asp:CheckBox ID="chkCopiasC" Enabled="false" runat="server"/>Copias Certificadas
                           <asp:DropDownList ID="drpTotalcopias"  style="width:40px; height:25px" runat="server" Enabled=false>
                        </asp:DropDownList>
                         </ContentTemplate>
                    </asp:UpdatePanel>
		              
                        
                      </label>
				   </div>
		        </div>
                   <div class="row" >
		            <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left">
                      <asp:UpdatePanel ID="actRenov" runat="server">
                    <ContentTemplate> 
		                <asp:CheckBox ID="chkRenovacionC" Enabled="false" runat="server"/>Renovación de Cedula
                        </ContentTemplate>
                        </asp:UpdatePanel>
		              </label>
                    </div>
		       		<div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		               <label class="checks_left">
                       <asp:UpdatePanel ID="actUnicaconstancia" runat="server">
                    <ContentTemplate> 
                        <asp:CheckBox ID="chkConstanciaUnicaP" Enabled="false" runat="server"  />Constancia Única Propiedad
                        </ContentTemplate>
                        </asp:UpdatePanel>
		              </label>
		            </div>
		        </div>
		        <div class="row" >
		            <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6 " >
		              <label class="checks_left">
                      <asp:UpdatePanel ID="actSub" runat="server">
                    <ContentTemplate> 
		                <asp:CheckBox ID="chkSubdivicionP" Enabled="false" runat="server" />Subdivición de Predios
                        </ContentTemplate>
                        </asp:UpdatePanel>
		              </label>
                    </div>
		       		<div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left">
                      <asp:UpdatePanel ID="actNoPropid" runat="server">
                    <ContentTemplate>
		                <asp:CheckBox ID="chkConstaciaNoP" Enabled="false" runat="server"  />Constancia de no propiedad
                        </ContentTemplate>
                        </asp:UpdatePanel>
		              </label>
		            </div>
		        </div>
		        <div class="row" >
		            <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left">
                      <asp:UpdatePanel ID="actFusion" runat="server">
                    <ContentTemplate> 
		                <asp:CheckBox ID="chkFusionP" Enabled="false" runat="server"  />Fusión de Predio
                        </ContentTemplate>
                        </asp:UpdatePanel>
		              </label>
                     </div>
		       		 <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left">
                         <asp:UpdatePanel ID="actdocex" runat="server">
                             <ContentTemplate> 
		                     <asp:CheckBox ID="chkDocumentosEx" Enabled="false" runat="server"/>Expedición de Documentos Extraviados
                            </ContentTemplate>
                            </asp:UpdatePanel>
		              </label>
                     </div>
		       	</div>
		        <div class="row" >
		            <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		               
		                <label class="checks_left">
                        <asp:UpdatePanel ID="actcol" runat="server">
                    <ContentTemplate> 
                         <asp:CheckBox ID="chkMedidasColindancia" Enabled="false" runat="server"/>Certificado de medidas y colindancias
                         </ContentTemplate>
                         </asp:UpdatePanel>
		                </label>
                    </div>
		       		<div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left"> 
                      <asp:UpdatePanel ID="actSolip" runat="server">
                    <ContentTemplate> 
                           <asp:CheckBox ID="chkSolicitudP" Enabled="false" runat="server"  />Solicitud de copia de Planos
                           </ContentTemplate>
                           </asp:UpdatePanel>
		              </label>
		            </div>
		        </div>
		        <div class="row" >
		            <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left">
                      <asp:UpdatePanel ID="actConOfi" runat="server">
                    <ContentTemplate> 
		                <asp:CheckBox ID="chkConstaciaOff" Enabled="false" runat="server"  />Constancia de número oficial
                    </ContentTemplate>    </asp:UpdatePanel>
		              </label>
		            </div>
		       		<div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left">
                      <asp:UpdatePanel ID="actCroquis" runat="server">
                    <ContentTemplate> 
		                <asp:CheckBox ID="chkCroquis" Enabled="false" runat="server" />Croquis de localización
                        </ContentTemplate>
                        </asp:UpdatePanel>
		              </label>
		            </div>
		        </div>
		        <div class="row" >
		           <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left">
                      <asp:UpdatePanel ID="actConsReg" runat="server">
                    <ContentTemplate> 
		                 <asp:CheckBox ID="chkConstanciaRegistro" Enabled="false" runat="server"  />Constancia de Registro
                         </ContentTemplate>
                         </asp:UpdatePanel>
		              </label>
                   </div>
		    	   <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6 " >
		              <label class="checks_left">
                      <asp:UpdatePanel ID="actOtro" runat="server">
                    <ContentTemplate> 
                        <asp:CheckBox ID="chkOtro" Enabled="false" runat="server"  />OTRO
                     </ContentTemplate>   </asp:UpdatePanel>
		              </label>
		              
		          </div>
		   </div>
		   <div class="form-group">
			  <label for="comment">Observaciones:</label>
              <asp:UpdatePanel ID="actObser" runat="server">
                    <ContentTemplate> 
			      <asp:textbox id="txtObservaciones" TextMode="multiline" Columns="50"
                                 Rows="10" style="max-width:100%; height:100px;"  runat="server"  
                                 CssClass="form-control input-error" Enabled="false"/>
                                 </ContentTemplate>
                                 </asp:UpdatePanel>
              
             
                  
		   </div>
            <div class="row" >
		          <div  class="col-lg-8 col-lg-offset-2
                   col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1 col-xs-10 col-xs-offset-1" >
            <label class="Centrado" style=" text-align: center;">Proporcione su archivo de pago. De preferencia PDF</label> 
         
                   </div>
                </div>
                 <div class="input-group">
                    <asp:UpdatePanel ID="actFile" runat="server" >
                        <ContentTemplate> 
                            <div class="col-lg-12 col-md-9  col-sm-8 col-xs-8">
                                <span class="file-input centrado">Buscar Archivo… </span>
                                    <div class="input-group">
                                       <asp:FileUpload ID="UpFile"  runat="server" Enabled="false" CssClass="form-control" />
                                       <asp:LinkButton ID="TestLinkButton" CssClass="input-group-addon btn btn-warning" runat="server" style="color:white; border-color: #101010; background: #4aaf51;"  OnClick="btnActualizarArchivo_Click"  >ENVIAR</asp:LinkButton>    
                      
                                       </div>
                                             <asp:RegularExpressionValidator
                                                id="RegularExpressionValidator1" runat="server"
                                                ErrorMessage="¡Solo se permiten archivos PDF menores de 1mb!"
                                               
                                                ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                ControlToValidate="UpFile" CssClass="btn btn-danger" Style="color:white; display:block !Important;">
                                             </asp:RegularExpressionValidator>

                                
                           

                        </ContentTemplate>
                       <Triggers>
                            <asp:PostBackTrigger ControlID="TestLinkButton" />
                        </Triggers>
                    </asp:UpdatePanel> 
                   </div>
              </div>  
           </div>
        </div>    
     </div>     
  </div>
</div>
 
<hr class="featurette-divider"/>
   <footer>
        <div class="row">
             <div class="col-sm-8 col-sm-offset-2 text " >
                   <img alt="footer" class="img-rounded"  src="../../../Styles/assets/images/banner abajo(1).jpg" width="958"><br> 
             </div>
        </div>
 <hr class="featurette-divider"/>
     <div class="row">
          <div class="col-sm-8 col-sm-offset-2 text " >
                <p class="text_tam">© 2015 Company, Inc. · <a href="http://getbootstrap.com/examples/carousel/#">Privacy</a> · <a href="http://getbootstrap.com/examples/carousel/#">Terms</a></p>
          </div>
        </div>
     </footer>
  </div>






<div id="myModal" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="static">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        
          <header>
     <img alt="" class="img-rounded"  src="../../../Styles/assets/images/banner alto.png" width="958">
</header>
<hr class="featurette-divider"/>
        <h3 class="modal-title centrado">Denominación de tramite y  Observaciones</h3>

      </div>
      <div class="modal-body">
      
       <div class="panel panel-info">
            <div class="panel-heading">

              <h3 class="panel-title centrado">Denominación del Tramite</h3>
            </div>
            <div class="panel-body">
            	<div class="row" >
		            <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		                 <label class="checks_left">
                          <asp:UpdatePanel ID="Act_Renovacion" runat="server">
                                <ContentTemplate>
                                    <asp:CheckBox ID="chkRenovacion" runat="server" AutoPostBack="True"
                                        oncheckedchanged="chkRenovacion_CheckedChanged" />Renovación de Cedula
                                    
                                </ContentTemplate>
                            </asp:UpdatePanel>
		                    
		                  </label>
		       		 </div>
		       		 <div class="col-lg-7 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left pull-left">
                      <asp:UpdatePanel ID="Act_Copias_TOTAL" runat="server">
                       <ContentTemplate>
                       <asp:CheckBox ID="chkCopiasCer" runat="server" AutoPostBack="True"
                                        oncheckedchanged="chkCopiasCer_CheckedChanged" />Copias Certificadas
                           
                            <asp:DropDownList ID="drdCopias" runat="server" Enabled="False" AutoPostBack="True"
                           onselectedindexchanged="drdCopias_SelectedIndexChanged"  style="width:35px; height:20px">
                                    
                         </asp:DropDownList>
                        </ContentTemplate>
                      </asp:UpdatePanel>
		              </label>
				   </div>
		        </div>
		        <div class="row" >
		            <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left">
                       <asp:UpdatePanel ID="Act_certificadoColin" runat="server">
                        <ContentTemplate>
                        <asp:CheckBox ID="chkCertificadoM" runat="server" AutoPostBack="True"
                                        oncheckedchanged="chkCertificadoM_CheckedChanged" />Certificado de medidas y colindancias
		                    
                        </ContentTemplate>
                       </asp:UpdatePanel>
		              </label>
                    </div>
		       		 <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		               <label class="checks_left">
                       <asp:UpdatePanel ID="Act_constanciaUni" runat="server">
                        <ContentTemplate>
                        <asp:CheckBox ID="chkConstanciaUnica" runat="server" AutoPostBack="True"
                                        oncheckedchanged="chkConstanciaUnica_CheckedChanged" />Constancia Única Propiedad
		                    
                        </ContentTemplate>
                       </asp:UpdatePanel>

		              </label>
				   </div>
		        </div>
		         <div class="row" >
		             <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6 " >
		              <label class="checks_left">
                       <asp:UpdatePanel ID="Act_NumOficial" runat="server">
                        <ContentTemplate>
                        <asp:CheckBox ID="chkNumOficial" runat="server" AutoPostBack="True"
                                        oncheckedchanged="chkNumOficial_CheckedChanged" />Constancia de número oficial
		                    
                        </ContentTemplate>
                       </asp:UpdatePanel>
		               
		              </label>
                     </div>
		       		 <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left">
                      <asp:UpdatePanel ID="Act_NoPropiedad" runat="server">
                        <ContentTemplate>
                        <asp:CheckBox ID="chkNopropiedad" runat="server" AutoPostBack="True"
                                        oncheckedchanged="chkNopropiedad_CheckedChanged" />Constancia de no propiedad
		                    
                        </ContentTemplate>
                       </asp:UpdatePanel>
		                
		              </label>
		             </div>
		        </div>
		        <div class="row" >
		            <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
		              <label class="checks_left">
                       <asp:UpdatePanel ID="Act_Registro" runat="server">
                        <ContentTemplate>
                        <asp:CheckBox ID="chkRegistroC" runat="server" AutoPostBack="True"
                                        oncheckedchanged="chkRegistroC_CheckedChanged" />Constancia de Registro
		                    
                        </ContentTemplate>
                       </asp:UpdatePanel>
		                
		               </label>
		         
		       		 </div>
		       		 <div class="col-lg-5 col-md-6 col-sm-6 col-xs-6" >
                          <label class="checks_left">
                          <asp:UpdatePanel ID="Act_Croquis" runat="server">
                             <ContentTemplate>
                                 <asp:CheckBox ID="chkCroquisLoc" runat="server" AutoPostBack="True"
                                            oncheckedchanged="chkCroquisLoc_CheckedChanged" />Croquis de localización
		                    
                            </ContentTemplate>
                           </asp:UpdatePanel>
		                
		                 
		                  </label>
		       		 </div>
		        </div>
		     </div>
          </div>
          <div class="panel panel-info">
            <div class="panel-heading">
              <h3 class="panel-title centrado">Enviar por Paqueteria</h3>
            </div>
            <div class="panel-body centrado">
            <div class="checkbox ">
		    <label class="checks_left ">
             <asp:UpdatePanel ID="Act_Envio" runat="server">
                 <ContentTemplate>
                     <asp:CheckBox ID="chkMetodoEnvio" runat="server" AutoPostBack="True"
                                            oncheckedchanged="chkMetodoEnvio_CheckedChanged" />Enviar
		                    
                 </ContentTemplate>
             </asp:UpdatePanel>
		    </label>
		    </div>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
               <asp:DropDownList ID="drMetodoEnvioS" runat="server" Enabled="False" DataTextField="Descripcion" DataValueField="Descripcion" 
               AutoPostBack="True"
                onselectedindexchanged="drMetodoEnvioS_SelectedIndexChanged">
                    
                </asp:DropDownList>
                  <label >Costo de Envio:</label>&nbsp;&nbsp;<label>$</label> <asp:Label ID="Envio" runat="server" Text="00"></asp:Label>&nbsp;&nbsp;<label>MXN</label>
                 </ContentTemplate>
             </asp:UpdatePanel>
            </div>
          </div>
          <div class="panel panel-info">
            <div class="panel-heading">
              <h3 class="panel-title centrado">Observaciones</h3>
            </div>
            <div class="panel-body">
              <div class="form-group">
			      <label class="centrado" for="">Comentarios:</label>
                    <asp:textbox id="txtObservacionesData" TextMode="multiline" Columns="50"
                                 Rows="10" style="max-width:100%; height:100px;"  runat="server"  
                                 CssClass="form-control input-error" Enabled="True"/>
			     
			    </div>
            </div>
          </div>
          <div class="panel panel-info">
            <div class="panel-heading">
              <h3 class="panel-title centrado">Costo</h3>
            </div>
            <div class="panel-body centrado">
              <asp:UpdatePanel ID="Act_Precio" runat="server">
                <ContentTemplate>
                    <label >Costo de los Tramites:</label>&nbsp;&nbsp;<label>$</label> <asp:Label ID="lblPrecio" runat="server" Text="00"></asp:Label>&nbsp;&nbsp;<label>MXN</label>
                   
                    
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
          </div>

           <div class="modal-footer">
           <asp:UpdatePanel ID="upBtn" runat="server">
                <ContentTemplate>
                 <div class="row">      
                   <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">           
                        <asp:Button ID="btnCrearTramite" class="button_sub  btn btn-info " 
                            runat="server"  Text="Crear Tramite" OnClick="btnCrearTramite_Click"/>
                   </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">   
                            <asp:Button ID="btnCancelarCreartramite" class="button_sub  btn btn-danger " 
                            runat="server"  Text="Cancelar Tramite" OnClick="btnCancelarCreartramite_Click"/>
                            </div>
                   </div>
                  </ContentTemplate>
                  
                  <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnCrearTramite" />
                     <asp:AsyncPostBackTrigger ControlID="btnCancelarCreartramite" />
                  </Triggers>
            </asp:UpdatePanel>


              </div>
    
      </div>
     </div>
    </div>
</div>


<!-- Modal -->
<div id="eliminarTramite" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="static">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
         <header>
             <img alt="" class="img-rounded"  src="../../../Styles/assets/images/banner alto.png" width="958">
        </header>
<hr class="featurette-divider"/>
        <h3 class="modal-title centrado">Eliminar Tramite</h3>
      </div>
      <div class="modal-body">
      <div class="content">
        <p>A continuación se eleminara el tramite elegido</p>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Aceptar</button>
      </div>
    </div>

  </div>
</div>

<!-- Modal -->
<div id="ActualizarUsuario" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="static">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        
         <header>
             <img alt="" class="img-rounded"  src="../../../Styles/assets/images/banner alto.png" width="958">
         </header>
        <hr class="featurette-divider"/>
        <h3 class="modal-title centrado ">Editar Perfil de Usuario</h3>
    
        </div>
      <div class="modal-body">
     
        <div class="content">
        <asp:UpdatePanel ID="act_datps" runat="server">
           <ContentTemplate>  
                  <div class="form-group">
                      <label class="control-label " for="contacto">Nombre de Contacto:</label>
                      <asp:TextBox  ID="txtedit_NombreContacto" maxlength="20" pattern="^[ A-z0-9]{1,}$" type="text" data-toggle="validator" data-match-error="Este campo es Obligatorio" runat="server" placeholder="Nombre de Contacto" CssClass="form-control input-error" required=""></asp:TextBox>  <i class="form-control-feedback" data-fv-icon-for="number" style="display: none;"></i>
                      <div class="help-block with-errors"></div>
                    </div>
                    <div class="form-group">
                      <label class="control-label " for="email">Email:</label>
                      <asp:TextBox ID="txtedit_Email" type="email" data-toggle="validator"  data-match-error="Este direccion de Email es invalida"  runat="server" placeholder="Ejemplo: abc@hotmail.com" CssClass="form-control input-error" required=""></asp:TextBox>  <i class="form-control-feedback" data-fv-icon-for="number" style="display: none;"></i>
                      <div class="help-block with-errors"></div>
                    </div>
                    <div class="form-group">
                          <label class="control-label " for="telefono">Telefono:</label>
                          <asp:TextBox ID="txtedit_NumeroTelefono" type="text"  pattern="[+0-9]{13}"  maxlength="13" data-toggle="validator"  data-match-error="El numero de Caracteres debe ser igual a 13"  runat="server" placeholder="Ejemplo: +52 9831234567" CssClass="form-control input-error" required="" ></asp:TextBox>                     
                          <i class="form-control-feedback" data-fv-icon-for="number" style="display: none;"></i>
                          <div class="help-block with-errors"></div>
                    </div>
                    
                
                 </ContentTemplate>
    </asp:UpdatePanel>
        </div>
      </div>
      <div class="modal-footer">
         <div class="row">
       <asp:UpdatePanel ID="Up" runat="server">
       <ContentTemplate>
         <div class="col-lg-7 col-md-6 col-sm-6 col-xs-12">
                      <asp:Button ID="btnEditarContacto" class="button_sub  btn btn-info " 
                            runat="server"  Text="Editar Contacto" OnClick="btnEditarContacto_clicklistener" />
                            </div>
                            <div class= "col-lg-5 col-md-6 col-sm-5 col-xs-12">
              <asp:Button ID="btnCerrarModal" class="button_sub  btn btn-warning " 
                            runat="server"  Text="Cancelar " OnClick="btnCerrarModal_clicklistener" />
             </div>
        </ContentTemplate>
         <Triggers>
             <asp:AsyncPostBackTrigger ControlID="btnEditarContacto" />
             <asp:AsyncPostBackTrigger ControlID="btnCerrarModal" />
          </Triggers>
         </asp:UpdatePanel>
         </div>
                    
      </div>
     
            
    </div>
    </div>
 
                                     
                                          <div class="text_tam help-block "><p>Se Requieren 17 caracteres numericos.</p></div> 
                                       </div>
                                      
                                          <div class="text_tam help-block with-errors"></div>
                                          <i class="glyphicon form-control-feedback" data-fv-icon-for="number" ></i>
                                       </div>
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
                                       <script type="text/javascript">
                                           $(document).ready(function () {

                                               $('.ir-arriba').click(function () {
                                                   $('body, html').animate({
                                                       scrollTop: '0px'
                                                   }, 300);
                                               });

                                               $(window).scroll(function () {
                                                   if ($(this).scrollTop() > 0) {
                                                       $('.ir-arriba').slideDown(300);
                                                   } else {
                                                       $('.ir-arriba').slideUp(300);
                                                   }
                                               });

                                           });
                                         </script>       

</form>

</asp:Content>