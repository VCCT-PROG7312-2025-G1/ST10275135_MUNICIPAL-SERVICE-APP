using System;

namespace MunicipalServicesApp.Models
{
    public class Issue
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // unique ID

        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public string SubmittedAt { get; set; }

        public string Status { get; set; } = "Pending"; 

        public override string ToString()
        {
            return $"{Category} @ {Location}";
        }
    }
}
