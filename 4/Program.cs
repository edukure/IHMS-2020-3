using System;

namespace Lista_10
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] P1 = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            double[] P2 = {1.2, 2.5, 3.3, 4.7, 5.3, 6.2, 7.1, 8.3, 9.1, 9.8};
            double[] P3 = {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};

            Console.WriteLine("Exercício 4\n");
            Console.WriteLine($"Distância P1P2: {DistanciaEuclidiana(P1, P2)}");
            Console.WriteLine($"Distância P1P3: {DistanciaEuclidiana(P1, P3)}");
            Console.WriteLine($"Distância P2P3: {DistanciaEuclidiana(P2, P3)}");
        }

        static double DistanciaEuclidiana(double[] p, double[] q) {
            if(p.Length != q.Length) {
                throw new Exception("Não é possível calcular a distância entre vetores de tamanhos diferentes");
            }

            double soma = 0;

            for (int k = 0; k < p.Length; k++) {
                soma += Math.Pow((p[k] - q[k]),2);
            }

            double distancia = Math.Sqrt(soma);

            return distancia;
        }
    }
}
