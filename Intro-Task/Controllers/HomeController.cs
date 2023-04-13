using Intro_Task.Model;
using Intro_Task.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Intro_Task.Controllers
{
    public class HomeController : Controller
    {

        public DisplayMealViewModel vm { get; set; }
        public IActionResult Index()
        {
            vm = new DisplayMealViewModel();
            return View(vm);
        }

        public async Task<ViewResult> GetMeal(string ctg)
        {

            var meals = await FoodApiService.GetMealsByCategory(ctg);

            vm = new DisplayMealViewModel
            {
                Meals = meals
            };
            return View(vm);
        }



    }
}
