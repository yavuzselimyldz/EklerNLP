using MetroFramework.Forms;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ek1;
using Novacode;
using System.Diagnostics;
namespace test2
{
    public partial class MetinDenetleme : MetroForm
    {
        private static object DosyaYolu;
        private static string DosyaAdi = string.Empty;
       

        public MetinDenetleme()
        {
            InitializeComponent();
        }

        private void MetinDenetleme_Load(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            file.RestoreDirectory = true;
            file.Title = "Word veya Text Dosyası Seçiniz..";
            file.Filter = "Word Documents|*.docx|Text|*.txt";


            if (file.ShowDialog() == DialogResult.OK)
            {
                 DosyaYolu = file.FileName;
                 DosyaAdi = file.SafeFileName;

                metroLabel3.Text = "Denetleniyor... " + "/" + DosyaAdi;
                metroTextBox1.Text = DosyaYolu.ToString();

                metroProgressSpinner1.Visible = true;
                metroLabel3.Visible = true;
                backgroundWorker1.RunWorkerAsync();
               
            }

            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            

            ArrayList düzeltilmisler = new ArrayList();
            string[] array = new string[] { };
            StreamWriter docx = File.CreateText(@"C:\Users\" + Environment.UserName + @"\Documents\" + DosyaAdi + ".txt");
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Document doc = new Document();


            // Define an object to pass to the API for missing parameters
            object missing = System.Type.Missing;
            doc = word.Documents.Open(ref DosyaYolu,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            String read = string.Empty;
            List<string> data = new List<string>();
            foreach (Range tmpRange in doc.StoryRanges)
            {
                //read += tmpRange.Text + "<br>";
                read += tmpRange.Text;
              
            }
    ((_Document)doc).Close();
            ((_Application)word).Quit();

            array = read.Split(new Char[] { ',',' ', '_','-','.','"',';',':', '“', '”','!','(',')','[',']','{','}' });


            for (int i = 0; i < array.Length; i++)
            {
                düzeltilmisler.Add(Denetim.Düzelt(array[i].Trim()));
                backgroundWorker1.ReportProgress((i + 1) * 100 / array.Length);
            }



           

            for (int i = 0; i < düzeltilmisler.Count; i++)
            {
                try
                {
                    if((string)düzeltilmisler[i] != array[i].ToLower().Trim())
                    {
                        docx.WriteLine(array[i].ToLower() + "    ->  " + düzeltilmisler[i]);
                    }
                   
                   

                }
                catch (Exception e2)
                {

                }

                
            }

            docx.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
            metroProgressSpinner1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            metroProgressSpinner1.Visible = false;
            metroLabel3.Visible = false;


            DialogResult rslt =  MessageBox.Show(" Denetlendi ve Başarılı Bir Şekilde Kaydedildi.Başka Bir Denetleme Yapmak İstiyor musunuz?",DosyaAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (rslt == DialogResult.Yes)
                metroTextBox1.Text = "Dosya Yolu ->";

            else if(rslt == DialogResult.No)
            {
                metroTextBox1.Text = "Dosya Yolu ->";
                this.Close();

            }

            
             
        }

    

        private void MetinDenetleme_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

   
    }
    }

