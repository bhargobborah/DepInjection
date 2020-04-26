using System.ComponentModel.DataAnnotations;

namespace DependencyInjectionWithUnity.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string EmpCode { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string OfficeLocation { get; set; }
    }
}