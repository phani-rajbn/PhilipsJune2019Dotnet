using System.IO;

namespace SampleWpfApp.Models
{
    public static class FileIO
    {
        public static string ReadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return string.Empty;
            if (!File.Exists(fileName)) return string.Empty;
            StreamReader reader = new StreamReader(fileName);
            var content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        //This functionality will not append the file, it simply replaces the contents of the file....
        public static void WriteFile(string fileName, string content)
        {
            if (string.IsNullOrEmpty(fileName)) return;
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(content);
            }
        }

    }
}
