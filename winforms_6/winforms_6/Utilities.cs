using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winforms_6
{
    public static class Utilities
    {
        public static double DistanciaEuclidiana(VetorCaracteristico p, VetorCaracteristico q)
        {
            double soma = 0;

            soma += Math.Pow(p.MAV - q.MAV,2);
            soma += Math.Pow(p.AutoCorrAbs - q.AutoCorrAbs,2);
            soma += Math.Pow(p.StdAbs - q.StdAbs, 2);

            double distancia = Math.Sqrt(soma);

            return distancia;
        }

        public static double MeanAbsoluteValue(double[] s)
        {
            //necessário uso do namespace System.Linq
            double sum = s.Sum(x => Math.Abs(x)); // soma os valores dentro de s aplicando Math.Abs() em cada valor
            double mean = sum / s.Length;
            return (mean);
        }

        public static double AutoCorrAbs(double[] s, int m)
        {
            double sum = 0;

            //equação fornecida pelo exercício
            for (int k = 0; k < s.Length - m; k++)
            {
                sum += Math.Abs(s[k]) * Math.Abs(s[k + m]);
            }

            return sum;

        }

        public static double StdAbs(double[] s)
        {
            double sum = 0;

            //não ficou claro se a média a ser usada seria a absoluta (MAV) ou normal
            //foi utilizado o cálculo normal de uma média
            double average = Math.Abs(s.Sum() / s.Length); //necessário uso do namespace System.Linq

            //equação fornecida pelo exercício
            for (int k = 0; k < s.Length; k++)
            {
                sum += Math.Pow((Math.Abs(s[k]) - Math.Abs(average)), 2);
            }
            double stdAbs = Math.Sqrt(sum / s.Length);

            return stdAbs;
        }
    }
}
