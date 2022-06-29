using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeOrganisationController : Controller
    {
        private readonly ILogger<EmployeeOrganisationController> _logger;
        public EmployeeOrganisationController(ILogger<EmployeeOrganisationController> logger)
        {
            _logger = logger;
        }
        public List<EmployeeOrganisation> Organisations = new List<EmployeeOrganisation>
        {
            new EmployeeOrganisation()
            {
                OrganisationId = 1,
                OrganisationName ="TCS",
                EmployeeId = 100
            },
            new EmployeeOrganisation()
            {
                OrganisationId = 2,
                OrganisationName ="Kelltech",
                EmployeeId = 101
            },
        };
        
        [HttpPost]
        public ActionResult AddEmployeeOrganisationFromQuery([FromQuery] int OrganisationId, [FromQuery] string OrganisationName, [FromQuery] int EmployeeId)
        {
            Organisations.Add(new EmployeeOrganisation { OrganisationId = OrganisationId, OrganisationName = OrganisationName, EmployeeId = EmployeeId });

            return Ok($"Employee Organisation List is Added: {Organisations} ");
        }
        [HttpGet]
        public ActionResult GetOrganisationListOfAEmployeeFromQuery([FromQuery] int OrganisationId)
        {

            var employeeOrganisatonList = Organisations.Where(e => e.OrganisationId == OrganisationId).ToList();
            if (employeeOrganisatonList.Count > 0)
            {
                var serializedOutput = JsonConvert.SerializeObject(employeeOrganisatonList);
                return Ok($"{serializedOutput}");
            }
            else
            {
                return Ok($"EmployeeID: {OrganisationId} does not have any Organisation details.");
            }
        }
        [HttpPut]
        public ActionResult UpdatedEmployeeOrganisationDetailsFromQuery([FromQuery] int OrganisationId, [FromQuery] EmployeeOrganisation Organisation)
        {

            var organisation = Organisations.Where(organisation => organisation.OrganisationId == OrganisationId).FirstOrDefault();
            if (organisation == null)
            {
                return Ok("Employee organisation id not found");
            }
            else
            {
                organisation.OrganisationName = Organisation.OrganisationName;
                organisation.EmployeeId = Organisation.EmployeeId;
                var serializedOutput = JsonConvert.SerializeObject(organisation);
                return Ok($"{serializedOutput} Employee organisation is updated");
            }
        }
        [HttpPatch]
        public ActionResult UpdateOnlyOragnisationName([FromQuery] int OrganisationId, [FromQuery] EmployeeOrganisation employeeOrganisation)
        {
           var empOrgnasition=Organisations.Where(o => o.OrganisationId== OrganisationId).FirstOrDefault();
            if(empOrgnasition == null)
            {
                return Ok("Employee organisation id not found");
            }
            else
            {
                empOrgnasition.OrganisationName = employeeOrganisation.OrganisationName;
                
                var serializedOutput = JsonConvert.SerializeObject(employeeOrganisation);
                return Ok($"{serializedOutput} Employee organisation updated");
            }
        }
        [HttpDelete]
        public ActionResult DateteAEmployeeOrganisation([FromQuery] int OrganisationId)
        {
            var deleteEmployeeOrganisation = Organisations.Where(o => o.OrganisationId == OrganisationId).FirstOrDefault();
            if (deleteEmployeeOrganisation == null)
            {
                return Ok($"OrganisationId: {OrganisationId} not found");
                
            }
            else
            {
                Organisations.Remove(deleteEmployeeOrganisation);

                return Ok($"OrganisationId: {OrganisationId} removed from employee organisation list.");
            }

        }
        [HttpPost]
        public ActionResult AddEmployeeOrganisationFromBody([FromBody] EmployeeOrganisation employeeOrganisation)
        {
            Organisations.Add(new EmployeeOrganisation { OrganisationId = employeeOrganisation.OrganisationId, OrganisationName=employeeOrganisation.OrganisationName,EmployeeId=employeeOrganisation.EmployeeId});
            var serializedOutput = JsonConvert.SerializeObject(Organisations);
            return Ok($"{serializedOutput} added in the employeeEduList");
        }

        [HttpGet]
        public ActionResult GetOrganistionListOfAEmployeeFromBody( int OrganisationId,[FromBody] EmployeeOrganisation employeeOrganisation)
        {
            var employeeOrganisationList = Organisations.Where(e => e.OrganisationId == OrganisationId).ToList();
            var serializedOutput = JsonConvert.SerializeObject(employeeOrganisationList);
            return Ok($"{serializedOutput}");

        }

        [HttpPut]
        public ActionResult UpdatedEmployeeOrganisationDetailsFromBody(int OrganisationId, [FromBody] EmployeeOrganisation Organisation)
        {

            var organisation = Organisations.Where(organisation => organisation.OrganisationId == OrganisationId).FirstOrDefault();
            if (organisation == null)
            {
                return Ok("Employee organisation id not found");
            }
            else
            {
                organisation.OrganisationName = Organisation.OrganisationName;
                organisation.EmployeeId = Organisation.EmployeeId;
                var serializedOutput = JsonConvert.SerializeObject(organisation);
                return Ok($"{serializedOutput} Employee organisation is updated");
            }
        }

        [HttpPatch]
        public ActionResult UpdateOnlyOragnisationNameFromBody( int OrganisationId, [FromBody] EmployeeOrganisation employeeOrganisation)
        {
            var empOrgnasition = Organisations.Where(o => o.OrganisationId == OrganisationId).FirstOrDefault();
            if (empOrgnasition == null)
            {
                return Ok("Employee organisation id not found");
            }
            else
            {
                empOrgnasition.OrganisationName = employeeOrganisation.OrganisationName;

                var serializedOutput = JsonConvert.SerializeObject(employeeOrganisation);
                return Ok($"{serializedOutput} Employee organisation updated");
            }
        }
        [HttpDelete]
        public ActionResult DateteAEmployeeOrganisationFromBody(int OrganisationId, [FromBody] EmployeeOrganisation employeeOrganisation)
        {
            var deleteEmployeeOrganisation = Organisations.Where(o => o.OrganisationId == OrganisationId).FirstOrDefault();
            if (deleteEmployeeOrganisation == null)
            {
                return Ok($"OrganisationId: {OrganisationId} not found");

            }
            else
            {
                Organisations.Remove(deleteEmployeeOrganisation);

                return Ok($"OrganisationId: {OrganisationId} removed from employee organisation list.");
            }

        }
    }
  
}
