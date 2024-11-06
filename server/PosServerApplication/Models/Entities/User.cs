using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PosServerApplication.Models.Attributes;
using System;

namespace PosServerApplication.Models.Entities
{
    [BsonCollection("Users")]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("username")]
        [BsonRequired]
        public string Username { get; set; }

        [BsonElement("email")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; }

        [BsonElement("passwordHash")]
        [BsonRequired]
        public string PasswordHash { get; set; }

        [BsonElement("firstName")]
        [BsonRepresentation(BsonType.String)]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        [BsonRepresentation(BsonType.String)]
        public string LastName { get; set; }

        [BsonElement("phoneNumber")]
        [BsonRepresentation(BsonType.String)]
        public string PhoneNumber { get; set; }

        [BsonElement("roleId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonRequired]
        public string RoleId { get; set; }

        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("lastLogin")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? LastLogin { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; } = true;

        [BsonElement("refreshToken")]
        public string RefreshToken { get; set; }

        [BsonElement("refreshTokenExpiryTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? RefreshTokenExpiryTime { get; set; }

        [BsonIgnore]
        public string FullName => $"{FirstName} {LastName}".Trim();
    }
}
