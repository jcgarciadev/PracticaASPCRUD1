using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaASPCRUD2.Models.Entities
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage ="El campo nombre es requerido")]
        [Column("NombreEmpleado",TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }
        public int Documento { get; set; }

        [DisplayName("Cargo empleado")]
        
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }

        public string Telefono { get; set; }
    }
}
