using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using challenge.Data;


namespace challenge.Repositories
{
    public class ReportingStructureRepository : IReportingStructureRepository
    {
        private readonly ReportingStructureContext _reportingStructureContext;
        private readonly ILogger<IReportingStructureRepository> _logger;

        public ReportingStructureRepository(ILogger<IReportingStructureRepository> logger, ReportingStructureContext repContext) {

            _reportingStructureContext = repContext;
            _logger = logger;
        
        }

        public ReportingStructure Add(ReportingStructure rep) { 
        
            rep.getEmployee().EmployeeId = Guid.NewGuid().ToString();
            _reportingStructureContext.ReportingStructures.Add(rep);
            return rep;

        }

        public ReportingStructure GetById(string id)
        {
            return _reportingStructureContext.ReportingStructures.SingleOrDefault(e => e.getEmployee().EmployeeId == id);
        }

        public Task SaveAsync()
        {
            return _reportingStructureContext.SaveChangesAsync();
        }

        public ReportingStructure Remove(ReportingStructure rep)
        {
            return _reportingStructureContext.Remove(rep).Entity;
        }


    }
}
