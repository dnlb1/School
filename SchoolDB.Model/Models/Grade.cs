using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolDB.Model.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int StundetId { get; set; }
        public int SubjectId { get; set; }
        public int? Value { get; set; }
        public DateTime? Time { get; set; }
        public string SubjectArea { get; set; }

        public virtual Student Stundet { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
