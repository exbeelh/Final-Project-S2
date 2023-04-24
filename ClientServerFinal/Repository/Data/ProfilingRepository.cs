using ClientServerFinal.ViewModels;
using Microsoft.EntityFrameworkCore;
using ClientServerFinal.Data;
using ClientServerFinal.Models;
using ClientServerFinal.Repository.Contracts;

namespace ClientServerFinal.Repository.Data
{
    public class ProfilingRepository : GeneralRepository<Profiling, string, MyContext>, IProfilingRepository
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;

        public ProfilingRepository(MyContext context, IEducationRepository educationRepository, IUniversityRepository universityRepository) : base(context)
        {
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByLengthOfWorkDescending()
        {
            var getEmployees = await _context.Set<Employee>().ToListAsync();
            var getEmployeesByLengthOfWorkDescending = getEmployees.OrderByDescending(x => x.HiringDate);

            return getEmployeesByLengthOfWorkDescending;
        }

        public async Task<IEnumerable<EmployeeTotalVM>> GetEmployeesTotalByMajorAndUniversity()
        {
            var getEmployees = await _context.Set<Employee>().ToListAsync();
            var getProfiling = await GetAllAsync();
            var getEducations = await _educationRepository.GetAllAsync();
            var getUniversities = await _universityRepository.GetAllAsync();

            var getEmployeesTotalByMajorAndUniversity = getProfiling
                .Join(getEmployees, p => p.EmployeeNik, e => e.Nik, (p, e) => new { p, e })
                .Join(getEducations, pe => pe.p.EducationId, ed => ed.Id, (pe, ed) => new { pe, ed })
                .Join(getUniversities, ped => ped.ed.UniversityId, un => un.Id, (ped, un) => new { ped, un })
                .GroupBy(x => new { x.ped.ed.Major, x.un.Name })
                .Select(x => new EmployeeTotalVM
                {
                    Major = x.Key.Major,
                    University = x.Key.Name,
                    TotalEmployees = x.Count()
                })
                .OrderByDescending(x => x.TotalEmployees)
                .ToList();

            return getEmployeesTotalByMajorAndUniversity;
        }

        public async Task<IEnumerable<EmployeeGpaVM>> GetEmployeesAboveAvgGPAByMajorAndUniversity(int year)
        {
            var getEmployees = await _context.Set<Employee>().ToListAsync();
            var getProfiling = await GetAllAsync();
            var getEducations = await _educationRepository.GetAllAsync();
            var getUniversities = await _universityRepository.GetAllAsync();

            var getEmployeesAboveAvgGPAByDegreeAndUniversity = from profiling in getProfiling
                                                               join employee in getEmployees on profiling.EmployeeNik equals employee.Nik
                                                               join education in getEducations on profiling.EducationId equals education.Id
                                                               join university in getUniversities on education.UniversityId equals university.Id
                                                               where employee.HiringDate.Year == year
                                                               group new { employee, education, university } by new { education.Major, university.Name }
                                                               into g
                                                               let avgGPA = g.Average(x => x.education.Gpa)
                                                               from employee in g
                                                               where employee.education.Gpa > avgGPA
                                                               select new EmployeeGpaVM
                                                               {
                                                                   Major = g.Key.Major,
                                                                   University = g.Key.Name,
                                                                   AvgGpa = avgGPA,
                                                                   Employees = g.Select(d => new EmployeeProfileVM
                                                                   {
                                                                       Nik = d.employee.Nik,
                                                                       FullName = d.employee.FirstName + " " + d.employee.LastName,
                                                                       Gender = d.employee.Gender,
                                                                       Email = d.employee.Email,
                                                                       Major = d.education.Major,
                                                                       Degree = d.education.Degree,
                                                                       Gpa = d.education.Gpa,
                                                                       University = d.university.Name,
                                                                       HiringDate = d.employee.HiringDate
                                                                   }).Where(x => x.Gpa > avgGPA)
                                                               };

            return getEmployeesAboveAvgGPAByDegreeAndUniversity;
        }
    }
}
