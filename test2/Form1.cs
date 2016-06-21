using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ek1;
using System.IO;
using net.zemberek.tr.yapi;
using net.zemberek.erisim;
using System.Xml.Linq;
using Microsoft.Office.Interop.Word;
using MetroFramework.Forms;

namespace test2
{
    
    public partial class Ekler_Tr : MetroForm
    {
        MetinDenetleme metindenetleme = new MetinDenetleme();
        Denetlenmişler denetlenmişler = new Denetlenmişler();
        Ekler ek = new Ekler();
        public Ekler_Tr()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

            metindenetleme.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            denetlenmişler.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroTextBox7.Text = ek.Ayrılma_Eki_Getir(metroComboBox3.SelectedItem.ToString()) + " satın alınan araç, " + ek.Bulunma_Eki_Getir(metroTextBox1.Text) + " " + ek.Bulunma_Eki_Getir(metroComboBox2.SelectedItem.ToString()) + " üretildi." + ek.İlgi_Eki_Getir(metroTextBox4.Text) + " arızalı bölgesi " +
               ek.İyelik_Eki_Getir(metroComboBox1.SelectedItem.ToString())+".";
           

            metroTextBox7.Text += "Araç son kontroller yapıldıktan sonra " + ek.Yönelme_Eki_Getir(metroComboBox4.SelectedItem.ToString()) + " gönderildi.";
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroLabel7.Text = ek.Ayrılma_Eki_Getir(metroTextBox2.Text);
            metroLabel8.Text = ek.Belirtme_Eki_Getir(metroTextBox2.Text);
            metroLabel9.Text = ek.Bulunma_Eki_Getir(metroTextBox2.Text);
            metroLabel10.Text = ek.Yönelme_Eki_Getir(metroTextBox2.Text);
            metroLabel11.Text = ek.Çogul_Eki_Getir(metroTextBox2.Text);
            metroLabel12.Text = ek.İlgi_Eki_Getir(metroTextBox2.Text);
            metroLabel13.Text = ek.İyelik_Eki_Getir(metroTextBox2.Text);
        }
    }
}
