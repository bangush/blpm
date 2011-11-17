///////////////////////////////////////////////////////////
//  Permiso.cs
//  Implementation of the Class Permiso
//  Generated by Enterprise Architect
//  Created on:      20-jun-2011 16:21:52
//  Original author: Pablo Nicoliello
///////////////////////////////////////////////////////////



using EDUAR_Entities.Shared;
using System;
namespace EDUAR_Entities
{
    [Serializable]
    public class Permiso:DTBase
    {
        public int idPermiso;
        private Object _elemento;
        private string _nombre;
        private string _privilegio;

        public Permiso()
        {

        }

        ~Permiso()
        {

        }

        public virtual void Dispose()
        {

        }

        public Object elemento
        {
            get
            {
                return _elemento;
            }
            set
            {
                _elemento = value;
            }
        }

        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        public string privilegio
        {
            get
            {
                return _privilegio;
            }
            set
            {
                _privilegio = value;
            }
        }

    }//end Permiso
}