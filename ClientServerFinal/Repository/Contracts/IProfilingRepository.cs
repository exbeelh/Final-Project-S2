using ClientServerFinal.ViewModel;
using Server.Models;

namespace Server.Repository.Contracts;
public interface IProfilingRepository : IGeneralRepository<Profiling, string> 
{
    Task<IEnumerable<Employee>> GetEmployeesByLengthOfWorkDescending();
    Task<IEnumerable<EmployeeTotalVM>> GetEmployeesTotalByMajorAndUniversity();
    Task<IEnumerable<EmployeeGpaVM>> GetEmployeesAboveAvgGPAByMajorAndUniversity(int year);
}

