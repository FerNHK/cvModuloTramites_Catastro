using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Data.SqlTypes;

namespace cvModuloTramites_Catastro.Data
{
    public class Login_helper
    {
       
        #region Variableslogin_Contacto
        private ConeccionCatastro coneccion = new ConeccionCatastro();
        private SqlCommand comando = null;
        private SqlDataReader lector = null;
        private SqlDataAdapter daAdaptador = null;
        private DataTable user_datos = null;
        private bool verificación = false;
        private static string regesaClave = "",
                              contacto = "", 
                              email = "",
                              telefono = "";
        #endregion
        #region getYsetLogin_datosContacto
        //Establecer Clave Catastral
        public void setClave_Catastral(String clv)
        {
            regesaClave = clv;
        }
        //OBtener Clave Catastral
        public static String getClave_Catastral()
        {
            return regesaClave;
        }
        //Establecer (DataTable) datos de Cotacto
        public void setDatos_Contacto(DataTable tabUs)
        {
            this.user_datos = tabUs;
        }
        //Obtener (DataTable) datos de Cotacto
        public DataTable getDatos_Contacto()
        {
            return user_datos;
        }
        #endregion
        #region ConsultaLogin_DatosContacto
        //LOGIN
        public bool consultaClave()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.commando(), conn);
                    comando.Parameters.AddWithValue("@ClaveCatastral", getClave_Catastral());
                    int count = Convert.ToInt32(comando.ExecuteScalar());

                    if (count == 1)
                    {
                        verificación = true;
                    }
                    else
                    {
                        verificación = false;
                    }
                    conn.Close();
                    return verificación;
                }
            }
            catch (SqlException)
            {
                verificación = false;
                return verificación;
            }
        }
        //endLogin

        //Consulta y validación de datos de Usuario
        public bool consultaDatosContacto()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.busquedaDatosContacto(), conn);
                    comando.Parameters.AddWithValue("@ClaveCatastral", getClave_Catastral());
                    lector = comando.ExecuteReader();

                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            contacto = lector.GetString(0);
                            email = lector.GetString(1);
                            telefono = lector.GetString(2);

                        }

                        if (contacto != "" && contacto != null &&
                            email != "" && email != null &&
                            telefono != "" && telefono != null)
                        {
                            verificación = true;
                            conn.Close();
                            conn.Open();
                            daAdaptador = new SqlDataAdapter(comando);
                            DataTable dtDatos = new DataTable();
                            daAdaptador.Fill(dtDatos);
                            setDatos_Contacto(dtDatos);
                            conn.Close();
                        }
                        else
                        {
                            verificación = false;

                        }
                    }
                    else
                    {
                        verificación = false;
                    }

                    conn.Close();
                    return verificación;
                }
            }
            catch (SqlException)
            {
                verificación = false;
                return verificación;
            }
        }

        #endregion
    }
}