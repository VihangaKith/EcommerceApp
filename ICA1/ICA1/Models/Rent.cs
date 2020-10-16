using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ICA1.Models
{
    [Table("Rent_tbl")]
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String PropertyNo { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String Ptype { get; set; }
        public int Rooms { get; set; }
        [ForeignKey("Owner")]
        public String RefOwnerNo { get; set; }
        [ForeignKey("Staff")]
        public String RefStaffNo { get; set; }
        [ForeignKey("Branch")]
        public String RefBranchNo { get; set; }
        public int Rents { get; set; }
        public Owner Owner { get; set; }
        public Staff Staff { get; set; }
        public Branch Branch { get; set; }
       

    }
}