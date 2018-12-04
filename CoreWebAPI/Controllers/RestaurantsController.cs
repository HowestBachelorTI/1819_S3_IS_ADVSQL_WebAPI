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
    }
}
