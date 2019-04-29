using sales.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesDataAccess salesDataAccess = new SalesDataAccess();
            while (true)
            {
                Console.WriteLine("1. Информация о Продавцов");
                Console.WriteLine("2. Информация о Покупателях");
                Console.WriteLine("3. Информация о Сделках");
                Console.Write("Выберите нужную информацию (1-3): ");
                int selectNumber = int.Parse(Console.ReadLine());



                if (selectNumber == 1)
                {
                    Console.WriteLine("Продавцы");
                    foreach (var seller in salesDataAccess.GetAllSellers())
                    {

                        Console.WriteLine($"Id:{seller.Id} - {seller.Name } { seller.Surname}");
                    }
                }

                else if (selectNumber == 2)
                {
                    Console.WriteLine("Покупатели");
                    foreach (var shopper in salesDataAccess.GetAllShoppers())
                    {

                        Console.WriteLine($"Id:{shopper.Id} - {shopper.Name } { shopper.Surname}");
                    }

                }

                else if (selectNumber == 3)
                {

                    Console.WriteLine("Сделки");
                    foreach (var sales in salesDataAccess.GetAllSales())
                    {

                        Console.WriteLine($"{sales.Id}. \nСумма: {sales.SalesSumm }тг \nДата: { sales.SalesDate} \nID Продавца: {sales.Seller_Id} \nID Покупателя: {sales.Shopper_Id} ");
                    }
                }

                else { Console.WriteLine("Вы ввели неверное чсило"); }
               
            }
            
        }
    }
}
