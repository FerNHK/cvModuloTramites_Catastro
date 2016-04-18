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
    public class Register_Helper
    {
        #region VariablesGloables_RegistroContacto
        private ConeccionCatastro coneccion = new ConeccionCatastro();
        private SqlCommand comando = null;
        private SqlDataReader lector = null;
        private SqlDataAdapter daAdaptador = null;
        private DataTable user_datos = null;
        private bool verificación = false;
        private  string regesaClave = "",
                              contacto = "",
                              email = "",
                              telefono = "",
                              Terreno_id = " ";
        #endregion
        #region getYset_RegistroContacto
        //Establecer Clave Catastral
        public void setClave_Catastral(String clv)
        {
            regesaClave = clv;
        }
        //OBtener Clave Catastral
        public  String getClave_Catastral()
        {
            return regesaClave;
        }
        
        //Establecer y obtener  Datos de Contacto faltantes
        //nombre de Contacto.
        public void setContacto(String contac)
        {
            this.contacto = contac;
        }
        public String getContacto()
        {
            return contacto;
        }
        //email.
        public void setEmail(String cor)
        {
            this.email = cor;
        }
        public String getEmail()
        {
            return email;
        }
        //telefono
        public void setTelefono(String tel)
        {
            this.telefono = tel;
        }
        public String getTelefono()
        {
            return telefono;
        }
        #endregion  
        #region Inserta_RegistroContacto
        public bool RegistroUsuarioNuevo()
        {
            try
            {
                String id = consultaIdTerreno();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.insertaContacto(), conn);
                    comando.Parameters.AddWithValue("@idTerreno", id);
                    comando.Parameters.AddWithValue("@contacto", getContacto());
                    comando.Parameters.AddWithValue("@email", getEmail());
                    comando.Parameters.AddWithValue("@telefono", getTelefono());
                    int count = Convert.ToInt32(comando.ExecuteNonQuery());

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
            catch (SqlException )
            {
                verificación = false;
                return verificación;
            }

        }
        public String consultaIdTerreno()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.busquedaIdTerreno(), conn);
                    comando.Parameters.AddWithValue("@ClaveCatastral", getClave_Catastral());
                    lector = comando.ExecuteReader();
                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            Terreno_id = lector.GetInt32(0).ToString();
                        }
                    }
                    return Terreno_id;
                }
            }
            catch (SqlException)
            {
                return null;
            }
        }
        #endregion
    }
}