using Microsoft.AspNetCore.Mvc;
using PracticaASPCRUD2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaASPCRUD2.Models.Abstract
{
    public interface IEmpleadoBusiness
    {
        Task<IEnumerable<Empleado>> ObtenerListaEmpleados();
        Task<Empleado> ObtenerEmpleadoPorId(int id);
        Task<IEnumerable<Cargo>> ObtenerListaCargos();
        Task<Empleado> ObtenerEmpleadoPorDoc(int doc);
        Task GuardarEmpleado(Empleado empleado);
        Task EditarEmpleado(Empleado empleado);
        Task EliminarEmpleado(Empleado empleado);
        Task<ActionResult<IEnumerable<Empleado>>> ObtenerListaEmpleadosAPI();

    }
}
