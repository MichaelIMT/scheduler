using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }

        public int KafedraId { get; set; }
        public Kafedra kafedra { get; set; }
    }
}
