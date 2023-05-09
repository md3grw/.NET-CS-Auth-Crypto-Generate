using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.WorkWithFiles
{
    internal class FileManager
    {
        public void CreateFile(string path)
        {
            if (!File.Exists(path)) 
                File.Create(path);
        }

        public void WriteToFile(string path, string text)
        {
            //it creates file for IsPathRooted
            try { using (FileStream stream = new FileStream(path, FileMode.Open)) { } }
            catch {}

            if (!Path.IsPathRooted(path)) { File.WriteAllText(path, text); }
            else { File.WriteAllText("RESULT.txt", text); }
        }

    }
}
