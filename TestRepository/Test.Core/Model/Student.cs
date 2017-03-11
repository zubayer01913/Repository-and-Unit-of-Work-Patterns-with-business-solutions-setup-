using System.ComponentModel.DataAnnotations;

namespace Test.Core.Model
{
    public  class Student : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public string Information { get; set; }
        public string Comment { get; set; }
    }
}
