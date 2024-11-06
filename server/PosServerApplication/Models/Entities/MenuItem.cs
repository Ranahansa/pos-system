using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PosServerApplication.Models.Attributes;
using System;
using System.Collections.Generic;

namespace PosServerApplication.Models.Entities
{
    [BsonCollection("MenuItems")]
    public class MenuItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonElement("description")]
        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonElement("category")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Category { get; set; }

        [BsonElement("price")]
        [BsonRequired]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonElement("cost")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Cost { get; set; }

        [BsonElement("imageUrl")]
        [BsonRepresentation(BsonType.String)]
        public string ImageUrl { get; set; }

        [BsonElement("ingredients")]
        public List<string> Ingredients { get; set; } = new List<string>();

        [BsonElement("allergens")]
        public List<string> Allergens { get; set; } = new List<string>();

        [BsonElement("preparationTime")]
        [BsonRepresentation(BsonType.Int32)]
        public int PreparationTimeMinutes { get; set; }

        [BsonElement("isAvailable")]
        public bool IsAvailable { get; set; } = true;

        [BsonElement("isPopular")]
        public bool IsPopular { get; set; }

        [BsonElement("calories")]
        [BsonRepresentation(BsonType.Int32)]
        public int? Calories { get; set; }

        [BsonElement("spicyLevel")]
        [BsonRepresentation(BsonType.Int32)]
        public int SpicyLevel { get; set; } = 0; // 0-5 scale

        [BsonElement("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("modifiers")]
        public List<MenuItemModifier> Modifiers { get; set; } = new List<MenuItemModifier>();
    }

    public class MenuItemModifier
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("options")]
        public List<MenuItemModifierOption> Options { get; set; } = new List<MenuItemModifierOption>();

        [BsonElement("required")]
        public bool Required { get; set; }

        [BsonElement("multiSelect")]
        public bool MultiSelect { get; set; }
    }

    public class MenuItemModifierOption
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("additionalPrice")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal AdditionalPrice { get; set; }
    }
}