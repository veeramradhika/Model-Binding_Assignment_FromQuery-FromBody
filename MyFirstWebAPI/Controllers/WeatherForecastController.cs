using Microsoft.AspNetCore.Mvc;
namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {

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

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public ActionResult PostEmployee()
        {
            Employees.Add(new Employee { EmployeeId = 104, EmployeeName = "Srilekha", EmployeeAddress = "Delhi" });

            return Ok(Employees);
        }
        [HttpGet]
        public ActionResult GetEmployee()
        {
            return Ok(Employees);
        }
        [HttpPut]
        public ActionResult PutEmployee()
        {
            Employees.Add(new Employee { EmployeeId = 1005, EmployeeName = "PutEmployeeName", EmployeeAddress = "PutEmployeeAddress" });
            return Ok(Employees);
        }
        [HttpDelete]
        public ActionResult DeleteEmployee()
        {
            Employees.RemoveAt(0);
            return Ok(Employees);
        }
        [HttpPatch]
        public ActionResult PatchEmployee(int Id, [FromBody] string Name)
        {
            var employee = Employees.FirstOrDefault(x => x.EmployeeId == Id);
            if (employee == null)
                return Ok("Wrong Employee ID");
            else
                employee.EmployeeName = Name;
            return Ok(employee);
        }


    }
}