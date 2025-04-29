using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Models;

public class EmployeeRequest
{
    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }

    [Required]
    public int Age { get; set; }

}
