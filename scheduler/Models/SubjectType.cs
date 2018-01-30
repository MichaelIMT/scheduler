using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class SubjectType
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
