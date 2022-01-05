using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace reView.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        
        public string Text { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        //
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public  ApplicationUser ApplicationUser{ get; set; }

    }
}
