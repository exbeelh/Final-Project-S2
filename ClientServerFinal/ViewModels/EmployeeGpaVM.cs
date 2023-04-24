namespace ClientServerFinal.ViewModels
{
    public class EmployeeGpaVM
    {
        public string Major { get; set; } = null!;
        public string University { get; set; } = null!;
        public decimal AvgGpa { get; set; }
        public IEnumerable<EmployeeProfileVM> Employees { get; set; } = null!;
    }
}
