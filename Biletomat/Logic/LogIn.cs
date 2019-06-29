using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletomat.Logic
{
    public static class Login
    {
        public static bool ValidateUser(string login, string password)
        {
            if (login.Length == 0 || password.Length == 0)
                return false;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/";

            var files = Directory.GetFiles(path, "*.profile")
                .Select(Path.GetFileNameWithoutExtension);

            foreach (var file in files)
            {
                try
                {
                    using (var sr = new StreamReader(path + file + ".profile"))
                    {
                        var text = sr.ReadToEnd();
                        if (text.Contains("Nazwa: " + login) && text.Contains("Hasło: " + password))
                            return true;
                    }
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            return false;

        }
    }
}
