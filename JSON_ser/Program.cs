using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace JSON_ser
{
    class Program
    {
        static void Main(string[] args)
        {
            const int c = 5;
            Product[] arrayProduct = new Product[c];
            for (int i = 0; i < c; i++)
            {
                Product product = new Product();
                Console.Write($"Код товара {i + 1}: ");
                product.ProductArt = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Название товара {i + 1}: ");
                product.ProductName = Console.ReadLine();
                Console.Write($"Цена товара {i + 1}: ");
                product.ProductPrice = Convert.ToDouble(Console.ReadLine());
                arrayProduct[i] = product;
                Console.WriteLine();
            }
            string pathFolder = "C:/Output";
            string pathFile = "C:/Output/Products.json";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
            }
            if (!File.Exists(pathFile))
            {
                File.Create(pathFile);
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            using (StreamWriter sw = new StreamWriter(pathFile, false))
            {
                string json = JsonSerializer.Serialize<Product[]>(arrayProduct, options);
                sw.WriteLine(json);
            }
            Console.ReadKey();
        }
    }
}
