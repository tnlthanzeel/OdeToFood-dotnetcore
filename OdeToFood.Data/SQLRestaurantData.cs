using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class SQLRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext odeToFoodDbContext;

        public SQLRestaurantData(OdeToFoodDbContext odeToFoodDbContext)
        {
            this.odeToFoodDbContext = odeToFoodDbContext;
        }
        public Restaurants Add(Restaurants newResturant)
        {
            odeToFoodDbContext.Add(newResturant);
            return newResturant;
        }

        public int Commit()
        {
            return odeToFoodDbContext.SaveChanges();
        }

        public Restaurants Delete(int id)
        {
            var restaurant = odeToFoodDbContext.Restaurants.FirstOrDefault(f => f.Id == id);
            if (restaurant != null)
            {
                odeToFoodDbContext.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurants> GetAllRestaurantsByName(string name)
        {
            var query = from r in odeToFoodDbContext.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        select r;

            return query;
        }

        public Restaurants GetById(int resturantId)
        {
            return odeToFoodDbContext.Restaurants.Find(resturantId);
        }

        public Restaurants Update(Restaurants resturant)
        {
            var restaurant = odeToFoodDbContext.Restaurants.Attach(resturant);
            restaurant.State = EntityState.Modified;
            //return restaurant;
            return resturant;
        }
    }
}
