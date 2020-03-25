using System;
using System.Collections.Generic;
using System.Linq;

namespace calculatealgebra
{
    class Program
    {
        static List<int> count_del(int number)
        {
            List<int> result = new List<int>();
            int numb = number;
            for (int i = 1; i <= numb; i++)
                if (numb % i == 0)
                {
                    result.Add(i);
                }
      
            return result;
        }

        static List<string> count_c(int[] p, int[] q) // Выводит без отрицательных
        {
            List<string> result = new List<string>();
            List<double> temp_list = new List<double>();
            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < q.Length; j++)
                {
                    double temp = (double) p[i] / (double) q[j];
                    var indexOfValue = temp_list.IndexOf(temp);
                    if (indexOfValue == -1) {
                        temp_list.Add(temp);
                    if(Convert.ToInt32(temp)==Convert.ToDouble(temp)) 
                    {
	                    result.Add(temp.ToString());
                    }
                    else 
                        result.Add(p[i].ToString() + " / "+ q[j].ToString());   
                    }            
                }
            }
            return result;
        }

        static long count_func(int[] funcc, long x)  {
            int power = funcc.Length-1;
            long result = 0;
            for (int i = 0; i < funcc.Length-1; i++){
                result += funcc[i] * (long) Math.Pow(x, power);
                power--;
            }
            result += funcc[funcc.Length-1];
            return result;
        }

        static int[] str_to_result (string input) // выражение дробь в результат
        {
            int div_pos = 0;
            string first = "";
            string second = "";
            for (int i = 0; i < input.Length; i++) {
                if (Char.IsDigit(input[i])) {
                    first += input[i];
                }
                else if (input[i] == '-') {
                    first += "-";
                }
                else {
                    div_pos = i;
                    break;
                }
            }
            for (int i = div_pos; i < input.Length; i++) {
                if (char.IsDigit(input[i])) { 
                    second += input[i];
                }
                else if (input[i] == '-') {
                    second += "-";
                }
            }
            int[] result = new int[2];
            result[0] = Convert.ToInt32(first);
            result[1] = Convert.ToInt32(second);
            return result; 
        }

        static List<string> count_table1(List<string> c,int[] p, int[] q, int[] funcc) {
            Console.WriteLine();
            for (int i = 0; i < c.Count; i++) {
                Console.Write(c[i]+" | ");
            }
            Console.WriteLine();
            long f1 = count_func(funcc,1);
            long f2 = count_func(funcc,-1);
            Console.Write("(f(1) ) / (p-q) = "+f1.ToString() + "/ (p-q) | ");
            List<bool> tab1_bool_first = new List <bool> ();
            List<bool> tab1_bool_second = new List <bool> ();
            List<string> result = new List<string> ();
            for (int i = 0; i < c.Count; i++) {
                int[] fraction = str_to_result(c[i]);
                long denominator = fraction[0]-fraction[1];
                if (denominator != 0)
                {
                    double f_res = (double)f1 / (double)denominator;
                    if (f_res % 1 == 0)
                    {
                        Console.Write("Ц| ");
                        tab1_bool_first.Add(true);
                    }
                    else
                    {
                        Console.Write("Д| ");
                        tab1_bool_first.Add(false);
                    }
                }
                else
                {
                    Console.Write("-| ");
                    tab1_bool_first.Add(false);
                }
            }
            Console.WriteLine();
            Console.Write("(f(-1) ) / (p+q) = "+f2.ToString() + "/ (p+q) | ");
            for (int i = 0; i< c.Count; i++) {
                int[] fraction = str_to_result(c[i]);
                long denominator = fraction[0]+fraction[1];
                if (denominator != 0) {
                double f_res = (double)f2 / (double)denominator;
                    if (f_res % 1 == 0)
                    {
                        Console.Write("Ц| ");
                        tab1_bool_second.Add(true);
                    }
                    else
                    {
                        Console.Write("Д| ");
                        tab1_bool_second.Add(false);
                    }
                }
                else {
                    Console.Write("-| "); 
                    tab1_bool_second.Add(false);
                }
            }
            for (int k = 0; k < tab1_bool_first.Count; k++)
                {
                if ((tab1_bool_first[k] == tab1_bool_second[k]) && (tab1_bool_first[k] == true) ) {
                    result.Add(c[k]);  
                }
            }
            return result;
        } 

        static List<double> Results(List<double> possible_roots, int[] xs) // Корни
        {
            List<double> result = new List<double>();
            int possible_root_count = possible_roots.Count();
            for (int j = 0; j < possible_root_count; j++)
            {
                double temp = 0;
                int power = xs.Length - 1;
                for (int i = 0; i < xs.Length; i++)
                {
                    if (power > 0)
                    {
                        temp += (double)xs[i] * (double)Math.Pow((double)possible_roots[j], (double) power);
                        power--;
                    }
                    else
                        temp += xs[i];
                }
                if (temp == 0)
                    result.Add(possible_roots[j]);
            }
            return result;
        }

        static void Main()
        {
            Console.WriteLine("Введите количество коэффициентов при x (свободный член не учитывается):");
            int x = Convert.ToInt32(Console.ReadLine()) + 1;
            int[] xs = new int[x]; // Коэффициенты 
            int power = x-1; // Крайняя степень
            
            for (int i = 0; i < xs.Length-1; i++)
            {
                Console.WriteLine("Введите коэффициент при степени: " + power.ToString());
                xs[i] = Convert.ToInt32(Console.ReadLine());
                power--;
            } 
            Console.WriteLine("Введите значение свободного члена");
            xs[xs.Length - 1] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вы ввели:");
            power = x - 1;
            for (int i = 0 ; i < xs.Length; i++)
            {
                if (power > 0)
                    if (xs[i] > -1)
                        Console.Write("+ "+xs[i].ToString() + "x ^ " + power.ToString() + " ");
                    else
                    {
                        Console.Write(xs[i].ToString() + "x ^ " + power.ToString() + " ");
                    }
                else
                    if  (xs[xs.Length - 1] > -1)
                        Console.Write(" + "+xs[xs.Length - 1].ToString());
                    else
                    Console.Write(xs[xs.Length - 1].ToString());
                power--;
            }    

            int[] q = count_del(xs[0]).ToArray(); // Делители коэффициента самой старшей степени x
            int[] p = count_del(Math.Abs(xs[xs.Length - 1])).ToArray(); // Делители свободного члена
            List<string> noDupes = count_c(p, q).Distinct().ToList(); // Удаление дубликатов
            string[] c = noDupes.ToArray();        
            Console.WriteLine();
            for (int j = 0; j < c.Length; j++) 
            {
                Console.WriteLine("C: "+c[j]);
            }
            for (int j =0; j <q.Length; j++)
            {
                Console.WriteLine("q: " +q[j].ToString());
            }
            for (int j = 0; j < p.Length; j++)
            {
                Console.WriteLine("p: " +p[j].ToString());
            }
            List<string> dupes =  new List<string> ();
            for (int i = 0; i < noDupes.Count; i++) {
                dupes.Add(noDupes[i]);
                dupes.Add("-"+noDupes[i]);
            }
            List <string> tabl1 = count_table1(dupes,p,q,xs);
            Console.WriteLine();
            Console.WriteLine("Результат первой таблицы: ");
            Console.WriteLine();
            List<double> possible_roots = new List<double>();
            for (int i = 0; i < tabl1.Count; i++) {
                Console.WriteLine(tabl1[i]);
                int[] frac = str_to_result(tabl1[i]);
                double possible_root = (double) frac[0] / (double) frac[1];
                possible_roots.Add(possible_root);
            }
            List<double> res = Results(possible_roots, xs);
            Console.WriteLine("Корни: ");
            for (int i = 0; i < res.Count(); i++)
                Console.WriteLine(res[i]);
            Console.ReadKey();
        }
    }
}
