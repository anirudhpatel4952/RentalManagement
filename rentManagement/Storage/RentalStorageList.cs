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
        public Rental Create(Rental unitToCreate){
            _rentalStorageList.Add(unitToCreate);
            return unitToCreate;
        }
        public void Update(Rental rentalToUpdate){
            var unit = GetByUnitNum(rentalToUpdate.Unit);
            unit.Apartment = rentalToUpdate.Apartment;
            unit.Unit = rentalToUpdate.Unit;
            unit.NumberOfRoom = rentalToUpdate.NumberOfRoom;
            unit.IsAssigned = rentalToUpdate.IsAssigned;
        }
        public List<Rental> GetAll(){
            return _rentalStorageList;
        }

        public Rental GetByUnitNum(int unit) {
            var unitToSearch = _rentalStorageList.Find(x => x.Unit == unit);
            if (unitToSearch == null){
                throw new Exception($"The unit {unit} is invalid or not available");
                }
            return unitToSearch;           
        }

    }
}