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

        //МЕТоДЫ

            public String BytestoString(long byteCount)
        {
            string[] suf = { "Byt", "Kb", "MB", "GB", "TB", "RB", "EB", };
            // проверка
            if (byteCount == 0)
            {
                return "0+" + suf[0];
            }

            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes,1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);

            return (Math.Sign(byteCount) * num).ToString() + suf[place];
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

            int i = 0;

            // переменная для хранения пути хранения имени иконки

            string DirPath = @"tempFile\\Icon\\";

            // переменная для хранения имени иконки и разширения
            string nameIcon = ofd.SafeFileName;


            // если при открытой форме опен диалог нажата кнопка Ок
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // запись путей имен файлов в переменную
                FailPath = textBox1.Text = ofd.FileName;

                // запись имени и путей файлог в лог
                myUtiliti.ZapisTextFail(FailPath);

                string nameIcon1 = $"{nameIcon}+{i}+.png";

                // путь имя и разширение
                string tempname = DirPath + nameIcon1;

                // ЦИКЛ сохранений
               

                while (true)
                {


                    try
                    {

                   
                    // сохранение иконки
                    using (var icon = Icon.ExtractAssociatedIcon(FailPath))

                    using (var file = File.Create(tempname))
                        icon.Save(file);

                    var files = new FileInfo(FailPath);
                    // long size = files.Length;

                    //имя файла. без пути
                    string namelogg = ofd.SafeFileName;

                    // переменная для хранения размера иконки
                    string size = BytestoString(files.Length).ToString();

                    // запысываем полученные данные в  датагрид(Таблица)

                    // dataGridView1[0,0].Value = new Bitmap(tempname);
                    //  dataGridView1[1,0].Value = namelogg;
                    // dataGridView1[2,0].Value = size;

                    //создаем в гриде новую строку. При каждом  нажатии
                    dataGridView1.Rows.Add(new Bitmap(tempname), namelogg, size);

                        ///вывод для теста
                        // MessageBox.Show(ofd.SafeFileName +" "+BytestoString(files.Length));

                        break;
                    }

                    catch(Exception ex)
                    {
                        i++;
                    }

               }
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
