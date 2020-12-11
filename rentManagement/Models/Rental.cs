using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace rentManagement.Models
{
    public class Rental
    {
        public Rental(Guid rentalId, int apartmentNum, int unitNum, double numOfRooms, double cost, bool isAssigned)
        {
            this.RentalId = rentalId;
            this.Apartment = apartmentNum;
            this.Unit = unitNum;
            this.NumberOfRoom = numOfRooms;
            this.Cost = cost;
            this.IsAssigned = isAssigned;
        }
        public Rental()
        {
            
        }
        

        //properties
        public Guid RentalId {get; set;}
        public int Apartment { get; set; }
        public int Unit { get; set; }
        public double NumberOfRoom { get; set; }
        public double Cost { get; set; } 

        public bool IsAssigned { get; set; }   
        
        //changes made for webApi
        public void Assign(){
            if(!IsAssigned){
                IsAssigned = true;
            }
            else {
                throw new Exception($"Tenant {Unit} is already assigned!");
            }
        }
        //changes made for webApi
        public void UnAssign(){
            if(IsAssigned){
                IsAssigned = false;
            }
            else{
                throw new Exception($"Tenant {Unit} is already unassigned!");
            }
        }
        public override string ToString()
        {
            string details = "----- Rental Apartment -----\n";
            details += $"Apartment number : {Apartment}\n";
            details += $"Unit : {Unit.ToString()}\n";
            details += $"Number of Rooms : {NumberOfRoom}\n";
            details += $"Cost of the Unit : {Cost}\n";
            details += $"Is the Unit assigned : {IsAssigned}\n"; 
            return details;
        }

    }
    
}