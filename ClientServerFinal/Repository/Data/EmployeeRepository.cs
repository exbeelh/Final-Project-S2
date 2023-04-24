using Server.Data;
using Server.Models;
using Server.Repository;
using Server.Repository.Contracts;

namespace Server.Repository.Data;

public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
{
    public EmployeeRepository(MyContext context) : base(context)
    {
    }
}
