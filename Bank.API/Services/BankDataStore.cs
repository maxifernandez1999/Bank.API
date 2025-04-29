using System;
using Bank.API.Models;
namespace Bank.API.Services;

public class BankDataStore
{
    public List<Models.Bank> Banks { get; set; }

    public static BankDataStore Current { get; } = new BankDataStore(); // -> Patrón singleton
    public BankDataStore()
    {
        Banks = new List<Models.Bank>
        {
            new Models.Bank
            {
                Id = 1,
                Name = "Banco Nación",
                Country = "Argentina",
                SwiftCode = "NACNARBA",
                EstablishedYear = 1891,
                IsActive = true,
                Employees = new List<Employee>
                {
                    new Employee { Id = 1, Name = "Juan Pérez", Age = 35 },
                    new Employee { Id = 2, Name = "Ana Gómez", Age = 28 }
                }
            },
            new Models.Bank
            {
                Id = 2,
                Name = "Banco Santander",
                Country = "España",
                SwiftCode = "BSCHESMM",
                EstablishedYear = 1857,
                IsActive = true,
                Employees = new List<Employee>
                {
                    new Employee { Id = 3, Name = "Carlos Ruiz", Age = 42 }
                }
            },
            new Models.Bank
            {
                Id = 3,
                Name = "Chase Bank",
                Country = "Estados Unidos",
                SwiftCode = "CHASUS33",
                EstablishedYear = 1877,
                IsActive = false,
                Employees = new List<Employee>()
            }
        };
    }
}