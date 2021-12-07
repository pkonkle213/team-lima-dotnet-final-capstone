using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class FlashCard
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string FrontText { get; set; }
        
        [Required]
        [MaxLength(100)] 
        
        public string BackText { get; set; }
        
        public int DeckId { get; set; }
    }
}
