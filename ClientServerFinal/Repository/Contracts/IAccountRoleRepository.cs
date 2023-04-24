using ClientServerFinal.Models;

namespace ClientServerFinal.Repository.Contracts;
public interface IAccountRoleRepository : IGeneralRepository<AccountRole, int>
{
    Task<IEnumerable<string>> GetRolesByNikAsync(string nik);
}
