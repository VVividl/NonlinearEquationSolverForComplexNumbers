namespace kursova.Services
{
    public static class ComplexityAnalyzer
    {
        public static string GetComplexityReport(string methodName, int iterations, bool success)
        {
            string status = success ? "Success (root found)" : "Failed (iteration limit reached)";

            return $"--- Complexity Analysis ---\n" +
                   $"Method: {methodName}\n" +
                   $"Status: {status}\n" +
                   $"Iterations (k): {iterations}\n" +
                   $"Practical complexity: O(k), where k is the number of steps.\n" +
                   $"---------------------------";
        }
    }
}