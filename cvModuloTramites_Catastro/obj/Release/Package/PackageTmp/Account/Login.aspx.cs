using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cvModuloTramites_Catastro.Data;
using System.Diagnostics;
using System.Web.Security;
using System.Data;
namespace cvModuloTramites_Catastro.Account
{
    public partial class Login : System.Web.UI.Page
    {
        #region VariablesGlobales
        public static string cvCatastral_contacto = "";
        public static Busqueda_cvCat consultaClave = new Busqueda_cvCat();
        public static DataTable  tbContacto=null;
        public static int val = 0;
        #endregion
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string secc = (string)Session["ClvCat"];
                consultaClave.setClave(secc);
                if (secc == "" || secc == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-info'); 
                                                          $('#MainContent_mensajeTitulo').text('Informativo');
                                                          $('#MainContent_mensajeCuerpo').text('Su sesión a caducado.');});", true);
                    val = 3;
                }
                else
                {
                    if (consultaClave.consultaDatosContacto() == false)
                    {
                        Response.Redirect("usuarios/Register.aspx"); 
                    }
                    else
                    {
                        Response.Redirect("usuarios/MiCuenta/Principal.aspx");
                    }
                }
            }
        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            
            cvCatastral_contacto = ClaveCat.Text.Replace(";", "").Replace("--", "");
            if (cvCatastral_contacto != null && cvCatastral_contacto != "")
            {
                System.Threading.Thread.Sleep(5000);
                consultaClave.setClave(cvCatastral_contacto.ToString());
                if (consultaClave.consultaClave() == true)
                {
                    if (consultaClave.consultaDatosContacto() != false)
                    {
                       
                        val = 1;
                        tipeError.Attributes["class"] = "modal-header-success";
                        mensajeTitulo.Text = "Exito";
                        mensajeUsuario.CssClass = "text-nowrap";
                        mensajeUsuario.Text = "Usuario con la clave catastral:" + cvCatastral_contacto + ".";
                        mensajeCuerpo.Attributes["style"] = "text-nowrap";
                        mensajeCuerpo.InnerHtml = "Bienvenido. Usted se ha iniciado sesion correctamente";

                        ClientScript.RegisterStartupScript(GetType(), "Cumstom", "$('#alert').modal('show');", true);     
                    }
                    else
                    {
                        cl();
                        val = 2;
                        tipeError.Attributes["class"] = "modal-header-info";
                        mensajeTitulo.Text = "Informativo";
                        mensajeUsuario.CssClass = "text-nowrap";
                        mensajeUsuario.Text = "Usuario con la clave catastral:" + cvCatastral_contacto + ".";
                        mensajeCuerpo.Attributes["style"] = "text-nowrap";
                        mensajeCuerpo.InnerHtml = "No cuenta con los datos de contacto precione el boton de aceptar para ser redireccionado a la pagina de registro";

                        ScriptManager.RegisterStartupScript(this, GetType(),
                         "ServerControlScript", "$('#alert').modal('show');", true);         
                    }
                }
                else
                {
                    val = 3;


                    tipeError.Attributes["class"] = "modal-header-danger";
                    mensajeTitulo.Text = "Error";
                    mensajeUsuario.CssClass = "text-nowrap";
                    mensajeUsuario.Text = "Usuario con la clave catastral:" + cvCatastral_contacto + ".";
                    mensajeCuerpo.Attributes["style"] = "text-nowrap";
                    mensajeCuerpo.InnerHtml = "Verifique su conexion a internet  y que los datos que proporciono sean correctos." + "<br/>" + "Intentelo mas tarde.";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", "$('#alert').modal('show');", true);
             
                }
            }
        }
        public void cl()
        {
           Response.Clear();
           
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
        }

        protected void btnCloseModalAction_onClick(object sender, EventArgs e)
        {
            if(val == 1)
            {                       
               tbContacto = new DataTable();
               tbContacto = consultaClave.getDatos();
               Session["ClvCat"] = tbContacto.Rows[0]["cvecatastral"].ToString();
               String nombreContacto = tbContacto.Rows[0]["Nombre"].ToString(); 
               FormsAuthentication.RedirectFromLoginPage(nombreContacto, false);
               ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", "$('#alert').modal('toggle');", true);
               string script = "window.onload = function(){";
               script += "window.location ='usuarios/MiCuenta/Principal.aspx';}";
               ClaveCat.Text = "";
               ScriptManager.RegisterStartupScript(this, GetType(),
               "ServerControlScript", script, true);
               HttpContext.Current.ApplicationInstance.CompleteRequest();
              
            }else if (val == 2)
            {
                Session["ClvCat"] = cvCatastral_contacto.ToString();
                FormsAuthentication.RedirectFromLoginPage(cvCatastral_contacto, false);
                string script = "window.onload = function(){";
                script += "window.location ='usuarios/Register.aspx';}";
                ScriptManager.RegisterStartupScript(this, GetType(),
                           "ServerControlScript", "$('#alert').modal('toggle');", true);
                ClaveCat.Text = "";
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                ScriptManager.RegisterStartupScript(this, GetType(),
               "ServerControlScript", script, true);
            }else if (val == 3)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                           "ServerControlScript", "$('#alert').modal('toggle');", true);
                ClaveCat.Text = "";
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            
        }
    }
}
