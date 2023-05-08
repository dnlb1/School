using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolDB.Model.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
