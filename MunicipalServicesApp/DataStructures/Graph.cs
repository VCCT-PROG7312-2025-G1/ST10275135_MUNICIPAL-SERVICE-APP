using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    public class Graph
    {
        private Dictionary<string, List<string>> adj = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        public void AddEdge(string from, string to)
        {
            if (!adj.ContainsKey(from)) adj[from] = new List<string>();
            adj[from].Add(to);
            if (!adj.ContainsKey(to)) adj[to] = new List<string>();
        }

        public List<string> DfsTraverse(string start)
        {
            var result = new List<string>();
            var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (!adj.ContainsKey(start)) return result;
            DFS(start, visited, result);
            return result;
        }

        private void DFS(string node, HashSet<string> visited, List<string> result)
        {
            if (visited.Contains(node)) return;
            visited.Add(node);
            result.Add(node);
            if (!adj.ContainsKey(node)) return;
            foreach (var n in adj[node])
                DFS(n, visited, result);
        }

        
        public Dictionary<string, List<string>> GetAdjacency()
        {
            var copy = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            foreach (var kv in adj)
                copy[kv.Key] = new List<string>(kv.Value);
            return copy;
        }
    }
}
