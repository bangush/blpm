///////////////////////////////////////////////////////////
//  Alumno.cs
//  Implementation of the Class Alumno
//  Generated by Enterprise Architect
//  Created on:      12-jun-2011 07:44:10 p.m.
//  Original author: Pablo Nicoliello
///////////////////////////////////////////////////////////




public class Alumno : Persona {

	private Calificacion _calificaciones;
	private Curso _curso;
	private bool _esEmancipado;
	private Datetime _fechaAlta;
	private Datetime _fechaBaja;
	private Inasistencia _inasistencias;
	private int _legajo;
	private Sancion _sanciones;
	public Sancion m_Sancion;
	public Inasistencia m_Inasistencia;
	public Curso m_Curso;
	public Calificacion m_Calificacion;

	public Alumno(){

	}

	~Alumno(){

	}

	public override void Dispose(){

	}

	public Calificacion _calificaciones{
		get{
			return _calificaciones;
		}
		set{
			_calificaciones = value;
		}
	}

	public Curso _curso{
		get{
			return _curso;
		}
		set{
			_curso = value;
		}
	}

	public bool _esEmancipado{
		get{
			return _esEmancipado;
		}
		set{
			_esEmancipado = value;
		}
	}

	public Datetime _fechaAlta{
		get{
			return _fechaAlta;
		}
		set{
			_fechaAlta = value;
		}
	}

	public Datetime _fechaBaja{
		get{
			return _fechaBaja;
		}
		set{
			_fechaBaja = value;
		}
	}

	public Inasistencia _inasistencias{
		get{
			return _inasistencias;
		}
		set{
			_inasistencias = value;
		}
	}

	public int _legajo{
		get{
			return _legajo;
		}
		set{
			_legajo = value;
		}
	}

	public Sancion _sanciones{
		get{
			return _sanciones;
		}
		set{
			_sanciones = value;
		}
	}

}//end Alumno