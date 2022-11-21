using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex>-1)
            {
                string seciliDizin = listBox1.SelectedItem.ToString();

                DirectoryInfo dizin = new DirectoryInfo(seciliDizin);
                var dosyalar = dizin.GetFiles();

                listBox2.DataSource = dosyalar;
                listBox2.DisplayMember = "Name";
                listBox2.ValueMember = "FullName";
                
            }
           
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>-1)
            {
                string seciliSurucu = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                var dizinler = Directory.GetDirectories(seciliSurucu);
                listBox1.Items.Clear();
                foreach (var item in dizinler)
                {
                    listBox1.Items.Add(item);
                }
                

                    }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            List<DriveInfo> suruculer = DriveInfo.GetDrives()
                .Where(s=>s.IsReady==true).ToList();

            //foreach (var item in suruculer)
            //{
            //    comboBox1.Items.Add(item.Name);
            //}

            comboBox1.DataSource = suruculer;
            comboBox1.ValueMember = "Name";
            comboBox1.DisplayMember = "Name";

           //data binding
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = (listBox2.SelectedItem as FileInfo)
                .CreationTime.Date.ToString();

            //File.Delete((listBox2.SelectedItem as FileInfo).FullName);

        }
    }
}
