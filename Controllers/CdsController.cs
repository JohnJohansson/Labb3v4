﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb3v4.Data;
using Labb3v4.Models;

namespace Labb3v4.Controllers
{
    public class CdsController : Controller
    {
        private readonly MusicContext _context;

        public CdsController(MusicContext context)
        {
            _context = context;
        }

        // GET: Cds
        public async Task<IActionResult> Index()
        {
            var musicContext = _context.Cd.Include(c => c.Artist);
            return View(await musicContext.ToListAsync());
        }

        // GET: Cds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd
                .Include(c => c.Artist)
                .FirstOrDefaultAsync(m => m.CdId == id);
            if (cd == null)
            {
                return NotFound();
            }

            return View(cd);
        }

        // GET: Cds/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId");
            return View();
        }

        // POST: Cds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdId,CdName,CdInfo,ArtistId")] Cd cd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", cd.ArtistId);
            return View(cd);
        }

        // GET: Cds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd.FindAsync(id);
            if (cd == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", cd.ArtistId);
            return View(cd);
        }

        // POST: Cds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CdId,CdName,CdInfo,ArtistId")] Cd cd)
        {
            if (id != cd.CdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CdExists(cd.CdId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", cd.ArtistId);
            return View(cd);
        }

        // GET: Cds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd
                .Include(c => c.Artist)
                .FirstOrDefaultAsync(m => m.CdId == id);
            if (cd == null)
            {
                return NotFound();
            }

            return View(cd);
        }

        // POST: Cds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cd = await _context.Cd.FindAsync(id);
            _context.Cd.Remove(cd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CdExists(int id)
        {
            return _context.Cd.Any(e => e.CdId == id);
        }
    }
}
