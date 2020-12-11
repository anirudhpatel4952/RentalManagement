using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using rentManagement.Models;


namespace rentManagement.Storage
{
    public class AssignStorageEF : IStoreAssignment
    {
        private ApplicationContext _context;

        public AssignStorageEF(ApplicationContext context) {
            _context = context;
        }
        //changes fpr webApi
        public void Create(Assignment newAssignment){
            var assignmentToCreate = ConvertToDb(newAssignment);
            _context.Assignments.Add(assignmentToCreate);
            _context.SaveChanges();
        }

        public void Update(Assignment newAssignment){
            var assignmentDb = ConvertToDb(newAssignment);
            _context.Assignments.Update(assignmentDb);
            _context.SaveChanges();
        }
        
        public List<Assignment> GetAll(Guid userId){
            var assignmentDb = _context.Assignments
                                .AsNoTracking()
                                .Include(x => x.Rental)
                                .Include(x => x.Tenant)
                                .Where(x => x.UserId == userId)
                                .Select(x => ConvertFromDb(x))
                                .ToList();
            return assignmentDb;
        }
        //changes made for webApi
        
        public Assignment GetByUnit (Guid rentalId, Guid userId){
            var assignment = _context.Assignments
                                    .AsNoTracking()
                                    .Include(x => x.Rental)
                                    .Include(x => x.Tenant)
                                    .First(x => x.RentalId == rentalId && x.UserId == userId);

            var assignmentDb = ConvertFromDb(assignment);
            return assignmentDb;
        }

        private static EFModels.Assignment ConvertToDb(Assignment assignment){
            return new EFModels.Assignment(){
                AssignmentId = assignment.AssignId,
                TenantId = assignment.Tenant.TenantId,
                RentalId = assignment.Rental.RentalId,
                IsAssigned = assignment.IsAssigned,
                UserId = assignment.UserId
                //Tenant = TenantStorageEF.ConvertToDb(assignment.Tenant),
                //Rental = RentalStorageEF.ConvertToDb(assignment.Rental)
            };

        }

        private static Assignment ConvertFromDb(EFModels.Assignment assignment){
            return new Assignment(){
                AssignId = assignment.AssignmentId,
                Rental = RentalStorageEF.ConvertFromDb(assignment.Rental),
                Tenant = TenantStorageEF.ConvertFromDb(assignment.Tenant),
                IsAssigned = assignment.IsAssigned,
                UserId = assignment.UserId
            };
        }
        
    }
}