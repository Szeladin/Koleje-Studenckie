using System;
using System.Collections.Generic;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities
{
    public static class ShortGuidHandler
    {
        private static HashSet<string> existingIds = new HashSet<string>();

        public static string GenerateUniqueShortGuid(string prefix = "")
        {
            string newId;
            do
            {
                newId = prefix + Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                    .Replace("/", "_")
                    .Replace("+", "-")
                    .Substring(0, 8); // Usunięcie końcowego '='
            } while (existingIds.Contains(newId));

            existingIds.Add(newId);
            return newId;
        }
    }
}