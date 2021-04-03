using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaASPCRUD2.Models.Abstract;
using PracticaASPCRUD2.Models.DAL;
using PracticaASPCRUD2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaASPCRUD2.Models.Business
{

    public class EmpleadoBusiness: IEmpleadoBusiness
    {
        private readonly DbContextoPractica _context;
        public EmpleadoBusiness(DbContextoPractica context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> ObtenerListaEmpleados()
        {
            return await _context.Empleados.Include("Cargo").ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Empleado>>> ObtenerListaEmpleadosAPI()
        {
            return await _context.Empleados.Include("Cargo").ToListAsync();
        }


        public async Task<Empleado> ObtenerEmpleadoPorId(int id)
        {
           
            return await _context.Empleados.FirstOrDefaultAsync(m => m.EmpleadoId == id);

        }

        public async Task<Empleado> ObtenerEmpleadoPorDoc(int doc)
        {

            return await _context.Empleados.FirstOrDefaultAsync(m => m.Documento == doc);

        }

        public async Task<IEnumerable<Cargo>> ObtenerListaCargos()
        {
            return await _context.Cargos.ToListAsync();
        }

        public async Task GuardarEmpleado(Empleado empleado)
        {
            try
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task EditarEmpleado(Empleado empleado)
        {
            try
            {
                _context.Update(empleado);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task EliminarEmpleado(Empleado empleado)
        {
            try
            {
                _context.Remove(empleado);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }

        }


    }
}
