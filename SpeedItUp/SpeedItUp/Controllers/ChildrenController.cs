using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpeedItUp.Data;
using SpeedItUp.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SpeedItUp.Controllers
{
    public class ChildrenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChildrenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Children
        public async Task<IActionResult> Index()
        {
            var parentId = User.Identity.GetUserId();

            var children = _context.Child.Where(ch => ch.Parents.Any(p => p.Id == parentId));

            return View(await children.ToListAsync());
        }

        // GET: Children/AddToSlot/5
        public async Task<IActionResult> AddToSlot(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = _context.Slot.Where(s => s.Id == id).FirstOrDefault();

            if (slot == null)
            {
                return NotFound();
            }

            var parentId = User.Identity.GetUserId();

            var children = _context.Child.Where(ch => ch.Parents.Any(p => p.Id == parentId));

            if (children == null)
            {
                return NotFound();
            }

            AddToSlotViewModel result = new AddToSlotViewModel 
            {
                SlotID = slot.Id,
                Date = slot.Time,
                Children = children
            };

            return View(result);
        }

        // POST: Children/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToSlot( [FromForm] AddToSlotFormModel form)
        {
            if (ModelState.IsValid)
            {
                Slot slot = _context.Slot.Include(x => x.Children).Where(s => s.Id == form.SlotID).FirstOrDefault();
                foreach (var id in form.ChildIDs)
                {
                    var child = await _context.Child.FindAsync(id);
                    slot.Children.Add(child);
                }
                _context.Update(slot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: Children/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,NickName,BirthDate,Notes")] Child child)
        {
            if (ModelState.IsValid)
            {
                var user = this._context.Users.Where(x => x.Id == this.User.FindFirst(ClaimTypes.NameIdentifier).Value).First();
                if (child.Parents == null)
                {
                    child.Parents = new List<Person>();
                }
                child.Parents.Add(user);
                _context.Add(child);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(child);
        }

        // GET: Children/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Child.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }
            return View(child);
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,NickName,BirthDate,Notes")] Child child)
        {
            if (id != child.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(child);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChildExists(child.Id))
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
            return View(child);
        }

        // GET: Children/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Child
                .FirstOrDefaultAsync(m => m.Id == id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var child = await _context.Child.FindAsync(id);
            _context.Child.Remove(child);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChildExists(int id)
        {
            return _context.Child.Any(e => e.Id == id);
        }
    }
}
