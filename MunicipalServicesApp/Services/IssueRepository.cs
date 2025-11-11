using System.Collections.Generic;
using System.IO;
using MunicipalServicesApp.Models;
using Newtonsoft.Json;

namespace MunicipalServicesApp.Services
{
    public static class IssueRepository
    {
        private static readonly string filePath = "issues.json";
        private static List<Issue> issues = LoadIssues();

        public static void Add(Issue issue)
        {
            issues.Add(issue);
            SaveIssues();
        }

        public static List<Issue> GetAll()
        {
            return issues;
        }

        public static void Update(Issue issue)
        {
            var existing = issues.Find(i => i.Id == issue.Id);
            if (existing != null)
            {
                existing.Status = issue.Status;
                existing.Category = issue.Category;
                existing.Location = issue.Location;
                existing.Description = issue.Description;
                SaveIssues();
            }
        }

        private static void SaveIssues()
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(issues, Newtonsoft.Json.Formatting.Indented));
        }

        private static List<Issue> LoadIssues()
        {
            if (!File.Exists(filePath)) return new List<Issue>();
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Issue>>(json) ?? new List<Issue>();
        }
    }
}
