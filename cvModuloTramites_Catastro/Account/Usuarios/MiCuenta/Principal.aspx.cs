using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using cvModuloTramites_Catastro.Data;
using System.Diagnostics;
using System.Web.Security;
using System.Drawing;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;


namespace cvModuloTramites_Catastro.Account.Usuarios.MiCuenta
{
    public partial class Principal : System.Web.UI.Page
    {
        #region VariablesGlobales
      
        public static Tramite_Helper consultaClave = new Tramite_Helper();
        public static Login_Helper cBusqueda = new Login_Helper();
        public static int alertNumero = 0;
        public static string editNombre = "";
        ReportDocument crystalReport = new ReportDocument();
        public static DataTable tbDatosPropietario = null, tbTramitesDenominacion=null,
                                 tbPreciosTramite = null, tbMetodoPreciosEnvios = null,tbReport=null;
        public static DataTable tn = null;
        public static bool RevCedula = false, copiasCer = false,
                           medidasCol = false, ConstUnicapro = false,
                           numeroOficial = false, constanciaReg = false,
                          Croquiz = false,  ConstNoProp = false;
        public static BinaryReader stream=null;
        String clave = "";              
        static float TotalPrecio = 0;
        static float duplicados=0;
        static float mul = 0;
        static float val1, val2;
        static int idTramite = 0,  TramiteDetalleID=0;
        //Variables para Insertar en TRDetalle 
        static float RDC=0, CSP=0, CMC=0, CUP=0,
                     CNO=0, CNP=0, CDR=0, CDL=0;
                        
        #endregion
        #region Insert 
        
        Byte[] archivo = null;

        int status = 0;
        
