using System;
using System.Collections.Generic;
using rentManagement.Models;


namespace rentManagement.Storage
{
    public class AssignStorageList : IStoreAssignmentList
    {
        private readonly List<Assignment> _innerList;

        public AssignStorageList() {
            _innerList = new List<Assignment>();
        }
        //changes fpr webApi
        public Assignment Create(Assignment newAssignment){
            _innerList.Add(newAssignment);
            return newAssignment;
        }
        
        public List<Assignment> GetAll(){
            return _innerList;
        }
        //changes made for webApi
        public Assignment GetByTenantIdAndUnit (Guid tenantId, int unit){
            var assignment = _innerList.Find(x => x.Tenant.TenantId == tenantId && x.Rental.Unit == unit);

            if(assignment == null){
                throw new Exception($"Assignment does not exist between Tenant {tenantId} and Unit {unit}.");
            }
            return assignment;
        }
        public Assignment GetByUnit (int unit){
            var assignment = _innerList.Find(x => x.Rental.Unit == unit);

            if(assignment == null){
                throw new Exception($"Assignment does not exist for Unit {unit}.");
            }
            return assignment;
        }
        
    }
}