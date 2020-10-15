using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sample_e_commerce_application.Models
{
    [Table("Rent_tbl")]
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Property ID number")]
        public String PropertyNo { get; set; }

        public String Street { get; set; }

        public String City { get; set; }

        public String Ptype { get; set; }

        public int Rooms { get; set; }

        [ForeignKey("owner")]

        public String OwnerNoRef { get; set; }

        [ForeignKey("staff")]

        public String StaffNoRef { get; set; }

        [ForeignKey("branch")]

        public String BranchNoRef { get; set; }

        public virtual Branch branch { get; set; }

        public virtual Owner owner { get; set; }

        public virtual Staff staff { get; set; }

        [Display(Name = "Rent")]
        public int Rent1 { get; set; }

    }
}