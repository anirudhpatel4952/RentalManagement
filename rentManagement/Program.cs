using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using rentManagement.Models;
using rentManagement.Storage;


namespace rentManagement
{
    class Program
    {
        static void Main(string[] args)
        {
        //     var tenantStorageSystem = new TenantStorageList();  //<= just change the storage system type here to whatever storage system needs to be used & nothing would affected
        //     var rentalStorageSystem = new RentalStorageList();
        //     var assignmentStorageSystem = new AssignStorageList();

        //     //Initialize the StorageSystems and inject it into the rentManagementSystem constructor
        //     var rentManagementSystem = new RentManagementSystem(rentalStorageSystem, tenantStorageSystem, assignmentStorageSystem); //<= dependency injection
        //     // Tenant tenant = new Tenant();
        //     // Assignment assignment = new Assignment();
        //     System.Console.WriteLine("--------------------------------------");
        //     System.Console.WriteLine("Welcome to Your Rent Management System");
        //     System.Console.WriteLine("--------------------------------------");
        //     bool loopBreak = true;
        //     while (loopBreak)
        //     {
                
        //         System.Console.WriteLine("\nPlease select an option:\n" +
        //             "- A: TO LIST ALL THE RENTAL APARTMENT UNITS, TENANTS AND ASSIGNMENTS\n" + 
        //             "- B: TO ADD A TENANT\n" +
        //             "- C: TO REMOVE A TENANT\n" +
        //             "- D: TO SEARCH FOR A TENANT OR A UNIT\n" +
        //             "- E: TO ASSIGN A UNIT\n" +
        //             "- Q: TO QUIT\n"
        //             );
        //         var welcomeInput = Console.ReadLine().ToUpper();
        //         switch (welcomeInput)
        //         {
        //             case "A":
        //             var loopABreak = true;
        //                 while(loopABreak) {
        //                 System.Console.WriteLine("\nWhat would you like to check the list of?");
        //                 System.Console.WriteLine("\n- A: TO LIST ALL THE RENTAL APARTMENT UNITS\n" + 
        //                                         "- B: TO LIST ALL THE TENANTS\n" +
        //                                         "- C: TO LIST ALL THE RENTAL ASSIGNMENTS\n" +
        //                                         "- R: TO GO BACK TO THE MAIN OPTIONS");
        //                 var listResponse = Console.ReadLine().ToUpper();
                        
                            
        //                 if (listResponse == "A"){
        //                     try{
        //                         var listResponseA = rentManagementSystem.PrintAllUnitsInApartn();
        //                         foreach (var unit in listResponseA)
        //                         {
        //                             System.Console.WriteLine($"\n{unit.ToString()}");
        //                         }
        //                     }
                        
        //                     catch (Exception e)
        //                     {
        //                         Console.WriteLine(e.Message);
        //                     }
        //                     continue;
        //                 }
                        
        //                 if (listResponse == "B"){
        //                     try{
        //                         var listResponseB = rentManagementSystem.PrintAllTenants();
        //                         foreach (var unit in listResponseB)
        //                         {
        //                             System.Console.WriteLine($"\n{unit.ToString()}");
        //                         }
        //                     }
                        
        //                     catch (Exception e)
        //                     {
        //                         Console.WriteLine(e.Message);
        //                     }
        //                     continue;
        //                 }
                            
        //                 if (listResponse == "C"){
        //                     try{
        //                         var listResponseC = rentManagementSystem.PrintAllAssignments();
        //                         foreach (var assign in listResponseC)
        //                         {
        //                             System.Console.WriteLine($"\n{assign.ToString()}");
                                    
        //                         }
        //                     }
                        
        //                     catch (Exception e)
        //                     {
        //                         Console.WriteLine(e.Message);
        //                     }
        //                     continue;
        //                 }
        //                 if (listResponse == "R"){
        //                     try
        //                     {
        //                         loopABreak = false;
        //                     }
        //                     catch (Exception e)
        //                     {
        //                         System.Console.WriteLine(e.Message);
        //                     }
                            
        //                 }
        //                 else {
        //                     System.Console.WriteLine("Please enter a valid input");
        //                 }
        //                 }
        //                 break;
                        
        //             case "B":
        //             try
        //             {
        //                 System.Console.WriteLine("Adding a tenant.....");
        //                 System.Console.WriteLine("Please enter the following details of the Tenant:");
        //                 System.Console.WriteLine("Enter tenantId:");
        //                 var tenantIdInput = Convert.ToInt64(Console.ReadLine());
        //                 System.Console.WriteLine("Enter First Name:");
        //                 var firstNameInput = Console.ReadLine();
        //                 System.Console.WriteLine("Enter Last Name:");
        //                 var lastNameInput = Console.ReadLine();
        //                 System.Console.WriteLine("Enter Address:");
        //                 var addressInput = Console.ReadLine();
        //                 System.Console.WriteLine("Enter Postal Code:");
        //                 var postalCodeInput = Console.ReadLine();
        //                 System.Console.WriteLine("Enter City:");
        //                 var cityInput = Console.ReadLine();
        //                 System.Console.WriteLine("Enter the Id proof provided:");
        //                 var idProofInput = Console.ReadLine();
        //                 System.Console.WriteLine("Enter Deposit Amount:");
        //                 var depositInput = Convert.ToDouble(Console.ReadLine());
        //                 System.Console.WriteLine("Enter if the tenant is assigned:");
        //                 var isAssignedInput = Convert.ToBoolean(Console.ReadLine());
        //                 var tenantAdded = rentManagementSystem.AddATenant(tenantIdInput,firstNameInput, lastNameInput, addressInput, postalCodeInput, cityInput, idProofInput, depositInput, isAssignedInput);
                       
        //                 System.Console.WriteLine($"\nTenant with Id: {tenantAdded.TenantId} & First Name: {tenantAdded.FirstName} added");
        //             }
        //             catch (Exception e)
        //             {
        //                 System.Console.WriteLine(e.Message);
        //             }
        //                 break;

        //             case "C":
        //             try
        //             {
        //                 System.Console.WriteLine("Enter the tenantId to delete the Tenant:");
        //                 var tenantDelIdInput = Convert.ToInt64(Console.ReadLine());
        //                 var tenantDeleted = rentManagementSystem.DeleteATenant(tenantDelIdInput);
        //                 System.Console.WriteLine("Deleting a tenant.....");
        //                 System.Console.WriteLine($"Tenant with Id:{tenantDeleted.TenantId} removed"); 
        //             }
        //             catch (Exception e)
        //             {
        //                 System.Console.WriteLine(e.Message);
        //             }
        //                 break;   
                    
        //             case "D":
        //                 System.Console.WriteLine("Search for a Tenant or Unit?");
        //                 var searchResponse = Console.ReadLine().ToLower();
        //                 if (searchResponse == "tenant"){
        //                     try
        //                     {
        //                         System.Console.WriteLine("Please enter the Tenant Id to search for the tenant");
        //                         var searchTenantIdInput = Convert.ToInt32(Console.ReadLine());
        //                         var searchResult = rentManagementSystem.SearchForTenants(searchTenantIdInput);
                                
        //                         System.Console.WriteLine(searchResult.ToString());
                                
        //                     }
        //                     catch (Exception e)
        //                     {
        //                         System.Console.WriteLine(e.Message);
        //                     }
                             
        //                 }
        //                 else if (searchResponse == "unit"){
        //                     try
        //                     {
        //                         System.Console.WriteLine("Please enter the Unit number to search for the unit");
        //                         var searchUnitNumInput = Convert.ToInt32(Console.ReadLine());
        //                         var searchResult = rentManagementSystem.SearchForUnits(searchUnitNumInput);
        //                         System.Console.WriteLine(searchResult.ToString());
                         
        //                     }
        //                     catch (Exception e)
        //                     {
        //                         System.Console.WriteLine(e.Message);
        //                     }
        //                 }   
        //                 break;

        //             case "E":
        //                 System.Console.WriteLine("Assigning a Unit.....");
        //                 System.Console.WriteLine("Please enter a unit you want to assign:");
        //                 var unitNumInput = Convert.ToInt32(Console.ReadLine());
        //                 try
        //                 {
        //                     System.Console.WriteLine("Please enter a Tenant Id for the tenant to get a unit assigned:");
        //                 }
        //                 catch (Exception e)
        //                 {
        //                     System.Console.WriteLine(e.Message);
        //                 }
        //                 var tenantIdToassignInput = Convert.ToInt64(Console.ReadLine());
        //                 try
        //                 {
        //                     var assignmentComplete = rentManagementSystem.UnitAssigner(tenantIdToassignInput, unitNumInput);
        //                 }
        //                 catch (Exception e)
        //                 {
        //                     System.Console.WriteLine(e.Message);
        //                 }
        //                 var unitSearch = rentManagementSystem.SearchForUnits(unitNumInput);
        //                 var tenantSearch = rentManagementSystem.SearchForTenants(tenantIdToassignInput);
                        
        //                 if (unitSearch.IsAssigned == true && tenantSearch.IsAssigned == true) {
                            
        //                     try
        //                     {
        //                         System.Console.WriteLine($"Assignment Completed. The Tenant with Id: {tenantIdToassignInput} is assigned the unit: {unitNumInput}.");
        //                     }
        //                     catch (Exception e)
        //                     {
        //                         System.Console.WriteLine(e.Message);
        //                     }
                            
                            
        //                 }
        //                 else{
        //                     System.Console.WriteLine($"Either Tenant Id or Unit number not available, try again");
        //                 }
                        
                        
        //                 break;

        //             case "Q":
        //                 System.Console.WriteLine("Thanks for using Rent Management, See You Again !");
        //                 loopBreak = false;
        //                 break;

        //             default:
        //                 System.Console.WriteLine("Please enter a valid input");
        //                 break;
        //         }
        //     }
        }
        
    
    }
}
