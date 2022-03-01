using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogipRestAPI.Domain.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string Reference { get; set; }
        public float Amount { get; set; }
        public Company Company { get; set; }
        public Contact? Contact { get; set; }

        public DateTime? Received { get; set; }

        public bool? PaidStatus { get; set; }

        public DateTime InvoiceAdded { get; set; } = DateTime.Now;
        public float? Due { get; set; }
        public float? Paid { get; set; }
        public DateTime? DueDate { get; set; }

        public InvoiceCategory? Category { get; set; }
    }
}
