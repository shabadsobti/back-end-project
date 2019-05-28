using System;
using System.ComponentModel.DataAnnotations;

namespace Levvel_backend_project.Models
{
    public class Audit
    {
        [Key]
        public int AuditId { get; set; }
        public DateTime Timestamp { get; set; }
        public String TypeOfOperation { get; set; }
        public int TruckId { get; set; }
        public string InitialHours { get; set; }
        public string UpdatedHours { get; set; }
        public Address InitialLocation { get; set; }
        public Address UpdatedLocation { get; set; }
    }
}
