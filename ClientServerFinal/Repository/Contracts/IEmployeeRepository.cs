using ClientServerFinal.ViewModel;
using Server.Models;

namespace Server.Repository.Contracts;
public interface IEmployeeRepository : IGeneralRepository<Employee, string> 
{
    Task<UserDataVM> GetUserDataByEmailAsync(string email);
    Task<EmployeeProfileVM> GetEmployeeDataByEmailAsync(string email);
}
