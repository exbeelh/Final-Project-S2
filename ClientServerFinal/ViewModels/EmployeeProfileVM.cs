using ClientServerFinal.Utils;

namespace ClientServerFinal.ViewModels
{
    public class EmployeeProfileVM
    {
        public string Nik { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public GenderEnum Gender { get; set; }
        public string Email { get; set; } = null!;
        public string Major { get; set; } = null!;
        public string Degree { get; set; } = null!;
        public decimal Gpa { get; set; }
        public string University { get; set; } = null!;
        public DateTime HiringDate { get; set; }
    }
}
