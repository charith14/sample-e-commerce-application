using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sample_e_commerce_application.Models
{
    [Table("Staff_tbl")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Staff ID number")]
        public String StaffNo { get; set; }

        public String Fname { get; set; }

        public String Lname { get; set; }

        public String Position { get; set; }


        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public int Salary { get; set; }

        [ForeignKey("branch")]

        public String BranchNoRef { get; set; }

        public virtual Branch branch { get; set; }

        public List<Rent> rent { get; set; }
    }
}