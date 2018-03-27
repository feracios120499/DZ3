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
    public partial class Form2 : Form
    {
        List<Computer> computers = new List<Computer>();
        Form1 form;
        public Form2():this(null)
        {
            
        }
        public Form2(Form1 form)
        {
            InitializeComponent();
            this.computers.AddRange(form?.computers);
            RefreshItems();
            this.form = form;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Computer comp = listBox1.SelectedItem as Computer;
            textBoxName.Text = comp.Name;
            textBoxCharacteristic.Text = comp.Characteristic;
            textBoxDescription.Text = comp.Description;
            textBoxPrice.Text = comp.Price.ToString();
        }
        private bool Contains(Computer computer)
        {
            foreach(var comp in computers)
            {
                if (Computer.Eqauls(comp, computer))
                {
                    return true;
                }
            }
            return false;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(textBoxName.Text))
            {
                if (!string.IsNullOrEmpty(textBoxCharacteristic.Text))
                {
                    if (!string.IsNullOrEmpty(textBoxDescription.Text))
                    {
                        if (!string.IsNullOrEmpty(textBoxPrice.Text))
                        {
                            string Name;
                            string Characteristic;
                            string Description;
                            double Price;
                            try
                            {
                                Price = Convert.ToDouble(textBoxPrice.Text);
                                Name = textBoxName.Text;
                                Characteristic = textBoxCharacteristic.Text;
                                Description = textBoxDescription.Text;
                                Computer comp = new Computer(Name, Characteristic, Description, Price);
                                if (!Contains(comp))
                                {
                                    computers.Add(comp);
                                    RefreshItems();
                                }
                                else
                                {
                                    MessageBox.Show("Такой комп уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch(FormatException ex)
                            {
                                MessageBox.Show("Не правильно введена цена!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxPrice.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Цену", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxPrice.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите Описание", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxDescription.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Введите Характеристику", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxCharacteristic.Focus();
                }
            }
            else
            {
                MessageBox.Show("Введите Название","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBoxName.Focus();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                if (!string.IsNullOrEmpty(textBoxName.Text))
                {
                    if (!string.IsNullOrEmpty(textBoxCharacteristic.Text))
                    {
                        if (!string.IsNullOrEmpty(textBoxDescription.Text))
                        {
                            if (!string.IsNullOrEmpty(textBoxPrice.Text))
                            {
                                string Name;
                                string Characteristic;
                                string Description;
                                double Price;
                                try
                                {
                                    Price = Convert.ToDouble(textBoxPrice.Text);
                                    Name = textBoxName.Text;
                                    Characteristic = textBoxCharacteristic.Text;
                                    Description = textBoxDescription.Text;
                                    Computer comp = new Computer(Name, Characteristic, Description, Price);
                                    if (!Contains(comp))
                                    {
                                        computers[listBox1.SelectedIndex] = comp;
                                        RefreshItems();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Такой комп уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    MessageBox.Show("Не правильно введена цена!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBoxPrice.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введите Цену", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxPrice.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Описание", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxDescription.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите Характеристику", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxCharacteristic.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Введите Название", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxName.Focus();
                }
            }
        }
        private void RefreshItems()
        {
            listBox1.Items.Clear();
            foreach(var item in computers)
            {
                listBox1.Items.Add(item);
            }
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.computers = computers;
        }
    }
}
