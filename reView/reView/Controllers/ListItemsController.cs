using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using reView.Data;
using reView.Models;
using reView.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace reView.Controllers
{
    public class ListItemsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ListItemsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Phones()
        {
            var categoryString = "Phones";
            var categoryParamater = new SqlParameter("@Name", categoryString);
            var categoryID = _db.Category.FromSqlRaw("SELECT * FROM Category WHERE Name=@Name", categoryParamater).FirstOrDefault(); //za dobit Id phone

            var categoryIDParamater = new SqlParameter("@Id", categoryID.Id);
            IEnumerable<Item> objList = _db.Item.FromSqlRaw("SELECT * FROM Item WHERE CategoryId=@Id", categoryIDParamater).ToList();
             
            return View("Index", objList);
        }

        public IActionResult Headphones()
        {
            var categoryString = "Headphones";
            var categoryParamater = new SqlParameter("@Name", categoryString);
            var categoryID = _db.Category.FromSqlRaw("SELECT * FROM Category WHERE Name=@Name", categoryParamater).FirstOrDefault(); //za dobit Id phone

            var categoryIDParamater = new SqlParameter("@Id", categoryID.Id);
            IEnumerable<Item> objList = _db.Item.FromSqlRaw("SELECT * FROM Item WHERE CategoryId=@Id", categoryIDParamater).ToList();

            return View("Index", objList);
        }


       

        [HttpGet]
        public IActionResult SingleItem(int ID)
        {
            var itemId = ID;
            var itemIdParamater = new SqlParameter("@Id", itemId);
            var obj = _db.Item.FromSqlRaw("SELECT * FROM Item WHERE Id=@Id", itemIdParamater).FirstOrDefault();

            return View(obj);
        }

        
    }
}
