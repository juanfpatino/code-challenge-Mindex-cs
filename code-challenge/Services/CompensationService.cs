using challenge.Models;

namespace challenge.Services
{
    public interface CompensationService
    {
        Compensation read(string employeeID);
        Compensation create(Compensation compensation);

    }
}
