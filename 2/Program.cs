using System;
using System.Linq;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercicio 2\n");

            double[] input = {0.25, -2.28, 1.11, 0.42, -1.46, 0.19, -0.75, -0.29, 1.71, -0.78, -1.3, -0.11,
                              -0.76, 1.46, 2.44, 1.83, 0.33, 0.6, -0.74, -1.7 };

            int m = 2; //atraso informado pelo exercício

            Console.WriteLine($"Mean Absolute Value: {MeanAbsoluteValue(input)}");
            Console.WriteLine($"AutoCorrAbs: {AutoCorrAbs(input, m)}");
            Console.WriteLine($"stdAbs: {StdAbs(input)}");

            Console.ReadLine();
        }

        static double MeanAbsoluteValue(double[] s) 
        {
            //necessário uso do namespace System.Linq
            double sum = s.Sum(x => Math.Abs(x)); // soma os valores dentro de s aplicando Math.Abs() em cada valor
            double mean = sum / s.Length;
            return (mean);
        }

        static double AutoCorrAbs(double[] s, int m) 
        {
            double sum = 0;

            //equação fornecida pelo exercício
            for(int k = 0; k < s.Length - m; k++)
            {
                sum += Math.Abs(s[k]) * Math.Abs(s[k+m]); 
            }

            return sum;
        }

        static double StdAbs(double[] s)
        {
            double sum = 0;

            //não ficou claro se a média a ser usada seria a absoluta (MAV) ou normal
            //foi utilizado o cálculo normal de uma média
            double average = Math.Abs(s.Sum()/s.Length); //necessário uso do namespace System.Linq

            //equação fornecida pelo exercício
            for(int k = 0; k < s.Length; k++)
            {
                sum += Math.Pow((Math.Abs(s[k]) - Math.Abs(average)), 2);
            }
            double stdAbs = Math.Sqrt(sum/s.Length);

            return stdAbs;
        }

    }
}
