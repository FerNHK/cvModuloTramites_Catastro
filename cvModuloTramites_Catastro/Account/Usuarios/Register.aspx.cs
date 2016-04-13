using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using cvModuloTramites_Catastro.Data;
using System.Diagnostics;
using System.Data;

namespace cvModuloTramites_Catastro.Account
{
    public partial class Register : System.Web.UI.Page
    {
        #region Variables_
        private static String  contacto="", email="", tel="" ;
        public static Busqueda_cvCat consultaClave = new Busqueda_cvCat();
        public static int alerta = 0;
        #endregion
        #region Metodos
       
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string secc = (string)Session["ClvCat"];
                consultaClave.setClave(secc);
                if (secc == "" || secc == null)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    if (consultaClave.consultaDatosContacto() == false)
                    {
                       
                    }
                    else
                    {
                        Response.Redirect("MiCuenta/Principal.aspx");
                    }

                }

            }
        }
        
        protected void btnRegistrarContacto_Click(object sender, EventArgs e)
        {
           System.Threading.Thread.Sleep(3000);           
            contacto = txtNombreContacto.Text.ToString();
            email = txtEmail.Text.ToString();
            tel = txtNumeroTelefono.Text.ToString();

            if (contacto != "" || contacto != null ||
               email != "" || email != null
               || tel != "" || tel != null)
            {
                consultaClave.setContacto(contacto);
                consultaClave.setEmail(email);
                consultaClave.setTelefono(tel);
                if (consultaClave.RegistroUsuarioNuevo() == true)
                {

                    alerta = 2;
                    ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-success'); 
                                                          $('#MainContent_mensajeTitulo').text('Exito'); $('#MainContent_mensajeUsuario').addClass('textalerta'); " + "$('#MainContent_mensajeCuerpo').text('Exito  al almacenar sus datos de Contacto');});", true);
                    ScriptManager.RegisterStartupScript(this, GetType(),
                         "alert1", "$('#alert').modal('show');", true);

                }
                else
                {
                    clearControls();
                    alerta = 1;
                    ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-danger'); 
                                                          $('#MainContent_mensajeTitulo').text('Error');$('#MainContent_mensajeCuerpo').text('Ha surgido un error al almacenar sus datos intentelo mas tarde');});", true);

                    ScriptManager.RegisterStartupScript(this, GetType(),
                          "alert1", "$('#alert').modal('show');", true);


                  
                }
            }
            else
            {
                alerta = 1;
                
                ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-warning'); 
                                                          $('#MainContent_mensajeTitulo').text('Advertencia');$('#MainContent_mensajeCuerpo').text('¡Valores vacios en  los campos de texto. Verifique que esten escritos correctamente!');});", true);

                ScriptManager.RegisterStartupScript(this, GetType(),
                      "alert1", "$('#alert').modal('show');", true);
            }
        }



        protected void btnCloseModalAction_onClick(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
            switch (alerta)
            {
                case 1:
                    ScriptManager.RegisterStartupScript(this, GetType(),
                      "ServerControlScript", "$('#alert').modal('toggle');", true);
                    break;
                case 2:
                   
                    ScriptManager.RegisterStartupScript(this, GetType(),
                       "ServerControlScript", "$('#alert').modal('toggle');", true);
                    String nombreContacto = contacto;
                    FormsAuthentication.RedirectFromLoginPage(nombreContacto, false);
                    string script = "window.onload = function(){";
                    script    += "window.location ='MiCuenta/Principal.aspx';}";



                    ScriptManager.RegisterStartupScript(this, GetType(),
                   "sendData", script, true);

                   clearControls();
                 
                    break;
            }
        }
        #endregion

        #region Controles
        public void clearControls()
        {
            txtNombreContacto.Text = "";
            txtEmail.Text = "";
           
            txtNumeroTelefono.Text = "";
        }
        public void cl()
        {
            Response.Clear();

            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
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
    }
}
