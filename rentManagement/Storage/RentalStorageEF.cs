using System;
using System.Collections.Generic;
using rentManagement.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace rentManagement.Storage
{
    public class RentalStorageEF : IStoreRentals
    {
        private ApplicationContext _context;
        
        public RentalStorageEF(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(Rental unitToCreate){
            var rentalToDb = ConvertToDb(unitToCreate);
            _context.Rentals.Add(rentalToDb); 
            _context.SaveChanges();
        }
        public void Update(Rental rentalToUpdate){
            var rentalToDb = ConvertToDb(rentalToUpdate);
            _context.Rentals.Update(rentalToDb);
            _context.SaveChanges();
        }

        public void Remove(Guid rentalToRemove){
            var rental = _context.Rentals.First(x => x.RentalId == rentalToRemove); 
            rental.IsDeleted = true;
            _context.SaveChanges();
        }
        public List<Rental> GetAll(){
            var rentalFromDb = _context.Rentals
                                .AsNoTracking()
                                .Where(x => x.IsDeleted == false)
                                .Select(x => ConvertFromDb(x))
                                .ToList();
            
            return rentalFromDb;
        }

        public Rental GetById(Guid id) {
            var rentalFromDb = _context.Rentals
                                .AsNoTracking()
                                .First(x => x.RentalId == id);
            var rental = ConvertFromDb(rentalFromDb);        
            return rental;           
        }

        public static Rental ConvertFromDb(EFModels.Rental rentalFromDb){
            return new Rental(
                rentalFromDb.RentalId,
                rentalFromDb.Apartment,
                rentalFromDb.Unit,
                rentalFromDb.NumberOfRoom,
                rentalFromDb.Cost,
                rentalFromDb.IsAssigned
            );
        }

        public static EFModels.Rental ConvertToDb(Rental rental){
            return new EFModels.Rental(){
                RentalId = rental.RentalId,
                Apartment = rental.Apartment,
                Unit = rental.Unit,
                NumberOfRoom = rental.NumberOfRoom,
                Cost = rental.Cost,
                IsAssigned = rental.IsAssigned
            };
        }

    }
}