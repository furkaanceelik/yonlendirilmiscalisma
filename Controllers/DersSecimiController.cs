using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FurkanCelik.Data;
using FurkanCelik.Models;
using Microsoft.AspNetCore.Authorization;

namespace FurkanCelik.Controllers
{
    [Authorize]
    public class DersSecimiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DersSecimiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DersSecimi
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Ogretmen"))
            {
                return View(await _context.DersSecimi.Where(x => x.OgrenciSecmisMi == true).ToListAsync());

            }
            else
                return View(await _context.DersSecimi.ToListAsync());
        }

        // GET: DersSecimi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersSecimi = await _context.DersSecimi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dersSecimi == null)
            {
                return NotFound();
            }

            return View(dersSecimi);
        }

        // GET: DersSecimi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DersSecimi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DersAdi,OgrenciSecmisMi,OgretmenOnayi")] DersSecimi dersSecimi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dersSecimi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dersSecimi);
        }

        [Authorize(Roles = "Ogrenci")]
        // GET: DersSecimi/Edit/5
        public async Task<IActionResult> EditOgrenci(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersSecimi = await _context.DersSecimi.FindAsync(id);
            if (dersSecimi == null)
            {
                return NotFound();
            }
            return View(dersSecimi);
        }

        // POST: DersSecimi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Ogrenci")]
        public async Task<IActionResult> EditOgrenci(int id, [Bind("Id,DersAdi,OgrenciSecmisMi,OgretmenOnayi")] DersSecimi dersSecimi)
        {
            if (id != dersSecimi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dersSecimi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DersSecimiExists(dersSecimi.Id))
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
            return View(dersSecimi);
        }

        [Authorize(Roles = "Ogretmen")]
        // GET: DersSecimi/Edit/5
        public async Task<IActionResult> EditOgretmen(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersSecimi = await _context.DersSecimi.FindAsync(id);
            if (dersSecimi == null)
            {
                return NotFound();
            }
            return View(dersSecimi);
        }

        // POST: DersSecimi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Ogretmen")]
        public async Task<IActionResult> EditOgretmen(int id, [Bind("Id,DersAdi,OgrenciSecmisMi,OgretmenOnayi")] DersSecimi dersSecimi)
        {
            if (id != dersSecimi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dersSecimi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DersSecimiExists(dersSecimi.Id))
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
            return View(dersSecimi);
        }

        // GET: DersSecimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersSecimi = await _context.DersSecimi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dersSecimi == null)
            {
                return NotFound();
            }

            return View(dersSecimi);
        }

        // POST: DersSecimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dersSecimi = await _context.DersSecimi.FindAsync(id);
            _context.DersSecimi.Remove(dersSecimi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DersSecimiExists(int id)
        {
            return _context.DersSecimi.Any(e => e.Id == id);
        }
    }
}
