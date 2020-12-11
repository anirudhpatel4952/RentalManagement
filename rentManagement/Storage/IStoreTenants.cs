using System;
using System.Collections.Generic;

using rentManagement.Models;

namespace rentManagement.Storage
{
    public interface IStoreTenants
    {
         //changes for webApi
        void Create(Tenant tenantToCreate);

        //below function for console only
        // Tenant CreateATenant(Guid tenantId, string firstName, string lastName, string address, string postalCode, string city, string idProof, double deposit, bool isAssigned);

        void Update(Tenant tenantToUpdate);
        
        //method to delete a tenant

        void Remove(Guid tenantIdInput);
        
        List<Tenant> GetAll();

        Tenant GetById(Guid tenantToSearchById);
        
    }
}

    
