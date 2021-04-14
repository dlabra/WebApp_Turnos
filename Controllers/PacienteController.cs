using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _context;

        public PacienteController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var paciente = await _context.Paciente.FirstOrDefaultAsync(x => x.IdPaciente == id);

            if (paciente == null)
                return NotFound();

            return View(paciente);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Esta propiedad valida que el metodo create se haya ejecutado desde el formulario y no desde algun a url del navegador 
        public async Task<IActionResult> Create([Bind("idPaciente, Nombre, Apellido, Direccion, Telefono, Email")] Paciente paciente)
        {

            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }
    }
}