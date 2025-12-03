
using System.IO;
using System.Text.Json;
using StudentsData.Model;
using System.Collections.Generic;

namespace StudentsData.FileHandler
{
    public class FileManager
    {
        private static string file = "students.json";

        public static void Save(List<StudentsInfo> li)
        {
            string json = JsonSerializer.Serialize(li);
            File.WriteAllText(file, json);
        }

        public static List<StudentsInfo> Load()
        {
            if (!File.Exists(file))
                return new List<StudentsInfo>();

            string json = File.ReadAllText(file);
            return JsonSerializer.Deserialize<List<StudentsInfo>>(json);
        }
    }
}