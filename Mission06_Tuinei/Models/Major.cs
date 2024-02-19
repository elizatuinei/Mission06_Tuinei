using System.ComponentModel.DataAnnotations;

namespace Mission06_Tuinei.Models
{
    public class Major
    {
        [Key]
        public int MajorID { get; set; }

        public string MajorName { get; set; }
    }
}
