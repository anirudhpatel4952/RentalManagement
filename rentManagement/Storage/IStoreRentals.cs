using System;
using System.Collections.Generic;
using rentManagement.Models;

namespace rentManagement.Storage
{
    public interface IStoreRentals
    {
        
        void Create(Rental unitToCreate);
        void Update(Rental rentalToUpdate);

        void Remove(Guid rentalToRemove);
        List<Rental> GetAll();

        Rental GetById(Guid id);

    }
}