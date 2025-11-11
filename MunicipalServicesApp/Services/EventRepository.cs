using System;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.DataStructures;

namespace MunicipalServicesApp.Services
{
    public static class EventRepository
    {
        // BST keyed by Date (date only) -> list of events on that date
        private static CustomBST<DateTime, CustomLinkedList<Event>> eventsByDate = new CustomBST<DateTime, CustomLinkedList<Event>>();

        // BST keyed by category -> list of events in category
        private static CustomBST<string, CustomLinkedList<Event>> eventsByCategory = new CustomBST<string, CustomLinkedList<Event>>();

        static EventRepository()
        {
            //  Demo events
            Add(new Event("E1", "Farmers Market", "Markets", "Fresh produce and crafts", DateTime.Today.AddDays(2), "Town Square"));
            Add(new Event("E2", "Roadworks Update", "Announcements", "Temporary roadworks on Main St.", DateTime.Today.AddDays(1), "Main St."));
            Add(new Event("E3", "Concert in the Park", "Entertainment", "Local bands perform", DateTime.Today.AddDays(10), "Bayview Park"));
            Add(new Event("E4", "Water Maintenance", "Announcements", "Planned maintenance", DateTime.Today.AddDays(3), "Citywide"));
            Add(new Event("E5", "Art Exhibition", "Arts", "Local artists showcase", DateTime.Today.AddDays(5), "Community Hall"));
        }

        public static void Add(Event e)
        {
            // By date (use date-only)
            DateTime keyDate = e.Date.Date;
            var list = eventsByDate.Find(keyDate);
            if (list == null) list = new CustomLinkedList<Event>();
            list.AddLast(e);
            eventsByDate.Insert(keyDate, list);

            // By category
            var cat = (e.Category ?? "Other").Trim().ToLowerInvariant();
            var clist = eventsByCategory.Find(cat);
            if (clist == null) clist = new CustomLinkedList<Event>();
            clist.AddLast(e);
            eventsByCategory.Insert(cat, clist);
        }

        // Retrieve events between dates inclusive
        public static CustomLinkedList<Event> GetByDateRange(DateTime start, DateTime end)
        {
            var result = new CustomLinkedList<Event>();
            foreach (var kv in eventsByDate)
            {
                var date = kv.Key;
                if (date >= start.Date && date <= end.Date)
                {
                    var list = kv.Value;
                    foreach (var ev in list) result.AddLast(ev);
                }
            }
            return result;
        }

        // Retrieve events by category 
        public static CustomLinkedList<Event> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category)) return new CustomLinkedList<Event>();
            var key = category.Trim().ToLowerInvariant();
            var list = eventsByCategory.Find(key);
            if (list == null) return new CustomLinkedList<Event>();
            return list;
        }

        // Return all events
        public static CustomLinkedList<Event> GetAll()
        {
            var result = new CustomLinkedList<Event>();
            foreach (var kv in eventsByDate)
            {
                foreach (var ev in kv.Value) result.AddLast(ev);
            }
            return result;
        }

        // Expose categories (unique) using a CustomSet-like traversal
        public static CustomLinkedList<string> GetAllCategories()
        {
            var result = new CustomLinkedList<string>();
            foreach (var kv in eventsByCategory)
            {
                result.AddLast(kv.Key);
            }
            return result;
        }
    }
}
