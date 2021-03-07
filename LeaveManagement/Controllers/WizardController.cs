using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Data;
using LeaveManagement.Models;

namespace LeaveManagement.Controllers
{
    public class WizardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WizardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wizard
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetailsLeaveTypeViewModel.ToListAsync());
        }


        // POST: Wizard/Index/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(int m16, int organization, int location, int budgetType)
        {
            try
            {

            var data = (from stages in _context.LeaveTypes
                        where stages.Name == "Vocation"
                        select new LeaveTypeViewModel
                        {
                            Id = stages.Id,
                            Name = stages.Name,
                            DateCreated = stages.DateCreated
                        }).ToList();
            var checkData = data.Count();
            return View(data);
            } catch
            {
                throw;
            }
        }



        // GET: Wizard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeViewModel = await _context.DetailsLeaveTypeViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveTypeViewModel == null)
            {
                return NotFound();
            }

            return View(leaveTypeViewModel);
        }

        // GET: Wizard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wizard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateCreated")] LeaveTypeViewModel leaveTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveTypeViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeViewModel);
        }

        // GET: Wizard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeViewModel = await _context.DetailsLeaveTypeViewModel.FindAsync(id);
            if (leaveTypeViewModel == null)
            {
                return NotFound();
            }
            return View(leaveTypeViewModel);
        }

        // POST: Wizard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateCreated")] LeaveTypeViewModel leaveTypeViewModel)
        {
            if (id != leaveTypeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveTypeViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeViewModelExists(leaveTypeViewModel.Id))
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
            return View(leaveTypeViewModel);
        }

        // GET: Wizard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeViewModel = await _context.DetailsLeaveTypeViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveTypeViewModel == null)
            {
                return NotFound();
            }

            return View(leaveTypeViewModel);
        }

        // POST: Wizard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveTypeViewModel = await _context.DetailsLeaveTypeViewModel.FindAsync(id);
            _context.DetailsLeaveTypeViewModel.Remove(leaveTypeViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeViewModelExists(int id)
        {
            return _context.DetailsLeaveTypeViewModel.Any(e => e.Id == id);
        }
    }
}
