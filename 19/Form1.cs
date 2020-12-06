using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logical;
using blet;

namespace _19
{
    public partial class Form1 : Form
    {
        private OpenFileDialog FD;
        private SaveFileDialog SFD;
        private Main main = new Main();
        Class1 Class = new Class1();

        string Answer;

        string style;
        float sizes;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            FD = new OpenFileDialog();
            FD.Filter = "Текстовый файл | *.txt";
            if (FD.ShowDialog() == DialogResult.Cancel)
            {
                FD.Dispose();
                return;
            }
            if (FD.FileName != null)
            {
                richTextBox1.Text = main.OpenText.Open(FD.FileName);
                FD.Dispose();
            }

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text != null || richTextBox1.Text != "")
            {
                SFD = new SaveFileDialog();
                SFD.Filter = "Текстовый файл (*.txt*)| *.txt";
                //SFD.Filter += "All (*.*)| *.*";
                if (SFD.ShowDialog() == DialogResult.Cancel)
                {
                    SFD.Dispose();
                    return;
                }
                if (SFD.FileName != null)
                {

                    Answer = main.FS.Find(richTextBox1.Text);
                    main.SF.Save(Answer, SFD.FileName);

                }

            }
            else
            {
                MessageBox.Show("Нету текста, нет вычислений!");
            }
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {

            FD = new OpenFileDialog();
            FD.Filter = "Текстовый файл | *.txt";
            if (FD.ShowDialog() == DialogResult.Cancel)
            {
                FD.Dispose();
                return;
            }
            if (FD.FileName != null)
            {
                Font font = new Font(style, sizes, FontStyle.Bold);
                //main.Print.PrintResult(FD.FileName);
                Class.PrintResult(font, FD.FileName);

                FD.Dispose();
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FD = new OpenFileDialog();
            FD.Filter = "Текстовый файл | *.txt";
            if (FD.ShowDialog() == DialogResult.Cancel)
            {
                FD.Dispose();
                return;
            }
            if (FD.FileName != null)
            {
                richTextBox1.Text = main.OpenText.Open(FD.FileName);
                FD.Dispose();
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                SFD = new SaveFileDialog();
                SFD.Filter = "Все файлы|*.*|  Текстовый файл без вычеслений (*.txt*)| *.txt";
                //SFD.Filter += "All (*.*)| *.*";
                if (SFD.ShowDialog() == DialogResult.Cancel)
                {
                    SFD.Dispose();
                    return;
                }
                if (SFD.FileName != null)
                {

                    Answer =richTextBox1.Text;
                    main.SF.Save(Answer, SFD.FileName);

                }

        }

        private void размерToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndex = 0;
            toolStripComboBox2.SelectedIndex = 0;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sizes = float.Parse(toolStripComboBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            style = toolStripComboBox2.Text;
        }

        private void поискСловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(toolStripTextBox1.Text) && !string.IsNullOrEmpty(richTextBox1.Text))
                Find(toolStripTextBox1.Text);
            //richTextBox1.SelectionColor = Color.Black;
            else
            {
                MessageBox.Show("Поле пустует, миллорд");
            }
        }


        void Find(string word)
        {
           
            int i = 0;
            if(!string.IsNullOrEmpty(word) && !string.IsNullOrEmpty(richTextBox1.Text))
            while (i <= richTextBox1.Text.Length - word.Length)
            {
                //выделение цветом
                i = richTextBox1.Text.IndexOf(word, i);
                if (i < 0) break;
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = word.Length;
                richTextBox1.SelectionColor = Color.Red;
                
                i += word.Length;
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
