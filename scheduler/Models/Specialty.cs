using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public int KafedraId { get; set; }
        public Kafedra kafedra { get; set; }

        public virtual ICollection<Group> Grops { get; set; }
        

    }
}
