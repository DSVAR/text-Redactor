using System;
using System.Collections.Generic;
using System.Text;

namespace Logical
{
    public class FindSum
    {
        private string[] Text;
        int Empty;
        int NextSim;

        public string Find(string text)
        {
            for(int o=0; o < text.Length; o++)
            {
                if (text[o].ToString()==" ")
                {
                    NextSim = i++;
                    Empty++;
                }
            }
            
            Text = new[] { text };
            for (int i = 0; i < text.Length; i++)
            {

            }

            return text;
        }
    }
}
