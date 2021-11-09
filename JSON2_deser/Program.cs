using JSON_ser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JSON2_deser
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFile = "C:/Output/Products.json";
            Product[] restoredProducts;
            using (StreamReader sr = new StreamReader(pathFile))
            {
                restoredProducts = JsonSerializer.Deserialize<Product[]>(sr.ReadToEnd());
            }
            int maxIndex = 0;
            for (int i = 0; i < 5; i++)
            {
                if (restoredProducts[maxIndex].ProductPrice < restoredProducts[i].ProductPrice)
                {
                    maxIndex = i;
                }
            }
            Console.WriteLine($"Самый дорогой товар из списка: {restoredProducts[maxIndex].ProductName}, стоимостью {restoredProducts[maxIndex].ProductPrice}");
            Console.Write("Удалить папку и файл этого проекта? Y/N: ");
            string c = Console.ReadLine();
            if (c == "Y")
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo("C:/Output");
                    dirInfo.Delete(true);
                    Console.WriteLine("Каталог с файлом удалены");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }
        }
    }
}
