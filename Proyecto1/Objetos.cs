using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1
{
    public class Objetos
    {
    }

    public class oTipoIdentificacion
    {
        public int id { get; set; }
        public string tipoIdentificacion { get; set; }

    }

    public class oGenero
    {
        public int id { get; set; }
        public string genero { get; set; }

    }

    public class oEstadoCivil {
        public int id { get; set; }
        public string estado { get; set; }
    }

    public class oProvincia
    {
        public int id { get; set; }
        public string provincia { get; set;}
    }

    public class oMedico {
        public string id { get; set; }
        public string nombre { get; set; }

        public string apellido1 { get; set; }
        public string apellido2 { get; set; }

        public string tipoIdentificacion { get; set; }
        public string identificacion { get; set; }

        public string genero { get; set; }

        public string estadoCivil { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public string especialidad { get; set; }

        public string telefono { get; set; }

        public string correo { get; set; }
  
    }

    public class oExpediente
    {
        public string id_Paciente { get; set; }
        public string nombre_Paciente { get; set; }
        public string apellido_Paciente { get; set; }
        public string enfermedad { get; set; }
        public string descripcion_ENF { get; set; }
        public string id_Medico { get; set; }
        public string nombre_Medico { get; set; }
        public string apellido_Medico { get; set; }
        public string especialidad { get; set; }
        public string medicamento { get; set; }
        public string farmaceutica { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string sucursal { get; set; }
    }

}