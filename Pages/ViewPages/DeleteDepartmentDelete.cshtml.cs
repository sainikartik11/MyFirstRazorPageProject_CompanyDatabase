using DatabaseEPICORDb.Data;
using Epicor2Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseEPICORDb.Pages.ViewPages
{
    [BindProperties]
    public class DeleteDepartmentDeleteModel : PageModel
    {
        public readonly EpicorDbContext _db;
        public Department Department { get; set; }
        public List<Department> Departmentss { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Employee> UpadteEmployee { get; set; }
        public int ID;
        public DeleteDepartmentDeleteModel(EpicorDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            ID = id;
            if (id == 5)
            {
                return;
            }
            Department = _db.Departments.Find(id);
            Employees = _db.Employees.ToList();

        }
        public IActionResult OnPost()
        {
            if (Department.Id == 5)
            {
                return RedirectToPage("DeleteDepartment");
            }
            UpadteEmployee = _db.Employees.Where(e => e.DepartmentId == Department.Id).ToList();
            foreach (var item in UpadteEmployee)
            {
                Department d = _db.Departments.FirstOrDefault(e => e.Name == "Temporary");
                item.DepartmentId = d.Id;
                _db.Employees.Update(item);
                _db.Departments.Remove(Department);
            }
            _db.SaveChanges();
            return RedirectToPage("Index");
       
        }
    }
}
