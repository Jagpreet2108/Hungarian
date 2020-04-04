using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RollLogin.Data;
using RollLogin.Models;

namespace RollLogin.Controllers
{
    public class EmpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Emps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emps.ToListAsync());
        }

        // GET: Emps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emps = await _context.Emps
                .FirstOrDefaultAsync(m => m.EId == id);
            if (emps == null)
            {
                return NotFound();
            }

            return View(emps);
        }
        [Authorize]
        // GET: Emps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EId,Ename,Salary,Desingnation")] Emps emps)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emps);
        }
        [Authorize]
        // GET: Emps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emps = await _context.Emps.FindAsync(id);
            if (emps == null)
            {
                return NotFound();
            }
            return View(emps);
        }

        // POST: Emps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EId,Ename,Salary,Desingnation")] Emps emps)
        {
            if (id != emps.EId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emps);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpsExists(emps.EId))
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
            return View(emps);
        }
        [Authorize]
        // GET: Emps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emps = await _context.Emps
                .FirstOrDefaultAsync(m => m.EId == id);
            if (emps == null)
            {
                return NotFound();
            }

            return View(emps);
        }

        // POST: Emps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emps = await _context.Emps.FindAsync(id);
            _context.Emps.Remove(emps);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpsExists(int id)
        {
            return _context.Emps.Any(e => e.EId == id);
        }
    }
}
