using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurants> GetAllRestaurantsByName(string name);
        Restaurants GetById(int resturantId);
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

        public IEnumerable<Restaurants> GetAllRestaurantsByName(string name = null)
        {
            var result = from r in restaurants
                         where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                         orderby r.Name
                         select r;

            return result;
        }

        public Restaurants GetById(int resturantId)
        {
            return (from r in restaurants
                   where r.Id == resturantId
                   select r).FirstOrDefault();
        }
    }
}
