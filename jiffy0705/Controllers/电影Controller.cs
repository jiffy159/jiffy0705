using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jiffy0705.Data;
using jiffy0705.Models;
using Microsoft.AspNetCore.Authorization;

namespace jiffy0705.Controllers
{
   [Authorize(Policy = "Jiffy是管理员")]

    public class 电影Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public 电影Controller(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: 电影
        public async Task<IActionResult> Index()
        {
            return View(await _context.电影.ToListAsync());
        }

        // GET: 电影/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 电影 = await _context.电影
                .SingleOrDefaultAsync(m => m.Id == id);
            if (电影 == null)
            {
                return NotFound();
            }

            return View(电影);
        }

        // GET: 电影/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: 电影/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,名字,分类,发布时间")] 电影 电影)
        {
            if (ModelState.IsValid)
            {
                _context.Add(电影);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(电影);
        }

        // GET: 电影/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 电影 = await _context.电影.SingleOrDefaultAsync(m => m.Id == id);
            if (电影 == null)
            {
                return NotFound();
            }
            return View(电影);
        }

        // POST: 电影/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,名字,分类,发布时间")] 电影 电影)
        {
            if (id != 电影.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(电影);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!电影Exists(电影.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(电影);
        }

        // GET: 电影/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 电影 = await _context.电影
                .SingleOrDefaultAsync(m => m.Id == id);
            if (电影 == null)
            {
                return NotFound();
            }

            return View(电影);
        }

        // POST: 电影/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var 电影 = await _context.电影.SingleOrDefaultAsync(m => m.Id == id);
            _context.电影.Remove(电影);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool 电影Exists(int id)
        {
            return _context.电影.Any(e => e.Id == id);
        }
    }
}
