﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDUAR_DataAccess.Common;
using EDUAR_Entities;
using EDUAR_BusinessLogic.Shared;
using EDUAR_Entities.Shared;
using EDUAR_Utility.Excepciones;
using EDUAR_Utility.Enumeraciones;
using EDUAR_DataAccess.Shared;

namespace EDUAR_BusinessLogic.Common
{
    public class BLTemaContenido : BusinessLogicBase<TemaContenido, DATemaContenido>
    {
        #region --[Constante]--
        private const string ClassName = "BLTemaContenido";
        #endregion

        #region --[Constructores]--
        /// <summary>
        /// Constructor con DTO como parámetro.
        /// </summary>
        public BLTemaContenido(DTBase objTemaContenido)
        {
            Data = (TemaContenido)objTemaContenido;
        }
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public BLTemaContenido()
        {
            Data = new TemaContenido();
        }
        #endregion

        #region --[Propiedades Override]--
        protected override sealed DATemaContenido DataAcces
        {
            get { return dataAcces; }
            set { dataAcces = value; }
        }

        public override sealed TemaContenido Data
        {
            get { return data; }
            set { data = value; }
        }

        public override string FieldId
        {
            get { return DataAcces.FieldID; }
        }

        public override string FieldDescription
        {
            get { return DataAcces.FieldDescription; }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        public override void GetById()
        {
            try
            {
                Data = DataAcces.GetById(Data);
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - GetById", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }

        /// <summary>
        /// Método que guarda el registro actualmente cargado en memoria. No importa si se trata de una alta o modificación.
        /// </summary>
        public override void Save()
        {
            try
            {
                //Abre la transaccion que se va a utilizar
                DataAcces.Transaction.OpenTransaction();
                int idTemaContenido = 0;

                if (Data.idTemaContenido == 0)
                    DataAcces.Create(Data, out idTemaContenido);
                else
                    DataAcces.Update(Data);

                //Se da el OK para la transaccion.
                DataAcces.Transaction.CommitTransaction();
            }
            catch (CustomizedException ex)
            {
                if (DataAcces != null && DataAcces.Transaction != null)
                    DataAcces.Transaction.RollbackTransaction();
                throw ex;
            }
            catch (Exception ex)
            {
                if (DataAcces != null && DataAcces.Transaction != null)
                    DataAcces.Transaction.RollbackTransaction();
                throw new CustomizedException(string.Format("Fallo en {0} - Save()", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }

        /// <summary>
        /// Método que guarda el registro actualmente cargado en memoria. No importa si se trata de una alta o modificación.
        /// </summary>
        public override void Save(DATransaction objDATransaction)
        {
            try
            {
                //Si no viene el Id es porque se esta creando la entidad
                DataAcces = new DATemaContenido(objDATransaction);
                if (Data.idTemaContenido == 0)
                    DataAcces.Create(Data);
                else
                {
                    DataAcces.Update(Data);
                }
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - Save()", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public override void Delete()
        {
            try
            {
                DataAcces = new DATemaContenido();
                DataAcces.Delete(Data);
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - Delete()", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }

        /// <summary>
        /// Deletes the specified obj DA transaction.
        /// </summary>
        /// <param name="objDATransaction">The obj DA transaction.</param>
        public override void Delete(DATransaction objDATransaction)
        {
            try
            {
                DataAcces = new DATemaContenido(objDATransaction);
                DataAcces.Delete(Data);
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - Delete()", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }
        #endregion

        #region --[Métodos publicos]--
        /// <summary>
        /// Gets the temas by contenido.
        /// </summary>
        /// <param name="entidad">The entidad.</param>
        /// <returns></returns>
        /// <exception cref="CustomizedException"></exception>
        public List<TemaContenido> GetTemasByContenido(TemaContenido entidad)
        {
            try
            {
                return DataAcces.GetTemaContenidos(entidad);
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - GetTemasByContenido", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }

        /// <summary>
        /// Gets the temas by contenido.
        /// </summary>
        /// <param name="entidad">The entidad.</param>
        /// <returns></returns>
        /// <exception cref="CustomizedException"></exception>
        public Contenido GetTemasByContenido(int idContenido)
        {
            try
            {
                return DataAcces.GetTemaContenidos(idContenido);
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - GetTemasByContenido", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }

        /// <summary>
        /// Gets the temas by contenido.
        /// </summary>
        /// <param name="entidad">The entidad.</param>
        /// <returns></returns>
        /// <exception cref="CustomizedException"></exception>
        public List<TemaContenido> GetTemasByContenido(Contenido entidad)
        {
            TemaContenido unTemaContenido = new TemaContenido();
            unTemaContenido.idContenido = entidad.idContenido;
            try
            {
                return DataAcces.GetTemaContenidos(unTemaContenido);
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - GetTemasByContenido", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }

        /// <summary>
        /// Gets the temas by contenido. Info minima para realizar calculos.
        /// </summary>
        /// <param name="entidad">The entidad.</param>
        /// <returns></returns>
        /// <exception cref="CustomizedException"></exception>
        public List<TemaContenido> GetTemasByContenidoCalc(Contenido entidad)
        {
            TemaContenido unTemaContenido = new TemaContenido();
            unTemaContenido.idContenido = entidad.idContenido;
            try
            {
                return DataAcces.GetTemaContenidosCalc(unTemaContenido, new Curricula());
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - GetTemasByContenido", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }

        /// <summary>
        /// Gets the temas by curso asignatura.
        /// </summary>
        /// <param name="objAsignatura">The obj asignatura.</param>
        /// <returns></returns>
        public List<TemaContenido> GetTemasByCursoAsignatura(Curricula objAsignatura)
        {
            try
            {
                TemaContenido filtro = new TemaContenido();
                filtro.activo = true;
                return DataAcces.GetTemaContenidos(filtro, objAsignatura);
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - GetTemasByContenido", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }

        /// <summary>
        /// Gets the temas by Tema Planificacion Anual.
        /// </summary>
        /// <param name="objAsignatura">The obj TemaPlanificacionAnual.</param>
        /// <returns></returns>
        public List<TemaContenido> GetTemasByTemaPlanificacionAnual(TemaPlanificacionAnual objTemaPlanificacionAnual)
        {
            try
            {
                TemaContenido filtro = new TemaContenido();
                filtro.activo = true;
                return DataAcces.GetTemaContenidos(filtro, objTemaPlanificacionAnual);
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - GetTemasByTemaPlanificacionAnual", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }


        /// <summary>
        /// Gets the temas by Tema Planificacion Anual.
        /// </summary>
        /// <param name="objAsignatura">The obj TemaPlanificacionAnual.</param>
        /// <returns></returns>
        public List<TemaContenido> GetTemasByTemaPlanificacionAnualCalc(TemaPlanificacionAnual objTemaPlanificacionAnual)
        {
            try
            {
                TemaContenido filtro = new TemaContenido();
                filtro.activo = true;
                return DataAcces.GetTemaContenidosCalc(filtro, objTemaPlanificacionAnual);
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - GetTemasByTemaPlanificacionAnual", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }

        /// <summary>
        /// Gets the contenidos planificados.
        /// </summary>
        /// <param name="objAsignatura">The obj asignatura.</param>
        /// <returns></returns>
        public List<TemaContenido> GetContenidosPlanificados(AsignaturaCicloLectivo objAsignatura)
        {
            try
            {
                return DataAcces.GetContenidosPlanificados(objAsignatura);
            }
            catch (CustomizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomizedException(string.Format("Fallo en {0} - GetTemasByContenido", ClassName), ex,
                                              enuExceptionType.BusinessLogicException);
            }
        }
        #endregion

    }
}
