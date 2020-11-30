using System;

namespace rentManagement.Models
{
    public class Assignment
    {
        public Assignment(Rental rental, Tenant tenant) 
        {
            this.AssignId = Guid.NewGuid();
            this.Rental = rental;
            this.Tenant = tenant;
            this.IsAssigned = false;
            this.ContractDate = DateTime.Now;
               
        }
        public Assignment()
        {
            ContractDate = DateTime.Now;
        }
        public Guid AssignId { get; set;}
        public Tenant Tenant { get; set; }
        public Rental Rental { get; set; }
        public DateTime ContractDate { get; set; }
        public bool IsAssigned { get; set; }

        public override string ToString()
        {
            string details = "----- CONTRACT -----\n";
            details += $"AssignID: {AssignId}\n";
            details += $"Tenant: {Tenant.TenantId}\n";
            details += $"Unit Assigned: {Rental.Unit.ToString()}\n";
            details += $"Contract Date: {ContractDate}\n"; 
            return details;
        }
    }
}