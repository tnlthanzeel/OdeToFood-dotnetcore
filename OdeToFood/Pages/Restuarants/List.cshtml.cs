using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restuarants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Restaurants> Restaurants { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Restaurants = restaurantData.GetAllRestaurantsByName(SearchTerm);
        }
    }
}