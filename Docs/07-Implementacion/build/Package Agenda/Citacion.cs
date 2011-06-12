///////////////////////////////////////////////////////////
//  Citacion.cs
//  Implementation of the Class Citacion
//  Generated by Enterprise Architect
//  Created on:      12-jun-2011 07:38:31 p.m.
//  Original author: orkus
///////////////////////////////////////////////////////////




public class Citacion {

	private string _detalles;
	private Datetime _fecha;
	private Usuario _gestorEvento;
	private Datetime _horario;
	private MotivoCitacion _m_MotivoCitacion;
	private Tutor _m_Tutor;
	private Usuario _m_Usuario;
	private MotivoCitacion _motivo;
	private Tutor _tutor;
	private Tutor m_Tutor;
	private MotivoCitacion m_MotivoCitacion;
	public Usuario m_Usuario;

	public Citacion(){

	}

	~Citacion(){

	}

	public virtual void Dispose(){

	}

	public string _detalles{
		get{
			return _detalles;
		}
		set{
			_detalles = value;
		}
	}

	public Datetime _fecha{
		get{
			return _fecha;
		}
		set{
			_fecha = value;
		}
	}

	public Usuario _gestorEvento{
		get{
			return _gestorEvento;
		}
		set{
			_gestorEvento = value;
		}
	}

	public Datetime _horario{
		get{
			return _horario;
		}
		set{
			_horario = value;
		}
	}

	public MotivoCitacion _m_MotivoCitacion{
		get{
			return _m_MotivoCitacion;
		}
		set{
			_m_MotivoCitacion = value;
		}
	}

	public Tutor _m_Tutor{
		get{
			return _m_Tutor;
		}
		set{
			_m_Tutor = value;
		}
	}

	public Usuario _m_Usuario{
		get{
			return _m_Usuario;
		}
		set{
			_m_Usuario = value;
		}
	}

	public MotivoCitacion _motivo{
		get{
			return _motivo;
		}
		set{
			_motivo = value;
		}
	}

	public Tutor _tutor{
		get{
			return _tutor;
		}
		set{
			_tutor = value;
		}
	}

}//end Citacion