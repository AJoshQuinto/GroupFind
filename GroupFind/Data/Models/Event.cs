using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupFind.Data.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int CreatorID { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public required string EventTitle { get; set; }

        [Required]
        public DateTime EventStartDateTime { get; set; }

        [Required]
        public DateTime EventEndDateTime { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string Country { get; set; }

        [Required]
        public required string Address { get; set; }

        public required string SignupLinkFromCreator { get; set; }

        // Navigation properties
        public required virtual User User { get; set; }
        public required virtual Category Category { get; set; }
    }
}