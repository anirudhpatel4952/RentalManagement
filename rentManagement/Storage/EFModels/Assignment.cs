using System;
namespace rentManagement.Storage.EFModels
{
    public class Assignment
    {
        public Guid AssignmentId { get; set;}
        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Rental Rental { get; set; }
        public Guid RentalId { get; set; }
        public DateTime ContractDate { get; set; }
        public bool IsAssigned { get; set; }
    }
}