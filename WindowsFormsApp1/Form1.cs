using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = @"C:\Users\bchehab\Desktop\AssemblyHasher\ClassLibrary1\bin\Debug";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileToHash = textBox1.Text;

            var hash = new FileHasher.HashCalculator(fileToHash).CalculateFileHash();

            richTextBox1.Text = hash;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
