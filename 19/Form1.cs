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

namespace _19
{
    public partial class Form1 : Form
    {
        private OpenFileDialog FD;
        private SaveFileDialog SFD;
        private Main main = new Main();

        string Answer;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FD = new OpenFileDialog();
            FD.Filter = "Текстовый файл | *.txt";
            if (FD.ShowDialog()== DialogResult.Cancel)
            {
                FD.Dispose();
                return;
            }
            if (FD.FileName != null)
            {
               richTextBox1.Text= main.OpenText.Open(FD.FileName);
                textBox1.Text = main.OpenText.Open(FD.FileName);
                FD.Dispose();
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text!=null || richTextBox1.Text!="") 
            {
                SFD = new SaveFileDialog();
                SFD.Filter = "Текстовый файл (*.txt*)| *.txt";
                //SFD.Filter += "All (*.*)| *.*";
                if (SFD.ShowDialog() == DialogResult.Cancel)
                {
                    SFD.Dispose();
                    return;
                }
                if (SFD.FileName != null) { 

                Answer =main.FS.Find(richTextBox1.Text);
                    main.SF.Save(Answer, SFD.FileName);

                }

            }
            else
            {
                MessageBox.Show("Нету текста, нет вычислений!");
            }
        }
    }
}
