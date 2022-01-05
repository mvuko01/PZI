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
        private readonly UserManager<ApplicationUser> userManager;

        public ListItemsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
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
            var item_obj = _db.Item.FromSqlRaw("SELECT * FROM Item WHERE Id=@Id", itemIdParamater).FirstOrDefault();

            ViewBag.Item = item_obj;

            IEnumerable <Review> reviews = _db.Review.FromSqlRaw("SELECT * FROM Review WHERE ItemId=@Id", itemIdParamater).ToList();
            PostAndListVm site = new PostAndListVm();
            site.Reviews = reviews;

            return View(site);

        }

        [HttpPost]
        public async Task<IActionResult> SingleItem(PostAndListVm model)
        {
            var itemId = model.ReviewToPost.ItemId;
            var itemIdParamater = new SqlParameter("@Id", itemId);
            var item_obj = _db.Item.FromSqlRaw("SELECT * FROM Item WHERE Id=@Id", itemIdParamater).FirstOrDefault();
            ViewBag.Item = item_obj;

            //var itemId = ID;
            //var itemIdParamater = new SqlParameter("@Id", itemId);
            //var obj = _db.Item.FromSqlRaw("SELECT * FROM Item WHERE Id=@Id", itemIdParamater).FirstOrDefault();

            //ReviewViewModel myViewModel = new ReviewViewModel();
            //myViewModel.Item = obj;

            

            var user = await userManager.GetUserAsync(User);
            model.ReviewToPost.ApplicationUser = user;

            _db.Review.Add(model.ReviewToPost);
            _db.SaveChanges();

            IEnumerable<Review> reviews = _db.Review.FromSqlRaw("SELECT * FROM Review WHERE ItemId=@Id", itemIdParamater).ToList();
            PostAndListVm site = new PostAndListVm();
            site.Reviews = reviews;

            return View(site);

           
        }
    }
}
