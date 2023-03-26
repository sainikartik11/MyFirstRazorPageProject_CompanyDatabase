using DatabaseEPICORDb.Data;
using Epicor2Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseEPICORDb.Pages.ViewPages
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public readonly EpicorDbContext _db;
        public Employee Employees { get; set; }
        public DeleteModel(EpicorDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Employees = _db.Employees.Find(id);
        }
        public IActionResult OnPost()
        {
             _db.Remove(Employees);
             _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
