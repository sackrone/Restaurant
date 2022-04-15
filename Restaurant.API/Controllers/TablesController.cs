using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.API.Data;
using Restaurant.API.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    public class TablesController : Controller
    {
        private readonly DataContext _context;

        public TablesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tables.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TableEntity tableEntity = await _context.Tables.FirstOrDefaultAsync(m => m.Id == id);
            if (tableEntity == null)
            {
                return NotFound();
            }

            return View(tableEntity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Available")] TableEntity tableEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableEntity);
        }

        // GET: Tables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TableEntity tableEntity = await _context.Tables.FindAsync(id);
            if (tableEntity == null)
            {
                return NotFound();
            }
            return View(tableEntity);
        }

        // POST: Tables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Available")] TableEntity tableEntity)
        {
            if (id != tableEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableEntityExists(tableEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tableEntity);
        }

        // GET: Tables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TableEntity tableEntity = await _context.Tables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableEntity == null)
            {
                return NotFound();
            }

            return View(tableEntity);
        }

        // POST: Tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            TableEntity tableEntity = await _context.Tables.FindAsync(id);
            _context.Tables.Remove(tableEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableEntityExists(int id)
        {
            return _context.Tables.Any(e => e.Id == id);
        }
    }
}
