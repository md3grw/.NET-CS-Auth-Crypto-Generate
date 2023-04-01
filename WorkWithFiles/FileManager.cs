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
            {
                File.Create(path);
                //the file has been successfully created
            }
            else
            {
                //file has been already created
            }

        }

    }
}
