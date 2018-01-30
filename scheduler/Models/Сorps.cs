using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class Сorps
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Audience> Audiences { get; set; }
    }
}
