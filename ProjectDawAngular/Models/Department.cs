using ProjectDawAngular.Models.Base;
using System.Collections.Generic;

namespace ProjectDawAngular.Models
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        // One-to-Many cu Professor
        public ICollection<Professor> Professors { get; set; }
    }
}