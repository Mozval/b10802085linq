using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    internal class Program
    {
        static void Main(string[] args)
        {   


            var readText = File.ReadAllLines("product.csv").Skip(1).ToList();
           
            List<product> list = new List<product> { };
            foreach (var line in readText)
            {
                list.AddRange(CreateList(line));
            }
            string enter1;
            do
            {
               
                Console.WriteLine("觀看1到16題答案輸入:answer");
                Console.WriteLine("進入選單功能請輸入:17");
                enter1= Console.ReadLine();
                switch (enter1)
                {
                    case "n":
                        break;
                    case "answer":
                        //1
                        Console.WriteLine("第1題");
                        var price = list.Select(x => x.price).ToList();
                        var quantity=list.Select(x => x.quantity).ToList();
                     

                        decimal total=0;
                        for(int i = 0; i < price.Count; i++)
                        {
                            total = price[i] * quantity[i]+total;
                           
                        }
                        Console.WriteLine($"商品價格總和:{total}");
                        Console.WriteLine();
                        //2
                        Console.WriteLine("第2題");

                       
                        Console.WriteLine($"商品平均價格為:{total/quantity.Sum()}");
                        Console.WriteLine();
                        //3
                        Console.WriteLine("第3題");
                        var quantitytotal = list.Sum((x) => x.quantity);
                        Console.WriteLine($"商品數量總和: {quantitytotal}");
                        Console.WriteLine();
                        //4
                        Console.WriteLine("第4題");
                        var quantityavg = list.Average((x) => x.quantity);
                        Console.WriteLine($"商品數量平均: {quantityavg}");
                        Console.WriteLine();
                        //5
                        Console.WriteLine("第5題");
                        var maxpricename = list.OrderByDescending(x => x.price).First();
                        Console.WriteLine($"最貴的商品: {maxpricename.name}");
                        Console.WriteLine();
                        //6
                        Console.WriteLine("第6題");
                        var minpricename = list.OrderBy(x => x.price).First();
                        Console.WriteLine($"最便宜的商品: {minpricename.name}");
                        Console.WriteLine();
                        //7
                        Console.WriteLine("第7題");
                        var totalprice3c = list.Where(x => x.categories == "3C").Select(x=>x.price).ToList();
                        var totalprice3c1 = list.Where(x => x.categories == "3C").Select(x => x.quantity).ToList();
                        decimal total2 = 0;
                        for(int i = 0;i < totalprice3c.Count; i++)
                        {
                            total2 = totalprice3c[i]* totalprice3c1[i]+total2;
                        }

                        Console.WriteLine($"3c產品總價:{total2}");
                        Console.WriteLine();
                        //8
                        Console.WriteLine("第8題");
                        var totalpricedrink = list.Where(x => x.categories == "飲料").Select(x => x.price).ToList();
                        var totalpricedrink1 = list.Where(x => x.categories == "飲料").Select(x => x.quantity).ToList();
                        decimal total3=0;
                        for(int i = 0; i < totalpricedrink.Count; i++)
                        {
                            total3= totalpricedrink[i]* totalpricedrink1[i]+total3;
                        }
                        Console.WriteLine($"飲料產品總價:{total3}");

                        var totalpricefood = list.Where(x => x.categories == "食品").Select(x => x.price).ToList();
                        var totalpricefood1 = list.Where(x => x.categories == "食品").Select(x => x.quantity).ToList();
                        decimal total4 = 0;
                        for(int i = 0; i < totalpricefood.Count; i++)
                        {
                            total4 = totalpricefood[i] * totalpricefood1[i] + total4;
                        }
                        Console.WriteLine($"食品產品總價:{total4}");
                        Console.WriteLine();

                        //9
                        Console.WriteLine("第9題");
                        var foodquantity = list.Where(x => x.categories == "食品" && x.quantity > 100);
                        foreach (product fdq in foodquantity)
                        {
                            Console.WriteLine($"食品中商品數量大於100:{fdq.name}");
                        }
                        Console.WriteLine();
                        //10
                        Console.WriteLine("第10題");
                        var pricebigthan1000 = list.Where(x => x.price > 1000);
                        foreach (product fdq in pricebigthan1000)
                        {
                            Console.WriteLine($"{fdq.categories}類別 {fdq.name}商品價格大於1000");
                        }
                        Console.WriteLine();
                        //11
                        Console.WriteLine("第11題");
                        var pricebigthan1000avg = list.Where(x => x.price > 1000).Average(x => x.price);
                        foreach (product fdq in pricebigthan1000)
                        {
                            Console.WriteLine($"{fdq.categories}類別平均價格為{pricebigthan1000avg}");
                        }

                        Console.WriteLine();
                        //12
                        Console.WriteLine("第12題");
                        var pricehightolow = list.OrderByDescending(x => x.price);
                        Console.WriteLine("價格高到低");
                        foreach (product fdq in pricehightolow)
                        {
                            Console.WriteLine($"{fdq.name} {fdq.price}");
                        }
                        Console.WriteLine();
                        //13
                        Console.WriteLine("第13題");
                        var pricelowtohigh = list.OrderBy(x => x.price);
                        Console.WriteLine("價格低到高");
                        foreach (product fdq in pricelowtohigh)
                        {
                            Console.WriteLine($"{fdq.name} {fdq.price}");
                        }
                        Console.WriteLine();
                        //14
                        Console.WriteLine("第14題");
                        var categoriesmax = list.OrderByDescending(x => x.price).GroupBy(x => x.categories);
                        Console.WriteLine("各類別最貴商品:");
                        foreach (var fdq in categoriesmax)
                        {
                            Console.WriteLine($"{fdq.First().categories} {fdq.First().name} {fdq.First().price}");


                        }
                        Console.WriteLine();
                        //15
                        Console.WriteLine("第15題");
                        var categoriesmin = list.OrderBy(x => x.price).GroupBy(x => x.categories);
                        Console.WriteLine("各類別最便宜商品:");
                        foreach (var fdq in categoriesmin)
                        {
                            Console.WriteLine($"{fdq.First().categories} {fdq.First().name} {fdq.First().price}");


                        }
                        Console.WriteLine();
                        //16
                        Console.WriteLine("第16題");
                        var pricesmallthan10000 = list.Where(x => x.price <= 10000);
                        foreach (product fdq in pricesmallthan10000)
                        {
                            Console.WriteLine($"{fdq.categories}類別 {fdq.name} {fdq.price}$ 商品價格小於等於10000");
                        }

                        Console.WriteLine("輸入0回到上頁");
                        Console.ReadLine();
                        break;


                    case "17":
                        Console.WriteLine("你已進入選單頁面請輸入1~5頁面號碼");
                        string enter2;
                        do
                        {

                            enter2 = Console.ReadLine();


                            switch (enter2)
                            {
                                case "1":
                                    var page1 = list.OrderBy(x => x.number).Take(4);
                                    foreach (var line in page1)
                                    {
                                        Console.WriteLine($"{line.number} {line.name} {line.quantity} {line.price} {line.categories} ");
                                    }
                                    break;
                                case "2":
                                    var page2 = list.OrderBy(x => x.number).Skip(4).Take(4);
                                    foreach (var line in page2)
                                    {
                                        Console.WriteLine($"{line.number} {line.name} {line.quantity} {line.price} {line.categories} ");
                                    }
                                    break;
                                case "3":
                                    var page3 = list.OrderBy(x => x.number).Skip(8).Take(4);
                                    foreach (var line in page3)
                                    {
                                        Console.WriteLine($"{line.number} {line.name} {line.quantity} {line.price} {line.categories} ");
                                    }
                                    break;
                                case "4":
                                    var page4 = list.OrderBy(x => x.number).Skip(12).Take(4);
                                    foreach (var line in page4)
                                    {
                                        Console.WriteLine($"{line.number} {line.name} {line.quantity} {line.price} {line.categories} ");
                                    }
                                    break;
                                case "5":
                                    var page5 = list.OrderBy(x => x.number).Skip(16).Take(4);
                                    foreach (var line in page5)
                                    {
                                        Console.WriteLine($"{line.number} {line.name} {line.quantity} {line.price} {line.categories} ");
                                    }
                                    break;

                            }
                            Console.WriteLine("輸入1到5的頁碼或輸入0回到上頁");
                           
                        } while (enter2 != "0");



                        break;

                }
              
            } while (enter1 != "n");
           




          






        }

        static List<product> CreateList(string read)
        {
            string[] save = read.Split(',');
            return new List<product>()
            {

                  new product{ number = save[0],name=save[1],quantity=int.Parse(save[2]),price=Convert.ToDecimal(save[3]),categories=save[4] }
            };
        }
    }
}