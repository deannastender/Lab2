// I, Deanna Stender, student number 000732962, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1.Models;
using Lab1.Data;

namespace Lab1.Controllers
{
    public class DealershipController : Controller
    {
        private readonly DealershipMgr _dealershipMgr = new DealershipMgr();

        // GET: Dealership
        public IActionResult Index()
        {
            return View(_dealershipMgr.GetDealerships());
        }

        // GET: Dealership/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(_dealershipMgr.GetDealership(id));
        }

        // GET: Dealership/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dealership/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Email,PhoneNumber")] Dealership dealership)
        {
            if (ModelState.IsValid)
            {
                _dealershipMgr.AddDealership(dealership);
                return RedirectToAction(nameof(Index));
            }
            return View(dealership);
        }

        // GET: Dealership/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership = _dealershipMgr.GetDealership(id);
            if (dealership == null)
            {
                return NotFound();
            }
            return View(dealership);
        }

        // POST: Dealership/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,Email,PhoneNumber")] Dealership dealership)
        {
            if (id != dealership.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dealershipMgr.UpdateDealership(dealership);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealershipExists(dealership.ID))
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
            return View(dealership);
        }

        // GET: Dealership/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership = _dealershipMgr.GetDealerships()
                .FirstOrDefault(m => m.ID == id);
            if (dealership == null)
            {
                return NotFound();
            }

            return View(dealership);
        }

        // POST: Dealership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dealershipMgr.DeleteDealership(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DealershipExists(int id)
        {
            return _dealershipMgr.GetDealerships().Any(e => e.ID == id);
        }
    }
}
