using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restuarants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurants Restaurants { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        // OnGet with void
        //public void OnGet(int restaurantId)
        //{
        //    Restaurants = restaurantData.GetById(restaurantId);
        //}

        //OnGet with IActionResult
        public IActionResult OnGet(int restaurantId)
        {
            Restaurants = restaurantData.GetById(restaurantId);

            if(Restaurants==null)
            {
                return RedirectToPage("./NotFound");
            }


            return Page();
        }
    }
}