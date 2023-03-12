using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.ProgramBody
{
    internal class DataProcessor
    {
        public static void begin()
        {
            SilevenText.WorkWithFiles.FileManager fileManager = new WorkWithFiles.FileManager();
            
            fileManager.createFolder();
            fileManager.createFile();

            
        }

        public static void end() 
        {

        }
    }
}
