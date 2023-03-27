using DatabaseEPICORDb.Data;
using Epicor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DatabaseEPICORDb.Pages.ViewPages
{
    [BindProperties]
    public class EditModel : PageModel
    {

        public readonly EpicorDbContext _db;
        public Employee Employees { get; set; }
        public EditModel(EpicorDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Employees = _db.Employees.Find(id);
            ViewData["ManagerId"] = new SelectList(_db.Employees,"Id","Name");
            ViewData["DepartmentID"]=new SelectList(_db.Departments,"Id","Name");
        }
        public IActionResult OnPost()
        {
            _db.Employees.Update(Employees);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
