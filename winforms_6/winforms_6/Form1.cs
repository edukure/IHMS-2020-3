using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace winforms_6
{
    public partial class Form1 : Form
    {
        double w = 50; //tamanho da janela em ms
        double fs = 500; //frequencia de amostragem
        double time = 10; //tempo total
        public Form1()
        {
            InitializeComponent();
        }

        public double[] GenerateNoise(double totalTime, double fs)
        {
            Random random = new Random();
            int sampleSize = Convert.ToInt32(Math.Floor(totalTime * fs));
            double[] noise = new double[sampleSize];

            for (int k = 0; k < sampleSize; k++)
            {
                noise[k] = random.NextDouble();
            }

            return noise;
        }

        public VetorCaracteristico CalcularVetorTemplate(List<VetorCaracteristico> vetores)
        {
            double mav = vetores.Sum(vetor => vetor.MAV) / vetores.Count;
            double autoCorrAbs = vetores.Sum(vetor => vetor.AutoCorrAbs) / vetores.Count;
            double stdAbs = vetores.Sum(vetor => vetor.StdAbs) / vetores.Count;

            VetorCaracteristico vetorTemplate = new VetorCaracteristico(mav, autoCorrAbs, stdAbs);

            return vetorTemplate;
        }

        public double Limiar(double[] xn, double w, double fs)
        {
            /*
             * xn: série temporal
             * w: tamanho da janela
             * fs: frequência de amostragem
             */

            int windowSize = Convert.ToInt32(Math.Floor(w * fs / 1000));
            int nWindows = Convert.ToInt32(Math.Floor(Convert.ToDouble(xn.Length) / windowSize));

            VetorCaracteristico vetorTemplate;

            List<VetorCaracteristico> vetoresDeCaracteristica = new List<VetorCaracteristico>();

            //separação das janelas e cálculo do vetor característico para cada janela
            int index;
            for (int currentWindow = 0; currentWindow < nWindows; currentWindow++)
            {
                index = currentWindow * windowSize;
                double[] window = new double[windowSize];
                for (int k = index, windowIndex = 0; k < index + windowSize; k++)
                {
                    window[windowIndex] = xn[k];
                }

                vetoresDeCaracteristica.Add(new VetorCaracteristico(window));
            }

            vetorTemplate = CalcularVetorTemplate(vetoresDeCaracteristica);


            List<double> distancias = new List<double>();
            foreach (var vetor in vetoresDeCaracteristica)
            {
                distancias.Add(Utilities.DistanciaEuclidiana(vetorTemplate, vetor));
            }

            //Max() requer o namespace System.Linq
            double limiar = distancias.Max(); //th

            return limiar;
        }

        public void UpdateChart(ChartValues<double> values)
        {
            NoiseChart.Series.Clear();
            NoiseChart.Series.Add(new LineSeries
            {
                LineSmoothness = 1, //straight lines, 1 really smooth lines
                PointGeometry = null,
                Values = values
            });
        }


        #region UI Events
        private void StartButton_Click(object sender, EventArgs e)
        {
            double[] noise = GenerateNoise(time, fs);
            ChartValues<double> values = new ChartValues<double>();
            values.AddRange(noise);

            double limiar = Limiar(noise, w, fs);
            ThLabel.Text = $"th (limiar): {limiar}";

            //change this to async?? performance is really low
            UpdateChart(values);
            
        }

        private void fsInput_TextChanged(object sender, EventArgs e)
        {
            string input = fsInput.Text;
            Double.TryParse(input, out time);
        }

        private void wInput_TextChanged(object sender, EventArgs e)
        {
            string input = wInput.Text;
            Double.TryParse(input, out time);
        }

        private void timeInput_TextChanged(object sender, EventArgs e)
        {
            string input = timeInput.Text;
            Double.TryParse(input, out time);
        }
        #endregion

    }
}
