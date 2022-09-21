using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SgnlrServer.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerNationalId { get; set; } = null!;

        public string CustomerPassportNum { get; set; } = null!;

        public string CustomerPasspostExpDate { get; set; } = null!;
        public string? CustomerHijriDateOfBirth { get; set; } = null;
        public string? CustomerGregorianDateOfBirth { get; set; } = null;

    }
}
