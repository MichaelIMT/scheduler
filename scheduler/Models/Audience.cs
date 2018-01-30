using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class Audience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountOfPlaces { get; set; }

        public int СorpsId { get; set; }
        public Сorps Сorps { get; set; }

        public int KafedraId { get; set; }
        public Kafedra kafedra { get; set; }
    }
}
