using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CoreWebAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Restaurant
    {
        [BsonId]
        [BsonElement(elementName: "_id")]
        public ObjectId MongoDbId { get; set; }
        [BsonElement(elementName: "address")]
        public RestaurantAddress Address { get; set; }
        [BsonElement(elementName: "borough")]
        public string Borough { get; set; }
        [BsonElement(elementName: "cuisine")]
        public string Cuisine { get; set; }
        [BsonElement(elementName: "grades")]
        public IEnumerable<RestaurantGrade> Grades { get; set; }
        [BsonElement(elementName: "name")]
        public string Name { get; set; }
        [BsonElement(elementName: "restaurant_id")]
        [BsonRepresentation(BsonType.String)]
        public int Id { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    [BsonIgnoreExtraElements]
    public class RestaurantAddress
    {
        [BsonElement(elementName: "building")]
        public string BuildingNr { get; set; }
        [BsonElement(elementName: "coord")]
        public double[] Coordinates { get; set; }
        [BsonElement(elementName: "street")]
        public string Street { get; set; }
        [BsonElement(elementName: "zipcode")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public int ZipCode { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class RestaurantGrade
    {
        [BsonElement(elementName: "date")]
        public DateTime InsertedUtc { get; set; }
        [BsonElement(elementName: "grade")]
        public string Grade { get; set; }
        [BsonElement(elementName: "score")]
        public object Score { get; set; }
    }
}

