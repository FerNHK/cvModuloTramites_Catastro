using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using cvModuloTramites_Catastro.Data;
using System.Diagnostics;
using System.Web.Security;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Configuration;
namespace cvModuloTramites_Catastro.Account.Usuarios.MiCuenta
{
    public partial class Contacto : System.Web.UI.Page
    {
        public static Tramite_Helper consultaClave = new Tramite_Helper();
      /**private static int exitoEditarDatos = 0, errorEditarDatos = 0,
                           exitoDescargarpdf = 0, errorDescargarpdf = 0,
                           exitoSubiArchivo = 0, errorSubirArchivo = 0,
                           exitoCrearTramite = 0, errorCreartramite = 0;**/
       // public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string clave = (string)Session["ClvCat"];
                consultaClave.setClave(clave);
                if (clave =="" || clave == null )
                {
                    Response.Write("Session caduco =" + clave);
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                   // Response.Redirect("Contacto.aspx");
                }

            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
         
            if (SendMail() == true)
            {              
                clear();
                ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-success'); 
                                                          $('#MainContent_mensajeTitulo').text('Exito'); $('#MainContent_mensajeUsuario').addClass('textalerta'); " + "$('#MainContent_mensajeCuerpo').text('Se ha enviado el correo de manera exitosa');});", true);


                ScriptManager.RegisterStartupScript(this, GetType(),
                      "alert1", "$('#alert').modal('show');", true); 
            }
            else
            {
                clear();
                ScriptManager.RegisterStartupScript(this, GetType(), "CumstomText", @"$(function(){
                                                          $('#MainContent_tipeError').addClass('modal-header-danger'); 
                                                          $('#MainContent_mensajeTitulo').text('Error');$('#MainContent_mensajeCuerpo').text('Ha surgido un error al enviar su correo. Intentelo mas tarde.');});", true);

                ScriptManager.RegisterStartupScript(this, GetType(),
                      "alert1", "$('#alert').modal('show');", true); 
               
            }
        }
        protected void btnCloseModalAction_onClick(object sender, EventArgs e)
        {
            this.Page.Title = "Modulo de Tramites | Principal";
           
                    ScriptManager.RegisterStartupScript(this, GetType(),
                           "ServerControlScript", "$('#alert').modal('toggle');", true);

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
            
        }
        #region Envio_correo
        public bool SendMail()
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"], "UsuarioCatastro:"+""+txtName.Text.ToString());
                    mailMessage.Subject = "DUDAS del Usuario Catastro:"+""+txtName.Text.ToString();
                    mailMessage.Body = @"Usuario:"+" "+txtName.Text.ToString()+"\n"+
                                        "Email:"+" "+txtEmail.Text+"\n"+
                                        "Numero telefonico:"+" "+txtTel.Text+"\n \n"+
                                        "Comentarios:"+" "+ txtComentario.Text ;
                    //Email de Soporte Tecnico
                    mailMessage.To.Add(new MailAddress("ookami_ferwt45@hotmail.com"));


                    if (UpFile.PostedFile != null)
                    {
                        string FileNameToAttache;
                        HttpPostedFile attFile = UpFile.PostedFile;
                        int attachFileLength = attFile.ContentLength;
                        if (attachFileLength > 0)
                        {
                            FileNameToAttache = Path.GetFileName(UpFile.PostedFile.FileName);
                            UpFile.PostedFile.SaveAs(Server.MapPath(FileNameToAttache));
                            mailMessage.Attachments.Add(new Attachment(Server.MapPath(FileNameToAttache)));
                        }
                    }

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                    NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    smtp.Send(mailMessage);
                    return true;


                }
            }
            catch (Exception )
            {
                return false;
            }
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

        #region Limpiar Controles
        public void clear()
        {
            txtName.Text = "";
            txtComentario.Text="";
            txtTel.Text = "";
            txtEmail.Text = "";
           
            
        }
        public void alerta()
        {

        }
        #endregion

       


    }
}