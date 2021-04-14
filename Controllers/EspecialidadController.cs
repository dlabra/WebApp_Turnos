using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        //Aca iran todos los metodos que ejecutar este controlador

        private readonly TurnosContext _context;

        //Constructor (inicializar los valores cuando instaciones el controlador)
        public EspecialidadController(TurnosContext context)
        {
            //inicializamos _context
            _context = context;
        }

        //IActionResult se encarga de mostrar el resultado que obtiene el metodo en la interface del usuario
        //convertimos los metodos a async para que soporten multiples peticiones
        public async Task<IActionResult> Index()
        {
            //le estamos pasando a la vista el objeto _context, accediendo a la entidad Especialidad(tabla)
            return View(await _context.Especialidad.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            //si es null retornamos un error 404
            if (id == null)
                return NotFound();

            var especialidad = await _context.Especialidad.FindAsync(id);

            if (especialidad == null)
                return NotFound();

            return View(especialidad);
        }

        //recibimos del form los cambios id y descripcion, con httpost le decimos que este sera el metodo encargado de ahcer el envio de la info
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.Id)
                return NotFound();

            //Si el enlace entre la propidad bind que nos trae los datos se realizo correctamente y las validaciones estan ok
            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(especialidad);
        }

        //redigire a la vista de eliminar
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var especilidad = await _context.Especialidad.FirstOrDefaultAsync(x => x.Id == id);

            if (especilidad == null)
                return NotFound();

            return View(especilidad);
        }

        //Ejecuta el proceso de eliminacion
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var especialidad = await _context.Especialidad.FindAsync(id);
            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Descripcion")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();

        }
    }
}