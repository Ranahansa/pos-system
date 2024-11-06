using System.Collections.Generic;

namespace PosServerApplication.Common.Constants
{
    public static class Roles
    {
        public static class Permissions
        {
            // Order Management
            public const string CreateOrder = "Orders.Create";
            public const string UpdateOrder = "Orders.Update";
            public const string DeleteOrder = "Orders.Delete";
            public const string ViewOrders = "Orders.View";

            // Inventory Management
            public const string ManageInventory = "Inventory.Manage";
            public const string ViewInventory = "Inventory.View";

            // Payment Management
            public const string ProcessPayment = "Payments.Process";
            public const string IssueRefund = "Payments.Refund";
            public const string ViewPayments = "Payments.View";

            // Employee Management
            public const string ManageEmployees = "Employees.Manage";
            public const string ViewEmployees = "Employees.View";

            // Reporting
            public const string GenerateReports = "Reports.Generate";
            public const string ViewReports = "Reports.View";

            // System Settings
            public const string ManageSettings = "Settings.Manage";
        }

        public static class DefaultPermissions
        {
            public static readonly IReadOnlyList<string> AdminPermissions = new List<string>
            {
                Permissions.CreateOrder,
                Permissions.UpdateOrder,
                Permissions.DeleteOrder,
                Permissions.ViewOrders,
                Permissions.ManageInventory,
                Permissions.ViewInventory,
                Permissions.ProcessPayment,
                Permissions.IssueRefund,
                Permissions.ViewPayments,
                Permissions.ManageEmployees,
                Permissions.ViewEmployees,
                Permissions.GenerateReports,
                Permissions.ViewReports,
                Permissions.ManageSettings
            }.AsReadOnly();

            public static readonly IReadOnlyList<string> ManagerPermissions = new List<string>
            {
                Permissions.CreateOrder,
                Permissions.UpdateOrder,
                Permissions.ViewOrders,
                Permissions.ManageInventory,
                Permissions.ViewInventory,
                Permissions.ProcessPayment,
                Permissions.IssueRefund,
                Permissions.ViewPayments,
                Permissions.ViewEmployees,
                Permissions.GenerateReports,
                Permissions.ViewReports
            }.AsReadOnly();

            public static readonly IReadOnlyList<string> CashierPermissions = new List<string>
            {
                Permissions.CreateOrder,
                Permissions.UpdateOrder,
                Permissions.ViewOrders,
                Permissions.ViewInventory,
                Permissions.ProcessPayment
            }.AsReadOnly();

            public static readonly IReadOnlyList<string> WaiterPermissions = new List<string>
            {
                Permissions.CreateOrder,
                Permissions.UpdateOrder,
                Permissions.ViewOrders
            }.AsReadOnly();

            public static readonly IReadOnlyList<string> KitchenPermissions = new List<string>
            {
                Permissions.ViewOrders,
                Permissions.UpdateOrder,
                Permissions.ViewInventory
            }.AsReadOnly();
        }
    }
}
