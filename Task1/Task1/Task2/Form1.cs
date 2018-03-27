using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public List<Computer> computers = new List<Computer>();
        private double Sum=0;
        public Form1()
        {
            InitializeComponent();
            computers.AddRange(new Computer[] {
                new Computer("Acer","New Nice Computer","GG",100.5),
                new Computer("Asus","ОЗУ:1000Гб","EZ",1000000.25)
            });
            RefreshItems();
        }

        private void buttonStock_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
            RefreshItems();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void RefreshItems()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(computers.ToArray());
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            listBoxItems.Items.Add(comboBox1.SelectedItem);
            Sum += (comboBox1.SelectedItem as Computer).Price;
            labelSum.Text = "Общая сумма:" + Sum;
        }
    }
}
