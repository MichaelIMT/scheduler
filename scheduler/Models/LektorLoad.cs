using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class LektorLoad
    {
        public int Id { get; set; }

        public int LektorId { get; set; }
        public Lektor Lektor { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string Lecture { get; set; }
        public string Seminar { get; set; }
        public string Lab { get; set; }


    }
}
