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
    [Route("api/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received compensation create request for '{compensation.getEmployee().FirstName} {compensation.getEmployee().LastName}'");

            _compensationService.Create(compensation);

            return CreatedAtRoute("GetCompensationByEmployeeId", new { id = compensation.getEmployee().EmployeeId }, compensation);
        }

        [HttpGet("{id}", Name = "GetCompensationByEmployeeId")]
        public IActionResult GetCompensationByEmployeeId(String id)
        {
            _logger.LogDebug($"Received employee compensation get request for '{id}'");

            var compensation = _compensationService.GetById(id);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceCompensation(String id, [FromBody] Compensation newComp)
        {
            _logger.LogDebug($"Recieved employee compensation update request for '{id}'");

            var existingComp = _compensationService.GetById(id);
            if (existingComp == null)
                return NotFound();

            _compensationService.Replace(existingComp, newComp);

            return Ok(newComp);
        }


    }
}
