using System.Text.Json;

namespace CookieServer {
    internal class FileStorage {
        String path = Environment.CurrentDirectory + "/CookieData.txt";
        public async Task SaveToFile() {
            FileCheckAndDelete(path);
            WriteToFile(Program.cookie, path);
        }

        public async Task LoadFromFile() {
            FileCheckAndCreate(path);
            String FileContent = ReadFileContent(path);
            Program.cookie = JsonSerializer.Deserialize<ProgressionData>(FileContent);
        }
        public static Boolean FileCheckAndCreate(String path) {
            if (!File.Exists(path)) {
                ProgressionData cookie = new ProgressionData(0, 0, 0, 0, 0, 0, 0, 0);
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