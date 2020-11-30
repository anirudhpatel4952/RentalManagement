using System;
using System.Collections.Generic;
using rentManagement.Models;


namespace rentManagement.Storage
{
    public interface IStoreAssignmentList
    {   
        //changes for webApi
        Assignment Create(Assignment newAssignment);
        
        List<Assignment> GetAll();

        Assignment GetByTenantIdAndUnit (Guid tenantId, int unit);

        Assignment GetByUnit (int unit);
        
    }
}