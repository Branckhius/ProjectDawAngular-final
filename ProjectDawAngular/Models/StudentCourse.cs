using ProjectDawAngular.Models.Base;

namespace ProjectDawAngular.Models
{
    public class StudentCourse : BaseEntity
    {
        // Foreign key pentru Student
        public int StudentId { get; set; }

        // Navigation property pentru Many-to-Many cu Student
        public Student Student { get; set; }

        // Foreign key pentru Course
        public int CourseId { get; set; }

        // Navigation property pentru Many-to-Many cu Course
        public Course Course { get; set; }
    }
}