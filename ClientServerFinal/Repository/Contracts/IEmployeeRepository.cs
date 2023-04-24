using ClientServerFinal.Models;
using ClientServerFinal.ViewModels;

namespace ClientServerFinal.Repository.Contracts;
public interface IEmployeeRepository : IGeneralRepository<Employee, string>
{
    Task<UserDataVM> GetUserDataByEmailAsync(string email);
}
