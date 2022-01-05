using reView.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace reView.ViewModels
{
    public class PostAndListVm
    {
        
        public Review ReviewToPost { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
    }
}
