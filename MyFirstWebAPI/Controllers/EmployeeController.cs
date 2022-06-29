using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
        public List<Employee> Employees = new List<Employee>()
        {
               new Employee()
               {
                   EmployeeId =100, EmployeeName="Radhika", EmployeeAddress ="Hyderabad"
               },
               new Employee()
               {
                   EmployeeId =101, EmployeeName="Lavanya" ,EmployeeAddress="Delhi"
               },
               new Employee()
               {
                   EmployeeId =102, EmployeeName="Ramya", EmployeeAddress="Mumbai"
               },
               new Employee()
               {
                   EmployeeId =103, EmployeeName="Amer" ,EmployeeAddress="Hyderabad"
               },
        };

        [HttpPost]
        public ActionResult AddEmployeeFromQuery([FromQuery] int EmployeeId, [FromQuery] string EmployeeName, [FromQuery] string EmployeeAddress)
        {
            Employees.Add(new Employee { EmployeeId = EmployeeId, EmployeeName = EmployeeName, EmployeeAddress = EmployeeAddress });

            return Ok($"Employee List is Added: {Employees} ");
        }

        [HttpGet]
        public ActionResult GetListOfAEmployeeFromQuery([FromQuery] int EmployeeId)
        {

            var employeeList = Employees.Where(e => e.EmployeeId == EmployeeId).ToList();
            if (employeeList.Count > 0)
            {
                var serializedOutput = JsonConvert.SerializeObject(employeeList);
                return Ok($"{serializedOutput}");
            }
            else
            {
                return Ok($"EmployeeID: {EmployeeId} does not have any employee details.");
            }
        }
        [HttpPut]
        public ActionResult UpdatedEmployeeDetailsFromQuery([FromQuery] int EmployeeId, [FromQuery] Employee employee)
        {

            var employeeDetails = Employees.Where(employeeDetails => employeeDetails.EmployeeId == EmployeeId).FirstOrDefault();
            if (employeeDetails == null)
            {
                return Ok($"Employee id {EmployeeId} not found");
            }
            else
            {
                employeeDetails.EmployeeName = employee.EmployeeName;
                employeeDetails.EmployeeAddress = employee.EmployeeAddress;
                var serializedOutput = JsonConvert.SerializeObject(employeeDetails);
                return Ok($"{serializedOutput} Employee is updated");
            }
        }
        [HttpPatch]
        public ActionResult UpdateOnlyEmployeeName([FromQuery] int EmployeeId, [FromQuery] Employee employee)
        {
            var employeeName = Employees.Where(o => o.EmployeeId == EmployeeId).FirstOrDefault();
            if (employeeName == null)
            {
                return Ok("Employee organisation id not found");
            }
            else
            {
                employeeName.EmployeeName = employee.EmployeeName;

                var serializedOutput = JsonConvert.SerializeObject(employeeName);
                return Ok($"{serializedOutput} Employee updated");
            }
        }
        [HttpDelete]
        public ActionResult DateteAEmployee([FromQuery] int EmployeeId)
        {
            var deleteEmployee = Employees.Where(o => o.EmployeeId == EmployeeId).FirstOrDefault();
            if (deleteEmployee == null)
            {
                return Ok($"Employee Id: {EmployeeId} not found");

            }
            else
            {
                Employees.Remove(deleteEmployee);

                return Ok($"Employee Id: {EmployeeId} removed from employee  list.");
            }

        }
        [HttpPost]
        public ActionResult AddEmployeeFromBody([FromBody] Employee employee)
        {
            Employees.Add(new Employee { EmployeeId = employee.EmployeeId, EmployeeName = employee.EmployeeName, EmployeeAddress = employee.EmployeeAddress });
            var serializedOutput = JsonConvert.SerializeObject(Employees);
            return Ok($"{serializedOutput} added in the employee List");
        }

        [HttpGet]
        public ActionResult GetListOfAEmployeeFromBody(int EmployeeId, [FromBody] Employee employee)
        {
            var employeeList = Employees.Where(e => e.EmployeeId == EmployeeId).ToList();
            var serializedOutput = JsonConvert.SerializeObject(employeeList);
            return Ok($"{serializedOutput}");

        }

        [HttpPut]
        public ActionResult UpdatedEmployeeDetailsFromBody(int EmployeeId, [FromBody] Employee employee)
        {

            var updateEmployee = Employees.Where(employee => employee.EmployeeId == EmployeeId).FirstOrDefault();
            if (updateEmployee == null)
            {
                return Ok("Employee  id not found");
            }
            else
            {
                updateEmployee.EmployeeName = employee.EmployeeName;
                updateEmployee.EmployeeAddress = employee.EmployeeAddress;
                var serializedOutput = JsonConvert.SerializeObject(updateEmployee);
                return Ok($"{serializedOutput} Employee is updated");
            }
        }

        [HttpPatch]
        public ActionResult UpdateOnlyNameFromBody(int EmployeeId, [FromBody] Employee employee)
        {
            var employeeName = Employees.Where(o => o.EmployeeId == EmployeeId).FirstOrDefault();
            if (employeeName == null)
            {
                return Ok("Employee id not found");
            }
            else
            {
                employeeName.EmployeeName = employee.EmployeeName;

                var serializedOutput = JsonConvert.SerializeObject(employeeName);
                return Ok($"{serializedOutput} Employee updated");
            }
        }
        [HttpDelete]
        public ActionResult DateteAEmployeeFromBody(int EmployeeId, [FromBody] Employee employee)
        {
            var deleteEmployee = Employees.Where(o => o.EmployeeId == EmployeeId).FirstOrDefault();
            if (deleteEmployee == null)
            {
                return Ok($"Employee Id: {EmployeeId} not found");

            }
            else
            {
                Employees.Remove(deleteEmployee);

                return Ok($"Employee Id: {EmployeeId} removed from employee  list.");
            }

        }
    }
}
