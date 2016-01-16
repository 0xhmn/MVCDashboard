using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Dahsboard.Models
{
    public class Program
    {
        public virtual int ProgramId { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public virtual ICollection<Term> Terms { get; set; }
    }

    public class Term
    {
        public int Id { get; set; }
        public int TermIdNumber { get; set; }
        public string TermTitle { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        [ForeignKey("Program"), Required]
        public int ProgramId { get; set; }              // foreign key
        public virtual Program Program { get; set; }
    }
}