using ProjectDawAngular.Models.Base;
using System.Collections.Generic;

namespace ProjectDawAngular.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        // Many-to-Many cu Course
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}