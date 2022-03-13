using link.Models;
using Microsoft.AspNetCore.Mvc;

namespace link.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class HomeController : Controller
    {

        private readonly BaseContext _context;

        public HomeController(BaseContext baseContext)
        {
            _context = baseContext;
        }
        [HttpGet("task-1")]
        public IEnumerable<Employee> getTask1()
        {
            var employee = _context.Employees.ToList();
            return employee;
        }
        //TODO 28. Napisz zapytanie wyświetlające nazwisko,
        //TODO stanowisko oraz wynagrodzenie dla wszystkich pracowników, których stanowisko to IT_PROG lub SH_CLERK,
        //TODO a wynagrodzenie nie jest równe 4500, 10000 lub 15000, wynik posortuj rosnąco. [employees]
        [HttpGet("task-28")]
        public IEnumerable<EmployeeSimple> getTask28()
        {
            var employee = _context.Employees
                .Where(e => e.JobId.Contains("IT_PROG") || e.JobId.Contains("SH_CLERK"))
                .Where(e => e.Salary != 4500 || e.Salary != 10000 || e.Salary != 15000)
                .Select(e => new EmployeeSimple() { Name = e.FirstName, LastName = e.LastName, Salary = e.Salary })
                .ToList();
            return employee;
        }
    }

    public class EmployeeSimple
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }

}

