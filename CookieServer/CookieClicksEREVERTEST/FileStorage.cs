using System.Text.Json;

namespace CookieServer {
    public class FileStorage {
        public static readonly String path = Environment.CurrentDirectory + "/CookieData.txt";
        public static async Task SaveToFile(String filePath, ProgressionData progressionData) {
            FileCheckAndDelete(filePath);
            WriteToFile(progressionData, filePath);
        }

        public static async Task<ProgressionData> LoadFromFile(String filePath) {
            FileCheckAndCreate(filePath);
            String FileContent = ReadFileContent(filePath);
            return JsonSerializer.Deserialize<ProgressionData>(FileContent);
        }
        public static Boolean FileCheckAndCreate(String path) {
            if (!File.Exists(path)) {
                ProgressionData cookie = new ProgressionData(0, 0, 0, 0, 0, 0, 0);
                WriteToFile(cookie, path);
                return true;
            }
            return false;
        }

        public static void FileCheckAndDelete(String FilePath) {
            if (File.Exists(FilePath)) {
                File.Delete(FilePath);
            }
        }
        public static string ReadFileContent(String filePath) {
            String fileContent = "";
            using (StreamReader sr = new StreamReader(filePath)) {
                while (!sr.EndOfStream) {
                    fileContent += sr.ReadLine();
                }
                sr.Close();
            }
            return fileContent;
        }

        private static void WriteToFile(ProgressionData cookie, String path) {
            using (StreamWriter sw = File.CreateText(path)) {
                String patientString = JsonSerializer.Serialize<ProgressionData>(cookie);
                sw.WriteLine(patientString);
                sw.Close();
            }
        }
    }
}