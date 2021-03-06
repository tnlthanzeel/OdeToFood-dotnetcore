﻿using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
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

        public Restaurants Add(Restaurants newResturant)
        {
            restaurants.Add(newResturant);

            newResturant.Id = restaurants.Max(m => m.Id) + 1;
            return newResturant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurants Delete(int id)
        {
            var resturant = restaurants.FirstOrDefault(f => f.Id == id);

            if (resturant != null)
            {
                restaurants.Remove(resturant);
            }
            return resturant;
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

        public int GetCountOfRestaurats()
        {
            throw new System.NotImplementedException();
        }

        public Restaurants Update(Restaurants resturant)
        {
            var restaurant = (from r in restaurants
                              where r.Id == resturant.Id
                              select r).SingleOrDefault();


            // this is for in memory data
            if (restaurant != null)
            {
                restaurant.Name = resturant.Name;
                restaurant.Location = resturant.Location;
                restaurant.Cuisine = resturant.Cuisine;

            }

            return restaurant;
        }
    }
}
