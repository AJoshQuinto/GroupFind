using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroupFind.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public required string CategoryName { get; set; }

        // Navigation property
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}