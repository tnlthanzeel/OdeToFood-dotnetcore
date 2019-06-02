using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurants> GetAllRestaurants();
    }


    public class InMemoryRestaurantsData : IRestaurantData
    {
        readonly List<Restaurants> restaurants;

        public InMemoryRestaurantsData()
        {
            restaurants = new List<Restaurants>()
            {
                new Restaurants{Cuisine=CuisineType.Indian,Id=1,Location="Delhi",Name="Ghandi Lodge" },
                new Restaurants{Cuisine=CuisineType.SriLankan,Id=2,Location="Colombo",Name="Mr. Shawarma" }
            };
        }

        public IEnumerable<Restaurants> GetAllRestaurants()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
