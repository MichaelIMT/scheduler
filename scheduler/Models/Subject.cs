using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class Subject
    {
        public int Id {get;set;}
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public int Period { get; set; }

        public int GroupId { get; set; }
        public Group Groups { get; set; }

        public int SubjectTypeId { get; set; }
        public SubjectType SubjectType { get; set; }
    }
}
