using System.ComponentModel.DataAnnotations;

namespace Mission06_Tuinei.Models
{
    public class Application
    {
        [Key]
        [Required(ErrorMessage = "MovieFormID is required")]
        public int MovieFormID { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or greater")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Edited is required")]
        public bool Edited { get; set; }

        [Required(ErrorMessage = "Lent_to is required")]
        public string Lent_to { get; set; }

        [Required(ErrorMessage = "Notes is required")]
        public string Notes { get; set; }

        // Other properties and methods...
    }
}
