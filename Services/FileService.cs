using System.IO;

namespace kursova.Services
{
    public static class FileService
    {
        public static void SaveResult(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}