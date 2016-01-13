using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSOMDataProvider
{
    public class Program
    {
        public int Id { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public ICollection<TermApplyActive> AvtiveTermsForProgram { get; set; } 
    }

    public class TermApplyActive
    {
        // public int Id { get; set; }
        public string TermTitle { get; set; }
        public Program Program { get; set; } 
        [Column(Order = 0), Key, ForeignKey("Program")]
        public int ProgramId { get; set; }      // foreign key to make it ONE to many (not zero/one to many) - or we can use [Required]
        public Term Term { get; set; }
        [Column(Order = 1), Key, ForeignKey("Term")]
        public int TermId { get; set; }
    }

    public class Term
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public ICollection<TermApplyActive> ActiveTerms { get; set; } 
    }

        
}
