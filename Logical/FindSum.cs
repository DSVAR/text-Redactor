using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Logical
{
    public class FindSum
    {
        private string[] Text;
        bool Empty = false;
        List<string> EndWord = new List<string>();
        List<int> Points = new List<int>();

        int Lenght;
        string ObTest, MtoB = null;
        string ALF = @"[йцукенгшщзхъфывапролджэячсмитьбю]";
        string Soglass = @"[цкнгшщхфвпрлджчсмтб]";


        public string Find(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                MtoB = "";
                Empty = false;
                ObTest = null;

                Points.Clear();
                EndWord.Clear();

                if (text[text.Length - 1].ToString() != " ")
                {
                    text += " ";
                }

                for (int i = 0; i < text.Length; i++)
                {

                    if (Regex.IsMatch(text[i].ToString(), ALF))
                    {
                        ObTest += text[i].ToString();
                        Empty = false;
                    }
                    else
                    {
                        if (text[i].ToString() == " ")
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
                    if (ObTest[o].ToString() == " " || ObTest[o].ToString() == null)
                    {
                        Points.Add(o);
                    }
                    Text[o] = ObTest[o].ToString();
                }

                Lenght = Points.Count - 1;

                for (int g = 0; g < Points.Count; g++)
                {
                    if (g % 2 == 0)
                    {

                        for (int m = Points[g] - 3; m < Points[g]; m++)
                        {
                            MtoB += Text[m];
                        }
                        //      MtoB += " ";

                        if (Points[g] <= Points[Lenght] - 3)
                            for (int m = Points[g] + 1; m < Points[g] + 4; m++)
                            {

                                MtoB += Text[m].ToString();

                            }

                        else
                            for (int m = Points[g]; m < Points.Count; m++)
                            {
                                MtoB += Text[m];
                            }
                        MtoB += " ";
                    }
                }

                Empty = false;
                Points.Clear();
                for (int l = 0; l < MtoB.Length; l++)
                {
                    if (MtoB[l].ToString() == " ")
                    {
                        Points.Add(l);
                        Empty = true;
                    }

                }




                Lenght = 0;
                for (int q = 0; q < Points.Count; q++)
                {
                    ObTest = null;
                    if (q == 0)
                    {
                        for (int t = 0; t < Points[q]; t++)
                        {
                            if (Regex.IsMatch(MtoB[t].ToString(), Soglass))
                            {
                                ObTest += MtoB[t].ToString();
                            }
                        }
                    }
                    else
                    {
                        for (int t = Points[q - 1]; t < Points[q]; t++)
                        {
                            if (Regex.IsMatch(MtoB[t].ToString(), Soglass))
                            {
                                ObTest += MtoB[t].ToString();
                            }
                        }
                    }

                    if (ObTest.Length > 4)
                        EndWord.Add(ObTest);

                }
                ObTest = null;
                for (int end = 0; end < EndWord.Count; end++)
                {
                    ObTest += $"{end + 1}.{EndWord[end]} \r\n";
                }


                return ObTest;
            }
            else
            {
                return "PUSTO";
            }
        }
    }
}
