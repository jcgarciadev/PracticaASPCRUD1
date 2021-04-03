using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaASPCRUD2.ViewModels
{
    public class EmpleadoViewModel
    {
        
        public int EmpleadoId { get; set; }        
        public string Nombre { get; set; }
        public int Documento { get; set; }       
        public string Cargo { get; set; }
        public string Telefono { get; set; }
    }
}
