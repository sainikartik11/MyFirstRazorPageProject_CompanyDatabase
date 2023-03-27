using DatabaseEPICORDb.Data;
using Epicor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace DatabaseEPICORDb.Pages.ViewPages
{
   
    [BindProperties]
    public class IndexModel : PageModel
    {

        public readonly EpicorDbContext _db;
        public List<Employee> Employees { get; set; }
        //public int id;
        //public Employee employee { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        public string SortOrder { get; set; }
        public string SearchString { get; set; }
        public IndexModel(EpicorDbContext db)
        {
            _db = db;
        }
       
        
        public IActionResult OnGet()
        {
            Departments = _db.Departments.ToList();
            if(Departments.Count==0) 
            {
                return RedirectToPage("CreateDepartment");
            }
            else
            Employees = _db.Employees.ToList();
            return Page();
        }
        public void OnPost()
        {
            //employee = _db.Employees.Find(id);
            //ViewData["ManagerId"] = new SelectList(_db.Employees, "Id", "Name");
            //ViewData["DepartmentID"] = new SelectList(_db.Departments, "Id", "Name");

            if (SearchString != null)
            {
                switch (SortOrder)
                {
                    case "Employee_Name":
                        Employees = _db.Employees.Where(e => e.Name.Contains(SearchString)).OrderBy(e => e.Name).ToList();
                        break;
                    case "Department_ID":
                        Employees = _db.Employees.Where(e => e.Name.Contains(SearchString)).OrderBy(e => e.DepartmentId).ToList();
                        break;
                    case "Manager_ID":
                        Employees = _db.Employees.Where(e => e.Name.Contains(SearchString)).OrderBy(e => e.ManagerId).ToList();
                        break;
                    default:
                        Employees = _db.Employees.Where(e => e.Name.Contains(SearchString)).OrderBy(e => e.Id).ToList();
                        break;
                }
            }
            else
            {
                switch (SortOrder)
                {
                    case "Employee_Name":
                        Employees = _db.Employees.OrderBy(e => e.Name).ToList();
                        break;
                    case "Department_ID":
                        Employees = _db.Employees.OrderBy(e => e.DepartmentId).ToList();
                        break;
                    case "Manager_ID":
                        Employees = _db.Employees.OrderBy(e => e.ManagerId).ToList();
                        break;
                    default:
                        Employees = _db.Employees.OrderBy(e => e.Id).ToList();
                        break;
                }
            }

        }
    }
}
