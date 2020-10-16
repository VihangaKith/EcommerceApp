using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ICA1.Models
{
    [Table("Staff_tbl")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String StaffNo { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Position { get; set; }
        [Column(TypeName ="Date")]
        public DateTime DateofBirth { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Branch")]
        public String RefBranchNo { get; set; }
        public Branch Branch { get; set; }
    }
}