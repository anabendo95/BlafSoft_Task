using System.ComponentModel.DataAnnotations;

namespace BlafSoft_Web.Models
{
    public class TaskT
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Title must not me more than 20 characters")]
        public string Title { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "Title must not me more than 1000 characters")]
        public string Description { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title must not me more than 50 characters")]
        public string Status { get; set; }
    }
}
