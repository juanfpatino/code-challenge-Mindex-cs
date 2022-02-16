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
    public class CompensationRepository : ICompensationRepository
    {
        private readonly CompensationContext _compContext;
        private readonly ILogger<CompensationRepository> _logger;

        public CompensationRepository(ILogger<CompensationRepository> logger, CompensationContext _compContext)
        {
            this._compContext = _compContext;
            _logger = logger;
        }

        public Compensation Add(Compensation comp)
        {
            comp.getEmployee().EmployeeId = Guid.NewGuid().ToString();
            _compContext.Compensations.Add(comp);
            return comp;
        }

        public Compensation GetById(string id)
        {
            return _compContext.Compensations.SingleOrDefault(e => e.getEmployee().EmployeeId == id);
        }

        public Task SaveAsync()
        {
            return _compContext.SaveChangesAsync();
        }

        public Compensation Remove(Compensation comp)
        {
            return _compContext.Remove(comp).Entity;
        }


    }
}
