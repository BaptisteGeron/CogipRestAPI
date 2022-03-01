using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogipRestAPI.Domain.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string? Email { get; set; }
        public string? Phonenumber { get; set; }
        public DateTime ContactAdded { get; set; } = DateTime.Now;

        public List<Company>? Companies { get; set; }
    }
}