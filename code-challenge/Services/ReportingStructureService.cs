using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;


namespace challenge.Services

{
    public class ReportingStructureService : IReportingStructureService
    {

        private readonly IReportingStructureRepository _reportingStructureRepository;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IReportingStructureRepository _reportingStructureRepository)
        {
            this._reportingStructureRepository = _reportingStructureRepository;
            _logger = logger;
        }

        public ReportingStructure Create(ReportingStructure rep)
        {
            if (rep != null)
            {
                _reportingStructureRepository.Add(rep);
                _reportingStructureRepository.SaveAsync().Wait();
            }

            return rep;
        }

        public ReportingStructure GetById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _reportingStructureRepository.GetById(id);
            }

            return null;
        }

        public ReportingStructure Replace(ReportingStructure originalRep, ReportingStructure newRep)
        {
            if (originalRep != null)
            {
                _reportingStructureRepository.Remove(originalRep);
                if (newRep != null)
                {
                    // ensure the original has been removed, otherwise EF will complain another entity w/ same id already exists
                    _reportingStructureRepository.SaveAsync().Wait();

                    _reportingStructureRepository.Add(newRep);
                    // overwrite the new id with previous employee id
                    newRep.getEmployee().EmployeeId = originalRep.getEmployee().EmployeeId;
                }
                _reportingStructureRepository.SaveAsync().Wait();
            }

            return newRep;
        }

    }
}
