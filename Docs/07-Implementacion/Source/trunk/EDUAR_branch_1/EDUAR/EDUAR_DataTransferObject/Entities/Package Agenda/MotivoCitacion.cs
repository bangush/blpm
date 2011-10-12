///////////////////////////////////////////////////////////
//  MotivoCitacion.cs
//  Implementation of the Class MotivoCitacion
//  Generated by Enterprise Architect
//  Created on:      20-jun-2011 16:21:51
//  Original author: Pablo Nicoliello
///////////////////////////////////////////////////////////

using System;
using EDUAR_Entities.Shared;
namespace EDUAR_Entities
{
    [Serializable]
    public class MotivoCitacion:DTBase
    {
		public int idMotivoCitacion { get; set; }
		public string descripcion { get; set; }
		public string nombre { get; set; }

        public MotivoCitacion()
        {

        }

        ~MotivoCitacion()
        {

        }

        public virtual void Dispose()
        {

        }
    }//end MotivoCitacion
}