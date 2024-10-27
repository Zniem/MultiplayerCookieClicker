using CookieCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Test;
using CookieCount;

namespace CookieClicksEREVERTEST
{
    internal class FileStorage
    {
        String path = Environment.CurrentDirectory + "/DataStorage.txt";
        public void SaveToFile() {
            FileCheckAndDelete(path);
            WriteToFile(Program.Cookie, path);


        }

        public void LoadFromFile() {
            FileCheckAndCreate(path);

            String FileContent = ReadFileContent(path);
            Program.Cookie = JsonSerializer.Deserialize<CookieCount.Cookie>(FileContent);
        }
        public static void FileCheckAndCreate(String file)
        {
            if (!File.Exists(file))
            {
                CookieCount.Cookie cookie = new CookieCount.Cookie(0,0,0,15,0,100,0,1100,0,12000,0,13000,0,1400000);
                WriteToFile(cookie, file);
                File.Create(file);
            }
        }

        public static void FileCheckAndDelete(String FilePath)
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }
        public static string ReadFileContent(String filePath)
        {
            String fileContent = "";
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    fileContent += sr.ReadLine();
                    
                }
                sr.Close();
            }
            return fileContent;
        }

        private static void WriteToFile(CookieCount.Cookie cookie, String path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                String patientString = JsonSerializer.Serialize<CookieCount.Cookie>(cookie);
                sw.WriteLine(patientString);
                sw.Close();
            }
            
        }

    }
}
