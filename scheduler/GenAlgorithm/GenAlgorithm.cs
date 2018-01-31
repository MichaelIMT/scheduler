using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.GenAlgorithm
{
    public static class GenAlgorithm
    {
        public static double[] LektorWeightCoefs = new double[] { 0.15, 0.1, 0.3, 0.2, 0.25 };
        public static double[] GroupWeightCoefs = new double[] { 0.2, 0.3, 0.4, 0.5, 0.2 };
        public static int[] GroupWindowsCount = new int[] { 1, 2, 3, 1, 1, 5 };
        public static int[] Capabilities = new int[25];



        private static double Estimate(Сhromosome сhromosome)
        {

            return (сhromosome.LektorKof * сhromosome.BinaryQ * сhromosome.GroupKof) / сhromosome.CountOfWindows;
        }

        private static void GenerateCapabilities()
        {

            Random random = new Random();
            for (var i = 0; i < Capabilities.Length; i++)
            {
                Capabilities[i] = random.Next(0, 2);
            }

        }


        public static void Run()
        {
            GenerateCapabilities();
            double bestEstimate = 1000;



            int _day = 0;
            var _para = 0;

            Сhromosome сhromosome = null;

            for (int day = 1; day <= 5; day++)
            {
                for (int para = 1; para <= 5; para++)
                {
                    сhromosome = new Сhromosome { BinaryQ = Capabilities[day*para - 1], CountOfWindows = GroupWindowsCount[day - 1], GroupKof = GroupWeightCoefs[day - 1], LektorKof = LektorWeightCoefs[day - 1] };
                    var res = Estimate(сhromosome);
                    if (res < bestEstimate && res > 0)
                    {
                        bestEstimate = res;
                        _day = day;
                        _para = para;
                    }
                }
            }

            var result = 0;
        }



    }

    public class Сhromosome
    {
        public double LektorKof { get; set; }
        public int BinaryQ { get; set; }
        public double GroupKof { get; set; }
        public int CountOfWindows { get; set; }
    }
}

