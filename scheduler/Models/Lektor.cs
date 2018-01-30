using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class Lektor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Primitka { get; set; }

        public virtual ICollection<MetodDni> MetodDni { get; set; }
        public virtual ICollection<Vacation> Vacations { get; set; }

        public virtual ICollection<Window> Windows { get; set; }

        public int KafedraId { get; set; }
        public Kafedra Kafedra { get; set; }

        public virtual ICollection<LektorLoad> LektorLoads { get; set; }
    }
}
