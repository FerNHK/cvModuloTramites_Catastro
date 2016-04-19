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
    public class Tramite_Helper
    {
        #region Variables insersion Tramites

        int idTra = 0;
        int folio = 0;
        int idEn = 0;

        String clvCatastro = "";

        String nombre1 = "";
        String nombre2 = "";
        String Ap = "";
        String Am = "";

        String comentarios = "";

        Byte[] pdf = null;
        int status = 0;

        bool rdc = false;
        bool cpc = false;
        bool cmc = false;
        bool cup = false;
        bool cno = false;
        bool cdr = false;
        bool cdl = false;
        bool cnp = false;
        float precioTotal = 0;
        String TotalCopias = "";
        int terrenoid = 0;

        
        #endregion
        #region getDatos Insercion Tramites
        //ID Tramite;
        public void setIdTramite(int id)
        {
            this.idTra = id;
        }
        public int getIdTramite()
        {
            return idTra;
        }

        //Folio
        public void setNuevoFolio(int folio)
        {
            this.folio = folio;
        }
        public int getNuevoFolio()
        {
            return folio;
        }

        //Envio
        public void setEnvioId(int idEnvio)
        {
            this.idEn = idEnvio;
        }
        public int getEnvioId()
        {
            return idEn;
        }
        //clave catastral
        public void setClvCatastral(String c)
        {
            this.clvCatastro = c;
        }
        public String getClvCatastral()
        {
            return clvCatastro;
        }

        /***Nombres y Apellidos***/
        public void setNombre_uno(String c)
        {
            this.nombre1 = c;
        }
        public String getNombre_uno()
        {
            return nombre1;
        }
        public void setNombre_dos(String c)
        {
            this.nombre2 = c;
        }
        public String getNombre_dos()
        {
            return nombre2;
        }
        public void setApePaterno(String c)
        {
            this.Ap = c;
        }
        public String getApePaterno()
        {
            return Ap;
        }
        public void setApeMaterno(string c)
        {
            this.Am = c;
        }
        public string getApeMaterno()
        {
            return Am;
        }

        /***Archivo***/
        public void setArchivoInser(Byte[] c)
        {
            this.pdf = c;
        }
        public Byte[] getArchivoInser()
        {
            return pdf;
        }

        /***Estatus***/
        public void setStatusInser(int c)
        {
            this.status = c;
        }
        public int getStatusInser()
        {
            return status;
        }

        /****Checksbox****/
        //ch1 Renovacion
        public void setRenovacion(bool c)
        {
            this.rdc = c;
        }
        public bool getRenovacion()
        {
            return rdc;
        }
        //ch2 Copias Certificadas
        public void setCopiasCer(bool c)
        {
            this.cpc = c;
        }
        public bool getCopiasCer()
        {
            return cpc;
        }
        //ch3 Medidas y colindancias
        public void setCerMedidas(bool c)
        {
            this.cmc = c;
        }
        public bool getCerMedidas()
        {
            return cmc;
        }

        //CH4 constancias unica
        public void setConsUnicap(bool c)
        {
            this.cup = c;
        }
        public bool getConsUnicap()
        {
            return cup;
        }
        //CH5 constancia numero oficial
        public void setConsNumOff(bool c)
        {
            this.cno = c;
        }
        public bool getConsNumOff()
        {
            return cno;
        }
        //chk6 constancia registro
        public void setConstRegistro(bool c)
        {
            this.cdr = c;
        }
        public bool getConstRegistro()
        {
            return cdr;
        }
        //chk7 croquiz
        public void setCroquis(bool c)
        {
            this.cdl = c;
        }
        public bool getCroquis()
        {
            return cdl;
        }
        //CHK8 COnstancia de No registro
        public void setConstanciaNoRegistro(bool c)
        {
            this.cnp = c;
        }
        public bool getConstanciaNoRegistro()
        {
            return cnp;
        }

        /***Total de copias Certificadas****/
        public void setTotalCopias(String c)
        {
            this.TotalCopias = c;
        }
        public String getTotalCopias()
        {
            return TotalCopias;
        }
        /*******Ide del Terreno********/
        public void setTerrenoId(int c)
        {
            this.terrenoid = c;
        }
        public int getTerrenoId()
        {
            return terrenoid;
        }
        /*******setComentarios*******/
        public void setComentarios(String c)
        {
            this.comentarios = c;
        }
        public String getComentarios()
        {
            return comentarios;
        }

        //precio Total
        public void setTotalTramite(float c)
        {
            this.precioTotal = c;
        }
        public float getTotalTramite()
        {
            return precioTotal;
        }

        #endregion
        #region Variables consulta Globales
            ConeccionCatastro coneccion = new ConeccionCatastro();
           
            SqlCommand comando = null;
            SqlDataReader lector = null;
            private String contacto = "", email = "", telefono = "",
                           Terreno_id=" ",setfolio="",setStatus="",ultimoFolio="";
            private Byte[] b = null;    
            private DataTable user_datos = null;
            private DataTable tnTramites = null,tnMetodEnvio=null,tbReport=null;
            private SqlDataAdapter daAdaptador = null;
            private DataSet setAdapter=null;
            private bool verificación = false;
            private static string regesaClave = "";
            private string regresaID= "";
            private int idDetalleTramite = 0;
        #endregion
        #region GetsYSet Consultas Globales
            //Establecer Clave Catastral
         public void setClave(String clv)
        {
            regesaClave = clv;
        }
            //OBtener Clave Catastral
          public static String getClave()
        {
            return regesaClave;
        }
         //Establecer (DataTable) datos de Cotacto
        public void setDatos(DataTable tabUs)
        {
            this.user_datos = tabUs;
        }
        //Obtener (DataTable) datos de Cotacto
        public DataTable getDatos()
        {
            return user_datos;
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

        //Datagridview
        public void setDataGrid(DataSet sda)
        {
            this.setAdapter = sda;
        }
        public DataSet getDataGrid()
        {
            return setAdapter;
        }
        //Denominacion
        public void setFolio(String folio)
        {
            this.setfolio = folio;
        }
        public String getFolio()
        {
            return setfolio;
        }
        //SETY GET Precios de los Tramites

        public void setTramites(DataTable tnTramites)
        {
            this.tnTramites = tnTramites;
        }
    
        public DataTable getTramites()
        {
            return tnTramites;
        }

        //Set y Get Metodos de Envio
        public void setEnvios(DataTable tnEnvio)
        {
            this.tnMetodEnvio = tnEnvio;
        }

        public DataTable getEnvios()
        {
            return tnMetodEnvio;
        }
        //Set Archivo
        public void setArchivo(Byte[] file)
        {
            this.b = file;
        }
        public Byte[] getArchivo()
        {
            return b;
        }
        //Set estatus
        public void setStatusCancelado(String s)
        {
            this.setStatus = s;
        }
        public String getStatusCancelado() { return setStatus; }

        //Get UltimoFolio
        public void setUltimoFolio(String uFolio)
        {
            this.ultimoFolio = uFolio;
        }
        public String getUltimoFolio()
        {
            return ultimoFolio;
        }
        public void setUltimoIDTRAMITE(String s)
        {
            this.regresaID = s;
        }
        public String getUltimoID()
        {
            return regresaID;
        }
        public void setidEnvio(String en)
        {
            this.regresaID = en;
        }
        public String getidEnvio()
        {
            return regresaID;
        }
       // Se datos Report
        public void setdatosRe(DataTable report)
        {
            this.tbReport = report;
        }

        public DataTable getdatosRe()
        {
            return tbReport;
        }

        //Obtener el ultimo Id de Detalles Tramite
        public void setDetalleId(int id)
        {
            this.idDetalleTramite = id;
        }

        public int getDetalleId()
        {
            return idDetalleTramite;
        }
        #endregion
        #region MetodosConsulta
       
        //Principal Datos del predio y Del propietario
        public void consultarDatosPropietario()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
            {
                conn.Open();
                    comando = new SqlCommand(coneccion.busquedaDatosUsuario(), conn);
                    comando.Parameters.AddWithValue("@ClaveCatastral", getClave());
                    daAdaptador = new SqlDataAdapter(comando);
                    DataTable dtDatos = new DataTable();
                    daAdaptador.Fill(dtDatos);
                    setDatos(dtDatos);
                conn.Close();
            }
        } 
        //Almacenamiento de datos de Contacto
        public String consultaIdTerreno()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.busquedaIdTerreno(), conn);
                    comando.Parameters.AddWithValue("@ClaveCatastral", getClave());
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
            catch (SqlException )
            {
                return null;
            }
        }
        public void consultarTramitesDenomiancion()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.busquedaTramites(), conn);
                    comando.Parameters.AddWithValue("@ClaveCatastral", getClave());
                    daAdaptador = new SqlDataAdapter(comando);
                    DataSet set = new DataSet();
                    daAdaptador.Fill(set, "Tramite");
                    setDataGrid(set);
                }
            }
            catch (SqlException )
            {

            }
        }
        public void consultarDenominacion()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
            {
                conn.Open();
                comando = new SqlCommand(coneccion.busquedaDenominacion(), conn);
                comando.Parameters.AddWithValue("@Folio", getFolio());
                comando.Parameters.AddWithValue("@ClaveCatastral", getClave());
                daAdaptador = new SqlDataAdapter(comando);
                
                DataTable dtDenominacion = new DataTable();
                daAdaptador.Fill(dtDenominacion);
                setDatos(dtDenominacion);
                conn.Close();
            }
        }
        public bool RegistroUsuarioNuevo()
        {
            String id = consultaIdTerreno();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
            {
                conn.Open();
                comando = new SqlCommand(coneccion.insertaContacto(), conn);
                comando.Parameters.AddWithValue("@idTerreno",id);
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
        public bool editUsuario()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    String id = consultaIdTerreno();
                    conn.Open();
                    comando = new SqlCommand(coneccion.act_usuario(), conn);
                    comando.Parameters.AddWithValue("@NuevoContacto", getContacto());
                    comando.Parameters.AddWithValue("@NuevoEmail", getEmail());
                    comando.Parameters.AddWithValue("@NuevoTelefono", getTelefono());
                    comando.Parameters.AddWithValue("@idTerreno", id);
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
        public void consultarPrecios()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
            {
                conn.Open();
                comando = new SqlCommand(coneccion.TramitePrecios(), conn);
                daAdaptador = new SqlDataAdapter(comando);
                DataTable dtTramites = new DataTable();
                daAdaptador.Fill(dtTramites);
                setTramites(dtTramites);
                conn.Close();
            }
        }
        public void cPreciosEnvios()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
            {
                conn.Open();
                comando = new SqlCommand(coneccion.ConsPrecioEnvio(), conn);
                daAdaptador = new SqlDataAdapter(comando);
                DataTable dtEnvios = new DataTable();
                daAdaptador.Fill(dtEnvios);
                setEnvios(dtEnvios);
                conn.Close();
            }
        }
        public bool cActualizacionArchivo()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
            {
                conn.Open();
                comando = new SqlCommand(coneccion.act_Archivo(), conn);
                comando.Parameters.AddWithValue("@Archivo", SqlDbType.Binary).Value = getArchivo();
                comando.Parameters.AddWithValue("@Folio", getFolio());
                comando.Parameters.AddWithValue("@ClaveCatastral", getClave());
                

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
        public bool cCancelacionTramite() 
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.act_Cancelartramite(), conn);
                    comando.Parameters.AddWithValue("@cCancelacion", getStatusCancelado());
                    comando.Parameters.AddWithValue("@Folio", getFolio());
                    comando.Parameters.AddWithValue("@ClaveCatastral", getClave());
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
                return false;
            }
        }
        public void cConsultarUltimoFolio()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
            {
                try
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.buscarUltimoFolio(), conn);
                    lector = comando.ExecuteReader();
                    String uF = "";
                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            uF = lector.GetInt32(0).ToString();

                        }

                        setUltimoFolio(uF);
                    }
                    else
                    {
                        uF = "0";
                        setUltimoFolio(uF);
                    }
                    
                }
                catch(SqlException )
                {
                   
                   
                }
            }
        }
        public void cConsultarUltimoTramite()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
            {
                try
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.buscarUltimoIdTramite(), conn);
                    lector = comando.ExecuteReader();
                    String uF = "";
                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            uF = lector.GetInt32(0).ToString();
                        }

                        setUltimoIDTRAMITE(uF);
                    }
                    else
                    {
                        uF = "0";
                        setUltimoIDTRAMITE(uF);
                    }
                    
                }
                catch (SqlException )
                {
                   
                }
            }
        }
        public void cConsultarIDEnvio(String nomEnvio)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
            {
                try
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.idEnvios(), conn);
                    comando.Parameters.AddWithValue("@id", nomEnvio);
                    lector = comando.ExecuteReader();
                    String uF = "";
                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            uF = lector.GetInt32(0).ToString();
                        }

                        setidEnvio(uF);
                    }

                }
                catch (SqlException )
                {
                   
                }
            }
        }
        public bool crearTramite()
        {
            try
            {
                DateTime now = DateTime.Now;
               //  String fecha = now.ToString();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.creaTramite(), conn);
                    comando.Parameters.AddWithValue("@nuevoId",getIdTramite() );
                    comando.Parameters.AddWithValue("@nuevoFolio", getNuevoFolio());
                    comando.Parameters.AddWithValue("@Fehca",now );
                    comando.Parameters.AddWithValue("@observacion",getComentarios());
                    comando.Parameters.AddWithValue("@total",getTotalTramite());

                    if (getEnvioId() == 0)
                    {
                        comando.Parameters.AddWithValue("@idEnvio", DBNull.Value);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@idEnvio", getEnvioId());
                    }
                    comando.Parameters.AddWithValue("@ClaveCatastral",getClvCatastral());
                    comando.Parameters.AddWithValue("@Nombre1",getNombre_uno() );
                    comando.Parameters.AddWithValue("@Nombre2",getNombre_dos()  );
                    comando.Parameters.AddWithValue("@Apellido1",getApePaterno() );
                    comando.Parameters.AddWithValue("@Apellido2",getApeMaterno());
                    comando.Parameters.AddWithValue("@Atendido", DBNull.Value);

                    comando.Parameters.AddWithValue("@Archivo", SqlBinary.Null);
                    
                    comando.Parameters.AddWithValue("@Status", getStatusInser());
                    comando.Parameters.AddWithValue("@renovacion",getRenovacion() );
                    comando.Parameters.AddWithValue("@copiasCer",getCopiasCer() );
                    comando.Parameters.AddWithValue("@cerMedidas", getCerMedidas());
                    comando.Parameters.AddWithValue("@constanciaProp", getConsUnicap());
                    comando.Parameters.AddWithValue("@consNumero", getConsNumOff());
                    comando.Parameters.AddWithValue("@consRegistro", getConstRegistro());
                    comando.Parameters.AddWithValue("@Croquis",getCroquis() );
                    comando.Parameters.AddWithValue("@numCopias", getTotalCopias());
                    comando.Parameters.AddWithValue("@TerrenoId", getTerrenoId());
                   
                    comando.Parameters.AddWithValue("@NoPropiedad", getConstanciaNoRegistro());
                   
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
               
                return false;
            }
            
        }
        public bool cConsultaAcuseTramite()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.datosReporte(), conn);
                    comando.Parameters.AddWithValue("@ClaveCatastral", getClave());
                    comando.Parameters.AddWithValue("@Folio", getFolio());
                    daAdaptador = new SqlDataAdapter(comando);

                    DataTable dtRep = new DataTable();
                    daAdaptador.Fill(dtRep);
                    setdatosRe(dtRep);
                    conn.Close();
                }
                return true;
            }
            catch (SqlException )
            {
                return false;
            }

        }
        public void cCbusquedaIncrementarId()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();
                    comando = new SqlCommand(coneccion.buscarIDTramiteDetalle(), conn);
                    lector = comando.ExecuteReader();
                    int uF =0;
                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            uF = lector.GetInt32(0);
                        }                      
                            setDetalleId(uF); 
                    }
                    else
                    {
                        uF = 0;
                        setDetalleId(uF);
       
                    }
                    conn.Close();
                }
               
            }
            catch (SqlException )
            {
              
            }
        }
        public bool cInsertarTRDetalle(List<Tuple<int, int, int, int, float>> lista)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CatastroConeccion"].ToString()))
                {
                    conn.Open();

                    string Sql = coneccion.insertarTR();
                    int c = 0;
                    int totalLista= lista.Count()-1;

                    while (c <= totalLista)
                    {
                        if (c == totalLista)
                        {
                            Sql += lista[c]+";";
                        }
                        else
                        {
                            Sql += lista[c]+",";
                        }

                        c++;
                    }
                    comando = new SqlCommand(Sql, conn);
                    int count = Convert.ToInt32(comando.ExecuteNonQuery());



                    if (count == lista.Count())
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
        #endregion
    }
}

