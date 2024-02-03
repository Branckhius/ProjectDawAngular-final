using ProjectDawAngular.Models.Base;
using System.Collections.Generic;

namespace ProjectDawAngular.Models
{
    public class Professor : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        // Navigation property pentru Many-to-One cu Department
        public Department Department { get; set; }

        // One-to-Many cu Course
        public ICollection<Course> Courses { get; set; }
        // One-to-One cu ProfessorDetails
        public ProfessorDetails ProfessorDetails { get; set; }
    }
}