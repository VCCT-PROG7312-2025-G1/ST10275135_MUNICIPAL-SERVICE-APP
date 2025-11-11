using System;
using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    public static class ServiceRequestRepository
    {
        private static SortedDictionary<DateTime, Queue<ServiceRequest>> requestsByDate =
            new SortedDictionary<DateTime, Queue<ServiceRequest>>();

        private static Dictionary<string, List<ServiceRequest>> requestsByStatus =
            new Dictionary<string, List<ServiceRequest>>(StringComparer.OrdinalIgnoreCase);

        private static HashSet<string> uniqueStatuses = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private static Stack<ServiceRequest> resolvedRequests = new Stack<ServiceRequest>();

        static ServiceRequestRepository()
        {
            // Demo service requests
            Add(new ServiceRequest("REQ001", "Water Leak - Main Street", "Pending", DateTime.Today.AddDays(-2)));
            Add(new ServiceRequest("REQ002", "Electricity Outage - Central", "In Progress", DateTime.Today.AddDays(-1)));
            Add(new ServiceRequest("REQ003", "Pothole Repair - Oak Ave", "Resolved", DateTime.Today));
            Add(new ServiceRequest("REQ004", "Broken Streetlight - Pine Rd", "Pending", DateTime.Today));
            Add(new ServiceRequest("REQ005", "Garbage Collection Delay", "In Progress", DateTime.Today.AddDays(-3)));
        }

        //  Add a new service request
        public static void Add(ServiceRequest request)
        {
            // Add to SortedDictionary (by date)
            if (!requestsByDate.ContainsKey(request.DateSubmitted))
                requestsByDate[request.DateSubmitted] = new Queue<ServiceRequest>();

            requestsByDate[request.DateSubmitted].Enqueue(request);

            // Add to Dictionary (by status)
            if (!requestsByStatus.ContainsKey(request.Status))
                requestsByStatus[request.Status] = new List<ServiceRequest>();

            requestsByStatus[request.Status].Add(request);

            // Add to Set (unique statuses)
            uniqueStatuses.Add(request.Status);

            // Push to stack if resolved
            if (request.Status.Equals("Resolved", StringComparison.OrdinalIgnoreCase))
                resolvedRequests.Push(request);
        }

        //  Get all requests (flattened list)
        public static List<ServiceRequest> GetAll()
        {
            var all = new List<ServiceRequest>();
            foreach (var queue in requestsByDate.Values)
            {
                foreach (var req in queue)
                    all.Add(req);
            }
            return all;
        }

        //  Get requests by status
        public static List<ServiceRequest> GetByStatus(string status)
        {
            if (requestsByStatus.ContainsKey(status))
                return new List<ServiceRequest>(requestsByStatus[status]);
            return new List<ServiceRequest>();
        }

        //  Get unique statuses
        public static HashSet<string> GetUniqueStatuses() => uniqueStatuses;

        //  Get recently resolved 
        public static List<ServiceRequest> GetRecentResolved()
        {
            var result = new List<ServiceRequest>();
            foreach (var req in resolvedRequests)
            {
                result.Add(req);
                if (result.Count == 5) break;
            }
            return result;
        }
    }
}
