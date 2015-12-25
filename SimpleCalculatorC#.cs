using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "2+22*4-100/2+(3*3)";
            char[] charArray = text.ToCharArray();
            List<String> res = new List<String>();
            Console.WriteLine(charArray.Length);
            String buffer = "";
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] >= '0' && charArray[i] <= '9')
                {
                    buffer += "" + charArray[i];
                }
                else {
                    if (buffer.Length > 0)
                    {
                        res.Add(buffer);
                        buffer = "";
                    }
                    res.Add("" + charArray[i]);
                }
            }
            if (buffer.Length > 0)
            {
                res.Add(buffer);
            }
            viewRes(res);
            Console.WriteLine(proccessBracket(res));
            Console.ReadLine();
        }

        public static int proccessBracket(List<String> res)
        {
            while (res.IndexOf("(") >= 0)
            {
                int s = res.IndexOf("(");
                int e = res.IndexOf(")");
                List<String> res2 = res.GetRange(s + 1, e-s);
                res[s]=null;
                res[e] = null;
                clearArray(res2);
                calc(res2);
                clearArray(res);
            }
            return calc(res);
        }

        public static void multiplay(List<String> res)
        {
            while (res.IndexOf("*") >= 0 || res.IndexOf("/") >= 0)
            {
                int i = 0;
                for (i = 0; i < res.Count; i++)
                {
                    if ((res[i]=="*" || res[i]=="/")
                            && i > 0 && i < res.Count - 1)
                    {
                        int x = getCalc(res[i - 1], res[i + 1], res[i]);
                        res[i - 1]=null;
                        res[i]=null;
                        res[i + 1]=x.ToString();
                    }
                }
                clearArray(res);
            }
        }

        public static int calc(List<String> res)
        {
            multiplay(res);
            int i = 0;
            while (i <= res.Count - 3)
            {
                int x = getCalc(res[i], res[i + 2], res[i + 1]);
                res[i]=null;
                res[i + 1]=null;
                res[i + 2]= x.ToString();
                i += 2;
            }
            clearArray(res);
            return Int32.Parse(res[0]);
        }

        public static void clearArray(List<String> res)
        {
            int i = 0;
            while (i < res.Count)
            {
                if (res[i] == null)
                {
                    res.RemoveAt(i);
                }
                else {
                    i++;
                }
            }
        }

        public static int getCalc(String aa, String bb, String operation)
        {

            int a = Int32.Parse(aa);
            int b = Int32.Parse(bb);

            if (operation=="+")
            {
                return a + b;
            }
            else if (operation=="-")
            {
                return a - b;
            }
            else if (operation=="*")
            {
                return a * b;
            }
            else if (operation=="/")
            {
                return a / b;
            }
            return 0;
        }

        public static void viewRes(List<String> res)
        {
            Console.WriteLine(res.Count);
            foreach (String item in res)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
