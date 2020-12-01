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
        private Main main = new Main();
        public Form1()
        {
            InitializeComponent();
            FD.Filter = "Текстовый файл | *.tx";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FD = new OpenFileDialog();
            if(FD.ShowDialog()== DialogResult.Cancel)
            {
                FD.Dispose();
                return;
            }
            if (FD.FileName != null)
            {
                main.OpenText.
            }

        }
    }
}
