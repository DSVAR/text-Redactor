using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logical
{
    public class Save_File
    {
        StreamWriter SW ;
       public void Save(string Text, string FileName)
        {
            SW = new StreamWriter(FileName);
            SW.WriteLine(Text);
            SW.Close();
            SW.Dispose();
            
            
        }
    }
}
