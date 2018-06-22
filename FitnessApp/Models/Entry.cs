using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessAPP.Models
{
    [DisplayColumn("Title")]
    [Table("Entry", Schema = "fitness")]
    public class Entry
    {
        public enum IntensityLevel
        {
            Low = 1,
            Medium = 2,
            High = 3
        }

        //default constructor
        public Entry() { }

        public Entry(int year, int month,int day,float duration, IntensityLevel intensity = IntensityLevel.Medium, bool exclude= false, string notes = null)
        {
            Date = new DateTime(year, month, day);           
            Duration = duration;
            Intensity = intensity;
            Exclude = exclude;
            Notes = notes;
        }

        [Key()]
        public Guid EntryId { get; set; }

        public DateTime Date { get; set; }
        [ForeignKey("Activity")]
        public int Activityid { get; set; }
        [Display(Name = "Activity")]
        public virtual Activity Activity { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:p0}")]
        [Display(Name = "Duration")]
        public float Duration { get; set; }

        [Display(Name = "IntensityLevel")]
        public IntensityLevel Intensity { get; set; }

        public bool Exclude { get; set; }

        [Display(Name = "Notes")]
        [MaxLength(200, ErrorMessage = "The notes field cannot be longer than 200 characters.")]
        public string Notes { get; set; }

        [Display(Name = "IntensityName")]
        public string IntensityName { get; set; }
    }
}
