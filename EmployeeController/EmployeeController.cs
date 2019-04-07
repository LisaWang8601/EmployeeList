using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeList.Models;

namespace EmployeeList.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly Apr02ThinkLPContext _context;
        private Apr02ThinkLPContext _context;

        public EmployeeController(Apr02ThinkLPContext context)
        {
            _context = context;
        }

        // GET: Employee - list by type selected
        public async Task<IActionResult> Index(string ListType)
        {
            var employees = from emp in _context.Employee
                            select emp;

            //Define a fake date as null to simlify the query to SQL
            DateTime NULLDATE = new DateTime(1800, 1, 1, 0, 0, 0);

            // ViewBag to pass 'null' date to view for dispaly decision
            ViewBag.nulldate = NULLDATE;

            // Listent to buttons "ListType" from index view
            // paths to display all, active, or terminated employees list
            // with TemData to show each list type
            if (ListType == "ActiveEmployees")
            {
                TempData["ButtonValue"] = "Active Employees";
                employees = employees.Where(emp => emp.TerminationDate == NULLDATE);
            }
            else if (ListType == "TerminatedEmployees")
            {
                TempData["ButtonValue"] = "Employees Terminated in Last Month";
                int filteringMonths = 1; // for customizing filter range when needs arise
                // define the starting date for filtering terminated employees
                var dateRangeStart = DateTime.Today.AddMonths(-filteringMonths);
                employees = employees.Where(emp => emp.TerminationDate >= dateRangeStart);
            }
            else if ((ListType == "AllEmployees") || (ListType == null))
            {
                TempData["ButtonValue"] = "All Employees:";
            }
            return View(await employees.ToListAsync());

           }

        // GET: Employee/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create  - get the Create view
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create, take input from Create view and save to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,DeptId,EmpName,Position,HireDate,TerminationDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit - view
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit - take edited info / input and update the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,DeptId,EmpName,Position,HireDate,TerminationDate")] Employee employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpId))
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
            return View(employee);
        }

        // GET: Employee/Delete - display and ask for confirmation in view 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete - delete (confirmed)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmpId == id);
        }
    }
}
