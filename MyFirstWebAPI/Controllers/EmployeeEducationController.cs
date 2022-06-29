using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class EmployeeEducationController : Controller
    {
        private readonly ILogger<EmployeeEducationController> _logger;
        public EmployeeEducationController(ILogger<EmployeeEducationController> logger)
        {
            _logger = logger;
        }
        static List<EmployeeEducation> employeeEducations = new List<EmployeeEducation>
        {
            new EmployeeEducation()
            {
                EmployeeEducationId=1000,
                CourseName="Python",
                UniversityName="JNTUK",
                MarksPercentage=90,
                EmployeeId=100
            },
            new EmployeeEducation()
            {
                EmployeeEducationId=1001,
                CourseName="C",
                UniversityName="JNTUA",
                MarksPercentage=80,
                EmployeeId=101
            },
            new EmployeeEducation()
            {
                EmployeeEducationId=1002,
                CourseName="SQL",
                UniversityName="JNTUH",
                MarksPercentage=90,
                EmployeeId=102
            },
        };


        [HttpPost]
        public ActionResult AddEmployeeEduFromQuery([FromQuery] int EmployeeEducationId, [FromQuery] string CourseName, [FromQuery] string UniversityName, [FromQuery] int MarksPercentage, [FromQuery] int EmployeeId)
        {
            employeeEducations.Add(new EmployeeEducation { EmployeeEducationId = EmployeeEducationId, CourseName = CourseName, UniversityName = UniversityName, MarksPercentage = MarksPercentage, EmployeeId = EmployeeId });
            var serializedOutput = JsonConvert.SerializeObject(employeeEducations);
            return Ok($"{serializedOutput} employee Education List is added");
        }

        [HttpGet]
        public ActionResult GetEduListOfAEmployeeFromQuery([FromQuery] int EmployeeId)
        {

            var empEduList = employeeEducations.Where(e => e.EmployeeId == EmployeeId).ToList();
            if (empEduList.Count > 0)
            {
                var serializedOutput = JsonConvert.SerializeObject(empEduList);
                return Ok($"{serializedOutput}");
            }
            else
            {
                return Ok($"EmployeeID: {EmployeeId} does not have any education details.");
            }


        }

        [HttpPut]
        public ActionResult UpdatedEmployeeEduDetailsFromQuery([FromQuery] int EmployeeEducationId,EmployeeEducation employeeEducation)
        {
            var employeeDetails = employeeEducations.Where(employee => employee.EmployeeEducationId == EmployeeEducationId).FirstOrDefault();
            if (employeeDetails == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {

                employeeDetails.CourseName = employeeEducation.CourseName;
                employeeDetails.UniversityName = employeeEducation.UniversityName;
                employeeDetails.MarksPercentage = employeeEducation.MarksPercentage;
                employeeDetails.EmployeeId = employeeEducation.EmployeeId;
                var serializedOutput = JsonConvert.SerializeObject(employeeDetails);
                return Ok($"{serializedOutput} updated");
            }


        }

        [HttpPatch]
        public ActionResult UpdateOnlyMarksPercantageFieldFromQuery([FromQuery] int EmployeeEducationId, [FromQuery] int updatedPercantage)
        {
            var employee = employeeEducations.Where(employee => employee.EmployeeEducationId == EmployeeEducationId).FirstOrDefault();
            if (employee == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                employee.MarksPercentage = updatedPercantage;
                var serializedOutput = JsonConvert.SerializeObject(employee);
                return Ok($"{serializedOutput} updated");
            }
        }

        [HttpDelete]
        public ActionResult DateteAEmployeeFromQuery([FromQuery] int EmployeeEducationId)
        {
            var deleteEmployee = employeeEducations.Where(e => e.EmployeeEducationId == EmployeeEducationId).FirstOrDefault();
            if (deleteEmployee != null)
            {
                employeeEducations.Remove(deleteEmployee);

                return Ok($"EmployeeId: {EmployeeEducationId} removed from employee edu list.");
            }
            else
            {
                return Ok($"EmployeeId: {EmployeeEducationId} not found");
            }

        }

        [HttpPost]
        public ActionResult AddEmployeeEducationnFromBody([FromBody] EmployeeEducation employeeEducation)
        {
            employeeEducations.Add(new EmployeeEducation { EmployeeEducationId = employeeEducation.EmployeeEducationId, CourseName = employeeEducation.CourseName, UniversityName = employeeEducation.UniversityName, MarksPercentage = employeeEducation.MarksPercentage, EmployeeId = employeeEducation.EmployeeId });
            var serializedOutput = JsonConvert.SerializeObject(employeeEducations);
            return Ok($"{serializedOutput} added in the employee Education List");
        }

        [HttpGet]
        public ActionResult GetEduListOfAEmployeeFromBody([FromBody] int EmployeeId)
        {

            var empEduList = employeeEducations.Where(e => e.EmployeeId == EmployeeId).ToList();
            var serializedOutput = JsonConvert.SerializeObject(empEduList);
            return Ok($"{serializedOutput}");

        }

        [HttpPut]
        public ActionResult UpdatedEmployeeEduDetailsFromBody([FromBody] EmployeeEducation employeeEducation)
        {
            var employeeDetails = employeeEducations.Where(employee => employee.EmployeeEducationId == employeeEducation.EmployeeEducationId).FirstOrDefault();
            if (employeeDetails == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                employeeDetails.CourseName = employeeEducation.CourseName;
                employeeDetails.UniversityName = employeeEducation.UniversityName;
                employeeDetails.MarksPercentage = employeeEducation.MarksPercentage;
                var serializedOutput = JsonConvert.SerializeObject(employeeDetails);
                return Ok($"{serializedOutput} updated");
            }


        }

        [HttpPatch]
        public ActionResult UpdateOnlyMarksPercantageFieldFromBody( int EmployeeEducationId, [FromBody] EmployeeEducation employeeEducation)
        {
            var employee = employeeEducations.Where(employee => employee.EmployeeEducationId == EmployeeEducationId).FirstOrDefault();
            if (employee == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                employee.MarksPercentage = employeeEducation.MarksPercentage;
                var serializedOutput = JsonConvert.SerializeObject(employee);
                return Ok($"{serializedOutput} updated");
            }
        }

        [HttpDelete]
        public ActionResult DeleteEmployeeFromBody([FromBody] int EmployeeEducationId)
        {
            var deleteEmployee = employeeEducations.Where(e => e.EmployeeEducationId == EmployeeEducationId).FirstOrDefault();
            if (deleteEmployee != null)
            {
                employeeEducations.Remove(deleteEmployee);

                return Ok($"EmployeeId: {EmployeeEducationId} removed from employee education list.");
            }
            else
            {
                return Ok($"EmployeeId: {EmployeeEducationId} not found");
            }

        }

    }
}
