using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Logical
{
    public class FindSum
    {
        private string[] Text;
        int Empty;
        int NextSim;
        string ALF = @"[йцукенгшщзхъфывапролджэячсмитьбю]";
        string Soglass = @"[цкнгшщхфвпрлджчсмтб]";
        public string Find(string text)
        {
            Text = new string[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                Text[i] = text[i].ToString();
            }


            for (int o=0; o < Text.Length; o++)
            {
                if (text[o].ToString()==" ")
                {
                    NextSim = o+1;
                    if (o != Text.Length) { 

                        if (!Regex.IsMatch(Text[NextSim], ALF))
                        {
                            text[o].ToString().Replace(" ", "");
                        }
                        else
                        {
                            Empty++;
                        }
                    }
                    else
                    { 
                        if (!Regex.IsMatch(Text[o], ALF))
                        {
                        text[o].ToString().Replace(" ", "");
                        }
                        else
                        {
                            Empty++;
                        }
                    }
                }
            }
            
            Text = new[] { text };
         
            return text;
        }
    }
}
