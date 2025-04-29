using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Models;

public class BankRequest
{
    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Country { get; set; }

}
