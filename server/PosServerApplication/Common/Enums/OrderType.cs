namespace PosServerApplication.Common.Enums
{
    public enum OrderStatus
    {
        Pending,
        InProgress,
        Ready,
        Completed,
        Cancelled
    }

    public enum OrderType
    {
        DineIn,
        TakeOut,
        Delivery,
        DriveThru
    }
}
