using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace reView.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }

        public string  MainPicture { get; set; }

        public string SecondPicture { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
