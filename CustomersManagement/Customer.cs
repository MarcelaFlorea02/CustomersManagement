using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersManagement
{
    public record Customer
    {
        public int Id { get; set; }
        public required string  FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
