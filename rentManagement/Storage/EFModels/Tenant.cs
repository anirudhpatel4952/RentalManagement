using System;

namespace rentManagement.Storage.EFModels
{
    public class Tenant
    {
        public Guid TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string IdProof { get; set; }
        public double Deposit { get; set; }
        public bool IsAssigned { get; set;}
        public bool IsDeleted { get; set; }

        public Guid UserId { get; set; }
        
    }
}