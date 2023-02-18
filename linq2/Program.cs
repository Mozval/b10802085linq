using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string y = "y";
            do
            {
                Console.WriteLine("1A2B 猜數字");
                int[] numbers = new int[4];
                numbers[0] = new Random().Next(0, 10);//產生亂數初始值
                numbers[1] = new Random().Next(0, 10);
                numbers[2] = new Random().Next(0, 10);
                numbers[3] = new Random().Next(0, 10);
                do
                {
                    numbers[1] = new Random().Next(0, 10);
                } while (numbers[0] == numbers[1]);
                do
                {
                    numbers[2] = new Random().Next(0, 10);
                } while (numbers[1] == numbers[2] || numbers[0] == numbers[2]);
                do
                {
                    numbers[3] = new Random().Next(0, 10);
                } while (numbers[0] == numbers[3] || numbers[3] == numbers[2] || numbers[3] == numbers[1]);

                Console.WriteLine($"答案{numbers[0]}{numbers[1]}{numbers[2]}{numbers[3]}");
                bool d = true;



                do
                {


                    Console.WriteLine("請輸入數字");
                    string enter = Console.ReadLine();
                    int[] ch = new int[4];

                    int a = 0;
                    int b = 0;
                    int c = 0;

                    foreach (char i in enter)
                    {

                        ch[c++] = Convert.ToInt32(i - '0');
                    }
                    List<int> lista = new List<int> { ch[0], ch[1], ch[2], ch[3] };
                    List<int> listb = new List<int> { numbers[0], numbers[1], numbers[2], numbers[3] };
                    var union_list = lista.Where(t1 => listb.Contains(t1)).ToList();
                    b = union_list.Count;
                    for (int i = 0; i < 4; i++)
                    {

                        if (lista[i] == listb[i])
                        {
                            a = a + 1;
                            b = b - 1;


                        }

                    }
                    if (ch[0] == numbers[0])
                    {


                    }
                    if (ch[1] == numbers[1])
                    {

                    }
                    if (ch[2] == numbers[2])
                    {

                    }
                    if (ch[3] == numbers[3])
                    {

                    }
                    if (ch[1] == numbers[0] || ch[1] == numbers[2] || ch[1] == numbers[3])
                    {

                    }
                    if (ch[0] == numbers[1] || ch[0] == numbers[2] || ch[0] == numbers[3])
                    {


                    }
                    if (ch[2] == numbers[1] || ch[2] == numbers[3] || ch[2] == numbers[0])
                    {


                    }
                    if (ch[3] == numbers[1] || ch[3] == numbers[2] || ch[3] == numbers[0])
                    {


                    }
                    Console.WriteLine($"{a}A{b}B 恭喜你答對了");
                    if (a == 4)
                    {
                        d = false;

                        Console.WriteLine("是否繼續玩，是的話打y離開打n");
                        y = Console.ReadLine();
                    }

                } while (d);

            } while (y == "y");









        }
    }
    
}
