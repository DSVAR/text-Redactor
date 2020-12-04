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

            Points.Clear();
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
              if(ObTest[o].ToString()==" "||ObTest[o].ToString()== null)
                {
                    Points.Add(o);
                }  
                Text[o] = ObTest[o].ToString();
            }
            //
            if(Text[Text.Length-1]==" " || Text[Text.Length-1] ==null)
            {
                Text[Text.Length-1].Replace(Text[Text.Length-1], ".");
            }

            for (int g = 0; g < Points.Count; g++)
            {
             
             
                    for(int m = Points[g]-3; m < Points[g]; m++)
                    {
                        MtoB += text[m];
                    }
                //    MtoB += " ";

                    if(Points[g] <= Points[Points.Count-1] - 3)
                        for (int m = Points[g]; m < Points[g]+ 2; m++)
                        {
                            MtoB += text[m];
                        }

                    else
                        for (int m = Points[g]; m < Points.Count; m++)
                        {
                            MtoB += text[m];
                        }
             
            }

            Text = new[] { text };
         
            return text;
        }
    }
}
