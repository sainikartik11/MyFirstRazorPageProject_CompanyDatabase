using DatabaseEPICORDb.Data;
using Epicor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DatabaseEPICORDb.Pages.ViewPages
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        public readonly EpicorDbContext _db;
        public Employee Employees { get; set; }
        public CreateModel(EpicorDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            ViewData["DepartmentId"] = new SelectList(_db.Departments, "Id", "Name");
            ViewData["ManagerId"] = new SelectList(_db.Employees, "Id", "Name");
           
        }
        public async Task<IActionResult> OnPost()
        {
            await _db.Employees.AddAsync(Employees);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
