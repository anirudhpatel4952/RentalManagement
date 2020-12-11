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

        public void Remove(Guid rentalToRemove, Guid userId){
            var rental = _context.Rentals
                                    .AsNoTracking()
                                    .First(x => x.RentalId == rentalToRemove && x.UserId == userId); 
            rental.IsDeleted = true;
            _context.Rentals.Update(rental);
            _context.SaveChanges();
        }
        public List<Rental> GetAll(Guid userId){
            var rentalFromDb = _context.Rentals
                                .AsNoTracking()
                                .Where(x => x.IsDeleted == false && x.UserId == userId)
                                .Select(x => ConvertFromDb(x))
                                .ToList();
            
            return rentalFromDb;
        }

        public Rental GetById(Guid id, Guid userId) {
            var rentalFromDb = _context.Rentals
                                .AsNoTracking()
                                .Where(x => x.IsDeleted == false && x.UserId == userId)
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
                rentalFromDb.IsAssigned,
                rentalFromDb.UserId
            );
        }

        public static EFModels.Rental ConvertToDb(Rental rental){
            return new EFModels.Rental(){
                RentalId = rental.RentalId,
                Apartment = rental.Apartment,
                Unit = rental.Unit,
                NumberOfRoom = rental.NumberOfRoom,
                Cost = rental.Cost,
                IsAssigned = rental.IsAssigned,
                UserId = rental.UserId
            };
        }

    }
}