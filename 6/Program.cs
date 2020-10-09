using System;
using System.Linq;
using System.Collections.Generic;
using static Utilities; //classe com funções criadas nos exercícios anteriores

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercício 6\n");
            
            double w = 50; //tamanho da janela em ms
            double fs = 500; //frequencia de amostragem
            double time = 10; //tempo total

            double[] noise = GenerateNoise(time, fs);
            double limiar = Limiar(noise, w, fs);
            Console.WriteLine(limiar);
            
        }

        static double Limiar(double[] xn, double w, double fs)
        {
            /*
             * xn: série temporal
             * w: tamanho da janela
             * fs: frequência de amostragem
             */

            int windowSize = Convert.ToInt32(Math.Floor(w * fs / 1000));
            int nWindows = Convert.ToInt32(Math.Floor(Convert.ToDouble(xn.Length)/windowSize)); 

            double[] vetorTemplate = {0.0, 0.0, 0.0};
            
            List<double[]> vetoresDeCaracteristica = new List<double[]>();

            //separação das janelas e cálculo do vetor característico para cada janela
            //o operador Range " .. " está disponível apenas a partir do C# 8.0
            // int index;
            // for (int currentWindow = 0; currentWindow < nWindows; currentWindow++)
            // {
            //     index = currentWindow * windowSize;
            //     double[] window = new double[windowSize];
            //     for (int k = index, windowIndex = 0; k < index + windowSize; k++, windowIndex++)
            //     {
            //         window[windowIndex] = xn[k];
            //     }

            //     vetoresDeCaracteristica.Add(new VetorCaracteristico(window));
            // }

             int index;
            for(int currentWindow= 0; currentWindow < nWindows; currentWindow++)
            {
                index = currentWindow * windowSize;
                double[] window = new double[windowSize];
                for (int k = index, windowIndex = 0; k < index + windowSize; k++, windowIndex++)
                {
                    window[windowIndex] = xn[k];
                }
                vetoresDeCaracteristica.Add(VetorCaracteristico(window)); 
            }

            vetorTemplate = VetorTemplate(vetoresDeCaracteristica);

            List<double> distancias = new List<double>();
            foreach(var vetor in vetoresDeCaracteristica)
            {
                distancias.Add(Utilities.DistanciaEuclidiana(vetorTemplate, vetor));
            }
            
            //Max() requer o namespace System.Linq
            double limiar = distancias.Max(); //th

            return limiar;
        }

        static double[] VetorCaracteristico(double[] window)
        {
            double[] vetorCaracteristico = new double[3];
            vetorCaracteristico[0] = Utilities.MeanAbsoluteValue(window);
            vetorCaracteristico[1] = Utilities.AutoCorrAbs(window, 2);
            vetorCaracteristico[2] = Utilities.StdAbs(window);

            return vetorCaracteristico;
        }

        static double[] VetorTemplate(List<double[]> vetores)
        {
            double[] vetorTemplate = new double[3];
            
            double mav = vetores.Sum(vetor => vetor[0])/vetores.Count;
            double autoCorrAbs = vetores.Sum(vetor => vetor[1])/vetores.Count;
            double stdAbs = vetores.Sum(vetor => vetor[2])/vetores.Count;
            
            vetorTemplate[0] = mav;
            vetorTemplate[1] = autoCorrAbs;
            vetorTemplate[2] = stdAbs;

            System.Console.WriteLine(vetorTemplate[0]);
            System.Console.WriteLine(vetorTemplate[1]);
            System.Console.WriteLine(vetorTemplate[2]);

            return vetorTemplate;
        }

        static double[] GenerateSignal(double totalTime, double fs, double amplitude)
        {
            Random random = new Random();
            int sampleSize = Convert.ToInt32(Math.Floor(totalTime * fs));
            double[] signal = new double[sampleSize];

            for(int k = 0; k < sampleSize; k++)
            {
                signal[k] = amplitude *  random.NextDouble();
            }

            return signal;
        }

        static double[] GenerateNoise(double totalTime, double fs)
        {
            Random random = new Random();
            int sampleSize = Convert.ToInt32(Math.Floor(totalTime * fs));
            double[] noise = new double[sampleSize];

            for(int k = 0; k < sampleSize; k++)
            {
                noise[k] =  random.NextDouble();
            }

            return noise;

            
        }
    }
}
