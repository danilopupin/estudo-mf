using estudo_mf.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace estudo_mf.Controllers
{
    [Authorize]
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculo.ToListAsync();
            return View(dados);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculos veiculos)
        {
            if (ModelState.IsValid)
            {
                _context.Veiculo.Add(veiculos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var dados = await _context.Veiculo.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculos veiculo)
        {
            if (id != veiculo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Veiculo.Update(veiculo);

                _context.Veiculo.Update(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculo.FindAsync(id);

            if (dados == null)
                return NotFound();


            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculo.FindAsync(id);

            if (dados == null)
                return NotFound();


            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculo.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Veiculo.Remove(dados);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Relatorio (int? id)
        {
            if (id == null)
                return NotFound();

            var veiculo = await _context.Veiculo.FindAsync(id);

            if (veiculo == null)
                return NotFound();

            var consumos = await _context.Consumos
                .Where(c => c.Id == id)
                .OrderByDescending(c => c.Data)
                .ToListAsync();

            decimal total = consumos.Sum(c => c.Valor);

            ViewBag.Veiculo = veiculo;
            ViewBag.Total = total;

            return View(consumos);
        }
    }


}
