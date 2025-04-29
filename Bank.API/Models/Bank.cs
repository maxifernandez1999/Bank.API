using System;

namespace Bank.API.Models;

public class Bank
{
    public int Id { get; set; }

    // Nombre del banco (ej: "Banco Nación")
    public string? Name { get; set; }

    // País donde opera el banco (ej: "Argentina")
    public string? Country { get; set; }

    // Código SWIFT para transferencias internacionales (ej: "NACNARBA")
    public string? SwiftCode { get; set; }

    // Año en que se fundó el banco
    public int EstablishedYear { get; set; }

    // Lista de clientes del banco
    public List<Employee> Employees { get; set; } = new List<Employee>();

    // Lista de cuentas del banco
    // public List<Account> Accounts { get; set; }

    // Indica si el banco está activo o no
    public bool IsActive { get; set; }

    // Constructor
    // public Bank(string name, string country, string swiftCode, int establishedYear)
    // {
    //     Name = name;
    //     Country = country;
    //     SwiftCode = swiftCode;
    //     EstablishedYear = establishedYear;
    //     Clients = new List<Client>();
    //     Accounts = new List<Account>();
    //     IsActive = true;
    // }
}

