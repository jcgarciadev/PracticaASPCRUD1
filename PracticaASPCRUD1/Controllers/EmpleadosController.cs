using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaASPCRUD2.Models.Abstract;
using PracticaASPCRUD2.Models.DAL;
using PracticaASPCRUD2.Models.Entities;
using PracticaASPCRUD2.ViewModels;

namespace PracticaASPCRUD2.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoBusiness _empleadoBusiness;

        public EmpleadosController(IEmpleadoBusiness empleadoBusiness)
        {
            _empleadoBusiness = empleadoBusiness;
        }


        // GET: Empleados
        public async Task<IActionResult> Index()
        {        

            return View(await _empleadoBusiness.ObtenerListaEmpleados());
            
        }

      

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _empleadoBusiness.ObtenerEmpleadoPorId(id.Value);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        

        // GET: Empleados/Create
        public async Task<IActionResult> Create()
        {
            ViewData["listaCargos"] = new SelectList(await _empleadoBusiness.ObtenerListaCargos(), "CargoId", "Nombre");
            return View();
        }
        
        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoId,Nombre,Documento,CargoId,Telefono")] Empleado empleado)
        {    

            if (ModelState.IsValid)
            {
                var empleadoTemp = await _empleadoBusiness.ObtenerEmpleadoPorDoc(empleado.Documento);

                if (empleadoTemp == null)
                {
                    await _empleadoBusiness.GuardarEmpleado(empleado);
                    return RedirectToAction(nameof(Index));
                }
            }

            if(empleado.CargoId==0)
                ViewData["errorCargo"] = "Seleccione un cargo";

            ViewData["errorDoc"] = "Se encuentra registrado un empleado con este documento";

            ViewData["listaCargos"] = new SelectList(await _empleadoBusiness.ObtenerListaCargos(), "CargoId", "Nombre");

            return View(empleado);
        }

        

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _empleadoBusiness.ObtenerEmpleadoPorId(id.Value);
            ViewData["listaCargos"] = new SelectList(await _empleadoBusiness.ObtenerListaCargos(), "CargoId", "Nombre");
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoId,Nombre,Documento,CargoId,Telefono")] Empleado empleado)
        {
            if (id != empleado.EmpleadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _empleadoBusiness.EditarEmpleado(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _empleadoBusiness.ObtenerEmpleadoPorId(id.Value);
            if (empleado == null)
            {
                return NotFound();
            }

            await _empleadoBusiness.EliminarEmpleado(empleado);

            return RedirectToAction(nameof(Index));

            //return View(empleado);
        }



        /*

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _empleadoBusiness.ObtenerEmpleadoPorId(id);
            
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }
        /*
        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.EmpleadoId == id);
        }

        */
    }
}
