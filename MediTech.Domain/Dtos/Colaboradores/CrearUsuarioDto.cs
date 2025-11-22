using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediTech.Domain.Dtos.Colaboradores
{
    public class CrearUsuarioDto
    {
        // Datos del usuario
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }

        // Datos del colaborador
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CURP { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaContrato { get; set; }
        public string MatriculaProfesional {  get; set; }
        public string Licencia { get; set; }
        public string Genero { get; set; }       
        public bool EsActivo { get; set; } = true;  

        // Colaborador y cede
        public int ID_Cede { get; set; }
        public int ID_TipoColaborador { get; set; }

        // valor por defecto debido a que no es dinamico
        public int ID_Modulo { get; set; } = 1;
        public int ID_Especialidad { get; set; }

    }

    public class RegistroResultadoDto
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public int? UsuarioId { get; set; } // opcional, para devolver el ID si se creó
    }

}
