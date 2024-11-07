using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PosServerApplication.Common.Constants;
using PosServerApplication.Common.Enums;
using System.Collections.Generic;

namespace PosServerApplication.Models.Entities
{
    public class OrderItem
    {
        [BsonElement("menuItemId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonRequired]
        public string MenuItemId { get; set; }

        [BsonElement("name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("quantity")]
        [BsonRequired]
        public int Quantity { get; set; }

        [BsonElement("unitPrice")]
        [BsonRepresentation(BsonType.Decimal128)]
        [BsonRequired]
        public decimal UnitPrice { get; set; }

        [BsonElement("subtotal")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Subtotal { get; set; }

        [BsonElement("modifications")]
        public List<string> Modifications { get; set; } = new List<string>();

        [BsonElement("notes")]
        public string Notes { get; set; }

        [BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [BsonElement("isVoid")]
        public bool IsVoid { get; set; } = false;

        [BsonElement("voidReason")]
        public string VoidReason { get; set; }

        [BsonElement("discount")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Discount { get; set; }
    }
}