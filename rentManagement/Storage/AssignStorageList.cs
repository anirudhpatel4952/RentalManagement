using System;
using System.Collections.Generic;
using rentManagement.Models;


namespace rentManagement.Storage
{
    public class AssignStorageList : IStoreAssignment
    {
        private readonly List<Assignment> _innerList;

        public AssignStorageList() {
            _innerList = new List<Assignment>();
        }
        //changes fpr webApi
        public void Create(Assignment newAssignment){
            _innerList.Add(newAssignment);
        }

        public void Update(Assignment newAssignment){
            
        }
        
        public List<Assignment> GetAll(){
            return _innerList;
        }
        //changes made for webApi
        // public Assignment GetByTenantIdAndUnit (Guid tenantId, int unit){
        //     var assignment = _innerList.Find(x => x.Tenant.TenantId == tenantId && x.Rental.Unit == unit);

        //     if(assignment == null){
        //         throw new Exception($"Assignment does not exist between Tenant {tenantId} and Unit {unit}.");
        //     }
        //     return assignment;
        // }
        public Assignment GetByUnit (Guid rentalId){
            var assignment = _innerList.Find(x => x.Rental.RentalId == rentalId);

            if(assignment == null){
                throw new Exception($"Assignment does not exist : {assignment}.");
            }
            return assignment;
        }
        
    }
}