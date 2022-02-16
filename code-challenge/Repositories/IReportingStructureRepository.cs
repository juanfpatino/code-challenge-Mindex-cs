using challenge.Models;
using System;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public interface IReportingStructureRepository
    {

        ReportingStructure GetById(String id);
        ReportingStructure Add(ReportingStructure rep);
        ReportingStructure Remove(ReportingStructure rep);

        Task SaveAsync();

    }
}
