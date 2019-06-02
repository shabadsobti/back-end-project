using System;
using System.ComponentModel.DataAnnotations;

namespace Levvel_backend_project.Models
{
    public class Audit
    {
        public int AuditId { get; set; }
        public DateTime Timestamp { get; set; }
        public String TypeOfOperation { get; set; }
        public int TruckId { get; set; }
        public string Hours { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
    }
}
