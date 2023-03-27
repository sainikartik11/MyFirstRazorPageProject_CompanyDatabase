using DatabaseEPICORDb.Data;
using Epicor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DatabaseEPICORDb.Pages.ViewPages
{
    [BindProperties]
    public class DetailsModel : PageModel
    {

        public readonly EpicorDbContext _db;
        public Employee Employees { get; set; }
        public Employee Manager { get; set; }
        public Department departments { get; set; }
        public DetailsModel(EpicorDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Employees = _db.Employees.Include(e=>e.Department).Include(e => e.Manager).FirstOrDefault(e => e.Id == id);
            //if (Employees != null)
            //{
            //    departments = Employees.Department;
            //    Manager=Employees.Manager;
            //}
        }
    }
}
