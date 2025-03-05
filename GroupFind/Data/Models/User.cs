using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroupFind.Data.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public required string LegalFirstName { get; set; }

        [Required]
        [StringLength(100)]
        public required string LegalLastName { get; set; }

        [Required]
        [EmailAddress]
        public required string EmailAddress { get; set; }

        [Required]
        [StringLength(20)]
        public required string PhoneNumber { get; set; }

        [Required]
        public required string Password { get; set; } // Consider hashing passwords

        public bool AdminStatus { get; set; } // 1 = Admin, 0 = Regular User

        // Navigation property
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}