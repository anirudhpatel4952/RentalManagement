using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using F23.StringSimilarity;

using rentManagement.Storage;
using rentManagement.Models;

namespace rentManagement
{
    public class RentManagementSystem
    {
        //--------------CONSTRUCTOR-------------------//
        public RentManagementSystem(
            IStoreRentals rentalStorageArg, 
            IStoreTenants tenantsStorageArg, 
            IStoreAssignment assignStorageArg)
    
        {
            _tenantStorage = tenantsStorageArg;           //<= on doing the dependency injection
            _rentalStorage = rentalStorageArg;
            _assignStorage = assignStorageArg;
            
        }
        //---------END OF CONTRUCTOR---------------//

        //---------DATA MEMBERS---------//
        private IStoreTenants _tenantStorage;
        private IStoreRentals _rentalStorage;
        private IStoreAssignment _assignStorage; 

        //----------METHODS-------------//
        //method to add a tenant 
        
        //changes for webapi
        public Tenant AddTenant(Tenant tenant){
            _tenantStorage.Create(tenant);
            return tenant;
        }

        public void UpdateTenant(Tenant tenantToUpdate){
            _tenantStorage.Update(tenantToUpdate);
        }

        public List<Tenant> SearchForTenantByName(string firstNameToSearch, Guid userId){
            var result = new List<Tenant>();
            var lowerCaseSearch = firstNameToSearch.ToLower();
            var tenants = _tenantStorage.GetAll(userId);

            foreach(var tenant in tenants){
                var lowerCaseFirstName = tenant.FirstName.ToLower();
                // if (lowerCaseFirstName.Contains(lowerCaseSearch)){
                //     result.Add(tenant);
                // }
                if (lowerCaseFirstName.StartsWith(lowerCaseSearch)){
                    result.Add(tenant);
                }
            }
            return result;

        }
        public Rental AddUnit(Rental rental){
            _rentalStorage.Create(rental);
            return rental;
        }

        public void UpdateUnit(Rental unitToUpdate){
            _rentalStorage.Update(unitToUpdate);
        }
        //below function for console only
        // public Tenant AddATenant(long tenantId, string firstName, string lastName, string address, string postalCode, string city, string idProof, double deposit, bool isAssigned){
        //     return _tenantStorage.CreateATenant(tenantId, firstName, lastName, address, postalCode, city, idProof, deposit, isAssigned); 
        // }
        //added for webApi
        public Assignment CreateAssignment(Guid tenantId, Guid rentalId, Guid userId){
            var tenant = _tenantStorage.GetById(tenantId, userId);
            tenant.Assign();
            _tenantStorage.Update(tenant);

            var unit = _rentalStorage.GetById(rentalId, userId);
            unit.Assign();
            _rentalStorage.Update(unit);

            var assignment = new Assignment(unit, tenant, userId){
                Rental = unit,
                Tenant = tenant,
                IsAssigned = true
            };
            
            _assignStorage.Create(assignment);
            return assignment;
            
        }
        
        // public void Unassignment(Guid tenantId, Guid rentalId){
        //     var unit = _rentalStorage.GetById(rentalId);
        //     unit.UnAssign();
        //     _rentalStorage.Update(unit);

        //     var tenant = _tenantStorage.GetById(tenantId);
        //     tenant.UnAssign();
        //     _tenantStorage.Update(tenant);

        //     var assignment = _assignStorage.GetByUnit(rentalId);
        //     assignment.IsAssigned = false;
        //     assignment.ContractDate = DateTime.Now;
        //     _assignStorage.Update(assignment);
        // }

        public void UnassignmentByUnit(Guid rentalId, Guid userId){
            var unit = _rentalStorage.GetById(rentalId, userId);
            unit.UnAssign();
            _rentalStorage.Update(unit);

            var assignment = _assignStorage.GetByUnit(rentalId, userId);
            assignment.IsAssigned = false;
            // assignment.ContractDate = DateTime.Now;
            _assignStorage.Update(assignment);

            var tenant = _tenantStorage.GetById(assignment.Tenant.TenantId, assignment.Tenant.UserId);
            tenant.UnAssign();
            _tenantStorage.Update(tenant);

            
            // var assignmentComplete = new Assignment(unit, tenant);
            // _assignStorage.Create(assignmentComplete);
            
        }
        
        //method to delete a tenant

        public void DeleteATenant(Guid tenantIdInput, Guid userId){
            _tenantStorage.Remove(tenantIdInput, userId); 
        }

        public void DeleteARental(Guid rentalToRemove, Guid userId){
            _rentalStorage.Remove(rentalToRemove, userId);
        }
        
        //method to print all the tenants
        
        public List<Tenant> PrintAllTenants(Guid userId){
            return _tenantStorage.GetAll(userId);
        }

        //method to print all the units in the apartment
        public List<Rental> PrintAllUnitsInApartn(Guid userId){
            return _rentalStorage.GetAll(userId);
        }
        //method to print all assignments
        public List<Assignment> PrintAllAssignments(Guid userId){
            return _assignStorage.GetAll(userId);
        }
        
        //search functionality to search for a tenant
        public Tenant SearchForTenants(Guid tenantToSearchById, Guid userId){
           return _tenantStorage.GetById(tenantToSearchById, userId);
        }

        //search functionality to search for a unit
        public Rental SearchForUnits(Guid rentalId, Guid userId) {
            return _rentalStorage.GetById(rentalId, userId);
        }

    }
}