using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Info_Fail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // кнопка открыть файл
        private void button1_Click(object sender, EventArgs e)
        {
            //переменная опернфайл диалог
            OpenFileDialog ofd = new OpenFileDialog();

            // если при открытой форме опен диалог нажата кнопка Ок
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                // в переменную текст бокса записываем путь к файлу
                textBox1.Text = ofd.FileName;

            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
