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
        List<string> EndWords = new List<string>();
        List<int> Points = new List<int>();
        string ObTest,MtoB = null;
        string ALF = @"[йцукенгшщзхъфывапролджэячсмитьбю]";
        string Soglass = @"[цкнгшщхфвпрлджчсмтб]";

        int Check ;
        public string Find(string text)
        {
            MtoB = null;
            Empty = false;
            Check = 0;
            EndWords.Clear();
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

            Text = new string[ObTest.Length];
            Empty = false;

            for (int o = 0; o < ObTest.Length; o++)
            {
                
                Text[o] = ObTest[o].ToString();
            }
            //
            if(Text[Text.Length-1]==" " || Text[Text.Length-1] ==null)
            {
                Text[Text.Length-1].Replace(Text[Text.Length-1], ".");
            }

            for (int g = 0; g < Text.Length; g++)
            {
                if (Text[g] == " ")
                {
                    Empty = true;
                    Check = g;
                }

                if (Check > 0)
                {
                    for(int m = Check-3; m < Check; m++)
                    {
                        MtoB += text[m];
                    }
                    MtoB += " ";

                    if(Check<=Text.Length-3)
                        for (int m = Check ; m < Check+3; m++)
                        {
                            MtoB += text[m];
                        }

                    else
                        for (int m = Check; m < Text.Length; m++)
                        {
                            MtoB += text[m];
                        }
                }
            }

            Text = new[] { text };
         
            return text;
        }
    }
}
