using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int StudentsCount { get; set; }
        public virtual ICollection<Vacation> Vacations { get; set; }

        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }


    }
}
