using reView.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace reView.ViewModels
{
    public class ReviewViewModel
    {
        
        public string Text { get; set; }

        
        public string Username { get; set; }

        public int ItemId { get; set; }


    }
}
