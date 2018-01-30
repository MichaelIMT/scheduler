using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        public int Day { get; set; }

        public int GroupId { get; set; }
        public Group Groups { get; set; }

        public int LektorId { get; set; }
        public Lektor Lektors { get; set; }
    }
}
