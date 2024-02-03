using ProjectDawAngular.Models.Base;

namespace ProjectDawAngular.Models
{
    public class ProfessorDetails : BaseEntity
    {
        public string OfficeLocation { get; set; }
        public int ProfessorId { get; set; }
        // One-to-One cu Professor
        public Professor Professor { get; set; }
    }
}