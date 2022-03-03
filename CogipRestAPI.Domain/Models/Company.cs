using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CogipRestAPI.Domain.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string? Vat { get; set; }
        public string? Status { get; set; }
        public DateTime Added { get; set; } = DateTime.Now;
        public string? Country { get; set; }
        public string? Town { get; set; }
        public string? Street { get; set; }
        public int? Zip { get; set; }
        public string? StreetNumber { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public List<Contact>? Contacts { get; set; }
    }
}
