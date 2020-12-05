using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace Logical
{
    class Print
    {
        StreamReader streamToPrint; //поток для принтера
        Font printFont;
        
        // Метод печати файла
        // Входные параметры: передаются параметры шрифта
        // Результат: переданный текст выводится на печать,  
        //            и, если нет ошибки, возвращается true
        //            иначе – false.

        public bool PrintResult(Font pF)
        {
            try
            {
                streamToPrint = new StreamReader(filename,
                    System.Text.Encoding.GetEncoding(1251));
                try
                {
                    printFont = pF;
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler
                       (this.pd_PrintPage);
                    pd.Print();
                    return true;
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch
            {
                return false;
            }
        }

        // Событие PrintPage вызывается для каждой страницы, которая будет напечатана
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Чтобы вычислить количество строк на странице
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            // Печатаем каждую строку файла
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                leftMargin, yPos, new StringFormat());
                count++;
            }

            // если строки не закончились, распечатаем еще одну страницу
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

    }
}
