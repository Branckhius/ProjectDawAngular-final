// Course.cs
using ProjectDawAngular.Models.Base;
using System.Collections.Generic;

namespace ProjectDawAngular.Models
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public int Credits { get; set; }

        // Foreign key pentru One-to-Many cu Professor
        public int ProfessorId { get; set; }

        // Navigation property pentru One-to-Many cu Professor
        public Professor Professor { get; set; }

        // Many-to-Many cu Student
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
