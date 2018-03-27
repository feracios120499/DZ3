using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form2 : Form
    {
        Form1 form;
        string TextEditor;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            this.textBoxText.Text = form.TextEditor;
            this.TextEditor = form.TextEditor;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            form.TextEditor = textBoxText.Text;
            TextEditor= textBoxText.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxText.Text = TextEditor;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
