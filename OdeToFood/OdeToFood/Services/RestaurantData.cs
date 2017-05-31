using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurants> GetAll();
        Restaurants Get(int id);
        Restaurants Add(Restaurants newRestaurant);
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        static  InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurants>
            {
                new Restaurants{Id=1,Name="The House of Kobe"},
                new Restaurants{Id=2,Name="LJ's and the Kat"},
                new Restaurants{Id=3,Name="King's Contrivance"}
            };
        }

        public IEnumerable<Restaurants> GetAll()
        {
            return _restaurants;
        }

        public Restaurants Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurants Add(Restaurants newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        static List<Restaurants> _restaurants;
    }
}
