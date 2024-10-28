using System.Text.Json;
using Test;

namespace CookieClicksEREVERTEST {
    internal class FileStorage {
        String path = Environment.CurrentDirectory + "/CookieData.txt";
        public async Task SaveToFile() {
            FileCheckAndDelete(path);
            WriteToFile(Program.Cookie, path);
            
        }

        public async Task LoadFromFile() {
            if (FileCheckAndCreate(path)) {
            
            }

            String FileContent = ReadFileContent(path);
            Program.Cookie = JsonSerializer.Deserialize<CookieCount.Cookie>(FileContent);
        }
        public static Boolean FileCheckAndCreate(String path) {
            if (!File.Exists(path)) {
                CookieCount.Cookie cookie = new CookieCount.Cookie(0, 0, 0, 15, 0, 100, 0, 1100, 0, 12000, 0, 13000, 0, 1400000);
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

        private static void WriteToFile(CookieCount.Cookie cookie, String path) {
            using (StreamWriter sw = File.CreateText(path)) {
                String patientString = JsonSerializer.Serialize<CookieCount.Cookie>(cookie);
                sw.WriteLine(patientString);
                sw.Close();
            }

        }

    }
}
