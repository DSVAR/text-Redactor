using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Logical
{
    public class Open_text
    {
        private StreamReader SR ;
        public string Open(string filename)
        {
            string Text;
            SR = new StreamReader(filename);
            Text= SR.ReadToEnd();
            return Text;
        }
    }
}
