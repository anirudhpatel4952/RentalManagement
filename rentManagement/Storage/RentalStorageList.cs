using System;
using System.Collections.Generic;
using rentManagement.Models;
using System.Linq;
namespace rentManagement.Storage
{
    public class RentalStorageList : IStoreRentals
    {
        private List<Rental> _rentalStorageList;
        public RentalStorageList()
        {
            _rentalStorageList = new List<Rental>();
        }
        public void Create(Rental unitToCreate){
            _rentalStorageList.Add(unitToCreate);
        }
        public void Update(Rental rentalToUpdate){
            var unit = GetById(rentalToUpdate.RentalId);
            unit.Apartment = rentalToUpdate.Apartment;
            unit.Unit = rentalToUpdate.Unit;
            unit.NumberOfRoom = rentalToUpdate.NumberOfRoom;
            unit.IsAssigned = rentalToUpdate.IsAssigned;
        }

        public void Remove(Guid rentalToRemove){
            var rental = GetById(rentalToRemove);
             if (rental == null)
                {
                    throw new Exception($"The tenant with id:{rental.Unit}you are trying to delete doesnot exist ");
                }
                
                else{
                    _rentalStorageList.Remove(rental);
                    }  
            
        }
        public List<Rental> GetAll(){
            return _rentalStorageList;
        }

        public Rental GetById(Guid id) {
            var unitToSearch = _rentalStorageList.Find(x => x.RentalId == id);
            if (unitToSearch == null){
                throw new Exception($"The unit {unitToSearch} is invalid or not available");
                }
            return unitToSearch;           
        }

    }
}