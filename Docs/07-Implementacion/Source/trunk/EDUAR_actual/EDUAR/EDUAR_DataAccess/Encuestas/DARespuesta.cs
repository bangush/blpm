﻿using System;
using EDUAR_DataAccess.Shared;
using EDUAR_Entities;
using System.Data.SqlClient;
using EDUAR_Utility.Excepciones;
using EDUAR_Utility.Enumeraciones;
using System.Data;
using System.Collections.Generic;

namespace EDUAR_DataAccess.Encuestas
{
    public class DARespuesta : DataAccesBase<Respuesta>
    {
        #region --[Atributos]--
        private const string ClassName = "DARespuesta";
        #endregion

        #region --[Constructor]--
        public DARespuesta()
        {
        }

        public DARespuesta(DATransaction objDATransaction)
            : base(objDATransaction)
        {

        }
        #endregion

        #region --[Implementación métodos heredados]--
        public override string FieldID
        {
            get { throw new NotImplementedException(); }
        }

        public override string FieldDescription
        {
            get { throw new NotImplementedException(); }
        }

        public override Respuesta GetById(Respuesta entidad)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Creates the specified entidad.
		/// </summary>
		/// <param name="entidad">The entidad.</param>
        public override void Create(Respuesta entidad)
        {
			try
			{
				int identificador = 0;
				this.Create(entidad, out identificador);
			}
			catch (SqlException ex)
			{
				throw new CustomizedException(string.Format("Fallo en {0} - Create()", ClassName),
									ex, enuExceptionType.SqlException);
			}
			catch (Exception ex)
			{
				throw new CustomizedException(string.Format("Fallo en {0} - Create()", ClassName),
									ex, enuExceptionType.DataAccesException);
			}
        }

        public override void Create(Respuesta entidad, out int identificador)
        {
            try
            {
                using (Transaction.DBcomand = Transaction.DataBase.GetStoredProcCommand("RespuestaPregunta_Insert"))
                {
                    Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@idRespuesta", DbType.Int32, 0);
                    Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@idPregunta", DbType.Int32, entidad.pregunta.idPregunta);
                    Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@username", DbType.String, entidad.encuestaDisponible.usuario.username);
                    Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@idEncuesta", DbType.Int32, entidad.encuestaDisponible.encuesta.idEncuesta);
                    if (entidad.respuestaSeleccion == 0) Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@valorRespuestaTextual", DbType.String, entidad.respuestaTextual);
                    Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@valorRespuestaSeleccion", DbType.Int32, entidad.respuestaSeleccion);
                    //Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@respondida", DbType.Boolean, true);
                    //Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@fechaRespuesta", DbType.DateTime, DateTime.Now);

                    if (Transaction.Transaction != null)
                        Transaction.DataBase.ExecuteNonQuery(Transaction.DBcomand, Transaction.Transaction);
                    else
                        Transaction.DataBase.ExecuteNonQuery(Transaction.DBcomand);

                    identificador = Int32.Parse(Transaction.DBcomand.Parameters["@idRespuesta"].Value.ToString());
                }
            }
            catch (SqlException ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - Create()", ClassName),
                                    ex, enuExceptionType.SqlException);
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - Create()", ClassName),
                                    ex, enuExceptionType.DataAccesException);
            }
        }

        public override void Update(Respuesta entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Respuesta entidad)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region --[Métodos Públicos]--
        /// <summary>
        /// Obtiene las respuestas de una encuesta dada
        /// </summary>
        /// <param name="entidad">The entidad.</param>
        /// <param name="respondida">if set to <c>true</c> [respondida].</param>
        /// <returns></returns>
        //public List<Respuesta> GetRespuestasEncuesta(Encuesta entidad, bool respondida)
        //{
        //    try
        //    {
        //        Transaction.DBcomand = Transaction.DataBase.GetStoredProcCommand("RespuestasEncuesta_Select");

        //        if (entidad != null)
        //        {
        //            if (entidad.idEncuesta > 0)
        //                Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@idEncuesta", DbType.Int32, entidad.idEncuesta);
        //            Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@respondida", DbType.Boolean, respondida);
        //        }

        //        IDataReader reader = Transaction.DataBase.ExecuteReader(Transaction.DBcomand);

        //        List<Respuesta> listaRespuestas = new List<Respuesta>();
        //        Respuesta objRespuesta;

        //        while (reader.Read())
        //        {
        //            objRespuesta = new Respuesta();

        //            objRespuesta.idRespuesta = Convert.ToInt32(reader["idRespuesta"]);
        //            objRespuesta.respuestaSeleccion = Convert.ToInt32(reader["valorRespuestaSeleccion"]);
        //            objRespuesta.respuestaTextual = reader["valorRespuestaTextual"].ToString();
        //            objRespuesta.idEncuesta = Convert.ToInt32(reader["idEncuesta"]);

        //            objRespuesta.usuario = new Persona();
        //            {
        //                objRespuesta.usuario.idPersona = Convert.ToInt32(reader["idEncuestado"]);
        //            }

        //            objRespuesta.pregunta = new Pregunta();
        //            {
        //                objRespuesta.pregunta.idPregunta = Convert.ToInt32(reader["idPregunta"]);
        //            }

        //            listaRespuestas.Add(objRespuesta);
        //        }
        //        return listaRespuestas;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CustomizedException(string.Format("Fallo en {0} - GetRespuestasEncuesta()", ClassName),
        //                            ex, enuExceptionType.SqlException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CustomizedException(string.Format("Fallo en {0} - GetRespuestasEncuesta()", ClassName),
        //                            ex, enuExceptionType.DataAccesException);
        //    }
        //}

        //public List<Encuesta> GetEncuestasDisponibles(string username)
        //{
        //    try
        //    {
        //        Transaction.DBcomand = Transaction.DataBase.GetStoredProcCommand("RespuestasEncuesta_Select");

        //        Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@respondida", DbType.Boolean, false);
        //        Transaction.DataBase.AddInParameter(Transaction.DBcomand, "@username", DbType.String, username);

        //        IDataReader reader = Transaction.DataBase.ExecuteReader(Transaction.DBcomand);

        //        List<Encuesta> listaEncuestasDisponibles = new List<Encuesta>();
        //        Encuesta objEncuesta;

        //        while (reader.Read())
        //        {
        //            objEncuesta = new Encuesta();

        //            objEncuesta.idEncuesta = Convert.ToInt32(reader["idEncuesta"]);

        //            objEncuesta.usuario = new Persona();
        //            {
        //                objEncuesta.usuario.idPersona = Convert.ToInt32(reader["idEncuestado"]);
        //            }

        //            listaEncuestasDisponibles.Add(objEncuesta);
        //        }
        //        return listaEncuestasDisponibles;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CustomizedException(string.Format("Fallo en {0} - GetEncuestasDisponibles()", ClassName),
        //                            ex, enuExceptionType.SqlException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CustomizedException(string.Format("Fallo en {0} - GetEncuestasDisponibles()", ClassName),
        //                            ex, enuExceptionType.DataAccesException);
        //    }
        //}
        #endregion
    }
}
