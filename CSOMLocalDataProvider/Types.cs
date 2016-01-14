using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSOMLocalDataProvider
{
    public class Program
    {
        public int Id { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public ICollection<Term> Terms { get; set; } 
    }

    public class Term
    {
        [Column(Order = 0), Key]
        public int Id { get; set; }
        public string TermTitle { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public Program Program { get; set; } 
        [Column(Order = 1), Key, ForeignKey("Program")]
        public int ProgramId { get; set; }
    }

}
