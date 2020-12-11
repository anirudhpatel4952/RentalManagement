using System;
namespace rentManagement.Storage.EFModels
{
    public class Rental
    {
        public Guid RentalId { get; set;}
        public int Apartment { get; set; }
        public int Unit { get; set; }
        public double NumberOfRoom { get; set; }
        public double Cost { get; set; } 
        public bool IsAssigned { get; set; }

        public bool IsDeleted { get; set;}
    }
}