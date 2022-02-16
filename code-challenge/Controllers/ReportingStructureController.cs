using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/reportingstructure")]

    public class ReportingStructureController : Controller
    {

        private readonly ILogger _logger;
        private readonly IReportingStructureService _reportingStructureService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingStructureService _reportingStructureService) { 
        
            _logger = logger;
            this._reportingStructureService = _reportingStructureService;

        }

        [HttpPost]
        public IActionResult CreateReportingStructure([FromBody] ReportingStructure rep)
        {
            _logger.LogDebug($"Received ReportingStructure create request for '{rep.getEmployee().FirstName} {rep.getEmployee().LastName}'");

            _reportingStructureService.Create(rep);

            return CreatedAtRoute("getEmployee().getEmployeeById", new { id = rep.getEmployee().EmployeeId }, rep);
        }

        public IActionResult GetReportingStructureById(String id)
        {
            _logger.LogDebug($"Received employee get request for '{id}'");

            var reportingStructure = _reportingStructureService.GetById(id);

            if (reportingStructure == null)
                return NotFound();

            return Ok(reportingStructure);
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceReportingStructure(String id, [FromBody] ReportingStructure newRep)
        {
            _logger.LogDebug($"Recieved employee update reporting structure request for '{id}'");

            var existingRep = _reportingStructureService.GetById(id);
            if (existingRep == null)
                return NotFound();

            _reportingStructureService.Replace(existingRep, newRep);

            return Ok(newRep);
        }


    }
}
