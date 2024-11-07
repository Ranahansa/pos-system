using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PosServerApplication.Common.Constants;
using PosServerApplication.Common.Enums;
using PosServerApplication.Models.Attributes;
using System;
using System.Collections.Generic;

namespace PosServerApplication.Models.Entities
{
    [BsonCollection("Orders")]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("orderNumber")]
        [BsonRequired]
        public string OrderNumber { get; set; }

        [BsonElement("customerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }

        [BsonElement("userId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonRequired]
        public string UserId { get; set; }

        [BsonElement("items")]
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        [BsonElement("subtotal")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Subtotal { get; set; }

        [BsonElement("tax")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Tax { get; set; }

        [BsonElement("discount")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Discount { get; set; }

        [BsonElement("total")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Total { get; set; }

        [BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [BsonElement("orderType")]
        [BsonRepresentation(BsonType.String)]
        public OrderType OrderType { get; set; }

        [BsonElement("tableNumber")]
        public string TableNumber { get; set; }

        [BsonElement("notes")]
        public string Notes { get; set; }

        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("completedAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? CompletedAt { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; } = true;

        [BsonElement("paymentStatus")]
        [BsonRepresentation(BsonType.String)]
        public string PaymentStatus { get; set; } = OrderConstants.PaymentStatus.Pending;

        [BsonElement("paymentMethod")]
        [BsonRepresentation(BsonType.String)]
        public string PaymentMethod { get; set; }

        [BsonElement("deliveryAddress")]
        public string DeliveryAddress { get; set; }

        [BsonElement("specialInstructions")]
        public string SpecialInstructions { get; set; }
    }
}