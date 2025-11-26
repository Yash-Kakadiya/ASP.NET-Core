using System.ComponentModel.DataAnnotations;

namespace CRUDRevision.Models
{
    public class EmployeeModel
    {
        public int EmpID { get; set; }

        [Required]
        public string EmpName { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int DeptID { get; set; }

        public string DepartmentName { get; set; }

        public class DepartmentDropDownModel
        {
            public int DeptID { get; set; }
            public string DepartmentName { get; set; }
        }
    }
}
