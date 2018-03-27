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

namespace Task1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.Text = folder.SelectedPath;
                if (!string.IsNullOrWhiteSpace(textBoxFilter.Text))
                {
                    foreach(var item  in Directory.GetFiles(this.Text, textBoxFilter.Text))
                    {
                        listBox1.Items.Add(Path.GetFileName(item));
                    }
                }
                else
                {
                    MessageBox.Show("Please!Write filter!");
                    textBoxFilter.Focus();
                }
            }
        }
    }
}
