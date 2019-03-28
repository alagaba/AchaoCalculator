using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CalculChao
{
    public class Calcul
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入需要的四则运算个数：");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string formula = Create_Arith();
                string ans = Compute(formula);
                if (int.Parse(ans) >= 0)
                {
                    Console.WriteLine(formula + "=" + ans);
                }
                else
                {
                    i--;
                }
            }
            Console.ReadKey();

        }
        public static string Create_Arith()
        {
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            string[] op = new string[] { "+", "-", "*", "/" };//存符号的字符串
            int op_count = ran.Next(2, 4);//2-3个运算符
            int[] number = new int[op_count + 1];
            StringBuilder express = new StringBuilder();
            for (int i = 0; i <= op_count; i++)
            {
                number[i] = ran.Next(100) + 1;//避免0
            }
            for (int i = 0; i < op_count; i++)
            {
                int op_choose = ran.Next(4);//随机选取某个运算符
                express.Append(Convert.ToString(number[i]) + Convert.ToString(op[op_choose]));
                if (op_choose == 3)
                {
                    number[i + 1] = Judge(number[i], number[i + 1]);
                }
            }
            express.Append(Convert.ToString(number[op_count]));
            return express.ToString();
        }
        public static int Judge(int x, int y)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            if (x % y != 0)
            {
                y = rand.Next(100) + 1;
                return Judge(x, y);
            }
            else
            {
                return y;
            }
        }

        public static string Compute(string expression)
        {
            DataTable dt = new DataTable();
            string result = dt.Compute(expression, null).ToString();
            return result;
        }
    }
}
