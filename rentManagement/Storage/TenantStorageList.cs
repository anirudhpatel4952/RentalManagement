using System;
using System.Collections.Generic;
using System.Linq;


using rentManagement.Models;

namespace rentManagement.Storage
{
    public class TenantStorageList : IStoreTenants
    {
        private List<Tenant> _tenantStorageList;
        public TenantStorageList()
        {
            _tenantStorageList = new List<Tenant>();
        }
        //changes for webApi
        public Tenant Create(Tenant tenantToCreate) {
            _tenantStorageList.Add(tenantToCreate);
            return tenantToCreate;
            
        }
        // public Tenant CreateATenant(Guid tenantId, string firstName, string lastName, string address, string postalCode, string city, string idProof, double deposit, bool isAssigned){
        //     if (_tenantStorageList.Count <= 8){
        //     var tenant = new Tenant(tenantId, firstName, lastName, address, postalCode, city, idProof, deposit, isAssigned);
        //     _tenantStorageList.Add(tenant);
        //     return tenant;
        //     }
        //    else{
        //         throw new Exception("Maximum only 8 units equal to 8 Tenants. Limit reached");
        //     }
            
        // }

        public void Update(Tenant tenantToUpdate){
            
            var tenant = GetById(tenantToUpdate.TenantId);
                tenant.FirstName = tenantToUpdate.FirstName;
                tenant.LastName = tenantToUpdate.LastName;
                tenant.Address = tenantToUpdate.Address;
                tenant.PostalCode = tenantToUpdate.PostalCode;
                tenant.City = tenantToUpdate.City;
                tenant.IdProof = tenantToUpdate.IdProof;
                tenant.Deposit = tenantToUpdate.Deposit;
                tenant.IsAssigned = tenantToUpdate.IsAssigned;
        }

        //method to delete a tenant

        public void Remove(Guid tenantIdInput){
            var tenantToRemove = _tenantStorageList.Find(x => x.TenantId == tenantIdInput);
                if (tenantToRemove == null)
                {
                    throw new Exception($"The tenant with id:{tenantIdInput}you are trying to delete doesnot exist ");
                }
                
                else{
                    var removed = _tenantStorageList.Remove(tenantToRemove);
                    }   
        }
        
        public List<Tenant> GetAll(){
            return _tenantStorageList;
        }

        public Tenant GetById(Guid id){
            var tenant = _tenantStorageList.Find(x => x.TenantId == id);
            if (tenant == null)
                {
                    throw new Exception($"Tenant Id {id} is not a valid id.");
                }
            return tenant;
        }
        public List<Tenant> GetByFirstName(string firstName){
            return _tenantStorageList.Where(x => x.FirstName.ToLower() == firstName.ToLower()).ToList();
        }
    }
}