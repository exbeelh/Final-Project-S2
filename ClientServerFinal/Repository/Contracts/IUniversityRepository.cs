using ClientServerFinal.Models;

namespace ClientServerFinal.Repository.Contracts;
public interface IUniversityRepository : IGeneralRepository<University, int> 
{
    Task<University?> GetByName(string name);
    Task<bool> IsNameExist(string name);
}
