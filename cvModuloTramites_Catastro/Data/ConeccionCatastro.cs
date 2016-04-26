using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace cvModuloTramites_Catastro.Data
{
    public class ConeccionCatastro
    {

     
        public String commando()
        {
            String action = @"Select COUNT(*)  
                              From Propietario, Terreno 
                              where Propietario.PropID = Terreno.PROPID
                                and Terreno.cvecatastral = @ClaveCatastral";
                             
            return  action;
        }
        public String busquedaDatosContacto()
        {

            String action = @"Select Terreno.cvecatastral,
                                     Contacto.Nombre,
                                     Contacto.email, 
                                     Contacto.Telefono
                                From Propietario,Terreno,Contacto
                              where Propietario.PropID = Terreno.PROPID and
                                    Terreno.TERRENOID = Contacto.TerrenoID and 
                                    Terreno.cvecatastral = @ClaveCatastral";
            return action;
        }
        public String busquedaDatosUsuario()
        {


            String action = @"select Terreno.cvecatastral,Terreno.Cuenta,Terreno.cveCatastralAnt,
                                     TipoPredio.Tipo, tipoPropietario.Tipo,Propietario.RazoSoc, Propietario.RFC,
                                     Propietario.Nombre1 ,Propietario.Nombre2 ,Propietario.ApellidoP ,
	                                 Propietario.ApellidoM  
                                from Contacto,Terreno,Propietario,TipoPredio,tipoPropietario
                                where Contacto.TerrenoID =Terreno.TERRENOID and 
                                        Terreno.TipoPredioid = TipoPredio.TipoPredioID and
                                        Terreno.PROPID = Propietario.PropID and
                                        Propietario.tipoPropietario = tipoPropietario.tipoPropID
                                        and terreno.cvecatastral = @ClaveCatastral";
            return action;
        }
        public String busquedaIdTerreno()
        {
            String action = @"select Terreno.TerrenoID from Terreno
                               where Terreno.cvecatastral = @ClaveCatastral";
            return action;
        }
        public String insertaContacto()
        {
            String action = @"Insert into Contacto(Nombre,email,Telefono,TERRENOID)
                              values(@contacto,@email,@telefono,@idTerreno);";


                                  
            return action;
        }
        public String busquedaTramites()
        {
            String action = @"select Tramite.Folio,Tramite.FechaTramite,
                                     Tramite.Total, statusTramite.Nombre
                                from Tramite,Terreno,Contacto,statusTramite
                               where 
                                     Terreno.TERRENOID = Contacto.TerrenoID and
                                     Terreno.TERRENOID = Tramite.TERRENOID and
                                     Tramite.StatusTramite = statusTramite.StatusTramite and
                                     Terreno.cvecatastral = @ClaveCatastral Order By Folio ASC";
            return action;
        }

        
        public String busquedaDenominacion()
        {
            String action = @"Select RenovacionCedula,CopiaCertificada,
	                                 CerMedidasColindancia,constanciapropiedad,
                                     ConstanciaNumero,ConstanciaRegistro,
                                     Croquis,constanciaNopropiedad,NumCopias ,Tramite.Observaciones,

                                     Tramite.NombreArchivo, Tramite.RegistroPredio,
                                     Tramite.SubdivicionPredio, Tramite.FusionPredio,
                                     Tramite.ExpedicionDocumentos, Tramite.SolicitudPlanos,
                                     Tramite.Otro
                                 from Tramite
                               where Tramite.Folio = @Folio  and Tramite.ClaveCatastral = @ClaveCatastral";
            return action;
        }
        //EDITAR
        public String act_usuario()
        {
            String action = @"UPDATE Contacto
                              SET Nombre=@NuevoContacto, email=@NuevoEmail,Telefono=@NuevoTelefono
                            WHERE TERRENOID=@idTerreno;";
            return action;
        }

        //Busqueda Precios y Metodos de envio
        public String TramitePrecios()
        {
            String action = @"Select TramitePrecios.IDTramtePrecios,
                                     TramitePrecios.ClaveTramite, 
                                     TramitePrecios.Precio
                                from TramitePrecios";
            return action;
        }
        //consultaenvios
        public String ConsPrecioEnvio()
        {
            String action = @"Select Envios.Descripcion, Envios.precio from Envios";
            return action;
        }
        //Actualizacion de Archivo
        public String act_Archivo()
        {
            String action = @"UPDATE Tramite
                                 SET Archivo=@Archivo, NombreArchivo=@nombreArchivo
                               WHERE Folio=@Folio and 
                                     ClaveCatastral =@ClaveCatastral";
            return action;
        }
        //Cancelar Tramite
        public String act_Cancelartramite()
        {
            String action = @"UPDATE Tramite
                                 SET StatusTramite=@cCancelacion
                               WHERE Folio=@Folio and 
                                     ClaveCatastral =@ClaveCatastral";
            return action;
        }

        //Busqueda Folio y Crear Tramite e id envio
        public String buscarUltimoFolio()
        {
            String action = @"SELECT TOP 1 Folio
                                FROM Tramite
                            ORDER BY Folio DESC";
            return action;
        }
        public String creaTramite()
        {
            String action = @"SET IDENTITY_INSERT Tramite ON
                      Insert Into Tramite([IDTramite],[Folio],[FechaTramite],[Observaciones],
			                              [Total],[IDenvios],[ClaveCatastral],[Nombre1],[Nombre2],
			                              [ApePat],[ApeMat],[Atendio] ,[Archivo],[StatusTramite],
		                                  [RenovacionCedula],[CopiaCertificada],[CerMedidasColindancia],
		                                  [constanciapropiedad],[ConstanciaNumero],[ConstanciaRegistro],
		                                  [Croquis],[NumCopias],[TERRENOID],[constanciaNopropiedad],
                                          [NombreArchivo],[RegistroPredio],[SubdivicionPredio],
                                          [FusionPredio],[ExpedicionDocumentos],[SolicitudPlanos],[Otro])
                      values(@nuevoId,@nuevoFolio,@Fehca,@observacion,
                             @total,@idEnvio,@ClaveCatastral,@Nombre1,@Nombre2,@Apellido1,@Apellido2,@Atendido,@Archivo,@Status,
                             @renovacion,@copiasCer,@cerMedidas,@constanciaProp,@consNumero,@consRegistro,
                             @Croquis,@numCopias,@TerrenoId,@NoPropiedad,
                             @nombreArchivo,@RegistroPredio, @SubdivicionPredio,@FusionPredio,@ExDocumentos,@Planos,@Otro)
                             SET IDENTITY_INSERT Tramite OFF ";
            return action;
        }
        public String buscarUltimoIdTramite()
        {
            String action = @"SELECT TOP 1 Tramite.IDTramite
                               FROM Tramite
                           ORDER BY IDTramite DESC";
            return action;
        }
        public String idEnvios()
        {
            String action = @"Select IDenvios from Envios where Envios.Descripcion =@id";
            return action;
        }
        public String datosReporte()
        {
            String action = @"select   Tramite.ClaveCatastral,Terreno.Cuenta,
	                                   Propietario.RazoSoc,Propietario.RFC,
	                                   Propietario.Nombre1,Propietario.Nombre2,
	                                   Propietario.ApellidoP,Propietario.ApellidoM,
	                                   Propietario.CALLE as CallePropietario,Propietario.COLONIA as ColoniaPropietario,
	                                   Propietario.CIUDAD as CiudadPropietario,Propietario.NUMERO as NumPropietario,
	                                   Calle.Nombre as CallePredio,Colonia.Nombre as ColoniaPredio,
	                                   Terreno.Referencia as CallesPredio,
	                                  
                                       Tramite.RenovacionCedula,Tramite.CopiaCertificada,
	                                   Tramite.CerMedidasColindancia,Tramite.constanciapropiedad,
	                                   Tramite.ConstanciaNumero,Tramite.constanciaNopropiedad,
	                                   Tramite.ConstanciaRegistro,Tramite.Croquis,Tramite.Observaciones
                                from  Terreno,Propietario,Tramite,Calle,Colonia
                                where Terreno.PROPID = Propietario.PropID and
	                                  Terreno.TERRENOID = Tramite.TERRENOID and
	                                  Terreno.CALLEID = Calle.CalleID and
	                                  Terreno.ColID = Colonia.ColID and
                                      Terreno.cvecatastral = @ClaveCatastral and
                                      Tramite.Folio = @Folio ";
            return action;
        }


        //Metodos para la insercion de TRdetalleTramite
        public String buscarIDTramiteDetalle()
        {
            String action = @"SELECT TOP 1 TRamiteDetalle.IDTramiteDetalle
                                      FROM TRamiteDetalle
                                  ORDER BY IDTramiteDetalle DESC";
            return action;
        }
        public String insertarTR()
        {
            String action = @"insert into TRamiteDetalle([IDTramite],[IDTramiteDetalle],
                                                         [IDTramtePrecios],[Cant],[Precio]) 
                                   values";

            return action;
        }
    }
}