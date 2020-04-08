using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RollLogin.Data;
using RollLogin.Models;
using RollLogin.ViewModels;

namespace RollLogin.Controllers
{
    public class FoodManagmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
      
       
        public FoodManagmentsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewFile model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = null;
                if (model.formFile != null)
                {
                    string ext = System.IO.Path.GetExtension(model.formFile.FileName);
                    if (ext == ".jpeg"|| ext == ".jpg" || ext == ".png" || ext == ".jfif")
                    {
                        string upload = System.IO.Path.Combine(_env.WebRootPath, "images");
                        uniqueFilename = Guid.NewGuid().ToString() + "_" + model.formFile.FileName;
                        string filepath = System.IO.Path.Combine(upload, uniqueFilename);
                        model.formFile.CopyTo(new System.IO.FileStream(filepath, System.IO.FileMode.Create));
                        //string filepath = $"{_env.WebRootPath}/images/{model.formFile.FileName}";
                        //var stream = System.IO.File.Create(filepath);
                        //model.formFile.CopyTo(stream);
                    }
                    else
                    {
                        TempData["Error"] = "Only Pdf files are allowed";
                        return RedirectToAction("Create", "Files");
                    }
                }


                FoodManagment newfile = new FoodManagment
                {
                    FId = model.FId,
                    Fcode = model.Fcode,
                    FName = model.FName,
                    FPrice = model.FPrice,
                    FDisc = model.FDisc,
                    Quantity = model.Quantity,
                    Date = model.Date,
                    ODate=model.ODate,
                    Atri = uniqueFilename,

                };
                _context.Add(newfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View();
        }
        // GET: FoodManagments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodManagments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FId,Fcode,FName,FPrice,FDisc,Quantity,Atri,Date,ODate")] FoodManagment foodManagment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(foodManagment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(foodManagment);
        //}

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
