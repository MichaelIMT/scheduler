using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class Kafedra
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Specialty> Specialties { get; set; }
        public virtual ICollection<Lektor> Lektors { get; set; }
        public virtual ICollection<Audience> Audiences { get; set; }
    }
}
