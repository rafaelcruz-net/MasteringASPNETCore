using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Underwater.Data;
using Underwater.Models;

namespace Underwater.Controllers
{
    public class AquariumCodeController : Controller
    {
        private readonly UnderwaterContext _context;

        public AquariumCodeController(UnderwaterContext context)
        {
            _context = context;
        }

        // GET: AquariumCode
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aquariums.ToListAsync());
        }

        // GET: AquariumCode/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquarium = await _context.Aquariums
                .FirstOrDefaultAsync(m => m.AquariumId == id);
            if (aquarium == null)
            {
                return NotFound();
            }

            return View(aquarium);
        }

        // GET: AquariumCode/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AquariumCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AquariumId,Name,Address,Number,Open")] Aquarium aquarium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aquarium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aquarium);
        }

        // GET: AquariumCode/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquarium = await _context.Aquariums.FindAsync(id);
            if (aquarium == null)
            {
                return NotFound();
            }
            return View(aquarium);
        }

        // POST: AquariumCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AquariumId,Name,Address,Number,Open")] Aquarium aquarium)
        {
            if (id != aquarium.AquariumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aquarium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AquariumExists(aquarium.AquariumId))
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
            return View(aquarium);
        }

        // GET: AquariumCode/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquarium = await _context.Aquariums
                .FirstOrDefaultAsync(m => m.AquariumId == id);
            if (aquarium == null)
            {
                return NotFound();
            }

            return View(aquarium);
        }

        // POST: AquariumCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aquarium = await _context.Aquariums.FindAsync(id);
            _context.Aquariums.Remove(aquarium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AquariumExists(int id)
        {
            return _context.Aquariums.Any(e => e.AquariumId == id);
        }
    }
}
