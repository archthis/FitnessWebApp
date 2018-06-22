using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessAPP.Models
{
    [DisplayColumn("Title")]
    [Table("Activity", Schema = "fitness")]
    public class Activity
    {
        [Key()]
        public int ActiveId { get; set; }
        [Display(Name= "Name")]
        public string Name { get; set; }
        [Display(Name = "Entries")]
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
