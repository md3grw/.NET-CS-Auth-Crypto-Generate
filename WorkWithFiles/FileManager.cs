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
        readonly string path = "";
        readonly string fileName = "DOTU&TP.data";

        public FileManager()
        {
            path = "C:\\Users\\" + Environment.MachineName + "\\AppData\\Local\\.SilevenText";
        }

        public void createFolder()
        {
            try
            {
                if (!Directory.Exists(this.path))
                {
                    Directory.CreateDirectory(this.path);
                    //the folder has been successfully created
                }
                else
                {
                    //the folder is already exist.
                }
            }
            catch (Exception exception)
            {
                //something went wrong.
            }
        }

        public void createFile()
        {
            if (!File.Exists(this.path + fileName)) 
            {
                File.Create(this.path + fileName);
                //the file has been successfully created
            }
            else
            {
                //file has been already created
            }

        }
    }
}
