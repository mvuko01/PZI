using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reView.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace reView.Controllers
{
    public class AccountController : Controller
    {
        //GET
        public IActionResult Register()
        {
            return View("Register");
        }


    }
}
