using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            //var model = new Restaurants() { Id = 1, Name = "The House of Kobe" };
            var model = _restaurantData.GetAll();


            return View(model);
           
            //return Content("Hello, from the HomeController");
        }
    }
}
