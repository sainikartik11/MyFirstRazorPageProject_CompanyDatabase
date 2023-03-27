using DatabaseEPICORDb.Data;
using Epicor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace DatabaseEPICORDb.Pages.ViewPages
{
    [BindProperties]
    public class CreateDepartmentModel : PageModel
    {
        public readonly EpicorDbContext _db;
        public CreateDepartmentModel(EpicorDbContext db)
        {
            _db = db;
        }
        public Department Department { get; set; } = new Department();

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            { 
                _db.Departments.Add(Department);
               await _db.SaveChangesAsync();
                return RedirectToPage("./Index");
            } 
            return Page();
        }
    }
}
