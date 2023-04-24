using ClientServerFinal.Data;
using ClientServerFinal.Models;
using ClientServerFinal.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ClientServerFinal.Repository.Data;

public class UniversityRepository : GeneralRepository<University, int, MyContext>, IUniversityRepository
{
    public UniversityRepository(MyContext context) : base(context)
    {
    }

    public async Task<University?> GetByName(string name)
    {
        return await _context.Set<University>().FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<bool> IsNameExist(string name)
    {
        var entity = await _context.Set<University>().FirstOrDefaultAsync(x => x.Name == name);
        return entity is not null;
    }

    public override async Task<University?> InsertAsync(University entity)
    {
        if (await IsNameExist(entity.Name))
        {
            return await GetByName(entity.Name);
        }

        return await base.InsertAsync(entity);
    }
}
