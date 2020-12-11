using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using rentManagement.Models;

namespace rentManagement.Storage
{
    
    public class TenantStorageEF : IStoreTenants
    {
        private ApplicationContext _context;
        public TenantStorageEF(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Tenant tenantToCreate)
        {
            var newTenant = ConvertToDb(tenantToCreate);
            _context.Tenants.Add(newTenant);
            _context.SaveChanges();

        }

        public void Update(Tenant tenantToUpdate){
            var newTenant = ConvertToDb(tenantToUpdate);
            _context.Tenants.Update(newTenant);
            _context.SaveChanges();    
        }

        public void Remove(Guid tenantIdInput, Guid userId){
            var tenantToRemove = _context.Tenants
                                        .AsNoTracking()
                                        .First(x => x.TenantId == tenantIdInput && x.UserId == userId);
            tenantToRemove.IsDeleted = true;
            _context.Tenants.Update(tenantToRemove);
            _context.SaveChanges();
        }
        
        public List<Tenant> GetAll(Guid userId){
            List<Tenant> results = new List<Tenant>();
            var tenantFromDb = _context.Tenants
                                        .AsNoTracking()
                                        .Where(x => x.IsDeleted == false && x.UserId == userId)
                                        .ToList();
            foreach(var tenants in tenantFromDb){
                var tenant = ConvertFromDb(tenants);
                results.Add(tenant);
            };
            return results; 
        }

        public Tenant GetById(Guid id, Guid userId)
        {
            var tenantFromDb = _context.Tenants
                                        .AsNoTracking()
                                        .Where(x => x.IsDeleted == false && x.UserId == userId)
                                        .First(x => x.TenantId == id);
            var tenant = ConvertFromDb(tenantFromDb);
            return tenant;
        }

        public static Tenant ConvertFromDb(EFModels.Tenant tenantFromDb)
        {
            return new Tenant()
            {
                TenantId = tenantFromDb.TenantId,
                FirstName = tenantFromDb.FirstName,
                LastName = tenantFromDb.LastName,
                Address = tenantFromDb.Address,
                PostalCode = tenantFromDb.PostalCode,
                City = tenantFromDb.City,
                IdProof = tenantFromDb.IdProof,
                Deposit = tenantFromDb.Deposit,
                IsAssigned = tenantFromDb.IsAssigned,
                UserId = tenantFromDb.UserId
            };
        }
        public static EFModels.Tenant ConvertToDb(Tenant tenantToCreate)
        {
            return new EFModels.Tenant()
            {
                TenantId = tenantToCreate.TenantId,
                FirstName = tenantToCreate.FirstName,
                LastName = tenantToCreate.LastName,
                Address = tenantToCreate.Address,
                PostalCode = tenantToCreate.PostalCode,
                City = tenantToCreate.City,
                IdProof = tenantToCreate.IdProof,
                Deposit = tenantToCreate.Deposit,
                IsAssigned = tenantToCreate.IsAssigned,
                UserId = tenantToCreate.UserId
                
            };
        }

        public List<Tenant> GetByFirstName(string firstName){
            return new List<Tenant>();
        }
    }
}