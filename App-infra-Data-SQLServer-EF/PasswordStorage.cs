using Newtonsoft.Json;
using quiz.Entities;
using System.Text;

namespace quiz.reposetories
{
    public static class PasswordStorage
    {
        static string dir = @"C:\Users\user\source\repos\quiz\quiz\reposetories\DataBase.txt";

        public static void InsertCode(TempCode temp)
        {
            
            
            string text = JsonConvert.SerializeObject(temp);
            File.WriteAllText(dir, text, Encoding.UTF8);

        }
        
    }
}
