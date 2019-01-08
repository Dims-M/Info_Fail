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

namespace Info_Fail
{
    public partial class Form1 : Form
    {
        util myUtiliti = new util();

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
            // создание ктолога
            myUtiliti.SozdanieKataloga("TempFile");

            //переменная опернфайл диалог
            OpenFileDialog ofd = new OpenFileDialog();

            // переменная для хранения пути
            string FailPath = null;

            // переменная для хранения имени иконки
            string DirPath = @"tempFile\\Icon\\";
            
            // если при открытой форме опен диалог нажата кнопка Ок
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                // в переменную текст бокса записываем путь к файлу
                // запись путей имен файлов в лог
                FailPath = textBox1.Text = ofd.FileName;

                string nameIcon = ofd.SafeFileName;

                myUtiliti.ZapisTextFail(FailPath);

                

                // сохранение иконки
                using (var icon = Icon.ExtractAssociatedIcon(FailPath));

               // DirPath+ nameIcon
             //  string d = DirPath + nameIcon;
                // сохранение файла
                using (var file = File.Create(DirPath + nameIcon))
                    Icon.Save(file);
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
