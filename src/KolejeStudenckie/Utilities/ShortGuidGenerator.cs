namespace KolejeStudenckie.Utilities
{
    public static class ShortGuidHandler
    {
        private static readonly HashSet<string> existingIds = new HashSet<string>();

        public static string GenerateUniqueShortGuid(string prefix = "")
        {
            string newId;
            do
            {
                newId = prefix + Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                    .Replace("/", "_")
                    .Replace("+", "-")
                    .Substring(0, 8);
            } while (existingIds.Contains(newId));

            existingIds.Add(newId);
            return newId;
        }
    }
}