using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_FS
{
    class Program
    {
        static void Main(string[] args)
        {
            task8();   
        }
        static void task1()
        {
            //1.В папке С:\temp создайте папки К1 и К2.
            if (Directory.Exists(@"C:\temp"))
            {
                Directory.CreateDirectory(@"C:\temp\K1");
                Directory.CreateDirectory(@"C:\temp\K2");
            }
            else
            {
                Directory.CreateDirectory(@"C:\temp");
                Directory.CreateDirectory(@"C:\temp\K1");
                Directory.CreateDirectory(@"C:\temp\K2");
            }
        }
        static void task2()
        {
            //2.В папке К1:
            //  1.создайте файл t1.txt, в который запишите следующий текст:
            //  Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов
            //  2.создайте файл t2.txt, в который запишите следующий текст:
            //  Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс
            using (StreamWriter sw = new StreamWriter(@"C:\temp\K1\t1.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine("Иванов Иван Иванович, 1965 года рождения, место жительства г.Саратов");
            }
            using (StreamWriter sw = new StreamWriter(@"C:\temp\K1\t2.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
            }
        }
        static void task3()
        {
            //3. В папке К2 создайте файл t3.txt, в который перепишите вначале 
            //текст из файла t1.txt, а затем из t2.txt
            string text = "";
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\temp\K1\t1.txt", System.Text.Encoding.Default))
                {
                    text = sr.ReadToEnd();
                }
                using (StreamReader sr = new StreamReader(@"C:\temp\K1\t2.txt", System.Text.Encoding.Default))
                {
                    text += sr.ReadToEnd();
                }
                using (StreamWriter sw = new StreamWriter(@"C:\temp\K2\t3.txt", false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void task4()
        {
            //4. Выведите развернутую информацию о созданных файлах.
            try
            {
                FileInfo fileInf = new FileInfo(@"C:\temp\K2\t3.txt");
                if (fileInf.Exists)
                {
                    Console.WriteLine("Имя файла: {0}", fileInf.Name);
                    Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                    Console.WriteLine("Размер: {0}", fileInf.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void task5()
        {
            //5. Файл t2.txt перенесите в папку K2.
            try
            {
                File.Move(@"C:\temp\K1\t2.txt", @"C:\temp\K2\t2.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void task6()
        {
            //6. Файл t1.txt скопируйте в папку K2.
            try
            {
                File.Copy(@"C:\temp\K1\t1.txt", @"C:\temp\K2\t1.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void task7()
        {
            //7. Папку K2 переименуйте в ALL, а папку K1 удалите.
            try
            {
                if (Directory.Exists(@"C:\temp\K2"))
                {
                    Directory.Move(@"C:\temp\K2", @"C:\temp\ALL");                    
                }
                if (Directory.Exists(@"C:\temp\K1"))
                {
                    Directory.Delete(@"C:\temp\K1", true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void task8()
        {
            //8. Вывести полную информацию о файлах папки All.
            try
            {
                if (Directory.Exists(@"C:\temp\ALL"))
                {
                    foreach (var item in Directory.GetFiles(@"C:\temp\ALL"))
                    {
                        Console.WriteLine(item);
                    }                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
