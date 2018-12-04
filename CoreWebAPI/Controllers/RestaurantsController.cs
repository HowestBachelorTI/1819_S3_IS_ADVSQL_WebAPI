using System.Collections.Generic;
using System.Linq;
using CoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        public IActionResult Get()
        {
            MongoCredential credential = MongoCredential.CreateCredential("Restaurants", "howest", "howest");
            MongoClientSettings settings = new MongoClientSettings { Credential = credential };
            MongoClient mongoClient = new MongoClient(settings);
            IMongoDatabase db = mongoClient.GetDatabase("Restaurants");
            IMongoCollection<Restaurant> collection = db.GetCollection<Restaurant>("Restaurants");
            FilterDefinition<Restaurant> filter = FilterDefinition<Restaurant>.Empty;
            List<Restaurant> restaurants = collection.Find(filter).ToList();
            try
            {
                return Ok(restaurants);
            }
            catch { return BadRequest(); }
        }

        [Route("Borough")]
        public IActionResult GetBouroughs()
        {
            MongoCredential credential = MongoCredential.CreateCredential("Restaurants", "howest", "howest");
            MongoClientSettings settings = new MongoClientSettings { Credential = credential };
            MongoClient mongoClient = new MongoClient(settings);
            IMongoDatabase db = mongoClient.GetDatabase("Restaurants");
            IMongoCollection<Restaurant> collection = db.GetCollection<Restaurant>("Restaurants");
            FilterDefinition<Restaurant> filter = FilterDefinition<Restaurant>.Empty;
            List<string> boroughs = collection.Distinct<string>("borough",filter).ToList();
            try
            {
                return Ok(boroughs);
            }
            catch { return BadRequest(); }
        }

        [Route("{borough}")]
        public IActionResult GetRestaurants(string borough)
        {
            MongoCredential credential = MongoCredential.CreateCredential("Restaurants", "howest", "howest");
            MongoClientSettings settings = new MongoClientSettings { Credential = credential };
            MongoClient mongoClient = new MongoClient(settings);
            IMongoDatabase db = mongoClient.GetDatabase("Restaurants");
            IMongoCollection<Restaurant> collection = db.GetCollection<Restaurant>("Restaurants");
            FilterDefinition<Restaurant> filter = Builders<Restaurant>.Filter.Eq(r => r.Borough, borough);
            var restaurants = collection.Find(filter).ToList();
            try
            {
                return Ok(restaurants);
            }
            catch { return BadRequest(); }
        }
    }
}