using Server.Data;
using Server.Models;
using Server.ViewModels;
using Server.Repository;
using Server.Repository.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Server.Repository.Data;

public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
{
    public EmployeeRepository(MyContext context) : base(context)
    {
    }

    public async Task<UserDataVM> GetUserDataByEmailAsync(string email)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
        return new UserDataVM
        {
            Nik = employee!.Nik,
            Email = employee.Email,
            FullName = string.Concat(employee.FirstName, " ", employee.LastName)
        };
    }
}
