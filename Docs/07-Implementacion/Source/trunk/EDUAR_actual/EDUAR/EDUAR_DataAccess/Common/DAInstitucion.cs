﻿using System;
using EDUAR_DataAccess.Shared;
using EDUAR_Entities;

namespace EDUAR_DataAccess.Common
{
    public class DAInstitucion : DataAccesBase<Institucion>
    {
        #region --[Atributos]--
        private const string ClassName = "DAInstitucion";
        #endregion

        #region --[Constructor]--
        public DAInstitucion()
        {
        }

        public DAInstitucion(DATransaction objDATransaction)
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

        public override Institucion GetById(Institucion entidad)
        {
            throw new NotImplementedException();
        }

        public override void Create(Institucion entidad)
        {
            throw new NotImplementedException();
        }

        public override void Create(Institucion entidad, out int identificador)
        {
            throw new NotImplementedException();
        }

        public override void Update(Institucion entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Institucion entidad)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region --[Métodos Públicos]--
        #endregion
    }
}
