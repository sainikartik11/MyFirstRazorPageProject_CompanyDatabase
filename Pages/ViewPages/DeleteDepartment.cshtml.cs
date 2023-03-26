using DatabaseEPICORDb.Data;
using Epicor2Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseEPICORDb.Pages.ViewPages
{
    [BindProperties]
    public class DeleteDepartmentModel : PageModel
    {
        public readonly EpicorDbContext _db;
        public DeleteDepartmentModel(EpicorDbContext db)
        {
            _db = db;
        }
        public List<Department> Department { get; set; }
       
        public void OnGet()
        {
            Department =_db.Departments.ToList();
        }
       
    }
}
