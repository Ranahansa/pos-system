namespace PosServerApplication.Common.Constants
{
    public static class OrderStatus
    {
        // Order Statuses
        public const string Pending = "Pending";
        public const string InProgress = "InProgress";
        public const string Ready = "Ready";
        public const string Completed = "Completed";
        public const string Cancelled = "Cancelled";

        // Payment Statuses
        public const string PaymentPending = "Pending";
        public const string PaymentCompleted = "Completed";
        public const string PaymentFailed = "Failed";
        public const string PaymentRefunded = "Refunded";
        public const string PaymentPartiallyRefunded = "PartiallyRefunded";

        // Payment Methods
        public const string Cash = "Cash";
        public const string CreditCard = "CreditCard";
        public const string DebitCard = "DebitCard";
        public const string MobilePayment = "MobilePayment";
        public const string GiftCard = "GiftCard";

        // Order Type Descriptions
        public static class Descriptions
        {
            public const string Pending = "Order has been created but not yet processed";
            public const string InProgress = "Order is being prepared in the kitchen";
            public const string Ready = "Order is ready for pickup or delivery";
            public const string Completed = "Order has been delivered or picked up";
            public const string Cancelled = "Order has been cancelled";
        }

        // Status Transitions
        public static class AllowedTransitions
        {
            public static readonly string[] FromPending = new[] { "InProgress", "Cancelled" };
            public static readonly string[] FromInProgress = new[] { "Ready", "Cancelled" };
            public static readonly string[] FromReady = new[] { "Completed", "Cancelled" };
            public static readonly string[] FromCompleted = new string[] { };  // Terminal state
            public static readonly string[] FromCancelled = new string[] { };  // Terminal state
        }

        // Notification Triggers
        public static class NotificationTriggers
        {
            public const string OrderCreated = "OrderCreated";
            public const string OrderUpdated = "OrderUpdated";
            public const string OrderReady = "OrderReady";
            public const string OrderCompleted = "OrderCompleted";
            public const string OrderCancelled = "OrderCancelled";
            public const string PaymentReceived = "PaymentReceived";
            public const string RefundIssued = "RefundIssued";
        }
    }
}
