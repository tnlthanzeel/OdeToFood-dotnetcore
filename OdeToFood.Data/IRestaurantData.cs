using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurants> GetAllRestaurantsByName(string name);
        Restaurants GetById(int resturantId);
        Restaurants Update(Restaurants resturant);
        Restaurants Add(Restaurants newResturant);
        Restaurants Delete(int id);
        int GetCountOfRestaurats();
        int Commit();
    }
}
