using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            //estados Fx   
            //LOW, HIGH, LOW, IND, LOW, HIGH, LOW, HIGH, IND, LOW, HIGH, LOW
            List<bool> fx = new List<bool>()
            {
                false, true, false, true, false, true, false, true, true, false, true, false, false
            };

            //estados Fy
            //LOW, LOW, LOW, HIGH, LOW, LOW, LOW, LOW, HIGH, LOW, LOW, LOW
            List<bool> fy = new List<bool>()
            {
                false, false, false, true, false, false, false, false, true, false, false, false, false
            };

            //estados finais
            //1, 2, 1, 6, 1, 5, 1, 3, 1, 7, 1, 4
            //DOWN, UP, CLICK, LEFT, ROTATE, RIGHT 

            List<int> events = new List<int>() {
                1,2,1,6,1,5,1,3,1,7,1,4
            };
                    //   false, true, false, true, false, true, false, true, true, false, true, false
            int[] keyPoints = {1200, 1600, 2150, 3100, 4000, 4400, 5000, 6000, 6400, 6900, 9100, 9600};
            // int[] keyPoints = {120, 160, 215, 310, 400, 440, 500, 600, 640, 690, 910, 960};

            Dictionary<int, string> eventsDic = new Dictionary<int, string>();
            eventsDic.Add(1, "ON_STANDBY");
            eventsDic.Add(2, "DOWN");
            eventsDic.Add(3, "LEFT");
            eventsDic.Add(4, "RIGHT");
            eventsDic.Add(5, "SINGLE_CLICK");
            eventsDic.Add(6, "UP");
            eventsDic.Add(7, "ROTATE");

            //thread simulando ms
            //printa no console
            //Fx: val
            //Fy: val
            //Evento: 


            int ms = 0; //milissegundo
            int segundos = 10;
            int final = segundos * 1000;

            var fxGerado = GenerateF(fx,keyPoints, 400, segundos);
            var fyGerado = GenerateF(fy,keyPoints, 400, segundos);

            while(ms < final * 1000) {
                //analisa estado Fx
                bool fxState = fxGerado[ms];
                //analisa estado Fy
                bool fyState = fyGerado[ms];
                
                int opcao = 1; //baseado em fx e fy
                if((!fxState || !fyState) && th > 400)
                {
                    opcao = 1;
                } 
                else if(false) {
                    
                }



                //com o dicionário eventsDisc, o switch na verdade não seria necessário...
                //o evento poderia ser seleciono apenas com o índice
                switch(opcao) 
                {
                    case 1:
                        Console.WriteLine(eventsDic[opcao]);
                        break;
                    case 2:
                        Console.WriteLine(eventsDic[opcao]);
                        break;
                    case 3:
                        Console.WriteLine(eventsDic[opcao]);
                        break;
                    case 4:
                        Console.WriteLine(eventsDic[opcao]);
                        break;
                    case 5:
                        Console.WriteLine(eventsDic[opcao]);
                        break;
                    case 6:
                        Console.WriteLine(eventsDic[opcao]);
                        break;
                    case 7:
                        Console.WriteLine(eventsDic[opcao]);
                        break;

                }




                ms++;
                Thread.Sleep(1);
                

            }

            

            Console.ReadLine();
            
        }

        static int CheckEvent(int ms, bool fx, bool fy)
        {


            return 1;
        }


        //funções construidas tomando em consideração:
        //tempo: em ms e total de 10 segundos (10 * 1000)
        //th: tempo de ativação de 400ms
        //gráfico de exemplo da questão 1
        //o tempo de ativação foi considerado na criação de Fy e Fx,
        //ou seja, para ativação em 1000ms, o sinal precisa começar em 600ms
        static bool[] GenerateF(List<bool> states, int[] keyPoints, int th, int seconds){
            // Dictionary<int, bool> fx = new Dictionary<int, bool>();
            bool[] fx = new bool[1000 * seconds];
            bool state = states[0];

            int[] shifted = ShiftKeyPoints(keyPoints, th);
            
            int keyPointsIndex = 0;
            for(int ms = 0; ms < seconds * 1000; ms++)
            {
                if(shifted[keyPointsIndex] == ms) {
                    state = states[keyPointsIndex+1];

                    if(keyPointsIndex < keyPoints.Length - 1){
                        keyPointsIndex++;
                    }
                    
                }
                Console.WriteLine($"{ms}ms {state}");

                // fx.Add(ms, state);
                fx[ms] = state;
            }

            return fx;
        }

        static int[] ShiftKeyPoints(int[] keyPoints, int th)
        {
            int[] shifted = new int[keyPoints.Length];

            for(int k = 0; k < keyPoints.Length; k++)
            {
                shifted[k] = keyPoints[k] - th;
            }

            return shifted;
        }
    }
}
