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
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
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

        List<Restaurants> _restaurants;
    }
}
