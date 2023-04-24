using Server.Models;
using Server.ViewModels;

namespace Server.Repository.Contracts;
public interface IAccountRepository : IGeneralRepository<Account, string>
{
    Task<int> Register(RegisterVM registerVM);
    Task<bool> Login(LoginVM loginVM);
    Task<UserDataVM> GetUserData(string email);
    Task<IEnumerable<string>> GetRolesByEmail(string email);
    Task<Account?> GetByEmail(string email);
}
