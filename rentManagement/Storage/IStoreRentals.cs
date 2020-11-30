using System;
using System.Collections.Generic;
using rentManagement.Models;

namespace rentManagement.Storage
{
    public interface IStoreRentals
    {
        
        Rental Create(Rental unitToCreate);
        void Update(Rental rentalToUpdate);
        List<Rental> GetAll();

        Rental GetByUnitNum(int unitToSearchByUnitNum);

    }
}