using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info_Fail
{
   public class util
    {
        /// <summary>
        /// Запись строки в файл рядом к экзешником.
        /// </summary>
        /// <param name="Входящий параметр stroka"></param>
        public void ZapisTextFail(string stroka)
        {
            // путь куда сохранять файл.
            string readPath = "log.txt";

            //время дозаписи
            DateTime now = DateTime.Now;


            try
            {
                // Создаем поток для работы с текст файлом. И указываем путь, дозапись в файл(если он создаан) и кодировку
                using (StreamWriter sw = new StreamWriter(readPath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("\t\n Дата: \t\n" + now.ToString());
                    sw.Write(stroka);
                }
            }

            catch (Exception ex)
            {

            }
        }

        public void SozdanieKataloga(string MyPath)
        {

         //   string path = @"tempFile";
            string path = MyPath;

            string subpath = "Icon";

            // обьект для работы с каталогами.
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            // проверка на существование текущего каталога
            if (!dirInfo.Exists)
            {
                try
                {

                    dirInfo.Create();

                    //создание подкатолога
                    dirInfo.CreateSubdirectory(subpath);

                }

                catch (Exception ex)
                {

                }
            }

            
        }

    }

 }
