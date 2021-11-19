using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpeedItUp.Data;
using Microsoft.AspNet.Identity;
using SpeedItUp.Models;

namespace SpeedItUp.Controllers
{
    public class SlotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Slots
        public async Task<IActionResult> Index()
        {
            var parentId = User.Identity.GetUserId();

            var slots = _context.Slot
                .Include(t => t.Children).Take(10)
                .Include(t => t.Entertainers);
            return View(await slots.ToListAsync());
        }

        // GET: Slots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var parentId = User.Identity.GetUserId();

            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot
                .Include(s => s.Children.Where(ch => ch.Parents.Any(p => p.Id == parentId)))
                .Include(s => s.Entertainers)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // GET: Slots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Slots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time,Date")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slot);
        }

        // GET: Slots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot.FindAsync(id);
            if (slot == null)
            {
                return NotFound();
            }
            return View(slot);
        }

        // POST: Slots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,Date")] Slot slot)
        {
            if (id != slot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotExists(slot.Id))
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
            return View(slot);
        }

        // GET: Slots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // POST: Slots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slot = await _context.Slot.FindAsync(id);
            _context.Slot.Remove(slot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotExists(int id)
        {
            return _context.Slot.Any(e => e.Id == id);
        }
    }
}
