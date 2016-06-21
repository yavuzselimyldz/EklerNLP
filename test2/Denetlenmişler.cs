using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class Denetlenmişler : MetroForm
    {
        string[] filePaths;
        public Denetlenmişler()
        {
            InitializeComponent();
        }

        private void Denetlenmişler_Load(object sender, EventArgs e)
        {
             filePaths = Directory.GetFiles(@"C:\Users\"+Environment.UserName+@"\Documents\", "*.txt");
            if (filePaths.Length != 0)
            {
                for (int i = 0; i < filePaths.Length; i++) 
                metroComboBox1.Items.Add(Path.GetFileName(filePaths[i]));
            }


        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if(metroComboBox1.SelectedIndex != -1)
            System.Diagnostics.Process.Start(filePaths[metroComboBox1.SelectedIndex]);

        }

     

        private void Denetlenmişler_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
    }
}
