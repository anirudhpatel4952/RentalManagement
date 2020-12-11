using System;
using System.Collections.Generic;
using rentManagement.Models;


namespace rentManagement.Storage
{
    public interface IStoreAssignment
    {   
        //changes for webApi
        void Create(Assignment newAssignment);
        
        void Update(Assignment updatedAssignment);
        List<Assignment> GetAll(Guid userId);

        Assignment GetByUnit (Guid rentalId, Guid userId);
        
    }
} 