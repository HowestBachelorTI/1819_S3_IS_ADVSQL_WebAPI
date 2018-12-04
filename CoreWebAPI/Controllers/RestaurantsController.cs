using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
            MongoClientSettings settings =
                new MongoClientSettings { Credential = credential };
            MongoClient mongoClient = new MongoClient(settings);
            IMongoDatabase db = mongoClient.GetDatabase("Restaurants");
            IMongoCollection<BsonDocument> collection =
                db.GetCollection<BsonDocument>("Restaurants");
            FilterDefinition<BsonDocument> filter =
                FilterDefinition<BsonDocument>.Empty;
            List<BsonDocument> restaurants = collection.Find(filter).ToList();
            try
            {
                return Ok(restaurants);
            }
            catch { return BadRequest(); }
        }
    }
}
