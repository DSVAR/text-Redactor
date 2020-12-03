using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Logical
{
    public class FindSum
    {
        private string[] Text;
        bool Empty = false;

        string ObTest = null;
        string ALF = @"[йцукенгшщзхъфывапролджэячсмитьбю]";
        string Soglass = @"[цкнгшщхфвпрлджчсмтб]";
        public string Find(string text)
        {
          
            
            for (int i = 0; i < text.Length; i++)
            {

                if (Regex.IsMatch(text[i].ToString(), ALF))
                {
                    ObTest += text[i].ToString();
                    Empty = false;
                }
                else
                {
                    if (!Empty)
                    {
                        Empty = true;
                        ObTest += text[i].ToString();
                    }
                }

            }
            //Text = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //Text = ObTest.Split(new char[] { ' '  });

            for (int o = 0; o < ObTest.Length; o++)
            {
                Text[o] = ObTest[o].ToString();
            }



            Text = new[] { text };
         
            return text;
        }
    }
}
