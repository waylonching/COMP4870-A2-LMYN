using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.Models
{
    public class Boat
    {
        public int BoatId { get; set; }
        [Display(Name = "Boat Name")]
        [MaxLength(30)]
        public string BoatName { get; set; }
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Display(Name = "Length In Feet")]
        public int LengthInFeet { get; set; }
        [Display(Name = "Make")]
        public string Make { get; set; }
        [Display(Name = "Year")]
        public int Year { get; set; }
        [Display(Name = "Record Creation Date")]
        public DateTime RecordCreationDate { get; set; }

        [ForeignKey("User")]
        [ScaffoldColumn(false)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public ApplicationUser User { get; set; }

        public List<Borrow> Borrows { get; set; }
    }
}
