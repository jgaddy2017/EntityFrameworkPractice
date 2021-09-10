using EntityFrameworkPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice
{
    public class Todo
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime createdby { get; set;}
        public string item { get; set; }
        public bool isDone { get; set; }

        public Importance importance { get; set; }
    }
}
