using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RollLogin.Data;
using RollLogin.Models;

namespace RollLogin.Controllers
{
    public class FoodManagmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodManagmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodManagments
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodManagment.ToListAsync());
        }

        // GET: FoodManagments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodManagment = await _context.FoodManagment
                .FirstOrDefaultAsync(m => m.FId == id);
            if (foodManagment == null)
            {
                return NotFound();
            }

            return View(foodManagment);
        }

        // GET: FoodManagments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodManagments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FId,Fcode,FName,FPrice,FDisc,Quantity,Atri,Date,ODate")] FoodManagment foodManagment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodManagment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodManagment);
        }

        // GET: FoodManagments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodManagment = await _context.FoodManagment.FindAsync(id);
            if (foodManagment == null)
            {
                return NotFound();
            }
            return View(foodManagment);
        }

        // POST: FoodManagments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FId,Fcode,FName,FPrice,FDisc,Quantity,Atri,Date,ODate")] FoodManagment foodManagment)
        {
            if (id != foodManagment.FId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodManagment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodManagmentExists(foodManagment.FId))
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
            return View(foodManagment);
        }

        // GET: FoodManagments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodManagment = await _context.FoodManagment
                .FirstOrDefaultAsync(m => m.FId == id);
            if (foodManagment == null)
            {
                return NotFound();
            }

            return View(foodManagment);
        }

        // POST: FoodManagments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var foodManagment = await _context.FoodManagment.FindAsync(id);
            _context.FoodManagment.Remove(foodManagment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodManagmentExists(string id)
        {
            return _context.FoodManagment.Any(e => e.FId == id);
        }
    }
}
