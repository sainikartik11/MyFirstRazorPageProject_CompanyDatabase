using DatabaseEPICORDb.Data;
using Epicor2Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseEPICORDb.Pages.ViewPages
{
    [BindProperties]
    public class StructureModel : PageModel
    {
        public readonly EpicorDbContext _db;
        public StructureModel(EpicorDbContext db)
        {
            _db = db;
        }
        public Employee Employee { get; set; }
        //public List<Employee> Employees { get; set; } = new List<Employee>();
        //Dictionary<int,List<Employee>> map = new Dictionary<int,List<Employee>>();
        public List<Employee> Managers { get; set; }
        public void OnGet(int id)
        {
            Managers = new List<Employee>();
            Employee = _db.Employees.Find(id);
            while (Employee.ManagerId != null)
            {
                Managers.Add(Employee);
                Employee = _db.Employees.Find(Employee.ManagerId);
            }
            Employee = _db.Employees.FirstOrDefault(e => e.ManagerId == null);
            Managers.Add((Employee)Employee);
            Managers.Reverse();

            //List<Employee>e=new List<Employee>();
            //Employee=_db.Employees.FirstOrDefault(x => x.ManagerId == null);
            //e.Add(Employee);
            //map.Add(0,e);

            //Employees=_db.Employees.ToList();
            //foreach(var obj in map)

        }

    }
}