        int idEn = 0;
        float precioEnvio = 0;
        float tramitePrecios = 0;
        float total = 0;
        #endregion
        //  public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                
                drpTotalcopias.Items.Clear();
                drpTotalcopias.Items.Insert(0, new ListItem("0"));
                drMetodoEnvioS.Items.Insert(0, new ListItem("Seleccion de un Metodo de Envio"));
                string secc = (string)Session["ClvCat"];
                consultaClave.setClave(secc);
                if (secc == "" || secc == null)
                {
                    Response.Write("Session caduco =" + secc);
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    if (cBusqueda.consultaDatosContacto() == false)
                    {
                        Response.Redirect("~/Account/Login.aspx");
                    }
                    else
                    {
                        llenaDatosPropietario_Terreno();
                        llenaDatosTramites_Denominación();
                        obtencionPrecios();
                        initDrListTotalCopias();
                    }

                }

            }
            

        }
      
        #region LlenadoDatos
        public void llenaDatosPropietario_Terreno()
        {
            consultaClave.consultarDatosPropietario();
            tbDatosPropietario = new DataTable();
            tbDatosPropietario = consultaClave.getDatos();
            /**Datos del Terreno Primer Columna**/
            if (tbDatosPropietario.Rows[0]["cvecatastral"].Equals("") || tbDatosPropietario.Rows[0]["cvecatastral"].Equals(null))
            {
                txtClaveCatastral.Text = "Ninguno";
            }
            else
            {
                txtClaveCatastral.Text = tbDatosPropietario.Rows[0]["cvecatastral"].ToString();
            }
            if (tbDatosPropietario.Rows[0]["Cuenta"].ToString().Equals("") || tbDatosPropietario.Rows[0]["Cuenta"].ToString().Equals(null))
            {
                txtCuenta.Text = "Ninguno";
            }
            else
            {
                txtCuenta.Text = tbDatosPropietario.Rows[0]["Cuenta"].ToString();
            }
            if (tbDatosPropietario.Rows[0]["cveCatastralAnt"].ToString().Equals("") || tbDatosPropietario.Rows[0]["cveCatastralAnt"].ToString().Equals(null))
            {
                txtCCataAnt.Text  = "Ninguno";
            }
            else
            {
                txtCCataAnt.Text = tbDatosPropietario.Rows[0]["cveCatastralAnt"].ToString();
            }
            if (tbDatosPropietario.Rows[0]["Tipo"].ToString().Equals("") || tbDatosPropietario.Rows[0]["Tipo"].ToString().Equals(null))
            {
                txtTiPredio.Text = "Ninguno";
            }
            else
            {
                txtTiPredio.Text = tbDatosPropietario.Rows[0]["Tipo"].ToString();
            }

            /**Datos del Propietario Primer Fila**/
            if(tbDatosPropietario.Rows[0]["Tipo1"].ToString().Equals("") || tbDatosPropietario.Rows[0]["Tipo1"].ToString().Equals(null))
            {
                txtTiPersona.Text = "Ninguno";
            }else
            {
                txtTiPersona.Text = tbDatosPropietario.Rows[0]["Tipo1"].ToString();
            }
            
            if(tbDatosPropietario.Rows[0]["RazoSoc"].ToString().Equals("") || tbDatosPropietario.Rows[0]["RazoSoc"].ToString().Equals(null))
            {
                txtRazonS.Text = "Ninguno";
            }else
            {
                txtRazonS.Text = tbDatosPropietario.Rows[0]["RazoSoc"].ToString();
            }
           
            if(tbDatosPropietario.Rows[0]["RFC"].ToString().Equals("") || tbDatosPropietario.Rows[0]["RFC"].ToString().Equals(null))
            {
                 txtRFC.Text = "Ninguno";
            }else
            {
                 txtRFC.Text = tbDatosPropietario.Rows[0]["RFC"].ToString();
            }

            /****Datos del Propietario Segunda Fila***/
            
             if(tbDatosPropietario.Rows[0]["Nombre1"].ToString().Equals("") || tbDatosPropietario.Rows[0]["Nombre1"].ToString().Equals(null))
            {
                 txtNombre_uno.Text = "Ninguno";
            }
             else
            {
                 txtNombre_uno.Text = tbDatosPropietario.Rows[0]["Nombre1"].ToString();
            }
            
            if(tbDatosPropietario.Rows[0]["Nombre2"].ToString().Equals("") || tbDatosPropietario.Rows[0]["Nombre2"].ToString().Equals(null))
            {
            txtNombre_dos.Text = "Ninguno";
            }else
            {
                txtNombre_dos.Text = tbDatosPropietario.Rows[0]["Nombre2"].ToString();
            }
           
            if(tbDatosPropietario.Rows[0]["ApellidoP"].ToString().Equals("") || tbDatosPropietario.Rows[0]["ApellidoP"].ToString().Equals(null))
            {
                txtApellidoPaterno.Text ="Ninguno";
            }else
            {
                 txtApellidoPaterno.Text = tbDatosPropietario.Rows[0]["ApellidoP"].ToString();
            }
            
            if (tbDatosPropietario.Rows[0]["ApellidoM"].ToString().Equals("") || tbDatosPropietario.Rows[0]["ApellidoM"].ToString().Equals(null))
            {
                txtApellidoMaterno.Text = "Ninguno";
            }else
            {
                txtApellidoMaterno.Text = tbDatosPropietario.Rows[0]["ApellidoM"].ToString();
            }
        }
        public void llenaDatosTramites_Denominación()
        {
            consultaClave.consultarTramitesDenomiancion(); 
            gvCustomers.DataSource = consultaClave.getDataGrid();
            gvCustomers.DataBind();
           
        }
        public void obtencionPrecios()
        {
            consultaClave.consultarPrecios();
            tbPreciosTramite = new DataTable();
            tbPreciosTramite = consultaClave.getTramites();
            
        }
        public void obtencionEnvios()
        {
            consultaClave.cPreciosEnvios();
            tbMetodoPreciosEnvios = new DataTable();
            tbMetodoPreciosEnvios = consultaClave.getEnvios();
            drMetodoEnvioS.DataSource = tbMetodoPreciosEnvios;
            val1 = float.Parse(tbMetodoPreciosEnvios.Rows[0]["Precio"].ToString());
            val2 = float.Parse(tbMetodoPreciosEnvios.Rows[1]["Precio"].ToString()); 
            drMetodoEnvioS.DataTextField = "Descripcion";
            drMetodoEnvioS.DataValueField = "Descripcion";
            drMetodoEnvioS.DataBind();
            drMetodoEnvioS.Items.Insert(0, new ListItem("Seleccion de un Metodo de Envio"));
           

        }
        public void initDrListTotalCopias()
        {

            drdCopias.Items.Insert(0, new ListItem("0"));
            drdCopias.Items.Insert(1, new ListItem("1"));
            drdCopias.Items.Insert(2, new ListItem("2"));
            drdCopias.Items.Insert(3, new ListItem("3"));
            drdCopias.Items.Insert(4, new ListItem("4"));
            drdCopias.Items.Insert(5, new ListItem("5"));
            drdCopias.Items.Insert(6, new ListItem("6"));
            drdCopias.Items.Insert(7, new ListItem("7"));
            drdCopias.Items.Insert(8, new ListItem("8"));
            drdCopias.Items.Insert(9, new ListItem("9"));
        }
        #endregion
        #region EventosDataGridview
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(gvCustomers, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Tramites Realizados";
            }
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in gvCustomers.Rows)
            {
                if (row.RowIndex == gvCustomers.SelectedIndex)
                {
                    limpiar_controles();

                    UpFile.Enabled = true;

                  // TestLinkButton.Enabled = true;
                    string data = gvCustomers.SelectedRow.Cells[0].Text;
                    consultaClave.setFolio(data);
                    llenaDatosDenominacion();
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = "Se ha elegido esta el siguiente Folio"+""+data;
                    Page.Title = "Modulo de Tramites | Principal";
                    ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @" $(document).ready(function () {
                  $(document).on('change', '.btn-file :file', function () {
                      var input = $(this),
                          numFiles = input.get(0).files ? input.get(0).files.length : 1,
                          label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
                      input.trigger('fileselect', [numFiles, label]);
                  });

                  $('.btn-file :file').on('fileselect', function (event, numFiles, label) {
                      console.log(numFiles);
                      console.log(label);
                      $('#valdfil').val(label);
                  });
              });
            ", true);
                    



                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFFF");
                    row.ToolTip = "Seleccione la fila deseada";
                   
                }
            }
        }
        //EDITARFATA
        public void llenaDatosDenominacion()
        {
            
            int cantidad = 0;
            string observaciones = "";
            consultaClave.consultarDenominacion();
            tn = new DataTable();
            tn = consultaClave.getDatos();
            int total = tn.Rows.Count;
            for (int d = 0; d < total; d++)
            {
                RevCedula = Convert.ToBoolean(tn.Rows[d]["RenovacionCedula"]);
                copiasCer = Convert.ToBoolean(tn.Rows[d]["CopiaCertificada"]);
                medidasCol = Convert.ToBoolean(tn.Rows[d]["CerMedidasColindancia"]);
                ConstUnicapro = Convert.ToBoolean(tn.Rows[d]["constanciapropiedad"]);
                numeroOficial = Convert.ToBoolean(tn.Rows[d]["ConstanciaNumero"]);
                constanciaReg = Convert.ToBoolean(tn.Rows[d]["ConstanciaRegistro"]);
                Croquiz = Convert.ToBoolean(tn.Rows[d]["Croquis"]);
                ConstNoProp = Convert.ToBoolean(tn.Rows[d]["constanciaNopropiedad"]);
                
                cantidad = (int)tn.Rows[d]["NumCopias"];
                observaciones = tn.Rows[d]["Observaciones"].ToString();
                if (RevCedula == true)
                {
                    chkRenovacionC.Checked = RevCedula;
                    
                }
                else
                {
                    chkRenovacionC.Checked = RevCedula;
                }
                if (copiasCer == true)
                {
                    chkCopiasC.Checked = copiasCer;
                    if (cantidad >= 1)
                    {
                        drpTotalcopias.Items.Insert(0, new ListItem(cantidad.ToString()));
                    }
                   
                }
                else
                {
                    chkCopiasC.Checked = copiasCer;
                }
                if (medidasCol == true)
                {
                    chkMedidasColindancia.Checked = medidasCol;
                }
                else
                {
                    chkMedidasColindancia.Checked = medidasCol;
                }
                if (ConstUnicapro == true)
                {
                    chkConstanciaUnicaP.Checked = ConstUnicapro;
                }
                else
                {
                    chkConstanciaUnicaP.Checked = ConstUnicapro;
                }
                if (numeroOficial == true)
                {
                    chkConstaciaOff.Checked = numeroOficial;
                }
                else
                {
                    chkConstaciaOff.Checked = numeroOficial;
                }
                if (constanciaReg == true)
                {
                    chkConstanciaRegistro.Checked = constanciaReg;
                }
                else
                {
                    chkConstanciaRegistro.Checked = constanciaReg;
                }
                if (Croquiz == true)
                {
                    chkCroquis.Checked = Croquiz;
                }
                else
                {
                    chkCroquis.Checked = Croquiz;
                }
                if (ConstNoProp == true)
                {
                  
                    chkConstaciaNoP.Checked = ConstNoProp;
                }
                else { chkConstaciaNoP.Checked = ConstNoProp; }
                if (observaciones.Equals("") || observaciones.Equals(null))
                {
                    txtObservaciones.Text = "";
                }
                else
                {
                    txtObservaciones.Text = observaciones;
                }
            }
            tn.Clear();
        }
        public void limpiar_controles()
        {
          
                chkRegistroPredio.Checked = false;
                chkCopiasC.Checked = false;
                drpTotalcopias.Items.Clear();
                drpTotalcopias.Items.Insert(0, new ListItem("0"));
                chkRenovacionC.Checked = false;
                chkConstanciaUnicaP.Checked = false;
                chkSubdivicionP.Checked = false;
                chkConstaciaNoP.Checked = false;
                chkFusionP.Checked = false;
                chkMedidasColindancia.Checked = false;
                chkSolicitudP.Checked = false;
                chkConstaciaOff.Checked = false;
                chkCroquis.Checked = false;
                chkConstanciaRegistro.Checked = false;
                chkOtro.Checked = false;
                chkDocumentosEx.Checked = false;
                txtObservaciones.Text = "Limpiando";
        }
        #endregion
        #region  SessionClose
        protected void afterOut(object sender, EventArgs e)
        {
            Debug.Write("\nfallo1\n");
            Session.Abandon();
        }

        protected void previewOut(object sender, LoginCancelEventArgs e)
        {
            Debug.Write("\nfallo2\n");
        }
        #endregion
        #region TramiteCalculoChecks
        //CHK1
        protected void chkRenovacion_CheckedChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            clave = "RDC";
            float pre = cPrecio(clave);

            if (this.chkRenovacion.Checked == true)
            {    
                    TotalPrecio += pre;
                    lblPrecio.Text = TotalPrecio.ToString();
                    RDC += pre;
            }
            else
            {
                    TotalPrecio -= pre;
                    lblPrecio.Text = TotalPrecio.ToString();
                    RDC -= pre;
            }
         
        }
        //CHK2
        protected void chkCopiasCer_CheckedChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            if (chkCopiasCer.Checked == true)
            {
                //SE hablitael dropList
                drdCopias.Enabled = true; 
            }
            else
            {
                if (duplicados == 0)
                {
                    drdCopias.Enabled = false;

                }
                else
                {
                    TotalPrecio -= duplicados;
                    drdCopias.Enabled = false;
                    lblPrecio.Text = TotalPrecio.ToString();
                    duplicados = 0;
                    CSP -= CSP;
                }
            }
        }
        //CHK3
        protected void chkCertificadoM_CheckedChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            clave = "CMC";
            float pre = cPrecio(clave);
            if (chkCertificadoM.Checked == true)
            {
                TotalPrecio += pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CMC += pre;
            }
            else
            {
                TotalPrecio -= pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CMC -= pre;
            }
        }
        //CHK4
        protected void chkConstanciaUnica_CheckedChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            clave = "CUP";
            float pre = cPrecio(clave);
            if (chkConstanciaUnica.Checked == true)
            {
                TotalPrecio += pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CUP += pre;
            }
            else
            {
                TotalPrecio -= pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CUP -= pre;
            }
        }
        //CHK5
        protected void chkNumOficial_CheckedChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            clave = "CNO";
            float pre = cPrecio(clave);
            if (chkNumOficial.Checked == true)
            {
                TotalPrecio += pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CNO += pre;
            }
            else
            {
                TotalPrecio -= pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CNO -= pre;
            }
        }
        //CHK6
        protected void chkNopropiedad_CheckedChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            clave = "CNP";
            float pre = cPrecio(clave);
            if (chkNopropiedad.Checked == true)
            {
                TotalPrecio += pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CNP +=pre;
            }
            else
            {
                TotalPrecio -= pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CNP -= pre;
            }
        }
        //CHK7
        protected void chkRegistroC_CheckedChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            clave = "CDR";
            float pre = cPrecio(clave);
            if (chkRegistroC.Checked == true)
            {
                TotalPrecio += pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CDR += pre;
            }
            else
            {
                TotalPrecio -= pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CDR += pre;
            }
        }
        //CHK8
        protected void chkCroquisLoc_CheckedChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            clave = "CDL";
            float pre = cPrecio(clave);
            if (chkCroquisLoc.Checked == true)
            {
                TotalPrecio += pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CDL += pre;
            }
            else
            {
                TotalPrecio -= pre;
                lblPrecio.Text = TotalPrecio.ToString();
                CDL -= pre;
            }
        }
        //CHK9 ENVIO pa
        protected void chkMetodoEnvio_CheckedChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            if (chkMetodoEnvio.Checked == true)
            {
                //SE hablitael dropList
                drMetodoEnvioS.Enabled = true;
                obtencionEnvios();
            }
            else
            {
                drMetodoEnvioS.Enabled = false;

            }

        }
        //Get PreciosTramites()
        public float cPrecio(String clv)
        {
            String p="";
            p = clv;
            var c = "";
            int total = tbPreciosTramite.Rows.Count;
            float precio=0;
            for (int t = 0; t < total; t++)
            {
                c = tbPreciosTramite.Rows[t]["ClaveTramite"].ToString();
                if (p == c)
                {
                   
                   //Como Convertir de STRING A FLOAT
                    precio = float.Parse(tbPreciosTramite.Rows[t]["Precio"].ToString());
                    break;
                }
                else
                {
                    Debug.Write("La Clave es inexistente");
                    precio = 0;
                }
            }
            return precio;
        }
        //getPrecioEnvio()
        
      
        #endregion
        #region GenerarReporte

        protected void btnGenerarAcuse_clicklistener(object sender, EventArgs e)
        {
            if (consultaClave.getFolio().Equals(""))
            {
                alertNumero = 3;
                ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-warning'); 
                                                          $('#MainContent_mensajeTitulo').text('Informativo');$('#MainContent_mensajeCuerpo').text('Usted no ha elegido un tramite de la tabla para poder generar su acuse. Seleccione uno y pruebe volver a intentarlo.');});", true);

                ScriptManager.RegisterStartupScript(this, GetType(),
                      "alert1", "$('#alert').modal('show');", true);   
            }
            else
            {
      
                
                try
                {
                    
                    consultaClave.setClave((string)Session["ClvCat"]);
                    if (consultaClave.cConsultaAcuseTramite() == true)
                    {

                        regresaReport();
                        consultaClave.setFolio("");
                        alertNumero = 4;
                        Response.Buffer = false;
                        Response.ClearContent();
                        Response.ClearHeaders();
                        crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Acuse de recivido");
                        HttpContext.Current.ApplicationInstance.CompleteRequest();  
                    }
                    else
                    {
                        alertNumero = 3;

                        ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-danger'); 
                                                          $('#MainContent_mensajeTitulo').text('Error');$('#MainContent_mensajeCuerpo').text('A causa de un error no se ha podido generar el acuse de su tramite. Intentelo mas tarde.');});", true);

                        ScriptManager.RegisterStartupScript(this, GetType(),
                              "alert1", "$('#alert').modal('show');", true);  
                
                    }
                }
                catch (CrystalDecisions.CrystalReports.Engine.InvalidArgumentException ex)
                {
                    alertNumero = 3;

                    ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-danger'); 
                                                          $('#MainContent_mensajeTitulo').text('Exito');$('#MainContent_mensajeCuerpo').text('A causa de un error no se ha podido generar el acuse de su tramite. Intentelo mas tarde."+ex.ToString() +"');});", true);

                    ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert1", "$('#alert').modal('show');", true);  
                

                }  
            }
        }
        public void regresaReport()
        {
             string  rdc="",cmc="",cno="",cdr="",
                     cpc = "", cup = "", crl = "", cnp = "" ;
            tbReport = consultaClave.getdatosRe();
            //valores Iniciados para evaluacion
            rdc = tbReport.Rows[0]["RenovacionCedula"].ToString();
            cmc = tbReport.Rows[0]["CerMedidasColindancia"].ToString();
            cno=tbReport.Rows[0]["ConstanciaNumero"].ToString();
            cdr=tbReport.Rows[0]["ConstanciaRegistro"].ToString();
            cpc = tbReport.Rows[0]["CopiaCertificada"].ToString();
            cup = tbReport.Rows[0]["constanciapropiedad"].ToString();
            crl = tbReport.Rows[0]["Croquis"].ToString();
            cnp = tbReport.Rows[0]["constanciaNopropiedad"].ToString();

            //valores que se puden obtener directamente
            crystalReport.Load(Server.MapPath("Reportes/Acuse.rpt"));
            crystalReport.SetParameterValue("ClaveCatastral_bd", tbReport.Rows[0]["ClaveCatastral"].ToString());
            crystalReport.SetParameterValue("CuentaPredial_bd", tbReport.Rows[0]["Cuenta"].ToString());
            crystalReport.SetParameterValue("RazonSocial_bd",    tbReport.Rows[0]["RazoSoc"].ToString());
            crystalReport.SetParameterValue("RFC_bd",            tbReport.Rows[0]["RFC"].ToString());

            crystalReport.SetParameterValue("nombreUno_bd", tbReport.Rows[0]["Nombre1"].ToString());
            crystalReport.SetParameterValue("nombreDos_bd", tbReport.Rows[0]["Nombre2"].ToString());
            crystalReport.SetParameterValue("apPaterno_bd", tbReport.Rows[0]["ApellidoP"].ToString());
            crystalReport.SetParameterValue("apMaterno_bd", tbReport.Rows[0]["ApellidoM"].ToString());

            crystalReport.SetParameterValue("callePropietario_bd",   tbReport.Rows[0]["CallePropietario"].ToString());
            crystalReport.SetParameterValue("coloniaPropietario_bd", tbReport.Rows[0]["ColoniaPropietario"].ToString());
            crystalReport.SetParameterValue("localidadPropietario",  tbReport.Rows[0]["CiudadPropietario"].ToString());
            crystalReport.SetParameterValue("telefonoPropietario_bd",tbReport.Rows[0]["NumPropietario"].ToString());

            crystalReport.SetParameterValue("callePredio_bd",      tbReport.Rows[0]["CallePredio"].ToString());
            crystalReport.SetParameterValue("localidadPredio_bd",  tbReport.Rows[0]["ColoniaPredio"].ToString());
            crystalReport.SetParameterValue("referenciasPredio_bd",tbReport.Rows[0]["CallesPredio"].ToString());
            if (rdc.Equals("True"))
            {
                crystalReport.SetParameterValue("rdp_bd", "X");
            }
            else
            {
                crystalReport.SetParameterValue("rdp_bd", "  ");
            }
            if(cmc.Equals("True"))
            {
                crystalReport.SetParameterValue("cmc_bd","X");
            }else
            {
                crystalReport.SetParameterValue("cmc_bd"," ");
            }
           if (cno.Equals("True"))
            {
                crystalReport.SetParameterValue("cno_bd","X" ); 
            }
           else
            {
              crystalReport.SetParameterValue("cno_bd"," " );   
            }
            if (cdr.Equals("True"))
            {
               crystalReport.SetParameterValue("cdr_bd", "X");                
            } 
            else
            {
               crystalReport.SetParameterValue("cdr_bd", " ");      
            }
            //segunda parte de denomiancion
            if (cpc.Equals("True"))
            {
               crystalReport.SetParameterValue("csp_bd","X" );
            }
            else
            {
               crystalReport.SetParameterValue("csp_bd", " ");
            }
            if (cup.Equals("True"))
            {
               crystalReport.SetParameterValue("cup_bd","X" );
            } 
            else
            {
               crystalReport.SetParameterValue("cup_bd", " " );
            }
            if (crl.Equals("True"))
            {
               crystalReport.SetParameterValue("cdl_bd", "X");
            } 
            else
            {
               crystalReport.SetParameterValue("cdl_bd"," ");
            }
            if (cnp.Equals("True"))
            {
               crystalReport.SetParameterValue("cnp_bd", "X");
            } 
            else
            { 
                crystalReport.SetParameterValue("cnp_bd", " ");
            }
            crystalReport.SetParameterValue("observaciones_bd", tbReport.Rows[0]["Observaciones"].ToString());
        }
        #endregion
        #region Nuevo Tramite     
        protected void btnCrearTramite_Click(object sender, EventArgs e)
        {
            if (verificarChk() == true)
            {
                /** Init***/
                consultaClave.cConsultarUltimoFolio();
                consultaClave.cConsultarUltimoTramite();
                var drTotalCopias = "";
                  /***Asignar valores***/
                idTramite = Convert.ToInt32(consultaClave.getUltimoID()) + 1;
                int folio = Convert.ToInt32(consultaClave.getUltimoFolio()) + 1;
                /*Clave Catastral y datos del usuario**/
                string cat = txtClaveCatastral.Text;
                string n1 = txtNombre_uno.Text;
                string n2 = txtNombre_dos.Text;
                string ap = txtApellidoPaterno.Text;
                string am = txtApellidoMaterno.Text;
                String comentarios = txtObservacionesData.Text;
                bool rdc = this.chkRenovacion.Checked;
                bool cmc = this.chkCertificadoM.Checked;
                bool cno = this.chkNumOficial.Checked;
                bool cdr = this.chkRegistroC.Checked;
                bool cpc = this.chkCopiasCer.Checked;
                if (cpc == true)
                {
                    //Total Copias
                    drTotalCopias = drdCopias.SelectedItem.Value.ToString();
                    //asignar un status
                    status = 3;
                }
                else
                {
                    //asignar status y poner 0 copias
                    drTotalCopias = "0";
                    status = 1;
                }
                bool cup = this.chkConstanciaUnica.Checked;
                bool cdl = this.chkCroquisLoc.Checked;
                bool envio = this.chkMetodoEnvio.Checked;
                if (envio == true)
                {
                    var mEnvio = drMetodoEnvioS.SelectedItem.Value;
                    if (mEnvio == "0")
                    {

                    }
                    else
                    {
                        //BUSCAR IDE envio
                        consultaClave.cConsultarIDEnvio(mEnvio);
                        idEn = Convert.ToInt32(consultaClave.getidEnvio());
                    }
                }
                else
                {

                }
                if (Envio.Text.ToString() == "00")
                {
                    total = float.Parse(lblPrecio.Text.ToString());
                }
                else
                {
                    precioEnvio = float.Parse(Envio.Text.ToString());
                    tramitePrecios = float.Parse(lblPrecio.Text.ToString());
                    total = (precioEnvio + tramitePrecios);
                }

                /***Ide del Terreno**/
                int terrnoId = Convert.ToInt32(consultaClave.consultaIdTerreno());

                bool cnp = chkNopropiedad.Checked;
                /////Set Datos
                consultaClave.setIdTramite(idTramite);
                consultaClave.setNuevoFolio(folio);
                consultaClave.setEnvioId(idEn);
                consultaClave.setClvCatastral(cat);
                consultaClave.setNombre_uno(n1);
                consultaClave.setNombre_dos(n2);
                consultaClave.setApePaterno(ap);
                consultaClave.setApeMaterno(am);
                consultaClave.setComentarios(comentarios);
                consultaClave.setArchivoInser(archivo);
                consultaClave.setStatusInser(status);
                consultaClave.setRenovacion(rdc);
                consultaClave.setCopiasCer(cpc);
                consultaClave.setCerMedidas(cmc);
                consultaClave.setConsUnicap(cup);
                consultaClave.setConsNumOff(cno);
                consultaClave.setConstRegistro(cdr);
                consultaClave.setCroquis(cdl);
                consultaClave.setConstanciaNoRegistro(cnp);
                consultaClave.setTotalCopias(drTotalCopias);
                consultaClave.setTerrenoId(terrnoId);
                consultaClave.setTotalTramite(total);
               

                //validacion de la insercion
                if (consultaClave.crearTramite() == true && inserDetalleTramite(idTramite) == true)
                {

                        llenaDatosTramites_Denominación();
                        clearControls();
                        alertNumero = 4;
                        
                        ScriptManager.RegisterStartupScript(this, GetType(),
                            "cerrarActModal", "$('#myModal').modal('toggle');", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                              $('#MainContent_tipeError').addClass('modal-header-success'); 
                                                              $('#MainContent_mensajeTitulo').text('Exito'); $('#MainContent_mensajeUsuario').addClass('textalerta'); " +  
                                                              "$('#MainContent_mensajeCuerpo').text('Usted ha creado un nuevo tramite');});", true);
                        ScriptManager.RegisterStartupScript(this, GetType(),
                              "alert1", "$('#alert').modal('show');", true); 
                }
                else
                {
                        llenaDatosTramites_Denominación();
                        clearControls();
                        alertNumero = 4;
                        
                        ScriptManager.RegisterStartupScript(this, GetType(),
                        "cerrarActModal", "$('#myModal').modal('toggle');", true);

                        ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-danger'); 
                                                          $('#MainContent_mensajeTitulo').text('Error');
                                                          $('#MainContent_mensajeCuerpo').text('Ha surgido un error crear su tramite  intentelo mas tarde');});", true);

                        ScriptManager.RegisterStartupScript(this, GetType(),
                              "alert1", "$('#alert').modal('show');", true);                
                }
            }
            else
            {
                llenaDatosTramites_Denominación();
                alertNumero = 4;
                clearControls();
                ScriptManager.RegisterStartupScript(this, GetType(),
                 "cerrarActModal", "$('#myModal').modal('toggle');   ", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-warning'); 
                                                          $('#MainContent_mensajeTitulo').text('Advertencia');$('#MainContent_mensajeCuerpo').text('Verifique al menos un tramite esta seleccionado');});", true);
                ScriptManager.RegisterStartupScript(this, GetType(),
                      "alert1", "$('#alert').modal('show');", true);  
            }
        }
        protected void btnCancelarCreartramite_Click(object sender, EventArgs e)
        {
            this.chkRenovacion.Checked = false;
            this.chkCertificadoM.Checked = false;
            bool cno = this.chkNumOficial.Checked = false;
            bool cdr = this.chkRegistroC.Checked = false;
            bool cpc = this.chkCopiasCer.Checked = false;
            bool cup = this.chkConstanciaUnica.Checked = false;
            bool cdl = this.chkCroquisLoc.Checked = false;
            bool cnp = this.chkNopropiedad.Checked = false;
            this.chkMetodoEnvio.Checked = false;
            total = 0;
            duplicados = 0;
            tramitePrecios = 0;
            precioEnvio = 0;
            TotalPrecio = 0;
            lblPrecio.Text = "00";
            ScriptManager.RegisterStartupScript(this, GetType(),
                   "cerrarActModal", "$('#myModal').modal('toggle');   ", true);
            this.Page.Title = "Modulo de Tramites | Principal";
        }
        public bool verificarChk()
        {
                bool ver = false;
                bool rdc = this.chkRenovacion.Checked;
                bool cmc = this.chkCertificadoM.Checked;
                bool cno = this.chkNumOficial.Checked;
                bool cdr = this.chkRegistroC.Checked;
                bool cpc = this.chkCopiasCer.Checked;
                bool cup = this.chkConstanciaUnica.Checked;
                bool cdl = this.chkCroquisLoc.Checked;
                bool cnp = this.chkNopropiedad.Checked;
                if (rdc == false && cmc == false && cno == false && cdr == false && cpc == false && cup == false && cdl == false && cnp==false)
                {
                    return ver;

                }
                else 
                {
                    ver = true;
                    return ver;
                }
            
        }
        public bool inserDetalleTramite(int idTramite)
        {
            //IDDetalle
            consultaClave.cCbusquedaIncrementarId();
           
            List<Tuple<int,int,int,int,float>> list = new  List<Tuple<int,int,int,int,float>>();
            TramiteDetalleID = incrementoId();

            float p = 0;
            int idTramitePrecio=0, cant;
            
            bool rdc = this.chkRenovacion.Checked;
            if (rdc == true)
            {
                clave = "RDC";
                p = cPrecio(clave);
                idTramitePrecio= idDelPrecio(clave);
                cant = 1;
               
                list.Add(new Tuple<int,int,int,int,float>(idTramite,TramiteDetalleID,idTramitePrecio,cant,p));
              
                TramiteDetalleID +=1;
            }
            else
            {

            }
            bool cmc = this.chkCertificadoM.Checked;
            if (cmc == true)
            {
                clave = "CMC";
                p = cPrecio(clave);
                idTramitePrecio= idDelPrecio(clave);
                cant = 1;
                list.Add(new Tuple<int,int,int,int,float>(idTramite,TramiteDetalleID,idTramitePrecio,cant,p));
                TramiteDetalleID +=1;
            }
            else
            {

            }
            bool cno = this.chkNumOficial.Checked;
            if(cno == true)
            {
               
                clave = "CNO";
                p = cPrecio(clave);
                idTramitePrecio= idDelPrecio(clave);
                cant = 1;
                list.Add(new Tuple<int,int,int,int,float>(idTramite,TramiteDetalleID,idTramitePrecio,cant,p));
                TramiteDetalleID +=1;
            }else
            {

            }
            bool cdr = this.chkRegistroC.Checked;
            if(cdr == true)
            {
              clave="CDR";
              p = cPrecio(clave);
              idTramitePrecio= idDelPrecio(clave);
              cant = 1;
               list.Add(new Tuple<int,int,int,int,float>(idTramite,TramiteDetalleID,idTramitePrecio,cant,p));
                TramiteDetalleID +=1;
            }else
            {

            }
            bool cpc = this.chkCopiasCer.Checked;
            if(cpc==true)
            {
              clave = "CSP";
              p = cPrecio(clave);
              idTramitePrecio= idDelPrecio(clave);
              cant = Int32.Parse(drdCopias.SelectedItem.Value);
              list.Add(new Tuple<int,int,int,int,float>(idTramite,TramiteDetalleID,idTramitePrecio,cant,p));
                TramiteDetalleID +=1;

            }else
            {
            }
            bool cup = this.chkConstanciaUnica.Checked;
            if(cup == true)
            {
               clave = "CUP";
               p = cPrecio(clave);
              idTramitePrecio= idDelPrecio(clave);
              cant = 1;
               list.Add(new Tuple<int,int,int,int,float>(idTramite,TramiteDetalleID,idTramitePrecio,cant,p));
                TramiteDetalleID +=1;
            }
            bool cdl = this.chkCroquisLoc.Checked;
            if(cdl == true)
            {
                clave = "CDL";
               
               p = cPrecio(clave);
              idTramitePrecio= idDelPrecio(clave);
              cant = 1;
              list.Add(new Tuple<int,int,int,int,float>(idTramite,TramiteDetalleID,idTramitePrecio,cant,p));
                TramiteDetalleID +=1;
            }
            else
            {
            }
            bool cnp = this.chkNopropiedad.Checked;
            if(cnp ==true)
            {
                clave = "CNP";
                p = cPrecio(clave);
              idTramitePrecio= idDelPrecio(clave);
              cant = 1;
              list.Add(new Tuple<int,int,int,int,float>(idTramite,TramiteDetalleID,idTramitePrecio,cant,p));
                         
            }
            else
            {

            }

            if (consultaClave.cInsertarTRDetalle(list) == true)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public int idDelPrecio(String clv)
        {
            String p = "";
            p = clv;
            var c = "";
            int total = tbPreciosTramite.Rows.Count;
            int id = 0;
            for (int t = 0; t < total; t++)
            {
                c = tbPreciosTramite.Rows[t]["ClaveTramite"].ToString();
                if (p == c)
                {

                    //Como Convertir de STRING A FLOAT
                    id = Convert.ToInt32(tbPreciosTramite.Rows[t]["IDTramtePrecios"].ToString());
                        
                    break;
                }
                else
                {
                    Debug.Write("La Clave es inexistente");
                    id = 0;
                }
            }
            return id;
        }
        public int incrementoId()
        {
            int i = consultaClave.getDetalleId();
            
            if (i > 0)
            {
                i += 1;
                return i;
            }
            else
            {
                i = 1;
                consultaClave.setDetalleId(i);
                return i;
            }
        }

        public void clearControls()
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            this.chkRenovacion.Checked = false;
            this.chkCertificadoM.Checked = false;
            this.chkNumOficial.Checked = false;
            this.chkRegistroC.Checked = false;
            this.chkCopiasCer.Checked = false;
            this.chkConstanciaUnica.Checked = false;
            this.chkCroquisLoc.Checked = false;
            this.chkNopropiedad.Checked = false;
            this.chkMetodoEnvio.Checked = false;

            total = 0;
            duplicados = 0;
            tramitePrecios = 0;
            precioEnvio = 0;
            TotalPrecio = 0;
            lblPrecio.Text = "00";
            drMetodoEnvioS.Items.Clear();
            Envio.Text = "00";
            //Limpieza de Controles
     
        }
        #endregion
        #region Actualizaciones
        protected void btnActualizarArchivo_Click(object sender, EventArgs e)
        {
            gvCustomers.SelectedIndex = -1;
            if (UpFile.PostedFile == null || UpFile.PostedFile.ContentLength == 0 || UpFile.FileBytes.Length >= 1024000)
            {
                alertNumero = 3;
                ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').removeClass('modal-header-danger');
                                                          $('#MainContent_tipeError').removeClass('modal-header-info');
                                                          $('#MainContent_tipeError').removeClass('modal-header-succes');
                                                          $('#MainContent_tipeError').addClass('modal-header-warning'); 
                                                          $('#MainContent_mensajeTitulo').text('Advertencia');
                                                          $('#MainContent_mensajeCuerpo').text('No existe un archivo para ser alamcenado o este archivo supera el tamaño de 1 mb');});", true);
                ScriptManager.RegisterStartupScript(this, GetType(),
                      "alert1", "$('#alert').modal('show');", true);
                this.Page.Title = "Modulo de Tramites | Principal";
            }
            else
            {
                string filePath = UpFile.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                Stream fs = UpFile.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                consultaClave.setArchivo(bytes);
                if (consultaClave.cActualizacionArchivo() == true)
                {
                    alertNumero = 3;
                    ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').removeClass('modal-header-danger');
                                                          $('#MainContent_tipeError').removeClass('modal-header-warning');
                                                          $('#MainContent_tipeError').removeClass('modal-header-info');
                                                          $('#MainContent_tipeError').addClass('modal-header-success'); 
                                                          $('#MainContent_mensajeTitulo').text('Exito'); $('#MainContent_mensajeUsuario').addClass('textalerta'); " +
                                                         "$('#MainContent_mensajeCuerpo').text('Exito  al actualizar su archivo de pago');});", true);
                    ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert1", "$('#alert').modal('show');", true);
                    this.Page.Title = "Modulo de Tramites | Principal";
                    bytes = null;
                    consultaClave.setArchivo(bytes);
                    consultaClave.setArchivo(null);
                    consultaClave.setFolio("");
                }
                else
                {
                    bytes = null;
                    consultaClave.setArchivo(bytes);
                    consultaClave.setArchivo(null);
                    consultaClave.setFolio("");
                    ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').removeClass('modal-header-info');
                                                          $('#MainContent_tipeError').removeClass('modal-header-warning');
                                                          $('#MainContent_tipeError').removeClass('modal-header-success');
                                                          $('#MainContent_tipeError').addClass('modal-header-danger'); 
                                                          $('#MainContent_mensajeTitulo').text('Error');
                                                          $('#MainContent_mensajeCuerpo').text('A causa de un erro su archivo no pudo ser enviado satisfactoriamente. Intentelo mas tarde.');});", true);
                    ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert1", "$('#alert').modal('show');", true);
                    this.Page.Title = "Modulo de Tramites | Principal";
                }
            }
            
        }

        protected void btnCancelar_clicklistener(object sender, EventArgs e)
        {           
            this.Page.Title = "Modulo de Tramites | Principal";
            String status = "2";
            consultaClave.setStatusCancelado(status);
            if (consultaClave.getFolio().Equals(""))
            {
                alertNumero = 3;
                ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').removeClass('modal-header-success');
                                                          $('#MainContent_tipeError').removeClass('modal-header-danger');
                                                          $('#MainContent_tipeError').removeClass('modal-header-warning');
                                                          $('#MainContent_tipeError').addClass('modal-header-info'); 
                                                          $('#MainContent_mensajeTitulo').text('Informativo');
                                                          $('#MainContent_mensajeCuerpo').text('Usted no ha elegido un tramite de la tabla para poder cancelarlo. Seleccione uno y pruebe volver a intentarlo.');});", true);
                ScriptManager.RegisterStartupScript(this, GetType(),
                      "alert1", "$('#alert').modal('show');", true);
                this.Page.Title = "Modulo de Tramites | Principal";
            }
            else
            {
                if (consultaClave.cCancelacionTramite() == true)
                {
                    alertNumero = 3;
                    status = "";
                    consultaClave.setStatusCancelado(status);
                    ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').removeClass('modal-header-warning');
                                                          $('#MainContent_tipeError').removeClass('modal-header-danger');
                                                          $('#MainContent_tipeError').addClass('modal-header-success'); 
                                                          $('#MainContent_mensajeTitulo').text('Exito');
                                                          $('#MainContent_mensajeCuerpo').text('Usted ha cancelado su tramite');});", true);

                    ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert1", "$('#alert').modal('show');", true);
                    this.Page.Title = "Modulo de Tramites | Principal";
                    llenaDatosTramites_Denominación();
                }
                else
                {
                    alertNumero = 3;
                    ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').removeClass('modal-header-success');
                                                          $('#MainContent_tipeError').removeClass('modal-header-warning');
                                                          $('#MainContent_tipeError').addClass('modal-header-danger'); 
                                                          $('#MainContent_mensajeTitulo').text('Exito');
                                                          $('#MainContent_mensajeCuerpo').text('A causa de un error no se ha podido cancelar su tramite. Intentelo mas tarde.');});", true);
                    ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert1", "$('#alert').modal('show');", true);
                    this.Page.Title = "Modulo de Tramites | Principal";
                }
            }

        }
        #endregion


        //Verificar Mensaje de Exito y falla
        protected void btnEditarContacto_clicklistener(object sender, EventArgs e)
        {
            
           editNombre = txtedit_NombreContacto.Text.Replace(";", "").Replace("--", "");
            string editEmail = txtedit_Email.Text.Replace(";", "").Replace("--", "");
            string editTelefono = txtedit_NumeroTelefono.Text.Replace(";", "").Replace("--", "");
           // setCambio();
            if (editNombre != null && editNombre != "" &&
                editEmail != null && editEmail != "" &&
                editTelefono != null && editTelefono != "")
            {
                
                consultaClave.setContacto(editNombre);
                consultaClave.setEmail(editEmail);
                consultaClave.setTelefono(editTelefono);
                if (consultaClave.editUsuario() == true)
                {
                    //setCorrecto(); 
                    txtedit_NombreContacto.Text = "";
                    txtedit_Email.Text = "";
                    txtedit_NumeroTelefono.Text = "";
                    
                   
                    alertNumero = 1;
                  
                    
                    ScriptManager.RegisterStartupScript(this, GetType(),
                     "cerrarActualizarUsuario", "$('#ActualizarUsuario').modal('toggle');   ", true);
                    string name = @"$('#MainContent_mensajeUsuario').html('Usuario:" + " " + editNombre +"<br>"+
                                                                    "Correo:" + " " + editEmail + "" + "<br>" +
                                                                    "Telefono" + " " + editTelefono + "');";
                 
                    ScriptManager.RegisterStartupScript(this, GetType(), "ExitoActualizarUsuario", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-success'); 
                                                          $('#MainContent_tipeError').removeClass('modal-header-danger');
                                                          $('#MainContent_tipeError').removeClass('modal-header-warning');
                                                          $('#MainContent_mensajeTitulo').text('Exito'); 
                                                          $('#MainContent_mensajeUsuario').addClass('textalerta'); " + name +
                                                         "$('#MainContent_mensajeCuerpo').text('Exito al camabiar su usuario');});", true);   

                    ScriptManager.RegisterStartupScript(this, GetType(),
                          "AbrirModalAlerta", "$('#alert').modal('show');", true);
                    this.Page.Title = "Modulo de Tramites | Principal";
                   }
                else
                {
                    //setCorrecto(); 
                    txtedit_NombreContacto.Text = "";
                    txtedit_Email.Text = "";
                    txtedit_NumeroTelefono.Text = "";
                    alertNumero = 2;
                    ScriptManager.RegisterStartupScript(this, GetType(),
                   "cerrarActModal", "$('#ActualizarUsuario').modal('toggle');   ", true);
                  

                    ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').removeClass('modal-header-success');
                                                          $('#MainContent_tipeError').removeClass('modal-header-warning');
                                                          $('#MainContent_tipeError').addClass('modal-header-danger'); 
                                                          $('#MainContent_mensajeTitulo').text('Error');$('#MainContent_mensajeCuerpo').text('Ha surgido un error al almacenar sus datos intentelo mas tarde');});", true);

                    ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert1", "$('#alert').modal('show');", true);
                    this.Page.Title = "Modulo de Tramites | Principal";
                }
              }
            else
            {
                //setCorrecto(); 
                txtedit_NombreContacto.Text = "";
                txtedit_Email.Text = "";
                txtedit_NumeroTelefono.Text = "";
                alertNumero = 2;
                ScriptManager.RegisterStartupScript(this, GetType(),
                  "cerrarActModal", "$('#ActualizarUsuario').modal('toggle');   ", true);


                ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').removeClass('modal-header-success');
                                                          $('#MainContent_tipeError').removeClass('modal-header-danger');
                                                          $('#MainContent_tipeError').addClass('modal-header-warning'); 
                                                          $('#MainContent_mensajeTitulo').text('Advertencia');$('#MainContent_mensajeCuerpo').text('Verifique que los datos que esta agregando sean correctos');});", true);

                ScriptManager.RegisterStartupScript(this, GetType(),
                      "alert1", "$('#alert').modal('show');", true);
                this.Page.Title = "Modulo de Tramites | Principal";
            }

        }

        protected void btnCerrarModal_clicklistener(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(),
                      "cerrarActualizarUsuario", "$('#ActualizarUsuario').modal('toggle');", true);
            this.Page.Title = "Modulo de Tramites | Principal";
        }

        //seleccion Drlist
        protected void drMetodoEnvioS_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
           var da = drMetodoEnvioS.SelectedItem.Value.ToString();
           if (drMetodoEnvioS.SelectedIndex == 0)
           {
               Envio.Text = "0";
           }
           else if (da == "Correos de Mexico")
           {
               Envio.Text = val1.ToString();
           }
           else 
           {
               Envio.Text = val2.ToString();
           }
        }

        protected void drdCopias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            clave = "CSP";
            float pre = cPrecio(clave);
           
            if (drdCopias.SelectedItem.Value != "0" )
            {
                if (duplicados == 0)
                {
                    mul = float.Parse(drdCopias.SelectedItem.Value.ToString());
                    duplicados = pre * mul;
                    //Se hace la sumatoria en total Precios
                    TotalPrecio += duplicados;
                    //Se imprime en el Label
                    lblPrecio.Text = TotalPrecio.ToString();
                    CSP += pre;
                }
                else
                {
                    TotalPrecio -= duplicados;
                    mul = float.Parse(drdCopias.SelectedItem.Value.ToString());
                    duplicados = pre * mul;
                    //Se hace la sumatoria en total Precios
                    TotalPrecio += duplicados;
                    //Se imprime en el Label
                    lblPrecio.Text = TotalPrecio.ToString();
                    CSP -= pre;

                }
                 
            
            }else if(drdCopias.SelectedItem.Value == "0")
            {
                drdCopias.Enabled = false;
                chkCopiasCer.Checked = false;
                TotalPrecio -= duplicados;
                lblPrecio.Text = TotalPrecio.ToString();
                duplicados = 0;
            }

        }

       

        protected void btnCloseModalAction_onClick(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            switch (alertNumero)
            {
                case 1:
                    //cambio de usuario exitoso
                    FormsAuthentication.RedirectFromLoginPage(editNombre, false);
                    ScriptManager.RegisterStartupScript(this, GetType(),
                           "ServerControlScript", "$('#alert').modal('toggle');", true);

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    break;
               case 2:
                    //cambio de usuario erroneo
                    ScriptManager.RegisterStartupScript(this, GetType(),
                          "ServerControlScript", "$('#alert').modal('toggle');", true);
                    break;
                   
                case 3:
                    //exito al subir archivo, cancelar tramite,
                    ScriptManager.RegisterStartupScript(this, GetType(),
                         "ServerControlScript", "$('#alert').modal('toggle');", true);
                    break;
                
                case 4:
                 //   Crear nuevo tramite exito
                    ScriptManager.RegisterStartupScript(this, GetType(),
                         "ServerControlScript", "$('#alert').modal('toggle');", true);
                    break;

                //   Crear nuevo tramite error
               
            }
        }

        protected void lnkEnvioArchivo_Click(object sender, EventArgs e)
        {
            int filePath = UpFile.FileBytes.Length;
            Response.Write(filePath);
        }

    
    }

}