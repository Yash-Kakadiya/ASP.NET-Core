using System.ComponentModel.DataAnnotations;

namespace CRUDRevision.Models
{
    public class DepartmentModel
    {
        public int DeptID { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(100)]
        public string DepartmentName { get; set; }
    }
}
